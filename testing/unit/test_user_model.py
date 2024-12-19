import unittest
from backend.src.database.models.User import User  # Updated to use an absolute import

class TestUserModel(unittest.TestCase):

    def setUp(self):
        self.user = User(
            id=1,
            name="John Doe",
            email="john.doe@example.com",
            password="hashed_password",
            kyc_status="Verified"
        )

    def test_user_creation(self):
        self.assertEqual(self.user.name, "John Doe")
        self.assertEqual(self.user.email, "john.doe@example.com")
        self.assertEqual(self.user.kyc_status, "Verified")

    def test_user_password(self):
        # Assuming a `check_password` method exists
        self.assertTrue(self.user.check_password("hashed_password"))

    def test_update_kyc_status(self):
        self.user.update_kyc_status("Pending")
        self.assertEqual(self.user.kyc_status, "Pending")

if __name__ == "__main__":
    unittest.main()
