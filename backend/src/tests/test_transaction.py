import pytest
from fastapi.testclient import TestClient
from backend.src.main import app  # Change to absolute import
from backend.src.models.Transaction import Transaction  # Change to absolute import
from backend.src.database import SessionLocal, engine  # Change to absolute import

client = TestClient(app)

@pytest.fixture(scope="function")
def test_db():
    db = SessionLocal()
    yield db
    db.close()

def test_create_transaction(test_db):
    # Test transaction creation
    response = client.post("/transactions/", json={"user_id": 1, "amount": 100, "currency": "USD", "type": "deposit"})
    assert response.status_code == 201
    data = response.json()
    assert data["amount"] == 100
    assert data["currency"] == "USD"
    assert data["type"] == "deposit"

def test_transaction_status(test_db):
    # Test transaction status update
    response = client.post("/transactions/", json={"user_id": 1, "amount": 100, "currency": "USD", "type": "deposit"})
    transaction_id = response.json()["id"]
    
    # Update transaction status
    response = client.put(f"/transactions/{transaction_id}/status", json={"status": "completed"})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"

def test_internal_transfer(test_db):
    # Test internal transfer between users
    response = client.post("/users/", json={"email": "user1@example.com", "password": "password"})
    user1_id = response.json()["id"]
    
    response = client.post("/users/", json={"email": "user2@example.com", "password": "password"})
    user2_id = response.json()["id"]
    
    response = client.post("/transactions/", json={"user_id": user1_id, "amount": 100, "currency": "USD", "type": "deposit"})
    transaction_id = response.json()["id"]
    
    # Perform internal transfer
    response = client.post("/transactions/transfer", json={"from_user_id": user1_id, "to_user_id": user2_id, "amount": 50})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"
    assert data["amount"] == 50
