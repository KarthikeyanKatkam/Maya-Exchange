# backend/src/database/models/User.py
from sqlalchemy import Column, Integer, String
from sqlalchemy.orm import relationship
from backend.src.database import Base

class User(Base):
    __tablename__ = 'users'

    id = Column(Integer, primary_key=True, index=True)
    email = Column(String, unique=True, index=True)
    hashed_password = Column(String)

    # Add other fields as necessary (e.g., name, date_created, etc.)
