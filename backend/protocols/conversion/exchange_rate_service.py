import requests

def get_exchange_rate(from_symbol, to_symbol):
  # Replace with your actual CoinAPI key
  api_key = "bb9be9fd-1297-44fe-8381-ab5dcaded952"

  url = f"https://rest.coinapi.io/v1/exchangerate/{from_symbol}/{to_symbol}"
  headers = {"X-CoinAPI-Key": api_key}

  response = requests.get(url, headers=headers)
  response.raise_for_status()  # Raise an exception for bad status codes
  data = response.json()
  return data['rate']