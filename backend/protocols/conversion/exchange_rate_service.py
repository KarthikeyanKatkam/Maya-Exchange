import requests


def get_exchange_rate(from_symbol, to_symbol):
  """Fetches the exchange rate between two currencies using CoinAPI.

  Args:
      from_symbol (str): The base currency symbol (e.g., BTC).
      to_symbol (str): The quote currency symbol (e.g., USD).

  Returns:
      float: The exchange rate (price of the base currency in the quote currency).

  Raises:
      requests.exceptions.RequestException: If there's an error with the API request.
      ValueError: If the API response data is invalid.
  """

  api_key = "bb9be9fd-1297-44fe-8381-ab5dcaded952"
  url = f"https://rest.coinapi.io/v1/exchangerate/{from_symbol}/{to_symbol}"
  headers = {"X-CoinAPI-Key": api_key}

  try:
    response = requests.get(url, headers=headers)
    response.raise_for_status()  # Raise for status codes in the 400 or 500 range
    data = response.json()
    return data['rate']
  except requests.exceptions.RequestException as e:
    raise Exception(f"Error fetching exchange rate: {e}") from e
  except (KeyError, ValueError) as e:
    raise ValueError(f"Invalid API response data: {e}") from e