import unittest
import time
from fastapi.testclient import TestClient
from src.main import app

class TestLoadTransactions(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.user_data = {
            "name": "Load Tester",
            "email": "loadtester@example.com",
            "password": "testpassword123"
        }
        # Register and login the test user
        self.client.post("/auth/register", json=self.user_data)
        login_response = self.client.post("/auth/login", json={
            "email": self.user_data["email"],
            "password": self.user_data["password"]
        })
        self.token = login_response.json().get("access_token")
        self.headers = {"Authorization": f"Bearer {self.token}"}

    def test_transaction_load(self):
        start_time = time.time()
        for i in range(100):  # Simulating 100 transactions
            transaction_data = {
                "type": "Deposit" if i % 2 == 0 else "Withdraw",
                "amount": 10 + i,  # Increment amount for variety
                "currency": "USD"
            }
            response = self.client.post("/transactions/create", json=transaction_data, headers=self.headers)
            self.assertEqual(response.status_code, 201)
            self.assertIn("transaction_id", response.json())
            self.assertIn("status", response.json())

        end_time = time.time()
        print(f"Processed 100 transactions in {end_time - start_time:.2f} seconds.")

if __name__ == "__main__":
    unittest.main()
