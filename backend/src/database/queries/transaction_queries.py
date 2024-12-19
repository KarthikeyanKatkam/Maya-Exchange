# backend/src/database/queries/transaction_queries.py
from sqlalchemy import text
from database import engine

def get_transactions_by_user(user_id):
    sql_query = text("SELECT * FROM transactions WHERE user_id = :user_id")
    with engine.connect() as connection:
        result = connection.execute(sql_query, {"user_id": user_id})
        return result.fetchall()
