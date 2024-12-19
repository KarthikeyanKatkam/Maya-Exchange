# KYCService.py
import requests
from typing import Dict
from fastapi import HTTPException

class KYCService:
    def __init__(self, api_url: str):
        self.api_url = api_url
    
    def verify_kyc(self, user_id: int, kyc_data: Dict) -> Dict:
        """
        Verifies the KYC information for a user by sending it to the external API.
        
        Args:
            user_id (int): ID of the user.
            kyc_data (Dict): KYC data to be sent for verification.
        
        Returns:
            Dict: The verification result from the external API.
        
        Raises:
            HTTPException: If the verification process fails.
        """
        try:
            response = requests.post(f"{self.api_url}/verify", json=kyc_data)
            response.raise_for_status()  # Raise an error for bad status codes
            verification_result = response.json()
            return verification_result
        except requests.exceptions.RequestException as e:
            raise HTTPException(status_code=500, detail="Error while verifying KYC: " + str(e))
        
    def update_kyc_status(self, user_id: int, status: bool) -> bool:
        """
        Updates the KYC status of the user in the database.
        
        Args:
            user_id (int): The user ID.
            status (bool): KYC verification status.
        
        Returns:
            bool: Whether the status update was successful.
        """
        # Simulate updating the database status for the user's KYC status
        # In a real scenario, we would update the database record here
        return True
