import unittest
from unittest.mock import patch
from backend.src.services.UPIService import UPIService

class TestUPIService(unittest.TestCase):

    def setUp(self):
        self.upi_service = UPIService()

    @patch("src.services.UPIService.UPIService.initiate_transaction")
    def test_initiate_transaction(self, mock_initiate):
        mock_initiate.return_value = {
            "transaction_id": "UPI12345",
            "status": "Success",
            "message": "Transaction completed successfully."
        }

        response = self.upi_service.initiate_transaction(
            user_id=1, amount=500, upi_id="user@upi"
        )
        self.assertEqual(response["status"], "Success")
        self.assertEqual(response["transaction_id"], "UPI12345")

    @patch("src.services.UPIService.UPIService.verify_transaction")
    def test_verify_transaction(self, mock_verify):
        mock_verify.return_value = True
        is_verified = self.upi_service.verify_transaction("UPI12345")
        self.assertTrue(is_verified)

    def test_invalid_transaction(self):
        with self.assertRaises(ValueError):
            self.upi_service.initiate_transaction(user_id=1, amount=-100, upi_id="")

if __name__ == "__main__":
    unittest.main()
