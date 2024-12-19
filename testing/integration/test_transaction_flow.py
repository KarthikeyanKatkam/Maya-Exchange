import unittest
from fastapi.testclient import TestClient
from src.main import app

class TestTransactionFlowIntegration(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.user_data = {
            "name": "Alice",
            "email": "alice@example.com",
            "password": "strongpassword"
        }
        self.client.post("/auth/register", json=self.user_data)
        login_response = self.client.post("/auth/login", json={
            "email": self.user_data["email"],
            "password": self.user_data["password"]
        })
        self.token = login_response.json().get("access_token")
        self.headers = {"Authorization": f"Bearer {self.token}"}

    def test_deposit_transaction(self):
        deposit_data = {
            "type": "Deposit",
            "amount": 1000,
            "currency": "USD"
        }
        response = self.client.post("/transactions/deposit", json=deposit_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Completed")

    def test_withdraw_transaction(self):
        withdraw_data = {
            "type": "Withdraw",
            "amount": 500,
            "currency": "USD"
        }
        response = self.client.post("/transactions/withdraw", json=withdraw_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Pending")

    def test_transaction_history(self):
        response = self.client.get("/transactions/history", headers=self.headers)
        self.assertEqual(response.status_code, 200)
        self.assertIsInstance(response.json(), list)

if __name__ == "__main__":
    unittest.main()
