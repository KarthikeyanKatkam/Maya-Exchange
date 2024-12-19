from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session
from typing import List
from ..controllers.userController import create_user, register_user, get_user_profile, verify_kyc, UserProfileResponse
from ..database import get_db

router = APIRouter()

# Define user-related routes here
@router.get("/", response_model=List[UserProfileResponse])  # Assuming UserProfileResponse is the correct model
async def get_users(db: Session = Depends(get_db)):
    return await get_user_profile(db)

# Add more user routes as needed
