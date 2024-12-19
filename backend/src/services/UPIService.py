# UPIService.py
from fastapi import HTTPException
from typing import Dict
import requests

class UPIService:
    def __init__(self, upi_api_url: str):
        self.upi_api_url = upi_api_url
    
    def initiate_transaction(self, user_id: int, amount: float, upi_id: str) -> Dict:
        """
        Initiates a UPI payment request for the user.

        Args:
            user_id (int): The user ID.
            amount (float): The amount to be paid.
            upi_id (str): The UPI ID of the user.

        Returns:
            Dict: Response from the UPI system with payment details.
        
        Raises:
            HTTPException: If there's an issue with the UPI system.
            ValueError: If the amount is invalid or UPI ID is empty.
        """
        if amount <= 0 or not upi_id:
            raise ValueError("Invalid amount or UPI ID.")
        
        payload = {
            "user_id": user_id,
            "amount": amount,
            "upi_id": upi_id
        }
        try:
            response = requests.post(f"{self.upi_api_url}/payment", json=payload)
            response.raise_for_status()  # Raise an error for bad status codes
            payment_response = response.json()
            return payment_response
        except requests.exceptions.RequestException as e:
            raise HTTPException(status_code=500, detail="Error initiating UPI payment: " + str(e))
    
    def verify_transaction(self, payment_id: str) -> Dict:
        """
        Verifies the status of a UPI payment.
        
        Args:
            payment_id (str): The ID of the payment to verify.

        Returns:
            Dict: The payment status from the UPI system.
        
        Raises:
            HTTPException: If there’s an issue while verifying the payment.
        """
        try:
            response = requests.get(f"{self.upi_api_url}/payment/{payment_id}")
            response.raise_for_status()
            payment_status = response.json()
            return payment_status
        except requests.exceptions.RequestException as e:
            raise HTTPException(status_code=500, detail="Error verifying UPI payment: " + str(e))

    def verify_payment(self, payment_id: str) -> Dict:
        """
        Verifies the status of a UPI payment.
        
        Args:
            payment_id (str): The ID of the payment to verify.

        Returns:
            Dict: The payment status from the UPI system.
        
        Raises:
            HTTPException: If there’s an issue while verifying the payment.
        """
        try:
            response = requests.get(f"{self.upi_api_url}/payment/{payment_id}")
            response.raise_for_status()
            payment_status = response.json()
            return payment_status
        except requests.exceptions.RequestException as e:
            raise HTTPException(status_code=500, detail="Error verifying UPI payment: " + str(e))
