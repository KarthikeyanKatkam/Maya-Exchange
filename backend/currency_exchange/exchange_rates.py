import requests

# Replace with your actual CoinAPI key
API_KEY = "7a0d7376-e283-48a7-a2e4-7f547f81bc12"

def get_exchange_rate(from_symbol, to_symbol):
    url = f"https://rest.coinapi.io/v1/exchangerate/{from_symbol}/{to_symbol}"
    headers = {
        "X-CoinAPI-Key": API
    }