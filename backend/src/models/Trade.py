from sqlalchemy import Column, Integer, Float, String, ForeignKey
from sqlalchemy.orm import relationship
from backend.src.database import Base

class Trade(Base):
    __tablename__ = "trades"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    from_currency = Column(String)
    to_currency = Column(String)
    amount = Column(Float)
    price = Column(Float)
    timestamp = Column(String)  # Consider using a datetime type

    # Relationships
    user = relationship("User", back_populates="trades")

    def __repr__(self):
        return f"<Trade(id={self.id}, user_id={self.user_id}, amount={self.amount})>"
