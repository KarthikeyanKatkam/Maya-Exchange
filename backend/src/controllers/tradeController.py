from fastapi import APIRouter, HTTPException, Depends  # Ensure correct import
from sqlalchemy.orm import Session  # Import Session for type hinting
from pydantic import BaseModel
from ..services import trade_service
from .dependencies import get_db

router = APIRouter()


class TradeRequest(BaseModel):
    user_id: int
    from_currency: str
    to_currency: str
    amount: float
    trade_type: str  # 'spot', 'margin', 'futures', etc.


class TradeResponse(BaseModel):
    trade_id: int
    status: str
    from_currency: str
    to_currency: str
    amount: float
    price: float
    timestamp: str


@router.post("/trade", response_model=TradeResponse)
async def create_trade(request: TradeRequest, db: Session = Depends(get_db)):
    trade_data = {
        "user_id": request.user_id,
        "from_currency": request.from_currency,
        "to_currency": request.to_currency,
        "amount": request.amount,
        "trade_type": request.trade_type,
    }

    trade = await trade_service.create_trade(db, trade_data)

    if not trade:
        raise HTTPException(status_code=400, detail="Trade could not be completed")

    return TradeResponse(
        trade_id=trade.id,
        status=trade.status,
        from_currency=trade.from_currency,
        to_currency=trade.to_currency,
        amount=trade.amount,
        price=trade.price,
        timestamp=trade.timestamp,
    )


@router.get("/trade/{trade_id}", response_model=TradeResponse)
async def get_trade(trade_id: int, db: Session = Depends(get_db)):
    trade = await trade_service.get_trade_by_id(db, trade_id)

    if not trade:
        raise HTTPException(status_code=404, detail="Trade not found")

    return TradeResponse(
        trade_id=trade.id,
        status=trade.status,
        from_currency=trade.from_currency,
        to_currency=trade.to_currency,
        amount=trade.amount,
        price=trade.price,
        timestamp=trade.timestamp,
    )
