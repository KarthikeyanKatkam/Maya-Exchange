# TradeHistory.py
from sqlalchemy import Column, Integer, Float, String, ForeignKey
from sqlalchemy.orm import relationship
from ..database import Base

class TradeHistory(Base):
    __tablename__ = "trade_history"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    from_currency = Column(String)
    to_currency = Column(String)
    amount = Column(Float)
    price = Column(Float)
    timestamp = Column(String)  # Consider using a datetime type
    trade_type = Column(String)  # e.g., spot, margin, futures

    # Relationships
    user = relationship("User", back_populates="trades")

    def __repr__(self):
        return f"<TradeHistory(id={self.id}, user_id={self.user_id}, from_currency={self.from_currency}, to_currency={self.to_currency}, amount={self.amount}, price={self.price})>"
