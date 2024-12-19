import unittest
from fastapi.testclient import TestClient
from src.main import app

class TestUserAuthIntegration(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.test_user = {
            "name": "Jane Doe",
            "email": "jane.doe@example.com",
            "password": "securepassword123"
        }

    def test_user_registration(self):
        response = self.client.post("/auth/register", json=self.test_user)
        self.assertEqual(response.status_code, 201)
        self.assertIn("message", response.json())
        self.assertIn("user_id", response.json())

    def test_user_login(self):
        # First, register the user
        self.client.post("/auth/register", json=self.test_user)
        
        # Attempt login
        login_data = {
            "email": self.test_user["email"],
            "password": self.test_user["password"]
        }
        response = self.client.post("/auth/login", json=login_data)
        self.assertEqual(response.status_code, 200)
        self.assertIn("access_token", response.json())

    def test_protected_route_access(self):
        # Register and login to get token
        self.client.post("/auth/register", json=self.test_user)
        login_response = self.client.post("/auth/login", json={
            "email": self.test_user["email"],
            "password": self.test_user["password"]
        })
        token = login_response.json().get("access_token")
        
        # Access protected route
        headers = {"Authorization": f"Bearer {token}"}
        response = self.client.get("/protected", headers=headers)
        self.assertEqual(response.status_code, 200)
        self.assertIn("message", response.json())

if __name__ == "__main__":
    unittest.main()
