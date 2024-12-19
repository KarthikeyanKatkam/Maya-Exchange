import unittest
from backend.src.models.Transaction import Transaction

class TestTransactionModel(unittest.TestCase):

    def setUp(self):
        self.transaction = Transaction(
            id=101,
            user_id=1,
            type="Deposit",
            amount=1000.00,
            currency="USD",
            status="Completed"
        )

    def test_transaction_creation(self):
        self.assertEqual(self.transaction.type, "Deposit")
        self.assertEqual(self.transaction.amount, 1000.00)
        self.assertEqual(self.transaction.currency, "USD")
        self.assertEqual(self.transaction.status, "Completed")

    def test_update_status(self):
        self.transaction.update_status("Pending")
        self.assertEqual(self.transaction.status, "Pending")

    def test_transaction_to_dict(self):
        transaction_dict = self.transaction.to_dict()
        self.assertEqual(transaction_dict["user_id"], 1)
        self.assertEqual(transaction_dict["status"], "Completed")

if __name__ == "__main__":
    unittest.main()
