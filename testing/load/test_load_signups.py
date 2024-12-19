import unittest
import time
from fastapi.testclient import TestClient
from src.main import app

class TestLoadSignups(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)

    def test_signup_load(self):
        start_time = time.time()
        for i in range(100):  # Simulating 100 user signups
            signup_data = {
                "name": f"TestUser{i}",
                "email": f"testuser{i}@example.com",
                "password": "password123"
            }
            response = self.client.post("/auth/register", json=signup_data)
            self.assertEqual(response.status_code, 201)
            self.assertIn("user_id", response.json())
            self.assertIn("message", response.json())

        end_time = time.time()
        print(f"Processed 100 signups in {end_time - start_time:.2f} seconds.")

if __name__ == "__main__":
    unittest.main()
