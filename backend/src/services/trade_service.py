from ..models.Trade import Trade  # Corrected to use a relative import

async def create_trade(db, trade_data):
    trade = Trade(**trade_data)
    db.add(trade)
    await db.commit()
    await db.refresh(trade)
    return trade

async def get_trade_by_id(db, trade_id):
    return await db.query(Trade).filter(Trade.id == trade_id).first()
