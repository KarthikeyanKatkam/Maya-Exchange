# User.py
from sqlalchemy import Column, Integer, String, Boolean
from sqlalchemy.orm import relationship
from ..database import Base

class User(Base):
    # Add the following methods to the User class

    def check_password(self, password: str) -> bool:
        """Check if the provided password matches the stored password."""
        return self.password == password  # This should ideally use a hashed comparison

    def update_kyc_status(self, status: str):
        """Update the KYC status of the user."""
        self.kyc_verified = (status.lower() == "verified")
    __tablename__ = "users"

    id = Column(Integer, primary_key=True, index=True)
    username = Column(String, unique=True, index=True)
    email = Column(String, unique=True, index=True)
    password = Column(String)
    phone = Column(String, unique=True)
    kyc_verified = Column(Boolean, default=False)

    # Relationships
    transactions = relationship("Transaction", back_populates="user")
    trades = relationship("TradeHistory", back_populates="user")
    wallet = relationship("Wallet", back_populates="user", uselist=False)
    
    def __repr__(self):
        return f"<User(id={self.id}, username={self.username}, email={self.email})>"
