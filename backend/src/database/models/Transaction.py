# backend/src/database/models/Transaction.py
from sqlalchemy import Column, Integer, Float, DateTime, ForeignKey
from sqlalchemy.orm import relationship
from database import Base

class Transaction(Base):
    __tablename__ = 'transactions'

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey('users.id'))
    amount = Column(Float)
    transaction_type = Column(String)  # e.g., 'deposit', 'withdrawal'
    timestamp = Column(DateTime)

    user = relationship("User", back_populates="transactions")
