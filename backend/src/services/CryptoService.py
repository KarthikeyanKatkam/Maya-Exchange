# CryptoService.py
from fastapi import HTTPException
from typing import Dict
import requests

class CryptoService:
    def __init__(self, crypto_api_url: str):
        self.crypto_api_url = crypto_api_url

    def convert_currency(self, from_currency: str, to_currency: str, amount: float) -> float:
        """
        Converts one cryptocurrency into another (or from fiat to crypto).

        Args:
            from_currency (str): The currency to convert from (e.g., 'BTC', 'INR').
            to_currency (str): The currency to convert to (e.g., 'ETH', 'USD').
            amount (float): The amount to be converted.

        Returns:
            float: The converted amount in the target currency.
        
        Raises:
            HTTPException: If the conversion fails.
        """
        payload = {
            "from_currency": from_currency,
            "to_currency": to_currency,
            "amount": amount
        }
        try:
            response = requests.post(f"{self.crypto_api_url}/convert", json=payload)
            response.raise_for_status()
            converted_data = response.json()
            return converted_data['converted_amount']
        except requests.exceptions.RequestException as e:
            raise HTTPException(status_code=500, detail="Error converting currency: " + str(e))
    
    def get_current_price(self, currency: str) -> Dict:
        """
        Retrieves the current price for a given cryptocurrency or fiat currency.

        Args:
            currency (str): The currency symbol (e.g., 'BTC', 'ETH', 'INR').

        Returns:
            Dict: The current market price for the currency.
        
        Raises:
            HTTPException: If the API request fails.
        """
        try:
            response = requests.get(f"{self.crypto_api_url}/price/{currency}")
            response.raise_for_status()
            price_data = response.json()
            return price_data
        except requests.exceptions.RequestException as e:
            raise HTTPException(status_code=500, detail="Error fetching current price: " + str(e))

    def get_balance(self, user_id: int, currency: str) -> float:
        """
        Retrieves the balance of a user's cryptocurrency or fiat balance.

        Args:
            user_id (int): The user ID.
            currency (str): The currency symbol (e.g., 'BTC', 'ETH', 'INR').

        Returns:
            float: The balance of the specified currency.
        
        Raises:
            HTTPException: If the API request fails.
        """
        payload = {
            "user_id": user_id,
            "currency": currency
        }
        try:
            response = requests.post(f"{self.crypto_api_url}/balance", json=payload)
            response.raise_for_status()
            balance_data = response.json()
            return balance_data['balance']
        except requests.exceptions.RequestException as e:
            raise HTTPException(status_code=500, detail="Error fetching balance: " + str(e))
