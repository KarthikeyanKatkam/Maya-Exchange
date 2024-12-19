# Transaction.py
from sqlalchemy import Column, Integer, Float, String, ForeignKey, Enum, DateTime
from sqlalchemy.orm import relationship, validates  # Added validates import
from ..database import Base  # Corrected to reference the database module
from enum import Enum as PyEnum

class TransactionType(PyEnum):
    DEPOSIT = "deposit"
    WITHDRAWAL = "withdrawal"
    INTERNAL_TRANSFER = "internal_transfer"

class Transaction(Base):
    __tablename__ = "transactions"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    amount = Column(Float)
    currency = Column(String)
    transaction_type = Column(Enum(TransactionType))
    status = Column(String, default="pending")
    from datetime import datetime
    from datetime import datetime

    timestamp = Column(DateTime, default=datetime.utcnow)  # Set default to current time

    # Relationships
    user = relationship("User", back_populates="transactions")

    @validates('amount')
    def validate_amount(self, key, amount):
        if amount <= 0:
            raise ValueError("Amount must be positive")
        return amount

    @validates('currency')
    def validate_currency(self, key, currency):
        valid_currencies = ["USD", "EUR", "GBP"]  # Add more valid currencies as needed
        if currency not in valid_currencies:
            raise ValueError(f"Currency must be one of {valid_currencies}")
        return currency

    def __repr__(self):
        return f"<Transaction(id={self.id}, user_id={self.user_id}, amount={self.amount}, status={self.status})>"
