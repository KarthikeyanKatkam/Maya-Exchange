import unittest
from fastapi.testclient import TestClient
from src.main import app

class TestCryptoServiceIntegration(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.user_data = {
            "name": "Bob",
            "email": "bob@example.com",
            "password": "complexpassword"
        }
        self.client.post("/auth/register", json=self.user_data)
        login_response = self.client.post("/auth/login", json={
            "email": self.user_data["email"],
            "password": self.user_data["password"]
        })
        self.token = login_response.json().get("access_token")
        self.headers = {"Authorization": f"Bearer {self.token}"}

    def test_crypto_purchase(self):
        purchase_data = {
            "crypto": "BTC",
            "amount": 0.01,
            "currency": "USD",
            "price": 30000  # Assume a fixed price for testing
        }
        response = self.client.post("/crypto/purchase", json=purchase_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Completed")

    def test_crypto_sale(self):
        sale_data = {
            "crypto": "ETH",
            "amount": 0.5,
            "currency": "USD",
            "price": 2000  # Assume a fixed price for testing
        }
        response = self.client.post("/crypto/sell", json=sale_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Completed")

    def test_crypto_balance(self):
        response = self.client.get("/crypto/balance", headers=self.headers)
        self.assertEqual(response.status_code, 200)
        self.assertIsInstance(response.json(), dict)
        self.assertIn("BTC", response.json())
        self.assertIn("ETH", response.json())

if __name__ == "__main__":
    unittest.main()
