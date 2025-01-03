import requests
import aiohttp
from flask import Flask, request, jsonify

app = Flask(__name__)

@app.route('/crypto-to-fiat', methods=['POST'])
def crypto_to_fiat():
    data = request.get_json()
    crypto = data['crypto']
    amount = data['amount']
    fiat = data['fiat']
    user_account = data['userAccount']
    try:
        rate = fetch_rate(crypto, fiat)
        payout = amount * rate
        payment_status = process_payment(user_account, payout)
        return jsonify(success=True, payout=payout, status=payment_status)
    except Exception as err:
        return jsonify(success=False, error=str(err)), 500
async def fetch_rate(crypto, fiat):
    async with aiohttp.ClientSession() as session:
        async with session.get(f'https://api.example.com/price?symbol={crypto}&convert={fiat}') as response:
            data = await response.json()
            return data['rate']

async def process_payment(account, amount):
    # Call payment gateway API
    return "Success"
