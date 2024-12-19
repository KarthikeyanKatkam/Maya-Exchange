# transactionController.py
from fastapi import APIRouter, HTTPException, Depends, status
from pydantic import BaseModel
from typing import List, Literal
from sqlalchemy.orm import Session
from ..models import Transaction
from ..services import transaction_service  # Corrected to reference the services module
from .dependencies import get_db

router = APIRouter()

class TransactionRequest(BaseModel):
    user_id: int
    amount: float
    currency: str
    transaction_type: str  # 'deposit', 'withdrawal', 'internal_transfer'

class TransactionResponse(BaseModel):
    transaction_id: int
    user_id: int
    amount: float
    currency: str
    transaction_type: str
    status: str
    timestamp: str

@router.post("/transaction", response_model=TransactionResponse)
async def create_transaction(request: TransactionRequest, db: Session = Depends(get_db)) -> TransactionResponse:
    transaction_data = {
        "user_id": request.user_id,
        "amount": request.amount,
        "currency": request.currency,
        "transaction_type": request.transaction_type,
    }

    transaction = await transaction_service.create_transaction(db, transaction_data)

    if not transaction:
        raise HTTPException(status_code=400, detail="Transaction could not be processed")

    return TransactionResponse(
        transaction_id=transaction.id,
        user_id=transaction.user_id,
        amount=transaction.amount,
        currency=transaction.currency,
        transaction_type=transaction.transaction_type,
        status=transaction.status,
        timestamp=transaction.timestamp,
    )

@router.get("/transaction/{transaction_id}", response_model=TransactionResponse)
async def get_transaction(transaction_id: int, db: Session = Depends(get_db)) -> TransactionResponse:
    transaction = await transaction_service.get_transaction_by_id(db, transaction_id)

    if not transaction:
        raise HTTPException(status_code=404, detail="Transaction not found")

    return TransactionResponse(
        transaction_id=transaction.id,
        user_id=transaction.user_id,
        amount=transaction.amount,
        currency=transaction.currency,
        transaction_type=transaction.transaction_type,
        status=transaction.status,
        timestamp=transaction.timestamp,
    )
