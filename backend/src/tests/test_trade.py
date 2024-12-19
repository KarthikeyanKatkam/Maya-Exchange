# test_trade.py
import pytest
from fastapi.testclient import TestClient
from backend.src.main import app
from backend.src.models.TradeHistory import TradeHistory  # Change to absolute import
from backend.src.models.User import User  # Change to absolute import
from backend.src.database import SessionLocal, engine  # Change to absolute import

client = TestClient(app)

@pytest.fixture(scope="function")
def test_db():
    db = SessionLocal()
    yield db
    db.close()

def test_spot_trade(test_db):
    # Test spot trading
    user = User(email="testtrader@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    # Simulate a spot trade
    response = client.post("/trades/spot", json={"user_id": user.id, "from_currency": "USD", "to_currency": "BTC", "amount": 100})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"
    assert data["from_currency"] == "USD"
    assert data["to_currency"] == "BTC"
    assert data["amount"] == 100

def test_margin_trade(test_db):
    # Test margin trading
    user = User(email="testmargintrader@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    # Simulate margin trade
    response = client.post("/trades/margin", json={"user_id": user.id, "currency": "ETH", "amount": 10, "leverage": 2})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"
    assert data["currency"] == "ETH"
    assert data["amount"] == 10

def test_trade_history(test_db):
    # Test fetching trade history
    user = User(email="tradehistory@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    response = client.get(f"/users/{user.id}/trade-history")
    assert response.status_code == 200
    data = response.json()
    assert isinstance(data, list)
