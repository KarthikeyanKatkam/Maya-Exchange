from fastapi import APIRouter, HTTPException, Depends
from sqlalchemy.orm import Session
from pydantic import BaseModel
from typing import List
from ..database import get_db
from ..models.User import User
from ..services import user_service

router = APIRouter()

@router.post("/users/")
def create_user(email: str, password: str, db: Session = Depends(get_db)):
    db_user = User(email=email, hashed_password=password)
    db.add(db_user)
    db.commit()
    db.refresh(db_user)
    return db_user

class UserRegistrationRequest(BaseModel):
    username: str
    email: str
    password: str
    phone: str

class UserProfileResponse(BaseModel):
    user_id: int
    username: str
    email: str
    phone: str
    kyc_verified: bool

@router.post("/register", response_model=UserProfileResponse)
async def register_user(request: UserRegistrationRequest, db: Session = Depends(get_db)):
    user_data = {
        "username": request.username,
        "email": request.email,
        "password": request.password,
        "phone": request.phone,
    }

    user = await user_service.register_user(db, user_data)

    if not user:
        raise HTTPException(status_code=400, detail="User registration failed")

    return UserProfileResponse(
        user_id=user.id,
        username=user.username,
        email=user.email,
        phone=user.phone,
        kyc_verified=user.kyc_verified,
    )

@router.post("/kyc-verify/{user_id}")
async def verify_kyc(user_id: int, db: Session = Depends(get_db)):
    user = await user_service.verify_kyc(db, user_id)

    if not user:
        raise HTTPException(status_code=400, detail="User KYC verification failed")

    return {"message": "KYC verification successful"}

@router.get("/user/{user_id}", response_model=UserProfileResponse)
async def get_user_profile(user_id: int, db: Session = Depends(get_db)):
    user = await user_service.get_user_by_id(db, user_id)

    if not user:
        raise HTTPException(status_code=404, detail="User not found")

    return UserProfileResponse(
        user_id=user.id,
        username=user.username,
        email=user.email,
        phone=user.phone,
        kyc_verified=user.kyc_verified,
    )