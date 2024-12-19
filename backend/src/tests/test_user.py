import pytest
from fastapi.testclient import TestClient
from backend.src.main import app  # Change to absolute import
from backend.src.models.User import User  # Change to absolute import
from backend.src.services.KYCService import KYCService  # Change to absolute import
from backend.src.database import SessionLocal, engine  # Change to absolute import

# Initialize TestClient for making requests to FastAPI
client = TestClient(app)

@pytest.fixture(scope="function")
def test_db():
    # Set up the database for testing
    db = SessionLocal()
    yield db
    db.close()

def test_create_user(test_db):
    # Test user creation
    response = client.post("/users/", json={"email": "testuser@example.com", "password": "securepassword"})
    assert response.status_code == 201
    data = response.json()
    assert data["email"] == "testuser@example.com"
    assert "id" in data

def test_user_kyc_status(test_db):
    # Test KYC status retrieval
    user = User(email="testuser@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    # Assume KYC is pending for new users
    kyc_status = KYCService.get_kyc_status(user.id)
    assert kyc_status == "PENDING"

def test_user_login(test_db):
    # Test user login
    client.post("/users/", json={"email": "testuser@example.com", "password": "securepassword"})
    response = client.post("/login", data={"username": "testuser@example.com", "password": "securepassword"})
    assert response.status_code == 200
    assert "access_token" in response.json()
