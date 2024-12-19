from fastapi import HTTPException
from sqlalchemy.orm import Session
from ..models.User import User
from ..utils import hash_password, verify_password  # Assuming these utility functions exist

class UserService:
    def create_user(self, db: Session, email: str, password: str) -> User:
        # Check if the user already exists
        existing_user = db.query(User).filter(User.email == email).first()
        if existing_user:
            raise HTTPException(status_code=400, detail="Email already registered")

        # Create a new user
        hashed_password = hash_password(password)
        new_user = User(email=email, password=hashed_password)
        db.add(new_user)
        db.commit()
        db.refresh(new_user)
        return new_user

    def get_kyc_status(self, user_id: int) -> str:
        # Retrieve the KYC status of the user
        user = db.query(User).filter(User.id == user_id).first()
        if not user:
            raise HTTPException(status_code=404, detail="User not found")
        return "PENDING" if not user.kyc_verified else "VERIFIED"

    def login_user(self, db: Session, email: str, password: str) -> User:
        # Authenticate the user
        user = db.query(User).filter(User.email == email).first()
        if not user or not verify_password(password, user.password):
            raise HTTPException(status_code=401, detail="Invalid credentials")
        return user
