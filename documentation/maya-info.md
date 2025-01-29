# **Maya Exchange - Crypto Exchange with UPI Payment Service Provider Integration**
Next-Gen Crypto Exchange  

## **Table of Contents**
1. [Introduction](#introduction)  
2. [Core Features](#core-features)  
    1. [Trading Features](#trading-features)  
    2. [Wallet Features](#wallet-features)  
    3. [Payment Features](#payment-features)  
    4. [Security Features](#security-features)  
3. [Technology Stack](#technology-stack)  
4. [Development Roadmap](#development-roadmap)  
5. [APIs and Endpoints](#apis-and-endpoints)  
    1. [Market Data](#market-data)  
    2. [Trading APIs](#trading-apis)  
    3. [UPI Payment Service Provider (PSP)](#upi-payment-service-provider-psp)  
6. [Deployment](#deployment)  
7. [Scenarios](#scenarios)  
8. [Additional Features](#additional-features)  
9. [Starting the Application](#starting-the-application)

---

## **1. Introduction**

**Maya Exchange** is a cryptocurrency trading platform that offers secure and seamless trading between various cryptocurrencies, along with the ability to buy and sell using fiat currencies. The platform integrates **UPI (Unified Payments Interface)** to act as a **Payment Service Provider (PSP)**, directly connecting users with banking networks for deposits, withdrawals, and transactions.

- **Exchange Name**: Maya Exchange  
- **Core Features**: Crypto-to-fiat trading, LocalCurrency-to-Crypto (LCC), Crypto-to-LocalCurrency (CLC), Crypto-to-Crypto (CC), multi-currency wallets, secure payment gateway integration.  

---

## **9. Starting the Application**

To start the application, follow these steps:

### Frontend
1. Navigate to the frontend directory:
   ```bash
   cd frontend
   ```
2. Install dependencies (if not already done):
   ```bash
   npm install
   ```
3. Start the frontend application:
   ```bash
   npm start
   ```

### Backend
1. Navigate to the backend directory:
   ```bash
   cd backend
   ```
2. Install dependencies (if not already done):
   ```bash
   pip install -r requirements.txt
   ```
3. Start the backend application:
   ```bash
   uvicorn src.main:app --reload
   ```

Make sure to have the necessary environment variables set up as specified in the `.env` file.

---
- Peer-to-peer (P2P) trading where users can trade directly with each other using various fiat payment methods including UPI.  
- **LocalCurrency-to-Crypto (LCC)**: Convert local fiat currencies directly into crypto.  
- **Crypto-to-LocalCurrency (CLC)**: Sell crypto for local currencies instantly.  
- **Cross-Border Transactions**: Send fiat or crypto internationally, settling in the recipient's local currency or wallet.

---

### **2.2 Wallet Features**
- **Multi-Currency Wallet**: Supports fiat and crypto.  
- **Transaction History**: Track deposits, withdrawals, and trades.  
- **Private Key Management**: Secure storage for private keys with optional hardware wallet support.  
- **Cold and Hot Wallet Support**: Safeguard funds using both hot and cold storage.  

---

### **2.3 Payment Features**
- **UPI Integration**: Act as a Payment Service Provider (PSP) by integrating UPI for crypto-to-fiat and fiat-to-crypto transactions.  
- **Bank Account Linkage**: Enable users to link their bank accounts (e.g., PhonePe, Google Pay, UPI) for seamless deposits and withdrawals.  
- **Cross-App Transactions**: Allow transfers to/from other apps like Google Pay or Paytm.  
- **Fiat On/Off Ramp**: Convert crypto to fiat and fiat to crypto instantly with UPI as the main settlement method.  
- **Person-to-Person UPI Transfers**: Users can transfer money to others directly via UPI in local currencies.  
- **Multi-Currency and Forex Integration**: Users can convert their crypto to local fiat currencies or multi-currencies for international forex trading.  
- **Crypto-to-LocalCurrency (CLC) and LocalCurrency-to-Crypto (LCC)**:  
  - **Crypto-to-LocalCurrency (CLC)**: Sell crypto for local currencies instantly.  
  - **LocalCurrency-to-Crypto (LCC)**: Buy crypto directly using local fiat currencies, offering users the ability to easily access crypto markets.  
  - **Cross-Border Transactions**: Send and receive both fiat and crypto internationally, with conversions based on current forex and cryptocurrency rates.

---

### **2.4 Security Features**
- **KYC/AML Compliance**: Know your customer (KYC) and anti-money laundering (AML) processes to ensure regulatory compliance.  
- **Two-Factor Authentication (2FA)**: Protect user accounts with additional layers of security.  
- **End-to-End Encryption**: Ensure data privacy for all user transactions and wallet activities.  
- **DDoS Protection**: Safeguard the platform against distributed denial-of-service (DDoS) attacks.  

---

## **3. Technology Stack**
- **Frontend**: React.tsx, React Native, TailwindCSS.  
- **Backend**: Node.tsx (Express.tsx), Python (FastAPI).  
- **Blockchain**: Web3.tsx, Ethers.tsx, CoinGecko API.  
- **Database**: PostgreSQL, MongoDB.  
- **Infrastructure**: AWS, Docker, Kubernetes.  

---

## **4. Development Roadmap**
1. **Foundation**: Build core features, backend, and frontend.  
2. **Payment Integration**: UPI-based PSP integration.  
3. **Advanced Features**: Add Copy Trading, Staking, and more.  
4. **Security Enhancements**: KYC, 2FA, and regular audits.  
5. **Scaling and Optimization**: Deploy globally.  

---

## **7. Scenarios**
- **Scenario 1: LocalCurrency-to-Crypto (LCC)**: User converts fiat into crypto directly.  
- **Scenario 2: Cross-Border Transaction**: Send INR; recipient gets USD.  
- **Scenario 3: Peer-to-Peer UPI Payments**: UPI-based direct P2P crypto trading.  
- **Scenario 4: Forex Transaction**: User exchanges crypto to a foreign fiat currency like EUR or USD for international trade.  

---

## **8. Additional Features**
- **Referral Program**: Rewards for user referrals.  
- **AI-Powered Bots**: Automated trading assistance.  
- **Multilingual Support**: Localize for global users.  

---


================================================
File: SECURITY.md
================================================
# Security Policy

## Supported Versions

Use this section to tell people about which versions of your project are
currently being supported with security updates.

| Version | Supported          |
| ------- | ------------------ |
| 5.1.x   | :white_check_mark: |
| 5.0.x   | :x:                |
| 4.0.x   | :white_check_mark: |
| < 4.0   | :x:                |

## Reporting a Vulnerability

Use this section to tell people how to report a vulnerability.

Tell them where to go, how often they can expect to get an update on a
reported vulnerability, what to expect if the vulnerability is accepted or
declined, etc.


================================================
File: package.json
================================================
{
  "dependencies": {
    "@types/react": "^19.0.2",
    "@types/react-dom": "^19.0.2",
    "react": "^19.0.0",
    "react-router-dom": "^7.0.2",
    "redux": "^5.0.1",
    "redux-thunk": "^3.1.0"
  },
  "devDependencies": {
    "@types/history": "^5.0.0",
    "@types/node": "^22.10.3",
    "@types/react-router-dom": "^5.3.3",
    "@types/redux": "^3.6.0",
    "@types/redux-thunk": "^2.1.0",
    "typescript": "^5.7.2"
  }
}


================================================
File: state.md
================================================
================================================
File: README.md
================================================
# **Maya Exchange - Crypto Exchange with UPI Payment Service Provider Integration**
Next-Gen Crypto Exchange  

## **Table of Contents**
1. [Introduction](#introduction)  
2. [Core Features](#core-features)  
    1. [Trading Features](#trading-features)  
    2. [Wallet Features](#wallet-features)  
    3. [Payment Features](#payment-features)  
    4. [Security Features](#security-features)  
3. [Technology Stack](#technology-stack)  
4. [Development Roadmap](#development-roadmap)  
5. [APIs and Endpoints](#apis-and-endpoints)  
    1. [Market Data](#market-data)  
    2. [Trading APIs](#trading-apis)  
    3. [UPI Payment Service Provider (PSP)](#upi-payment-service-provider-psp)  
6. [Deployment](#deployment)  
7. [Scenarios](#scenarios)  
8. [Additional Features](#additional-features)  
9. [Starting the Application](#starting-the-application)

---

## **1. Introduction**

**Maya Exchange** is a cryptocurrency trading platform that offers secure and seamless trading between various cryptocurrencies, along with the ability to buy and sell using fiat currencies. The platform integrates **UPI (Unified Payments Interface)** to act as a **Payment Service Provider (PSP)**, directly connecting users with banking networks for deposits, withdrawals, and transactions.

- **Exchange Name**: Maya Exchange  
- **Core Features**: Crypto-to-fiat trading, LocalCurrency-to-Crypto (LCC), Crypto-to-LocalCurrency (CLC), Crypto-to-Crypto (CC), multi-currency wallets, secure payment gateway integration.  

---

## **9. Starting the Application**

To start the application, follow these steps:

### Frontend
1. Navigate to the frontend directory:
   ```bash
   cd frontend
   ```
2. Install dependencies (if not already done):
   ```bash
   npm install
   ```
3. Start the frontend application:
   ```bash
   npm start
   ```

### Backend
1. Navigate to the backend directory:
   ```bash
   cd backend
   ```
2. Install dependencies (if not already done):
   ```bash
   pip install -r requirements.txt
   ```
3. Start the backend application:
   ```bash
   uvicorn src.main:app --reload
   ```

Make sure to have the necessary environment variables set up as specified in the `.env` file.

---
- Peer-to-peer (P2P) trading where users can trade directly with each other using various fiat payment methods including UPI.  
- **LocalCurrency-to-Crypto (LCC)**: Convert local fiat currencies directly into crypto.  
- **Crypto-to-LocalCurrency (CLC)**: Sell crypto for local currencies instantly.  
- **Cross-Border Transactions**: Send fiat or crypto internationally, settling in the recipient's local currency or wallet.

---

### **2.2 Wallet Features**
- **Multi-Currency Wallet**: Supports fiat and crypto.  
- **Transaction History**: Track deposits, withdrawals, and trades.  
- **Private Key Management**: Secure storage for private keys with optional hardware wallet support.  
- **Cold and Hot Wallet Support**: Safeguard funds using both hot and cold storage.  

---

### **2.3 Payment Features**
- **UPI Integration**: Act as a Payment Service Provider (PSP) by integrating UPI for crypto-to-fiat and fiat-to-crypto transactions.  
- **Bank Account Linkage**: Enable users to link their bank accounts (e.g., PhonePe, Google Pay, UPI) for seamless deposits and withdrawals.  
- **Cross-App Transactions**: Allow transfers to/from other apps like Google Pay or Paytm.  
- **Fiat On/Off Ramp**: Convert crypto to fiat and fiat to crypto instantly with UPI as the main settlement method.  
- **Person-to-Person UPI Transfers**: Users can transfer money to others directly via UPI in local currencies.  
- **Multi-Currency and Forex Integration**: Users can convert their crypto to local fiat currencies or multi-currencies for international forex trading.  
- **Crypto-to-LocalCurrency (CLC) and LocalCurrency-to-Crypto (LCC)**:  
  - **Crypto-to-LocalCurrency (CLC)**: Sell crypto for local currencies instantly.  
  - **LocalCurrency-to-Crypto (LCC)**: Buy crypto directly using local fiat currencies, offering users the ability to easily access crypto markets.  
  - **Cross-Border Transactions**: Send and receive both fiat and crypto internationally, with conversions based on current forex and cryptocurrency rates.

---

### **2.4 Security Features**
- **KYC/AML Compliance**: Know your customer (KYC) and anti-money laundering (AML) processes to ensure regulatory compliance.  
- **Two-Factor Authentication (2FA)**: Protect user accounts with additional layers of security.  
- **End-to-End Encryption**: Ensure data privacy for all user transactions and wallet activities.  
- **DDoS Protection**: Safeguard the platform against distributed denial-of-service (DDoS) attacks.  

---

## **3. Technology Stack**
- **Frontend**: React.tsx, React Native, TailwindCSS.  
- **Backend**: Node.tsx (Express.tsx), Python (FastAPI).  
- **Blockchain**: Web3.tsx, Ethers.tsx, CoinGecko API.  
- **Database**: PostgreSQL, MongoDB.  
- **Infrastructure**: AWS, Docker, Kubernetes.  

---

## **4. Development Roadmap**
1. **Foundation**: Build core features, backend, and frontend.  
2. **Payment Integration**: UPI-based PSP integration.  
3. **Advanced Features**: Add Copy Trading, Staking, and more.  
4. **Security Enhancements**: KYC, 2FA, and regular audits.  
5. **Scaling and Optimization**: Deploy globally.  

---

## **7. Scenarios**
- **Scenario 1: LocalCurrency-to-Crypto (LCC)**: User converts fiat into crypto directly.  
- **Scenario 2: Cross-Border Transaction**: Send INR; recipient gets USD.  
- **Scenario 3: Peer-to-Peer UPI Payments**: UPI-based direct P2P crypto trading.  
- **Scenario 4: Forex Transaction**: User exchanges crypto to a foreign fiat currency like EUR or USD for international trade.  

---

## **8. Additional Features**
- **Referral Program**: Rewards for user referrals.  
- **AI-Powered Bots**: Automated trading assistance.  
- **Multilingual Support**: Localize for global users.  

---


================================================
File: SECURITY.md
================================================
# Security Policy

## Supported Versions

Use this section to tell people about which versions of your project are
currently being supported with security updates.

| Version | Supported          |
| ------- | ------------------ |
| 5.1.x   | :white_check_mark: |
| 5.0.x   | :x:                |
| 4.0.x   | :white_check_mark: |
| < 4.0   | :x:                |

## Reporting a Vulnerability

Use this section to tell people how to report a vulnerability.

Tell them where to go, how often they can expect to get an update on a
reported vulnerability, what to expect if the vulnerability is accepted or
declined, etc.


================================================
File: package.json
================================================
{
  "dependencies": {
    "@types/react": "^19.0.2",
    "@types/react-dom": "^19.0.2",
    "react": "^19.0.0",
    "react-router-dom": "^7.0.2",
    "redux": "^5.0.1",
    "redux-thunk": "^3.1.0"
  },
  "devDependencies": {
    "@types/history": "^5.0.0",
    "@types/node": "^22.10.3",
    "@types/react-router-dom": "^5.3.3",
    "@types/redux": "^3.6.0",
    "@types/redux-thunk": "^2.1.0",
    "typescript": "^5.7.2"
  }
}


================================================
File: analytics/ai-tools/market-prediction-model.py
================================================
import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error
import matplotlib.pyplot as plt
import yfinance as yf

# Fetch historical data for a cryptocurrency (e.g., Bitcoin)
crypto_symbol = 'BTC-USD'
data = yf.download(crypto_symbol, start='2020-01-01', end='2024-01-01')

# Prepare the data (using close price for prediction)
data['Date'] = data.index
data['Date'] = pd.to_datetime(data['Date'])
data['Date'] = data['Date'].map(lambda x: x.toordinal())  # Convert dates to ordinal values

# Define the feature and target variable
X = data[['Date']]  # Feature: Date
y = data['Close']  # Target: Closing price

# Split data into train and test sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Initialize the model and fit the training data
model = LinearRegression()
model.fit(X_train, y_train)

# Predict the prices using the test set
y_pred = model.predict(X_test)

# Calculate and display the error (Mean Squared Error)
mse = mean_squared_error(y_test, y_pred)
print(f"Mean Squared Error: {mse}")

# Visualize the results
plt.figure(figsize=(10,6))
plt.plot(data['Date'], data['Close'], label='Actual Prices')
plt.plot(X_test, y_pred, label='Predicted Prices', linestyle='--')
plt.xlabel('Date')
plt.ylabel('Price (USD)')
plt.title(f"{crypto_symbol} Market Prediction")
plt.legend()
plt.show()

# Save the model for future use (optional)
import joblib
joblib.dump(model, 'market_prediction_model.pkl')



================================================
File: analytics/ai-tools/sentiment-analysis.py
================================================
from textblob import TextBlob
import pandas as pd
import requests
from bs4 import BeautifulSoup

# Function to fetch cryptocurrency news articles (Example: using a public API or web scraping)
def fetch_news():
    url = "https://cryptonews.com/news/"
    response = requests.get(url)
    soup = BeautifulSoup(response.text, 'html.parser')
    
    articles = []
    for article in soup.find_all('div', class_='news-item'):
        title = article.find('a').text.strip()
        link = article.find('a')['href']
        articles.append({'title': title, 'link': link})
    
    return pd.DataFrame(articles)

# Perform sentiment analysis on the fetched news titles
def analyze_sentiment(news_data):
    news_data['polarity'] = news_data['title'].apply(lambda title: TextBlob(title).sentiment.polarity)
    news_data['sentiment'] = news_data['polarity'].apply(lambda p: 'positive' if p > 0 else ('negative' if p < 0 else 'neutral'))
    return news_data

# Main execution
if __name__ == "__main__":
    print("Fetching cryptocurrency news...")
    news_data = fetch_news()
    
    print("Analyzing sentiment of the news...")
    sentiment_data = analyze_sentiment(news_data)
    
    print("Sentiment analysis results:")
    print(sentiment_data)

    # Save the sentiment results to a CSV (optional)
    sentiment_data.to_csv("cryptocurrency_news_sentiment.csv", index=False)


================================================
File: analytics/reports/daily-report.md
================================================
# Daily Report for Maya Exchange

**Date:** {{current_date}}

## Summary

- **Total Transactions:** {{total_transactions}}
- **Total Volume (USD):** {{total_volume}}
- **Total Users:** {{total_users}}
- **New Signups:** {{new_signups}}
- **Active Users:** {{active_users}}

## Trading Summary

| Market        | Volume (USD) | Number of Trades |
|---------------|--------------|------------------|
| BTC-USD       | {{btc_usd_volume}} | {{btc_usd_trades}} |
| ETH-USD       | {{eth_usd_volume}} | {{eth_usd_trades}} |
| LTC-USD       | {{ltc_usd_volume}} | {{ltc_usd_trades}} |
| XRP-USD       | {{xrp_usd_volume}} | {{xrp_usd_trades}} |

## UPI Transactions

- **Total UPI Deposits:** {{total_upi_deposits}} 
- **Total UPI Withdrawals:** {{total_upi_withdrawals}}

## Compliance & Security

- **KYC Verified Users:** {{kyc_verified_users}}
- **AML Flagged Transactions:** {{aml_flagged_transactions}}

## Performance Metrics

- **API Latency (ms):** {{api_latency}}
- **System Uptime (%):** {{system_uptime}}

## Issues & Observations

- **Server Downtime:** {{downtime_duration}}
- **Alerts Triggered:** {{alerts_triggered}}

**End of Daily Report**


================================================
File: analytics/reports/user-activity-report.md
================================================
# User Activity Report for Maya Exchange

**Date:** {{report_date}}

## Overview

- **Total Users Analyzed:** {{total_users_analyzed}}
- **Active Users This Week:** {{active_users_this_week}}
- **Inactive Users:** {{inactive_users}}

## New User Signups

| Date           | New Signups | Cumulative Total Signups |
|----------------|-------------|--------------------------|
| {{date_1}}     | {{signups_1}} | {{cumulative_signups_1}} |
| {{date_2}}     | {{signups_2}} | {{cumulative_signups_2}} |
| {{date_3}}     | {{signups_3}} | {{cumulative_signups_3}} |

## User Activity Breakdown

| Activity Type      | Count |
|--------------------|-------|
| Total Logins       | {{total_logins}} |
| Total Trades       | {{total_trades}} |
| Average Trades per User | {{avg_trades_per_user}} |
| Deposits           | {{total_deposits}} |
| Withdrawals        | {{total_withdrawals}} |
| KYC Verifications  | {{kyc_verifications}} |

## User Retention

- **New Users Retained (30 days):** {{new_user_retention_30_days}}%
- **Overall Retention Rate:** {{overall_retention_rate}}%

## Active Users by Region

| Region            | Active Users |
|-------------------|--------------|
| North America     | {{na_active_users}} |
| Europe            | {{eu_active_users}} |
| Asia              | {{asia_active_users}} |
| Others            | {{other_active_users}} |

## Top User Actions

- **Highest Volume User:** {{top_user}} - {{top_user_volume}}
- **Most Active User (by trades):** {{most_active_user}} - {{most_active_user_trades}}
- **User with Most Withdrawals:** {{top_withdrawal_user}} - {{top_withdrawal_user_amount}}

## Issues & Concerns

- **Unusual Activity Detected:** {{unusual_activity_flagged}}
- **KYC Delays:** {{kyc_delays}}
- **Withdrawal Issues:** {{withdrawal_issues}}

## Recommendations

- **Increase Engagement**: Target users in the {{low_engagement_region}} to increase activity.
- **Improve KYC Process**: Address delays in verification by streamlining the process.

**End of User Activity Report**


================================================
File: analytics/reports/weekly-report.md
================================================
# Weekly Report for Maya Exchange

**Week Starting:** {{week_start_date}}  
**Week Ending:** {{week_end_date}}

## Key Metrics

- **Total Transactions:** {{weekly_total_transactions}}
- **Total Volume (USD):** {{weekly_total_volume}}
- **New Users:** {{new_users_this_week}}
- **Active Users:** {{active_users_this_week}}

## Trading Overview

| Trading Pair  | Total Volume (USD) | Number of Trades | Top Performing Coin |
|---------------|--------------------|------------------|---------------------|
| BTC-USD       | {{weekly_btc_usd_volume}} | {{weekly_btc_usd_trades}} | {{top_btc_pair}} |
| ETH-USD       | {{weekly_eth_usd_volume}} | {{weekly_eth_usd_trades}} | {{top_eth_pair}} |
| LTC-USD       | {{weekly_ltc_usd_volume}} | {{weekly_ltc_usd_trades}} | {{top_ltc_pair}} |

## UPI Activity

- **Total UPI Deposits:** {{weekly_upi_deposits}}
- **Total UPI Withdrawals:** {{weekly_upi_withdrawals}}
- **New UPI Users:** {{new_upi_users}}

## Compliance Check

- **KYC Verified Users:** {{kyc_verified_users_this_week}}
- **AML Flags:** {{aml_flags_this_week}}

## System & Performance

- **API Latency (ms):** {{weekly_api_latency}}
- **Server Uptime (%):** {{weekly_system_uptime}}
- **Number of Security Incidents:** {{weekly_security_incidents}}

## User Engagement

- **Top Performing Users (by volume):**
    - **User 1:** {{user1_name}} - {{user1_volume}}
    - **User 2:** {{user2_name}} - {{user2_volume}}
    - **User 3:** {{user3_name}} - {{user3_volume}}

- **Most Active Region:** {{most_active_region}}

## Market Trends

- **Top Gaining Coin (by percentage):** {{top_gaining_coin}} - {{percentage_increase}}%
- **Top Losing Coin (by percentage):** {{top_losing_coin}} - {{percentage_decrease}}%

**End of Weekly Report**


================================================
File: backend/Dockerfile
================================================
FROM python:3.10-slim-buster 

# Set environment variables
ENV PYTHONDONTWRITEBYTECODE=1
ENV PYTHONUNBUFFERED=1

# Set the working directory
WORKDIR /app

# Install dependencies
COPY requirements.txt ./
RUN pip install --no-cache-dir --upgrade pip && \
    pip install --no-cache-dir -r requirements.txt

# Copy the rest of the application code
COPY . .

# Expose the port
EXPOSE 8000

# Define the command to run the application
CMD ["uvicorn", "app.main:app", "--host", "0.0.0.0", "--port", "8000"]

================================================
File: backend/requirements.txt
================================================
fastapi==0.95.2
uvicorn==0.22.0
sqlalchemy==2.0.16
psycopg2-binary==2.9.6
pydantic==1.10.7
pyjwt==2.6.0
bcrypt==4.0.1
python-dotenv==0.21.1
aiohttp==3.8.4
requests==2.28.2
pytest==7.4.0
pytest-cov==4.1.0
pytest-mock==3.10.0
httpx==0.24.1
docker==6.0.1


================================================
File: backend/protocols/conversion/exchange_rate_service.py
================================================
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

================================================
File: backend/src/__init__.py
================================================
# Importing models
from .models.User import User
from .models.Transaction import Transaction
from .models.Wallet import Wallet
from .models.Trade import Trade
from .models.TradeHistory import TradeHistory

# Importing controllers
# Removed UserController import as it is not defined
from .controllers.transactionController import TransactionController
from .controllers.tradeController import TradeController

# Importing utilities
from .utils import some_utility_function  # Replace with actual utility functions as needed


================================================
File: backend/src/main.py
================================================
# main.py
from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from routers import user_router
from routers import transaction_router
from routers import trade_router
from .database import engine, Base
from .models import User, Transaction, Wallet, TradeHistory
from .config import settings
import uvicorn

# Create the FastAPI app instance
app = FastAPI()

# Add CORS middleware to allow requests from all origins (you can restrict it later)
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],  # Allow all origins for now
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Include the routers for users, transactions, and trades
app.include_router(user_router.router, prefix="/users", tags=["users"])
app.include_router(transaction_router.router, prefix="/transactions", tags=["transactions"])
app.include_router(trade_router.router, prefix="/trades", tags=["trades"])

# Initialize the database and create tables
Base.metadata.create_all(bind=engine)

# Startup event (runs when the application starts)
@app.on_event("startup")
async def startup():
    # You can add startup logic here if needed, such as initializing services or logging
    pass

# Shutdown event (runs when the application stops)
@app.on_event("shutdown")
async def shutdown():
    # You can add shutdown logic here, like closing database connections
    pass

# Root endpoint for health checks or testing the server
@app.get("/")
async def root():
    return {"message": "Welcome to Maya Exchange API"}

# Run the application using Uvicorn (if this file is executed directly)
if __name__ == "__main__":
    uvicorn.run(app, host=settings.APP_HOST, port=settings.APP_PORT)


================================================
File: backend/src/utils.py
================================================
import bcrypt

def hash_password(password: str) -> str:
    """Hash a password using bcrypt."""
    salt = bcrypt.gensalt()
    hashed = bcrypt.hashpw(password.encode('utf-8'), salt)
    return hashed.decode('utf-8')

def verify_password(plain_password: str, hashed_password: str) -> bool:
    """Verify a hashed password against a plain password."""
    return bcrypt.checkpw(plain_password.encode('utf-8'), hashed_password.encode('utf-8'))


================================================
File: backend/src/config/config.py
================================================
# config.py

import os
from dotenv import load_dotenv

# Load environment variables from a .env file (if present)
load_dotenv()

# Database URL (PostgreSQL example)
DATABASE_URL = os.getenv("DATABASE_URL", "postgresql://user:password@localhost/dbname")

# Secret key for JWT authentication (used for encoding/decoding tokens)
SECRET_KEY = os.getenv("SECRET_KEY", "your-secret-key")
ALGORITHM = os.getenv("ALGORITHM", "HS256")
ACCESS_TOKEN_EXPIRE_MINUTES = int(os.getenv("ACCESS_TOKEN_EXPIRE_MINUTES", 30))  # JWT expiration time

# Configuration for the external KYC service (example)
KYC_API_URL = os.getenv("KYC_API_URL", "https://api.kycservice.com")

# UPI API URL (example)
UPI_API_URL = os.getenv("UPI_API_URL", "https://api.upiservice.com")

# Crypto API URL (example)
CRYPTO_API_URL = os.getenv("CRYPTO_API_URL", "https://api.cryptoservice.com")

# AWS Credentials for S3 bucket (example, if you're using AWS)
AWS_ACCESS_KEY_ID = os.getenv("AWS_ACCESS_KEY_ID", "your-access-key")
AWS_SECRET_ACCESS_KEY = os.getenv("AWS_SECRET_ACCESS_KEY", "your-secret-key")
AWS_S3_BUCKET_NAME = os.getenv("AWS_S3_BUCKET_NAME", "your-bucket-name")

# Server configuration
HOST = os.getenv("HOST", "0.0.0.0")
PORT = int(os.getenv("PORT", 8000))

# Enable or disable debugging mode (for development)
DEBUG = bool(os.getenv("DEBUG", True))


================================================
File: backend/src/config/database.py
================================================
# database.py
from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
from .config import DATABASE_URL

# Create a database engine using the URL from the config
engine = create_engine(DATABASE_URL, echo=True)

# SessionLocal is a factory for creating new session instances
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

# Base class for defining models
Base = declarative_base()

# Dependency to get the database session
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


================================================
File: backend/src/controllers/dependencies.py
================================================
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker, Session
from typing import Generator  # Importing Generator
from ..config.database import DATABASE_URL

# Create a new SQLAlchemy engine instance
engine = create_engine(DATABASE_URL)
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

def get_db() -> Generator[Session, None, None]:
    """Provide a database session."""
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

================================================
File: backend/src/controllers/tradeController.py
================================================
from fastapi import APIRouter, HTTPException, Depends  # Ensure correct import
from sqlalchemy.orm import Session  # Import Session for type hinting
from pydantic import BaseModel
from ..services import trade_service
from .dependencies import get_db

router = APIRouter()


class TradeRequest(BaseModel):
    user_id: int
    from_currency: str
    to_currency: str
    amount: float
    trade_type: str  # 'spot', 'margin', 'futures', etc.


class TradeResponse(BaseModel):
    trade_id: int
    status: str
    from_currency: str
    to_currency: str
    amount: float
    price: float
    timestamp: str


@router.post("/trade", response_model=TradeResponse)
async def create_trade(request: TradeRequest, db: Session = Depends(get_db)):
    trade_data = {
        "user_id": request.user_id,
        "from_currency": request.from_currency,
        "to_currency": request.to_currency,
        "amount": request.amount,
        "trade_type": request.trade_type,
    }

    trade = await trade_service.create_trade(db, trade_data)

    if not trade:
        raise HTTPException(status_code=400, detail="Trade could not be completed")

    return TradeResponse(
        trade_id=trade.id,
        status=trade.status,
        from_currency=trade.from_currency,
        to_currency=trade.to_currency,
        amount=trade.amount,
        price=trade.price,
        timestamp=trade.timestamp,
    )


@router.get("/trade/{trade_id}", response_model=TradeResponse)
async def get_trade(trade_id: int, db: Session = Depends(get_db)):
    trade = await trade_service.get_trade_by_id(db, trade_id)

    if not trade:
        raise HTTPException(status_code=404, detail="Trade not found")

    return TradeResponse(
        trade_id=trade.id,
        status=trade.status,
        from_currency=trade.from_currency,
        to_currency=trade.to_currency,
        amount=trade.amount,
        price=trade.price,
        timestamp=trade.timestamp,
    )


================================================
File: backend/src/controllers/transactionController.py
================================================
# transactionController.py
from fastapi import APIRouter, HTTPException, Depends, status
from pydantic import BaseModel
from typing import List, Literal
from sqlalchemy.orm import Session
from ..models import Transaction
from ..services import transaction_service  # Corrected to reference the services module
from .dependencies import get_db

router = APIRouter()

class TransactionRequest(BaseModel):
    user_id: int
    amount: float
    currency: str
    transaction_type: str  # 'deposit', 'withdrawal', 'internal_transfer'

class TransactionResponse(BaseModel):
    transaction_id: int
    user_id: int
    amount: float
    currency: str
    transaction_type: str
    status: str
    timestamp: str

@router.post("/transaction", response_model=TransactionResponse)
async def create_transaction(request: TransactionRequest, db: Session = Depends(get_db)) -> TransactionResponse:
    transaction_data = {
        "user_id": request.user_id,
        "amount": request.amount,
        "currency": request.currency,
        "transaction_type": request.transaction_type,
    }

    transaction = await transaction_service.create_transaction(db, transaction_data)

    if not transaction:
        raise HTTPException(status_code=400, detail="Transaction could not be processed")

    return TransactionResponse(
        transaction_id=transaction.id,
        user_id=transaction.user_id,
        amount=transaction.amount,
        currency=transaction.currency,
        transaction_type=transaction.transaction_type,
        status=transaction.status,
        timestamp=transaction.timestamp,
    )

@router.get("/transaction/{transaction_id}", response_model=TransactionResponse)
async def get_transaction(transaction_id: int, db: Session = Depends(get_db)) -> TransactionResponse:
    transaction = await transaction_service.get_transaction_by_id(db, transaction_id)

    if not transaction:
        raise HTTPException(status_code=404, detail="Transaction not found")

    return TransactionResponse(
        transaction_id=transaction.id,
        user_id=transaction.user_id,
        amount=transaction.amount,
        currency=transaction.currency,
        transaction_type=transaction.transaction_type,
        status=transaction.status,
        timestamp=transaction.timestamp,
    )


================================================
File: backend/src/controllers/userController.py
================================================
from fastapi import APIRouter, HTTPException, Depends
from sqlalchemy.orm import Session
from pydantic import BaseModel
from typing import List
from ..database import get_db
from ..models.User import User
from ..services import user_service

router = APIRouter()

@router.post("/users/")
def create_user(email: str, password: str, db: Session = Depends(get_db)):
    db_user = User(email=email, hashed_password=password)
    db.add(db_user)
    db.commit()
    db.refresh(db_user)
    return db_user

class UserRegistrationRequest(BaseModel):
    username: str
    email: str
    password: str
    phone: str

class UserProfileResponse(BaseModel):
    user_id: int
    username: str
    email: str
    phone: str
    kyc_verified: bool

@router.post("/register", response_model=UserProfileResponse)
async def register_user(request: UserRegistrationRequest, db: Session = Depends(get_db)):
    user_data = {
        "username": request.username,
        "email": request.email,
        "password": request.password,
        "phone": request.phone,
    }

    user = await user_service.register_user(db, user_data)

    if not user:
        raise HTTPException(status_code=400, detail="User registration failed")

    return UserProfileResponse(
        user_id=user.id,
        username=user.username,
        email=user.email,
        phone=user.phone,
        kyc_verified=user.kyc_verified,
    )

@router.post("/kyc-verify/{user_id}")
async def verify_kyc(user_id: int, db: Session = Depends(get_db)):
    user = await user_service.verify_kyc(db, user_id)

    if not user:
        raise HTTPException(status_code=400, detail="User KYC verification failed")

    return {"message": "KYC verification successful"}

@router.get("/user/{user_id}", response_model=UserProfileResponse)
async def get_user_profile(user_id: int, db: Session = Depends(get_db)):
    user = await user_service.get_user_by_id(db, user_id)

    if not user:
        raise HTTPException(status_code=404, detail="User not found")

    return UserProfileResponse(
        user_id=user.id,
        username=user.username,
        email=user.email,
        phone=user.phone,
        kyc_verified=user.kyc_verified,
    )

================================================
File: backend/src/database/__init__.py
================================================
# backend/src/database/__init__.py
from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
import os

# Database URL, defaulting to an environment variable or a local database
DATABASE_URL = os.getenv("DATABASE_URL", "postgresql://user:password@localhost/dbname")

# Set up the SQLAlchemy engine
engine = create_engine(DATABASE_URL, connect_args={"check_same_thread": False})

# SessionLocal for dependency injection
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

# Base class for models
Base = declarative_base()

# Dependency to get the session (used in FastAPI routes)
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


================================================
File: backend/src/database/config.py
================================================
# backend/src/database/config.py
import os

# You can use environment variables to securely store your database URL
DATABASE_URL = os.getenv("DATABASE_URL", "postgresql://user:password@localhost/dbname")


================================================
File: backend/src/database/migrations/env.py
================================================
# backend/src/database/migrations/env.py
from logging.config import fileConfig
from sqlalchemy import engine_from_config, pool
from sqlalchemy.ext.declarative import declarative_base
from alembic import context
from database import Base  # Import the Base class from the database module

# This is the Alembic configuration object
config = context.config

# Setup for Alembic migration scripts
target_metadata = Base.metadata

# Database connection configuration
def run_migrations_online():
    # Get the URL from the config file (or use an env variable)
    config.set_main_option("sqlalchemy.url", "postgresql://user:password@localhost/dbname")

    # Create engine and connection
    engine = engine_from_config(
        config.get_section(config.config_ini_section),
        prefix="sqlalchemy.",
        poolclass=pool.NullPool,
    )

    # Run migrations using the engine
    with engine.connect() as connection:
        context.configure(connection=connection, target_metadata=target_metadata)
        with context.begin_transaction():
            context.run_migrations()

run_migrations_online()


================================================
File: backend/src/database/models/Transaction.py
================================================
# backend/src/database/models/Transaction.py
from sqlalchemy import Column, Integer, Float, DateTime, ForeignKey, String
from sqlalchemy.orm import relationship
from database import Base

class Transaction(Base):
    __tablename__ = 'transactions'

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey('users.id'))
    amount = Column(Float)
    transaction_type = Column(String)  # e.g., 'deposit', 'withdrawal'
    timestamp = Column(DateTime)

    user = relationship("User", back_populates="transactions")


================================================
File: backend/src/database/models/User.py
================================================
# backend/src/database/models/User.py
from sqlalchemy import Column, Integer, String
from sqlalchemy.orm import relationship
from backend.src.database import Base

class User(Base):
    __tablename__ = 'users'

    id = Column(Integer, primary_key=True, index=True)
    email = Column(String, unique=True, index=True)
    hashed_password = Column(String)

    # Add other fields as necessary (e.g., name, date_created, etc.)


================================================
File: backend/src/database/queries/transaction_queries.py
================================================
# backend/src/database/queries/transaction_queries.py
from sqlalchemy import text
from database import engine

def get_transactions_by_user(user_id):
    sql_query = text("SELECT * FROM transactions WHERE user_id = :user_id")
    with engine.connect() as connection:
        result = connection.execute(sql_query, {"user_id": user_id})
        return result.fetchall()


================================================
File: backend/src/models/Trade.py
================================================
from sqlalchemy import Column, Integer, Float, String, ForeignKey
from sqlalchemy.orm import relationship
from backend.src.database import Base

class Trade(Base):
    __tablename__ = "trades"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    from_currency = Column(String)
    to_currency = Column(String)
    amount = Column(Float)
    price = Column(Float)
    timestamp = Column(String)  # Consider using a datetime type

    # Relationships
    user = relationship("User", back_populates="trades")

    def __repr__(self):
        return f"<Trade(id={self.id}, user_id={self.user_id}, amount={self.amount})>"


================================================
File: backend/src/models/TradeHistory.py
================================================
# TradeHistory.py
from sqlalchemy import Column, Integer, Float, String, ForeignKey
from sqlalchemy.orm import relationship
from ..database import Base

class TradeHistory(Base):
    __tablename__ = "trade_history"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    from_currency = Column(String)
    to_currency = Column(String)
    amount = Column(Float)
    price = Column(Float)
    timestamp = Column(String)  # Consider using a datetime type
    trade_type = Column(String)  # e.g., spot, margin, futures

    # Relationships
    user = relationship("User", back_populates="trades")

    def __repr__(self):
        return f"<TradeHistory(id={self.id}, user_id={self.user_id}, from_currency={self.from_currency}, to_currency={self.to_currency}, amount={self.amount}, price={self.price})>"


================================================
File: backend/src/models/Transaction.py
================================================
# Transaction.py
from sqlalchemy import Column, Integer, Float, String, ForeignKey, Enum, DateTime
from sqlalchemy.orm import relationship, validates  # Added validates import
from ..database import Base  # Corrected to reference the database module
from enum import Enum as PyEnum

class TransactionType(PyEnum):
    DEPOSIT = "deposit"
    WITHDRAWAL = "withdrawal"
    INTERNAL_TRANSFER = "internal_transfer"

class Transaction(Base):
    __tablename__ = "transactions"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    amount = Column(Float)
    currency = Column(String)
    transaction_type = Column(Enum(TransactionType))
    status = Column(String, default="pending")
    from datetime import datetime
    from datetime import datetime

    timestamp = Column(DateTime, default=datetime.utcnow)  # Set default to current time

    # Relationships
    user = relationship("User", back_populates="transactions")

    @validates('amount')
    def validate_amount(self, key, amount):
        if amount <= 0:
            raise ValueError("Amount must be positive")
        return amount

    @validates('currency')
    def validate_currency(self, key, currency):
        valid_currencies = ["USD", "EUR", "GBP"]  # Add more valid currencies as needed
        if currency not in valid_currencies:
            raise ValueError(f"Currency must be one of {valid_currencies}")
        return currency

    def __repr__(self):
        return f"<Transaction(id={self.id}, user_id={self.user_id}, amount={self.amount}, status={self.status})>"


================================================
File: backend/src/models/User.py
================================================
# User.py
from sqlalchemy import Column, Integer, String, Boolean
from sqlalchemy.orm import relationship
from ..database import Base

class User(Base):
    # Add the following methods to the User class

    def check_password(self, password: str) -> bool:
        """Check if the provided password matches the stored password."""
        return self.password == password  # This should ideally use a hashed comparison

    def update_kyc_status(self, status: str):
        """Update the KYC status of the user."""
        self.kyc_verified = (status.lower() == "verified")
    __tablename__ = "users"

    id = Column(Integer, primary_key=True, index=True)
    username = Column(String, unique=True, index=True)
    email = Column(String, unique=True, index=True)
    password = Column(String)
    phone = Column(String, unique=True)
    kyc_verified = Column(Boolean, default=False)

    # Relationships
    transactions = relationship("Transaction", back_populates="user")
    trades = relationship("TradeHistory", back_populates="user")
    wallet = relationship("Wallet", back_populates="user", uselist=False)
    
    def __repr__(self):
        return f"<User(id={self.id}, username={self.username}, email={self.email})>"


================================================
File: backend/src/models/Wallet.py
================================================
# Wallet.py
from sqlalchemy import Column, Integer, Float, String, ForeignKey
from sqlalchemy.orm import relationship
from ..database import Base

class Wallet(Base):
    __tablename__ = "wallets"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    balance = Column(Float, default=0.0)
    currency = Column(String)

    # Relationships
    user = relationship("User", back_populates="wallet")

    def __repr__(self):
        return f"<Wallet(id={self.id}, user_id={self.user_id}, balance={self.balance}, currency={self.currency})>"


================================================
File: backend/src/models/__init__.py
================================================
# This file makes the models directory a package


================================================
File: backend/src/routers/conversion_routes.py
================================================
const express = require("express");
const { cryptoToFiat, fiatToCrypto } = require("../protocols/conversion");

const router = express.Router();

router.post("/crypto-to-fiat", cryptoToFiat);
router.post("/fiat-to-crypto", fiatToCrypto);

module.exports = router;


================================================
File: backend/src/routers/user_router.py
================================================
from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session
from typing import List
from ..controllers.userController import create_user, register_user, get_user_profile, verify_kyc, UserProfileResponse
from ..database import get_db

router = APIRouter()

# Define user-related routes here
@router.get("/", response_model=List[UserProfileResponse])  # Assuming UserProfileResponse is the correct model
async def get_users(db: Session = Depends(get_db)):
    return await get_user_profile(db)

# Add more user routes as needed


================================================
File: backend/src/services/CryptoService.py
================================================
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


================================================
File: backend/src/services/KYCService.py
================================================
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


================================================
File: backend/src/services/UPIService.py
================================================
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


================================================
File: backend/src/services/trade_service.py
================================================
from ..models.Trade import Trade  # Corrected to use a relative import

async def create_trade(db, trade_data):
    trade = Trade(**trade_data)
    db.add(trade)
    await db.commit()
    await db.refresh(trade)
    return trade

async def get_trade_by_id(db, trade_id):
    return await db.query(Trade).filter(Trade.id == trade_id).first()


================================================
File: backend/src/services/user_service.py
================================================
from fastapi import HTTPException
from sqlalchemy.orm import Session
from ..models.User import User
from ..utils import hash_password, verify_password  # Assuming these utility functions exist

class UserService:
    def create_user(self, db: Session, email: str, password: str) -> User:
        # Check if the user already exists
        existing_user = db.query(User).filter(User.email == email).first()
        if existing_user:
            raise HTTPException(status_code=400, detail="Email already registered")

        # Create a new user
        hashed_password = hash_password(password)
        new_user = User(email=email, password=hashed_password)
        db.add(new_user)
        db.commit()
        db.refresh(new_user)
        return new_user

    def get_kyc_status(self, db: Session, user_id: int) -> str:
        # Retrieve the KYC status of the user
        user = db.query(User).filter(User.id == user_id).first()
        if not user:
            raise HTTPException(status_code=404, detail="User not found")
        return "PENDING" if not user.kyc_verified else "VERIFIED"

    def login_user(self, db: Session, email: str, password: str) -> User:
        # Authenticate the user
        user = db.query(User).filter(User.email == email).first()
        if not user or not verify_password(password, user.password):
            raise HTTPException(status_code=401, detail="Invalid credentials")
        return user


================================================
File: backend/src/tests/test_trade.py
================================================
# test_trade.py
import pytest
from fastapi.testclient import TestClient
from backend.src.main import app
from backend.src.models.TradeHistory import TradeHistory  # Change to absolute import
from backend.src.models.User import User  # Change to absolute import
from backend.src.database import SessionLocal, engine  # Change to absolute import

client = TestClient(app)

@pytest.fixture(scope="function")
def test_db():
    db = SessionLocal()
    yield db
    db.close()

def test_spot_trade(test_db):
    # Test spot trading
    user = User(email="testtrader@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    # Simulate a spot trade
    response = client.post("/trades/spot", json={"user_id": user.id, "from_currency": "USD", "to_currency": "BTC", "amount": 100})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"
    assert data["from_currency"] == "USD"
    assert data["to_currency"] == "BTC"
    assert data["amount"] == 100

def test_margin_trade(test_db):
    # Test margin trading
    user = User(email="testmargintrader@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    # Simulate margin trade
    response = client.post("/trades/margin", json={"user_id": user.id, "currency": "ETH", "amount": 10, "leverage": 2})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"
    assert data["currency"] == "ETH"
    assert data["amount"] == 10

def test_trade_history(test_db):
    # Test fetching trade history
    user = User(email="tradehistory@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    response = client.get(f"/users/{user.id}/trade-history")
    assert response.status_code == 200
    data = response.json()
    assert isinstance(data, list)


================================================
File: backend/src/tests/test_transaction.py
================================================
import pytest
from fastapi.testclient import TestClient
from backend.src.main import app  # Change to absolute import
from backend.src.models.Transaction import Transaction  # Change to absolute import
from backend.src.database import SessionLocal, engine  # Change to absolute import

client = TestClient(app)

@pytest.fixture(scope="function")
def test_db():
    db = SessionLocal()
    yield db
    db.close()

def test_create_transaction(test_db):
    # Test transaction creation
    response = client.post("/transactions/", json={"user_id": 1, "amount": 100, "currency": "USD", "type": "deposit"})
    assert response.status_code == 201
    data = response.json()
    assert data["amount"] == 100
    assert data["currency"] == "USD"
    assert data["type"] == "deposit"

def test_transaction_status(test_db):
    # Test transaction status update
    response = client.post("/transactions/", json={"user_id": 1, "amount": 100, "currency": "USD", "type": "deposit"})
    transaction_id = response.json()["id"]
    
    # Update transaction status
    response = client.put(f"/transactions/{transaction_id}/status", json={"status": "completed"})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"

def test_internal_transfer(test_db):
    # Test internal transfer between users
    response = client.post("/users/", json={"email": "user1@example.com", "password": "password"})
    user1_id = response.json()["id"]
    
    response = client.post("/users/", json={"email": "user2@example.com", "password": "password"})
    user2_id = response.json()["id"]
    
    response = client.post("/transactions/", json={"user_id": user1_id, "amount": 100, "currency": "USD", "type": "deposit"})
    transaction_id = response.json()["id"]
    
    # Perform internal transfer
    response = client.post("/transactions/transfer", json={"from_user_id": user1_id, "to_user_id": user2_id, "amount": 50})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"
    assert data["amount"] == 50


================================================
File: backend/src/tests/test_user.py
================================================
import pytest
from fastapi.testclient import TestClient
from backend.src.main import app  # Change to absolute import
from backend.src.models.User import User  # Change to absolute import
from backend.src.services.KYCService import KYCService  # Change to absolute import
from backend.src.database import SessionLocal, engine  # Change to absolute import

# Initialize TestClient for making requests to FastAPI
client = TestClient(app)

@pytest.fixture(scope="function")
def test_db():
    # Set up the database for testing
    db = SessionLocal()
    yield db
    db.close()

def test_create_user(test_db):
    # Test user creation
    response = client.post("/users/", json={"email": "testuser@example.com", "password": "securepassword"})
    assert response.status_code == 201
    data = response.json()
    assert data["email"] == "testuser@example.com"
    assert "id" in data

def test_user_kyc_status(test_db):
    # Test KYC status retrieval
    user = User(email="testuser@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    # Assume KYC is pending for new users
    kyc_status = KYCService.get_kyc_status(user.id)
    assert kyc_status == "PENDING"

def test_user_login(test_db):
    # Test user login
    client.post("/users/", json={"email": "testuser@example.com", "password": "securepassword"})
    response = client.post("/login", data={"username": "testuser@example.com", "password": "securepassword"})
    assert response.status_code == 200
    assert "access_token" in response.json()


================================================
File: deployment/aws/ec2-setup.sh
================================================
#!/bin/bash

# Update system
sudo apt-get update -y
sudo apt-get upgrade -y

# Install dependencies
sudo apt-get install -y git curl unzip

# Install Node.js (required for the frontend)
curl -sL https://deb.nodesource.com/setup_18.x | sudo -E bash -
sudo apt-get install -y nodejs

# Install Docker (for containerization)
sudo apt-get install -y docker.io
sudo systemctl enable --now docker

# Install Docker Compose (for managing multi-container Docker applications)
sudo curl -L "https://github.com/docker/compose/releases/download/1.29.2/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
sudo chmod +x /usr/local/bin/docker-compose

# Install Python (for the backend)
sudo apt-get install -y python3-pip python3-dev
sudo apt-get install -y python3-venv

# Install AWS CLI (to interact with AWS services)
sudo apt-get install -y awscli

# Install Nginx (for reverse proxy)
sudo apt-get install -y nginx
sudo systemctl enable nginx
sudo systemctl start nginx

# Set up project directory
cd /home/ubuntu
git clone https://github.com/yourusername/maya-exchange.git
cd maya-exchange

# Set up the backend
cd backend
python3 -m venv venv
source venv/bin/activate
pip install -r requirements.txt

# Run backend server (e.g., using Gunicorn)
gunicorn --workers 3 src.main:app --bind 0.0.0.0:8000 &

# Set up the frontend
cd ../frontend
npm install
npm run build

# Set up Nginx to serve the frontend build
sudo cp -r dist/* /var/www/html/

# Restart Nginx to apply changes
sudo systemctl restart nginx

# Set up automatic updates
sudo apt-get install -y unattended-upgrades
sudo dpkg-reconfigure --priority=low unattended-upgrades

echo "EC2 setup completed successfully!"


================================================
File: deployment/aws/s3-setup.sh
================================================
#!/bin/bash

# Ensure AWS CLI is installed
if ! command -v aws &> /dev/null
then
    echo "AWS CLI not found. Installing..."
    sudo apt-get install -y awscli
fi

# Set AWS CLI configuration (replace with your credentials)
aws configure set aws_access_key_id YOUR_AWS_ACCESS_KEY
aws configure set aws_secret_access_key YOUR_AWS_SECRET_KEY
aws configure set default.region us-east-1

# Create an S3 bucket
echo "Creating S3 bucket..."
BUCKET_NAME="maya-exchange-assets-$(date +%s)"
aws s3 mb s3://$BUCKET_NAME

# Set up bucket policy to allow public read access (for static assets like images)
echo "Setting up bucket policy..."
cat <<EOF > bucket-policy.json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Sid": "PublicReadGetObject",
      "Effect": "Allow",
      "Principal": "*",
      "Action": "s3:GetObject",
      "Resource": "arn:aws:s3:::$BUCKET_NAME/*"
    }
  ]
}
EOF

aws s3api put-bucket-policy --bucket $BUCKET_NAME --policy file://bucket-policy.json

# Upload files to S3 bucket (replace with your actual file paths)
echo "Uploading assets to S3..."
aws s3 cp /path/to/your/static/assets s3://$BUCKET_NAME/ --recursive

echo "S3 setup completed successfully! Your bucket is: s3://$BUCKET_NAME"


================================================
File: deployment/ci-cd/build.sh
================================================
#!/bin/bash

# Frontend Build Process
echo "Starting frontend build..."
cd frontend
npm install
npm run build
echo "Frontend build completed."

# Backend Build Process (including creating a virtual environment and installing dependencies)
echo "Starting backend build..."
cd ../backend
python3 -m venv venv
source venv/bin/activate
pip install -r requirements.txt
echo "Backend build completed."

# Run tests for both frontend and backend
echo "Running frontend tests..."
cd ../frontend
npm run test

echo "Running backend tests..."
cd ../backend
source venv/bin/activate
pytest tests

echo "Build and test process completed successfully."


================================================
File: deployment/ci-cd/pipeline.yml
================================================
stages:
  - name: build
  - name: test
  - name: deploy

# Define build job
build:
  stage: build
  image: node:18 # Use the appropriate Node.js version for your frontend
  script:
    - echo "Building the frontend"
    - cd frontend
    - npm install
    - npm run build
    - echo "Building the backend"
    - cd ../backend
    - python3 -m venv venv
    - source venv/bin/activate
    - pip install -r requirements.txt
  artifacts:
    paths:
      - frontend/dist
      - backend/venv
    expire_in: 1 hour

# Define test job
test:
  stage: test
  image: python:3.9
  script:
    - echo "Running backend tests"
    - cd backend
    - source venv/bin/activate
    - pytest tests
    - echo "Running frontend tests"
    - cd ../frontend
    - npm run test

# Define deploy job
deploy:
  stage: deploy
  image: node:18
  script:
    - echo "Deploying to AWS EC2 and S3"
    - ./scripts/deploy.sh
  only:
    - master  # Trigger deploy only on the master branch


================================================
File: documentation/api/api-endpoints.md
================================================
# Maya Exchange API Endpoints

## Overview
This document lists the API endpoints available for Maya Exchange, grouped by functionality.

---

## **User Management**

### **Register a New User**
- **Endpoint**: `/api/v1/users/register`
- **Method**: `POST`
- **Description**: Registers a new user with KYC information.
- **Request Body**:
  ```json
  {
    "name": "John Doe",
    "email": "john.doe@example.com",
    "password": "securepassword",
    "mobile": "9876543210"
  }


================================================
File: documentation/api/authentication.md
================================================
# Maya Exchange API Authentication

## Overview
Maya Exchange uses **JSON Web Tokens (JWT)** for securing API endpoints. Each user must authenticate with the platform to receive a token that grants access to protected resources.

---

## **How Authentication Works**

1. **User Login**:
   - The user submits their email and password to the `/api/v1/users/login` endpoint.
   - Upon successful authentication, the server responds with a JWT token and its expiration time.

2. **Token Usage**:
   - The client includes the JWT in the `Authorization` header for all subsequent API requests.
   - Example:
     ```
     Authorization: Bearer <JWT_TOKEN>
     ```

3. **Token Validation**:
   - The backend verifies the token’s signature and expiration before granting access to the requested resource.

---

## **Login Flow**

1. **Request**:
   - **Endpoint**: `/api/v1/users/login`
   - **Method**: `POST`
   - **Body**:
     ```json
     {
       "email": "john.doe@example.com",
       "password": "securepassword"
     }
     ```

2. **Response**:
   ```json
   {
     "token": "jwt_token",
     "expires_in": 3600
   }


================================================
File: documentation/developer/contributing.md
================================================
# Contributing to Maya Exchange

Thank you for considering contributing to Maya Exchange! This document outlines the guidelines for contributing to the project.

---

## How to Contribute

1. **Fork the Repository**:
   - Navigate to the repository and click on the `Fork` button.

2. **Clone the Fork**:
   ```bash
   git clone https://github.com/your-username/maya-exchange.git
   cd maya-exchange


================================================
File: documentation/developer/setup-guide.md
================================================
# Maya Exchange Setup Guide

## Overview
This guide provides step-by-step instructions to set up the Maya Exchange project for local development. Ensure you have the required tools installed and follow the steps for both frontend and backend components.

---

## Prerequisites

1. **Node.js**:
   - Version: `20.x` (use [NVM](https://github.com/nvm-sh/nvm) if managing multiple versions).
   - Check: `node -v`

2. **Python**:
   - Version: `3.10+`
   - Check: `python3 --version`

3. **Database**:
   - PostgreSQL (Version: 14+)
   - Ensure the database is running and accessible.

4. **Docker** (Optional but recommended):
   - Version: `20.x`
   - Check: `docker --version`

5. **Additional Tools**:
   - `npm`, `pip`, and `virtualenv` for dependency management.
   - Kubernetes CLI (`kubectl`) for infrastructure deployment testing.

---

## Project Structure



================================================
File: documentation/frontend/app-architecture.md
================================================
# Maya Exchange App Architecture

This document provides an overview of the architecture for the frontend of Maya Exchange.

---

## Key Design Principles

1. **Modularization**:
   - Separation of concerns between components, pages, and utilities.
   - Reusable and testable code.

2. **State Management**:
   - Centralized state using Redux Toolkit.
   - Local component state for UI-specific behavior.

3. **API Integration**:
   - Asynchronous calls managed with Redux Thunks.
   - Error handling and loading states for improved UX.

4. **Responsive Design**:
   - Mobile-first approach using media queries.
   - Cross-platform support for web and mobile via React Native.

---

## Directory Structure



================================================
File: documentation/frontend/ui-components.md
================================================
# Maya Exchange UI Components

This document describes the key reusable UI components in the Maya Exchange frontend and their intended functionality.

---

## Component Overview

1. **Header**
   - Location: `src/components/Header.tsx`
   - Purpose: Displays the navigation bar, logo, and user-related actions like login/logout.

2. **Footer**
   - Location: `src/components/Footer.tsx`
   - Purpose: Provides links to important pages, social media, and company details.

3. **Button**
   - Location: `src/components/Button.tsx`
   - Purpose: A customizable button component used across the application.

4. **Input**
   - Location: `src/components/Input.tsx`
   - Purpose: A reusable input field for forms.

5. **Modal**
   - Location: `src/components/Modal.tsx`
   - Purpose: Displays overlay dialogs for actions like KYC verification and transaction confirmations.

6. **Card**
   - Location: `src/components/Card.tsx`
   - Purpose: Represents data visually (e.g., cryptocurrency prices, transaction summaries).

7. **Loader**
   - Location: `src/components/Loader.tsx`
   - Purpose: A loading spinner for asynchronous operations.

8. **Table**
   - Location: `src/components/Table.tsx`
   - Purpose: Displays tabular data (e.g., trade history, wallet balances).

---

## Component Guidelines

- **Styling**:
  - Follow a consistent theme defined in `src/styles/theme.ts`.
  - Use modular SCSS or styled-components for encapsulation.

- **State Management**:
  - Use `useState` or connect to the Redux store for state-driven behavior.

- **Testing**:
  - Ensure each component has unit tests in `src/__tests__/components/`.

---


================================================
File: documentation/frontend/user-guide.md
================================================
# Maya Exchange User Guide

This guide walks you through the features of the Maya Exchange platform and how to use them.

---

## Getting Started

1. **Sign Up**:
   - Navigate to [Maya Exchange](https://maya-exchange.example.com).
   - Click on **Sign Up** and complete the registration form.
   - Complete the KYC process for full access.

2. **Log In**:
   - Use your registered email and password to log in.

3. **Dashboard**:
   - After logging in, access your account summary, wallet balance, and recent transactions.

---

## Features

### Wallet
- **View Balances**: Check your fiat and crypto holdings.
- **Deposit**: Add funds via UPI or other supported payment methods.
- **Withdraw**: Transfer funds to your bank account.

### Trading
- **Spot Trading**:
  - Buy and sell cryptocurrencies at real-time prices.
  - Access live market charts and order books.

- **Margin Trading**:
  - Trade with leverage to maximize potential returns.
  - Ensure you understand the risks before trading.

- **Staking**:
  - Lock your cryptocurrencies and earn rewards over time.

### P2P Transactions
- Buy and sell crypto directly with other users.
- Use the built-in chat feature for seamless communication.

---

## Security

1. **Two-Factor Authentication (2FA)**:
   - Enable 2FA in the settings for an added layer of security.

2. **Transaction Alerts**:
   - Receive email and SMS notifications for all account activities.

3. **Password Reset**:
   - Reset your password securely using the "Forgot Password" feature.

---

## Help & Support

- **FAQs**:
  - Visit the [FAQ Page](https://maya-exchange.example.com/faq) for common questions.
  
- **Support Team**:
  - Email: support@maya-exchange.co.in
  - Phone: +91xxxxxxxxxx

---


================================================
File: frontend/declarations.d.ts
================================================
declare module '*.png' {
  const src: string;
  export default src;
}

declare module '*.jpg' {
  const src: string;
  export default src;
}

// Add more formats as needed

================================================
File: frontend/package.json
================================================
{
    "name": "maya-exchange",
    "version": "1.0.0",
    "description": "A cryptocurrency exchange platform with UPI payments integration",
    "main": "src/index.tsx",
    "scripts": {
      "start": "react-scripts start",
      "build": "react-scripts build",
      "test": "react-scripts test",
      "eject": "react-scripts eject",
      "lint": "eslint 'src/**/*.{ts,tsx}' --fix"
    },
    "dependencies": {
      "axios": "^1.4.0",
      "react": "^18.2.0",
      "react-dom": "^18.2.0",
      "react-redux": "^8.0.5",
      "react-router-dom": "^6.6.1",
      "redux": "^4.2.2",
      "redux-thunk": "^2.4.2",
      "react-scripts": "^5.0.1",
      "redux-devtools-extension": "^2.13.9",
      "typescript": "^4.6.4",
      "eslint": "^8.16.0",
      "eslint-plugin-react": "^7.31.0",
      "react-icons": "^4.6.0",
      "react-query": "^3.39.2",
      "moment": "^2.29.1",
      "react-hook-form": "^7.31.0"
    },
    "devDependencies": {
      "@types/react": "^18.0.26",
      "@types/react-dom": "^18.0.9",
      "@types/redux-thunk": "^2.1.0",
      "@typescript-eslint/eslint-plugin": "^5.2.0",
      "@typescript-eslint/parser": "^5.2.0",
      "eslint-config-airbnb-typescript": "^16.0.0",
      "eslint-plugin-import": "^2.25.3",
      "eslint-plugin-jsx-a11y": "^6.6.1",
      "eslint-plugin-react-hooks": "^4.6.0",
      "prettier": "^2.8.0"
    },
    "eslintConfig": {
      "extends": [
        "react-app",
        "react-app/jest",
        "airbnb-typescript",
        "plugin:react/recommended",
        "plugin:react-hooks/recommended",
        "plugin:jsx-a11y/recommended",
        "plugin:import/errors",
        "plugin:import/warnings"
      ],
      "parserOptions": {
        "project": "./tsconfig.json"
      }
    },
    "browserslist": {
      "production": [
        ">0.2%",
        "not dead",
        "not op_mini all"
      ],
      "development": [
        "last 1 chrome version",
        "last 1 firefox version",
        "last 1 safari version"
      ]
    }
  }
  

================================================
File: frontend/assets/styles.css
================================================
.crypto-list {
    display: flex;
    flex-direction: column;
    gap: 20px;
  }
  
  .crypto-card {
    display: flex;
    align-items: center;
    gap: 10px;
  }
  
  .crypto-icon {
    width: 30px;
    height: 30px;
  }

  /* Define the font-face for Roboto-Regular */
@font-face {
    font-family: 'Roboto';
    src: url('./assets/fonts/Roboto-Regular.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
  }
  
  /* Define the font-face for Montserrat-Bold */
  @font-face {
    font-family: 'Montserrat';
    src: url('./assets/fonts/Montserrat-Bold.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
  }
  
  /* Apply the fonts globally */
  body {
    font-family: 'Roboto', sans-serif;
  }
  
  /* Example of using Montserrat-Bold for headings */
  h1, h2, h3 {
    font-family: 'Montserrat', sans-serif;
  }
  

================================================
File: frontend/public/index.html
================================================
<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Maya Exchange</title>
  <link rel="icon" href="/favicon.ico" type="image/x-icon">
  <!-- Meta Tags for SEO -->
  <meta name="description" content="Maya Exchange - The platform for seamless crypto trading and payments">
  <meta name="keywords" content="crypto, exchange, bitcoin, ethereum, UPI, trading">
  <meta name="author" content="Maya Exchange">

  <!-- Open Graph for Social Media Preview -->
  <meta property="og:title" content="Maya Exchange" />
  <meta property="og:description" content="Maya Exchange - The platform for seamless crypto trading and payments" />
  <meta property="og:image" content="https://example.com/og-image.jpg" />
  <meta property="og:url" content="https://maya-exchange.com" />

  <!-- Apple Touch Icon for iOS Devices -->
  <link rel="apple-touch-icon" href="/apple-touch-icon.png">

  <!-- CSS File Link -->
  <link rel="stylesheet" href="/styles.css">
</head>

<body>
  <div id="root"></div>

  <!-- Scripts -->
  <script src="/bundle.js"></script> <!-- Bundled JS file -->
</body>

</html>


================================================
File: frontend/public/manifest.json
================================================
{
    "short_name": "Maya Exchange",
    "name": "Maya Exchange - Cryptocurrency Trading Platform",
    "description": "The most reliable exchange for crypto trading and payments",
    "icons": [
      {
        "src": "icons/icon-192x192.png",
        "sizes": "192x192",
        "type": "image/png"
      },
      {
        "src": "icons/icon-512x512.png",
        "sizes": "512x512",
        "type": "image/png"
      }
    ],
    "start_url": "/",
    "background_color": "#ffffff",
    "theme_color": "#4CAF50",
    "display": "standalone"
  }
  

================================================
File: frontend/public/robots.txt
================================================
User-agent: *
Disallow: /admin/
Disallow: /private/
Allow: /public/


================================================
File: frontend/public/styles.css
================================================
/* styles.css */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }
  
  body {
    font-family: Arial, sans-serif;
    background-color: #f4f4f4;
    color: #333;
  }
  
  h1, h2, h3, h4 {
    font-weight: bold;
  }
  
  a {
    text-decoration: none;
    color: inherit;
  }
  
  #root {
    padding: 20px;
  }
  

================================================
File: frontend/src/images.d.ts
================================================
declare module '*.png' {
  const src: string;
  export default src;
}declare module '*.jpg' {
  const src: string;
  export default src;
}

================================================
File: frontend/src/tsconfig.json
================================================
{
  "compilerOptions": {
    "esModuleInterop": true,
    "skipLibCheck": true,
    // other options...
    "jsx": "react"
  },
  "include": ["**/*"]
}

================================================
File: frontend/src/components/CryptoCard.tsx
================================================
import React from 'react';

interface CryptoCardProps {
  name: string;
  symbol: string;
  price: number;
  change: number;
}

const CryptoCard: React.FC<CryptoCardProps> = ({ name, symbol, price, change }) => {
  const formattedPrice = price.toLocaleString(); // Format price with commas

  return (
    <div className="crypto-card">
      <h3>{name} ({symbol})</h3>
      <p>Price: ${formattedPrice}</p>
      <p>24h Change: {change > 0 ? `+${change}%` : `${change}%`}</p>
    </div>
  );
};

export default CryptoCard;


================================================
File: frontend/src/components/CryptoList.tsx
================================================
import React, { FC } from 'react';
import CryptoCard from './CryptoCard';
import btcIcon from '../assets/images/crypto-icons/btc.png';
import ethIcon from '../assets/images/crypto-icons/eth.png';

const CryptoList: FC = () => {
  const cryptoData = [
    { name: 'Bitcoin', symbol: 'BTC', price: 55000, change: 2.5, icon: btcIcon },
    { name: 'Ethereum', symbol: 'ETH', price: 4000, change: -1.2, icon: ethIcon },
    // Add more cryptocurrencies as needed
  ];

  return (
    <div className="crypto-list">
      <h2>Popular Cryptocurrencies</h2>
      {cryptoData.map((crypto) => (
        <div key={crypto.symbol} className="crypto-card">
          <img src={crypto.icon} alt={crypto.name} className="crypto-icon" />
          <CryptoCard
            name={crypto.name}
            symbol={crypto.symbol}
            price={crypto.price}
            change={crypto.change}
          />
        </div>
      ))}
    </div>
  );
};

export default CryptoList;

================================================
File: frontend/src/components/Dashboard.tsx
================================================
import React from 'react';
import { Link } from 'react-router-dom';

const Dashboard: React.FunctionComponent = () => {
  return (
    <div className="dashboard">
      <h2>Welcome to Your Dashboard</h2>
      <div className="stats">
        <div className="stat">
          <h3>Current Balance</h3>
          <p>$5000</p>
        </div>
        <div className="stat">
          <h3>Portfolio Value</h3>
          <p>$12000</p>
        </div>
        <div className="stat">
          <h3>Active Trades</h3>
          <p>2</p>
        </div>
      </div>
      <Link to="/trade">Start Trading</Link>
    </div>
  );
};

export default Dashboard;


================================================
File: frontend/src/components/Footer.tsx
================================================
import React from 'react';

const Footer: React.FC = () => {
  return (
    <footer>
      <div className="footer-content">
        <p>© 2024 Maya Exchange. All rights reserved.</p>
        <div className="social-links">
          <a href="https://twitter.com" target="_blank" rel="noopener noreferrer">Twitter</a>
          <a href="https://linkedin.com" target="_blank" rel="noopener noreferrer">LinkedIn</a>
        </div>
      </div>
    </footer>
  );
};

export default Footer;


================================================
File: frontend/src/components/Header.tsx
================================================
import React from 'react';
import { Link } from 'react-router-dom';
import logo from '/home/kali/Desktop/Maya-Exchange/frontend/assets/images/logo.png'; // Import logo from assets folder

const Header: React.FC = () => {
  return (
    <header>
      <div className="logo">
        <img src={logo} alt="Maya Exchange Logo" /> {/* Updated to use imported logo */}
      </div>
      <nav>
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/trade">Trade</Link></li>
          <li><Link to="/wallet">Wallet</Link></li>
          <li><Link to="/profile">Profile</Link></li>
          <li><Link to="/login">Login</Link></li>
        </ul>
      </nav>
    </header>
  );
};

export default Header;


================================================
File: frontend/src/components/UserProfile.tsx
================================================
import React, { useState } from 'react';

const UserProfile: React.FC = () => {
  const [user, setUser] = useState({
    name: 'John Doe',
    email: 'johndoe@example.com',
    kycStatus: 'Verified',
  });

  return (
    <div className="user-profile">
      <h2>User Profile</h2>
      <div className="profile-info">
        <p>Name: {user.name}</p>
        <p>Email: {user.email}</p>
        <p>KYC Status: {user.kycStatus}</p>
      </div>
      <button>Edit Profile</button>
    </div>
  );
};

export default UserProfile;


================================================
File: frontend/src/pages/Dashboard.tsx
================================================
import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const Dashboard: React.FC = () => {
  const [userData, setUserData] = useState({
    name: 'John Doe',
    balance: 5000,
    portfolioValue: 12000,
    activeTrades: 2,
  });

  useEffect(() => {
    // Fetch user data from the API
    // Example: fetchUserData().then(data => setUserData(data));
  }, []);

  return (
    <div className="dashboard">
      <h2>Welcome, {userData.name}</h2>
      <div className="stats">
        <div className="stat">
          <h3>Balance</h3>
          <p>${userData.balance}</p>
        </div>
        <div className="stat">
          <h3>Portfolio Value</h3>
          <p>${userData.portfolioValue}</p>
        </div>
        <div className="stat">
          <h3>Active Trades</h3>
          <p>{userData.activeTrades}</p>
        </div>
      </div>
      <Link to="/trade">Start Trading</Link>
    </div>
  );
};

export default Dashboard;


================================================
File: frontend/src/pages/Home.tsx
================================================
import React from 'react';
import CryptoCard from '../components/CryptoCard';
import { Link } from 'react-router-dom';

const Home: React.FC = () => {
  // Sample data for cryptocurrencies
  const cryptos = [
    { name: 'Bitcoin', symbol: 'BTC', price: 35000, change: 2.5 },
    { name: 'Ethereum', symbol: 'ETH', price: 2000, change: -1.2 },
    { name: 'Ripple', symbol: 'XRP', price: 1.2, change: 0.8 },
  ];

  return (
    <div className="home">
      <h1>Welcome to Maya Exchange</h1>
      <p>Your gateway to seamless cryptocurrency trading and payments.</p>
      <div className="crypto-list">
        {cryptos.map((crypto, index) => (
          <CryptoCard
            key={index}
            name={crypto.name}
            symbol={crypto.symbol}
            price={crypto.price}
            change={crypto.change}
          />
        ))}
      </div>
      <Link to="/trade">Start Trading</Link>
    </div>
  );
};

export default Home;


================================================
File: frontend/src/pages/Login.tsx
================================================
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Login: React.FC = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Add your authentication logic here
    console.log('Logging in with:', email, password);
    // Redirect to dashboard or home page upon success
    navigate('/dashboard');
  };

  return (
    <div className="login">
      <h2>Login to Maya Exchange</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Email:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button type="submit">Login</button>
      </form>
      <p>
        Don't have an account? <a href="/signup">Sign up</a>
      </p>
    </div>
  );
};

export default Login;


================================================
File: frontend/src/pages/SignUp.tsx
================================================
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const SignUp: React.FC = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Add your sign-up logic here
    console.log('Signing up with:', name, email, password);
    // Redirect to login page or dashboard upon success
    navigate('/login');
  };

  return (
    <div className="signup">
      <h2>Create a New Account</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Name:</label>
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Email:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button type="submit">Sign Up</button>
      </form>
      <p>
        Already have an account? <a href="/login">Login</a>
      </p>
    </div>
  );
};

export default SignUp;


================================================
File: frontend/src/pages/Trade.tsx
================================================
import React, { useState } from 'react';

const Trade: React.FC = () => {
  const [selectedCrypto, setSelectedCrypto] = useState('BTC');
  const [amount, setAmount] = useState(0);

  const handleTrade = () => {
    // Add trade logic here (e.g., call API to process trade)
    console.log(`Trading ${amount} ${selectedCrypto}`);
  };

  return (
    <div className="trade">
      <h2>Trade Cryptocurrencies</h2>
      <div className="trade-form">
        <div>
          <label>Select Cryptocurrency:</label>
          <select value={selectedCrypto} onChange={(e) => setSelectedCrypto(e.target.value)}>
            <option value="BTC">Bitcoin (BTC)</option>
            <option value="ETH">Ethereum (ETH)</option>
            <option value="XRP">Ripple (XRP)</option>
          </select>
        </div>
        <div>
          <label>Amount:</label>
          <input
            type="number"
            value={amount}
            onChange={(e) => setAmount(parseFloat(e.target.value))}
            min="0"
            step="any"
          />
        </div>
        <button onClick={handleTrade}>Execute Trade</button>
      </div>
    </div>
  );
};

export default Trade;


================================================
File: frontend/src/pages/Wallet.tsx
================================================
import React from 'react';
import { Link } from 'react-router-dom';

const Wallet: React.FC = () => {
  return (
    <div className="wallet">
      <h2>Your Wallet</h2>
      <p>Manage your funds here.</p>
      <div className="wallet-balance">
        <h3>Fiat Balance</h3>
        <p>$5000</p>
      </div>
      <div className="wallet-balance">
        <h3>Crypto Balance</h3>
        <p>0.5 BTC</p>
      </div>
      <Link to="/deposit">Deposit Funds</Link>
      <Link to="/withdraw">Withdraw Funds</Link>
    </div>
  );
};

export default Wallet;


================================================
File: frontend/src/redux/actions.ts
================================================
// action.ts
export const SET_USER = 'SET_USER';
export const SET_BALANCE = 'SET_BALANCE';
export const SET_CRYPTO_BALANCE = 'SET_CRYPTO_BALANCE';
export const SET_TRADE_HISTORY = 'SET_TRADE_HISTORY';

// User Action
export const setUser = (user: { name: string; email: string; kycStatus: string }) => ({
  type: SET_USER,
  payload: user,
});

// Wallet Action
export const setBalance = (balance: number) => ({
  type: SET_BALANCE,
  payload: balance,
});

export const setCryptoBalance = (cryptoBalance: number) => ({
  type: SET_CRYPTO_BALANCE,
  payload: cryptoBalance,
});

// Trade Action
export const setTradeHistory = (tradeHistory: any[]) => ({
  type: SET_TRADE_HISTORY,
  payload: tradeHistory,
});


================================================
File: frontend/src/redux/reducers.ts
================================================
// reducers.ts
import { combineReducers } from 'redux';
export const SET_USER = 'SET_USER';
export const SET_BALANCE = 'SET_BALANCE';
export const SET_CRYPTO_BALANCE = 'SET_CRYPTO_BALANCE';
export const SET_TRADE_HISTORY = 'SET_TRADE_HISTORY';

interface UserState {
  name: string;
  email: string;
  kycStatus: string;
}

interface WalletState {
  balance: number;
  cryptoBalance: number;
}

interface TradeState {
  tradeHistory: any[];
}

const initialUserState: UserState = {
  name: '',
  email: '',
  kycStatus: '',
};

const initialWalletState: WalletState = {
  balance: 0,
  cryptoBalance: 0,
};

const initialTradeState: TradeState = {
  tradeHistory: [],
};

// User Reducer
const userReducer = (state = initialUserState, action: any): UserState => {
  switch (action.type) {
    case SET_USER:
      return {
        ...state,
        ...action.payload,
      };
    default:
      return state;
  }
};

// Wallet Reducer
const walletReducer = (state = initialWalletState, action: any): WalletState => {
  switch (action.type) {
    case SET_BALANCE:
      return {
        ...state,
        balance: action.payload,
      };
    case SET_CRYPTO_BALANCE:
      return {
        ...state,
        cryptoBalance: action.payload,
      };
    default:
      return state;
  }
};

// Trade Reducer
const tradeReducer = (state = initialTradeState, action: any): TradeState => {
  switch (action.type) {
    case SET_TRADE_HISTORY:
      return {
        ...state,
        tradeHistory: action.payload,
      };
    default:
      return state;
  }
};

// Combine reducers
const rootReducer = combineReducers({
  user: userReducer,
  wallet: walletReducer,
  trade: tradeReducer,
});

export default rootReducer;


================================================
File: frontend/src/redux/store.ts
================================================
import { createStore, applyMiddleware, Middleware } from 'redux';
import rootReducer from './reducers';
import thunk, { ThunkMiddleware } from 'redux-thunk';

const middleware: Middleware[] = [(thunk as unknown) as ThunkMiddleware];

const store = createStore(rootReducer, applyMiddleware(...middleware));

export default store;

================================================
File: frontend/src/utils/api.ts
================================================
// api.ts
const API_URL = 'https://api.maya-exchange.com'; // Replace with your actual API base URL

// Generic API request handler
const apiRequest = async (url: string, method: string = 'GET', body: any = null) => {
  try {
    const headers: any = {
      'Content-Type': 'application/json',
    };

    let options: RequestInit = {
      method,
      headers,
    };

    if (body) {
      options.body = JSON.stringify(body);
    }

    const response = await fetch(`${API_URL}${url}`, options);

    if (!response.ok) {
      throw new Error(`API request failed with status ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error('API Error:', error);
    throw error;
  }
};

// Example API functions
export const getUser = (userId: string) => apiRequest(`/users/${userId}`);

export const updateUser = (userId: string, userData: object) =>
  apiRequest(`/users/${userId}`, 'PUT', userData);

export const getBalance = (userId: string) => apiRequest(`/wallet/${userId}/balance`);

export const getTradeHistory = (userId: string) =>
  apiRequest(`/trades/${userId}/history`);


================================================
File: frontend/src/utils/formatCurrency.ts
================================================
// formatCurrency.ts
export const formatCurrency = (amount: number, currency: string = 'USD'): string => {
    return new Intl.NumberFormat('en-US', {
      style: 'currency',
      currency,
    }).format(amount);
  };
  
  // Example usage of formatting for different currencies
  export const formatFiatCurrency = (amount: number): string => formatCurrency(amount, 'USD');
  export const formatCryptoCurrency = (amount: number): string => formatCurrency(amount, 'BTC');
  

================================================
File: frontend/src/utils/validateForm.ts
================================================
export const isEmpty = (value: string): boolean => {
    return !value || value.trim().length === 0;
  };
  
  // Validate email format
  export const isValidEmail = (email: string): boolean => {
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    return emailRegex.test(email);
  };
  
  // Validate password (at least 8 characters, at least one letter and one number)
  export const isValidPassword = (password: string): boolean => {
    const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
    return passwordRegex.test(password);
  };
  
  // Example of usage for a registration form
  export const validateRegistrationForm = (email: string, password: string): string[] => {
    const errors: string[] = [];
  
    if (isEmpty(email)) {
      errors.push('Email is required');
    } else if (!isValidEmail(email)) {
      errors.push('Please enter a valid email address');
    }
  
    if (isEmpty(password)) {
      errors.push('Password is required');
    } else if (!isValidPassword(password)) {
      errors.push('Password must be at least 8 characters long and include at least one letter and one number');
    }
  
    return errors;
  };
  

================================================
File: infrastructure/docker/Dockerfile
================================================
# Base image for Python
FROM python:3.10-slim

# Set environment variables to avoid interactive prompts
ENV PYTHONUNBUFFERED 1

# Set the working directory in the container
WORKDIR /app

# Copy the backend files into the container
COPY ../../backend/requirements.txt /app/requirements.txt

# Install Python dependencies
RUN pip install --no-cache-dir -r requirements.txt

# Copy the rest of the backend code into the container
COPY /home/kali/Desktop/Maya-Exchange/backend/requirements.txt /app

# Expose the backend service port
EXPOSE 8000

# Start the FastAPI backend service
CMD ["uvicorn", "main:app", "--host", "0.0.0.0", "--port", "8000"]


================================================
File: infrastructure/docker/docker-compose.yml
================================================
version: '3.8'

services:
  backend:
    build:
      context: ../../
      dockerfile: infrastructure/docker/Dockerfile
    container_name: maya_backend
    ports:
      - "8000:8000"
    env_file:
      - ../../backend/.env
    depends_on:
      - db
    networks:
      - maya_network

  db:
    image: postgres:15
    container_name: maya_postgres
    ports:
      - "5432:5432"
    environment:
      POSTGRES_USER: admin
      POSTGRES_PASSWORD: adminpassword
      POSTGRES_DB: maya_exchange
    volumes:
      - postgres_data:/var/lib/postgresql/data
    networks:
      - maya_network

volumes:
  postgres_data:

networks:
  maya_network:


================================================
File: infrastructure/kubernetes/deployment.yaml
================================================
apiVersion: apps/v1
kind: Deployment
metadata:
  name: maya-backend-deployment
  labels:
    app: maya-backend
spec:
  replicas: 2
  selector:
    matchLabels:
      app: maya-backend
  template:
    metadata:
      labels:
        app: maya-backend
    spec:
      containers:
        - name: maya-backend
          image: maya-exchange-backend:latest
          ports:
            - containerPort: 8000
          envFrom:
            - configMapRef:
                name: backend-config
            - secretRef:
                name: backend-secrets
          resources:
            requests:
              memory: "512Mi"
              cpu: "500m"
            limits:
              memory: "1Gi"
              cpu: "1"
        - name: maya-db
          image: postgres:15
          ports:
            - containerPort: 5432
          env:
            - name: POSTGRES_USER
              valueFrom:
                secretKeyRef:
                  name: db-secrets
                  key: username
            - name: POSTGRES_PASSWORD
              valueFrom:
                secretKeyRef:
                  name: db-secrets
                  key: password
            - name: POSTGRES_DB
              value: maya_exchange
          resources:
            requests:
              memory: "256Mi"
              cpu: "250m"
            limits:
              memory: "512Mi"
              cpu: "500m"


================================================
File: infrastructure/kubernetes/ingress.yaml
================================================
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: maya-exchange-ingress
  annotations:
    nginx.ingress.kubernetes.io/rewrite-target: /
    nginx.ingress.kubernetes.io/proxy-body-size: "10m"
    nginx.ingress.kubernetes.io/ssl-redirect: "true"
spec:
  rules:
    - host: maya-exchange.local
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: maya-backend-service
                port:
                  number: 80
  tls:
    - hosts:
        - maya-exchange.local
      secretName: maya-exchange-tls


================================================
File: infrastructure/kubernetes/service.yaml
================================================
apiVersion: v1
kind: Service
metadata:
  name: maya-backend-service
  labels:
    app: maya-backend
spec:
  selector:
    app: maya-backend
  ports:
    - protocol: TCP
      port: 80
      targetPort: 8000
  type: ClusterIP

---
apiVersion: v1
kind: Service
metadata:
  name: maya-db-service
  labels:
    app: maya-db
spec:
  selector:
    app: maya-db
  ports:
    - protocol: TCP
      port: 5432
      targetPort: 5432
  type: ClusterIP


================================================
File: testing/run_tests.sh
================================================
#!/bin/bash

# Set the PYTHONPATH to include the backend/src directory
export PYTHONPATH=$PYTHONPATH:$(pwd)/backend

# Run the unit tests
python3 -m unittest discover -s testing/unit -p "*.py"


================================================
File: testing/integration/test_crypto_service.py
================================================
import unittest
from fastapi.testclient import TestClient
import sys
import os
sys.path.insert(0, os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))
from main import app  # Adjust the import based on your project structure

class TestCryptoServiceIntegration(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.user_data = {
            "name": "Bob",
            "email": "bob@example.com",
            "password": "complexpassword"
        }
        self.client.post("/auth/register", json=self.user_data)
        login_response = self.client.post("/auth/login", json={
            "email": self.user_data["email"],
            "password": self.user_data["password"]
        })
        self.token = login_response.json().get("access_token")
        self.headers = {"Authorization": f"Bearer {self.token}"}

    def test_crypto_purchase(self):
        purchase_data = {
            "crypto": "BTC",
            "amount": 0.01,
            "currency": "USD",
            "price": 30000  # Assume a fixed price for testing
        }
        response = self.client.post("/crypto/purchase", json=purchase_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Completed")

    def test_crypto_sale(self):
        sale_data = {
            "crypto": "ETH",
            "amount": 0.5,
            "currency": "USD",
            "price": 2000  # Assume a fixed price for testing
        }
        response = self.client.post("/crypto/sell", json=sale_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Completed")

    def test_crypto_balance(self):
        response = self.client.get("/crypto/balance", headers=self.headers)
        self.assertEqual(response.status_code, 200)
        self.assertIsInstance(response.json(), dict)
        self.assertIn("BTC", response.json())
        self.assertIn("ETH", response.json())

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/integration/test_transaction_flow.py
================================================
import unittest
from fastapi.testclient import TestClient
from src.main import app

class TestTransactionFlowIntegration(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.user_data = {
            "name": "Alice",
            "email": "alice@example.com",
            "password": "strongpassword"
        }
        self.client.post("/auth/register", json=self.user_data)
        login_response = self.client.post("/auth/login", json={
            "email": self.user_data["email"],
            "password": self.user_data["password"]
        })
        self.token = login_response.json().get("access_token")
        self.headers = {"Authorization": f"Bearer {self.token}"}

    def test_deposit_transaction(self):
        deposit_data = {
            "type": "Deposit",
            "amount": 1000,
            "currency": "USD"
        }
        response = self.client.post("/transactions/deposit", json=deposit_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Completed")

    def test_withdraw_transaction(self):
        withdraw_data = {
            "type": "Withdraw",
            "amount": 500,
            "currency": "USD"
        }
        response = self.client.post("/transactions/withdraw", json=withdraw_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Pending")

    def test_transaction_history(self):
        response = self.client.get("/transactions/history", headers=self.headers)
        self.assertEqual(response.status_code, 200)
        self.assertIsInstance(response.json(), list)

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/integration/test_user_auth.py
================================================
import unittest
from fastapi.testclient import TestClient
from src.main import app

class TestUserAuthIntegration(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.test_user = {
            "name": "Jane Doe",
            "email": "jane.doe@example.com",
            "password": "securepassword123"
        }

    def test_user_registration(self):
        response = self.client.post("/auth/register", json=self.test_user)
        self.assertEqual(response.status_code, 201)
        self.assertIn("message", response.json())
        self.assertIn("user_id", response.json())

    def test_user_login(self):
        # First, register the user
        self.client.post("/auth/register", json=self.test_user)
        
        # Attempt login
        login_data = {
            "email": self.test_user["email"],
            "password": self.test_user["password"]
        }
        response = self.client.post("/auth/login", json=login_data)
        self.assertEqual(response.status_code, 200)
        self.assertIn("access_token", response.json())

    def test_protected_route_access(self):
        # Register and login to get token
        self.client.post("/auth/register", json=self.test_user)
        login_response = self.client.post("/auth/login", json={
            "email": self.test_user["email"],
            "password": self.test_user["password"]
        })
        token = login_response.json().get("access_token")
        
        # Access protected route
        headers = {"Authorization": f"Bearer {token}"}
        response = self.client.get("/protected", headers=headers)
        self.assertEqual(response.status_code, 200)
        self.assertIn("message", response.json())

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/load/test_load_signups.py
================================================
import unittest
import time
from fastapi.testclient import TestClient
from src.main import app

class TestLoadSignups(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)

    def test_signup_load(self):
        start_time = time.time()
        for i in range(100):  # Simulating 100 user signups
            signup_data = {
                "name": f"TestUser{i}",
                "email": f"testuser{i}@example.com",
                "password": "password123"
            }
            response = self.client.post("/auth/register", json=signup_data)
            self.assertEqual(response.status_code, 201)
            self.assertIn("user_id", response.json())
            self.assertIn("message", response.json())

        end_time = time.time()
        print(f"Processed 100 signups in {end_time - start_time:.2f} seconds.")

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/load/test_load_transactions.py
================================================
import unittest
import time
from fastapi.testclient import TestClient
from src.main import app

class TestLoadTransactions(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.user_data = {
            "name": "Load Tester",
            "email": "loadtester@example.com",
            "password": "testpassword123"
        }
        # Register and login the test user
        self.client.post("/auth/register", json=self.user_data)
        login_response = self.client.post("/auth/login", json={
            "email": self.user_data["email"],
            "password": self.user_data["password"]
        })
        self.token = login_response.json().get("access_token")
        self.headers = {"Authorization": f"Bearer {self.token}"}

    def test_transaction_load(self):
        start_time = time.time()
        for i in range(100):  # Simulating 100 transactions
            transaction_data = {
                "type": "Deposit" if i % 2 == 0 else "Withdraw",
                "amount": 10 + i,  # Increment amount for variety
                "currency": "USD"
            }
            response = self.client.post("/transactions/create", json=transaction_data, headers=self.headers)
            self.assertEqual(response.status_code, 201)
            self.assertIn("transaction_id", response.json())
            self.assertIn("status", response.json())

        end_time = time.time()
        print(f"Processed 100 transactions in {end_time - start_time:.2f} seconds.")

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/unit/test_transaction_model.py
================================================
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


================================================
File: testing/unit/test_upi_service.py
================================================
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


================================================
File: testing/unit/test_user_model.py
================================================
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


================================================
File: .github/workflows/codeql.yml
================================================
# For most projects, this workflow file will not need changing; you simply need
# to commit it to your repository.
#
# You may wish to alter this file to override the set of languages analyzed,
# or to provide custom queries or build logic.
#
# ******** NOTE ********
# We have attempted to detect the languages in your repository. Please check
# the `language` matrix defined below to confirm you have the correct set of
# supported CodeQL languages.
#
name: "CodeQL Advanced"

on:
  push:
    branches: [ "main" ]
  pull_request:
    branches: [ "main" ]
  schedule:
    - cron: '21 20 * * 0'

jobs:
  analyze:
    name: Analyze (${{ matrix.language }})
    # Runner size impacts CodeQL analysis time. To learn more, please see:
    #   - https://gh.io/recommended-hardware-resources-for-running-codeql
    #   - https://gh.io/supported-runners-and-hardware-resources
    #   - https://gh.io/using-larger-runners (GitHub.com only)
    # Consider using larger runners or machines with greater resources for possible analysis time improvements.
    runs-on: ${{ (matrix.language == 'swift' && 'macos-latest') || 'ubuntu-latest' }}
    permissions:
      # required for all workflows
      security-events: write

      # required to fetch internal or private CodeQL packs
      packages: read

      # only required for workflows in private repositories
      actions: read
      contents: read

    strategy:
      fail-fast: false
      matrix:
        include:
        - language: javascript-typescript
          build-mode: none
        - language: python
          build-mode: none
        # CodeQL supports the following values keywords for 'language': 'c-cpp', 'csharp', 'go', 'java-kotlin', 'javascript-typescript', 'python', 'ruby', 'swift'
        # Use `c-cpp` to analyze code written in C, C++ or both
        # Use 'java-kotlin' to analyze code written in Java, Kotlin or both
        # Use 'javascript-typescript' to analyze code written in JavaScript, TypeScript or both
        # To learn more about changing the languages that are analyzed or customizing the build mode for your analysis,
        # see https://docs.github.com/en/code-security/code-scanning/creating-an-advanced-setup-for-code-scanning/customizing-your-advanced-setup-for-code-scanning.
        # If you are analyzing a compiled language, you can modify the 'build-mode' for that language to customize how
        # your codebase is analyzed, see https://docs.github.com/en/code-security/code-scanning/creating-an-advanced-setup-for-code-scanning/codeql-code-scanning-for-compiled-languages
    steps:
    - name: Checkout repository
      uses: actions/checkout@v4

    # Initializes the CodeQL tools for scanning.
    - name: Initialize CodeQL
      uses: github/codeql-action/init@v3
      with:
        languages: ${{ matrix.language }}
        build-mode: ${{ matrix.build-mode }}
        # If you wish to specify custom queries, you can do so here or in a config file.
        # By default, queries listed here will override any specified in a config file.
        # Prefix the list here with "+" to use these queries and those in the config file.

        # For more details on CodeQL's query packs, refer to: https://docs.github.com/en/code-security/code-scanning/automatically-scanning-your-code-for-vulnerabilities-and-errors/configuring-code-scanning#using-queries-in-ql-packs
        # queries: security-extended,security-and-quality

    # If the analyze step fails for one of the languages you are analyzing with
    # "We were unable to automatically build your code", modify the matrix above
    # to set the build mode to "manual" for that language. Then modify this step
    # to build your code.
    # ℹ️ Command-line programs to run using the OS shell.
    # 📚 See https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idstepsrun
    - if: matrix.build-mode == 'manual'
      shell: bash
      run: |
        echo 'If you are using a "manual" build mode for one or more of the' \
          'languages you are analyzing, replace this with the commands to build' \
          'your code, for example:'
        echo '  make bootstrap'
        echo '  make release'
        exit 1

    - name: Perform CodeQL Analysis
      uses: github/codeql-action/analyze@v3
      with:
        category: "/language:${{matrix.language}}"


================================================
File: .github/workflows/docker-image.yml
================================================
name: Docker Image CI

on:
  push:
    branches: [ "main" ]
  pull_request:
    branches: [ "main" ]

jobs:

  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v4
    - name: Build the Docker image
      run: docker build . --file Dockerfile --tag my-image-name:$(date +%s)




================================================
File: analytics/ai-tools/market-prediction-model.py
================================================
import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error
import matplotlib.pyplot as plt
import yfinance as yf

# Fetch historical data for a cryptocurrency (e.g., Bitcoin)
crypto_symbol = 'BTC-USD'
data = yf.download(crypto_symbol, start='2020-01-01', end='2024-01-01')

# Prepare the data (using close price for prediction)
data['Date'] = data.index
data['Date'] = pd.to_datetime(data['Date'])
data['Date'] = data['Date'].map(lambda x: x.toordinal())  # Convert dates to ordinal values

# Define the feature and target variable
X = data[['Date']]  # Feature: Date
y = data['Close']  # Target: Closing price

# Split data into train and test sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Initialize the model and fit the training data
model = LinearRegression()
model.fit(X_train, y_train)

# Predict the prices using the test set
y_pred = model.predict(X_test)

# Calculate and display the error (Mean Squared Error)
mse = mean_squared_error(y_test, y_pred)
print(f"Mean Squared Error: {mse}")

# Visualize the results
plt.figure(figsize=(10,6))
plt.plot(data['Date'], data['Close'], label='Actual Prices')
plt.plot(X_test, y_pred, label='Predicted Prices', linestyle='--')
plt.xlabel('Date')
plt.ylabel('Price (USD)')
plt.title(f"{crypto_symbol} Market Prediction")
plt.legend()
plt.show()

# Save the model for future use (optional)
import joblib
joblib.dump(model, 'market_prediction_model.pkl')



================================================
File: analytics/ai-tools/sentiment-analysis.py
================================================
from textblob import TextBlob
import pandas as pd
import requests
from bs4 import BeautifulSoup

# Function to fetch cryptocurrency news articles (Example: using a public API or web scraping)
def fetch_news():
    url = "https://cryptonews.com/news/"
    response = requests.get(url)
    soup = BeautifulSoup(response.text, 'html.parser')
    
    articles = []
    for article in soup.find_all('div', class_='news-item'):
        title = article.find('a').text.strip()
        link = article.find('a')['href']
        articles.append({'title': title, 'link': link})
    
    return pd.DataFrame(articles)

# Perform sentiment analysis on the fetched news titles
def analyze_sentiment(news_data):
    news_data['polarity'] = news_data['title'].apply(lambda title: TextBlob(title).sentiment.polarity)
    news_data['sentiment'] = news_data['polarity'].apply(lambda p: 'positive' if p > 0 else ('negative' if p < 0 else 'neutral'))
    return news_data

# Main execution
if __name__ == "__main__":
    print("Fetching cryptocurrency news...")
    news_data = fetch_news()
    
    print("Analyzing sentiment of the news...")
    sentiment_data = analyze_sentiment(news_data)
    
    print("Sentiment analysis results:")
    print(sentiment_data)

    # Save the sentiment results to a CSV (optional)
    sentiment_data.to_csv("cryptocurrency_news_sentiment.csv", index=False)


================================================
File: analytics/reports/daily-report.md
================================================
# Daily Report for Maya Exchange

**Date:** {{current_date}}

## Summary

- **Total Transactions:** {{total_transactions}}
- **Total Volume (USD):** {{total_volume}}
- **Total Users:** {{total_users}}
- **New Signups:** {{new_signups}}
- **Active Users:** {{active_users}}

## Trading Summary

| Market        | Volume (USD) | Number of Trades |
|---------------|--------------|------------------|
| BTC-USD       | {{btc_usd_volume}} | {{btc_usd_trades}} |
| ETH-USD       | {{eth_usd_volume}} | {{eth_usd_trades}} |
| LTC-USD       | {{ltc_usd_volume}} | {{ltc_usd_trades}} |
| XRP-USD       | {{xrp_usd_volume}} | {{xrp_usd_trades}} |

## UPI Transactions

- **Total UPI Deposits:** {{total_upi_deposits}} 
- **Total UPI Withdrawals:** {{total_upi_withdrawals}}

## Compliance & Security

- **KYC Verified Users:** {{kyc_verified_users}}
- **AML Flagged Transactions:** {{aml_flagged_transactions}}

## Performance Metrics

- **API Latency (ms):** {{api_latency}}
- **System Uptime (%):** {{system_uptime}}

## Issues & Observations

- **Server Downtime:** {{downtime_duration}}
- **Alerts Triggered:** {{alerts_triggered}}

**End of Daily Report**


================================================
File: analytics/reports/user-activity-report.md
================================================
# User Activity Report for Maya Exchange

**Date:** {{report_date}}

## Overview

- **Total Users Analyzed:** {{total_users_analyzed}}
- **Active Users This Week:** {{active_users_this_week}}
- **Inactive Users:** {{inactive_users}}

## New User Signups

| Date           | New Signups | Cumulative Total Signups |
|----------------|-------------|--------------------------|
| {{date_1}}     | {{signups_1}} | {{cumulative_signups_1}} |
| {{date_2}}     | {{signups_2}} | {{cumulative_signups_2}} |
| {{date_3}}     | {{signups_3}} | {{cumulative_signups_3}} |

## User Activity Breakdown

| Activity Type      | Count |
|--------------------|-------|
| Total Logins       | {{total_logins}} |
| Total Trades       | {{total_trades}} |
| Average Trades per User | {{avg_trades_per_user}} |
| Deposits           | {{total_deposits}} |
| Withdrawals        | {{total_withdrawals}} |
| KYC Verifications  | {{kyc_verifications}} |

## User Retention

- **New Users Retained (30 days):** {{new_user_retention_30_days}}%
- **Overall Retention Rate:** {{overall_retention_rate}}%

## Active Users by Region

| Region            | Active Users |
|-------------------|--------------|
| North America     | {{na_active_users}} |
| Europe            | {{eu_active_users}} |
| Asia              | {{asia_active_users}} |
| Others            | {{other_active_users}} |

## Top User Actions

- **Highest Volume User:** {{top_user}} - {{top_user_volume}}
- **Most Active User (by trades):** {{most_active_user}} - {{most_active_user_trades}}
- **User with Most Withdrawals:** {{top_withdrawal_user}} - {{top_withdrawal_user_amount}}

## Issues & Concerns

- **Unusual Activity Detected:** {{unusual_activity_flagged}}
- **KYC Delays:** {{kyc_delays}}
- **Withdrawal Issues:** {{withdrawal_issues}}

## Recommendations

- **Increase Engagement**: Target users in the {{low_engagement_region}} to increase activity.
- **Improve KYC Process**: Address delays in verification by streamlining the process.

**End of User Activity Report**


================================================
File: analytics/reports/weekly-report.md
================================================
# Weekly Report for Maya Exchange

**Week Starting:** {{week_start_date}}  
**Week Ending:** {{week_end_date}}

## Key Metrics

- **Total Transactions:** {{weekly_total_transactions}}
- **Total Volume (USD):** {{weekly_total_volume}}
- **New Users:** {{new_users_this_week}}
- **Active Users:** {{active_users_this_week}}

## Trading Overview

| Trading Pair  | Total Volume (USD) | Number of Trades | Top Performing Coin |
|---------------|--------------------|------------------|---------------------|
| BTC-USD       | {{weekly_btc_usd_volume}} | {{weekly_btc_usd_trades}} | {{top_btc_pair}} |
| ETH-USD       | {{weekly_eth_usd_volume}} | {{weekly_eth_usd_trades}} | {{top_eth_pair}} |
| LTC-USD       | {{weekly_ltc_usd_volume}} | {{weekly_ltc_usd_trades}} | {{top_ltc_pair}} |

## UPI Activity

- **Total UPI Deposits:** {{weekly_upi_deposits}}
- **Total UPI Withdrawals:** {{weekly_upi_withdrawals}}
- **New UPI Users:** {{new_upi_users}}

## Compliance Check

- **KYC Verified Users:** {{kyc_verified_users_this_week}}
- **AML Flags:** {{aml_flags_this_week}}

## System & Performance

- **API Latency (ms):** {{weekly_api_latency}}
- **Server Uptime (%):** {{weekly_system_uptime}}
- **Number of Security Incidents:** {{weekly_security_incidents}}

## User Engagement

- **Top Performing Users (by volume):**
    - **User 1:** {{user1_name}} - {{user1_volume}}
    - **User 2:** {{user2_name}} - {{user2_volume}}
    - **User 3:** {{user3_name}} - {{user3_volume}}

- **Most Active Region:** {{most_active_region}}

## Market Trends

- **Top Gaining Coin (by percentage):** {{top_gaining_coin}} - {{percentage_increase}}%
- **Top Losing Coin (by percentage):** {{top_losing_coin}} - {{percentage_decrease}}%

**End of Weekly Report**


================================================
File: backend/Dockerfile
================================================
FROM python:3.10-slim-buster 

# Set environment variables
ENV PYTHONDONTWRITEBYTECODE=1
ENV PYTHONUNBUFFERED=1

# Set the working directory
WORKDIR /app

# Install dependencies
COPY requirements.txt ./
RUN pip install --no-cache-dir --upgrade pip && \
    pip install --no-cache-dir -r requirements.txt

# Copy the rest of the application code
COPY . .

# Expose the port
EXPOSE 8000

# Define the command to run the application
CMD ["uvicorn", "app.main:app", "--host", "0.0.0.0", "--port", "8000"]

================================================
File: backend/requirements.txt
================================================
fastapi==0.95.2
uvicorn==0.22.0
sqlalchemy==2.0.16
psycopg2-binary==2.9.6
pydantic==1.10.7
pyjwt==2.6.0
bcrypt==4.0.1
python-dotenv==0.21.1
aiohttp==3.8.4
requests==2.28.2
pytest==7.4.0
pytest-cov==4.1.0
pytest-mock==3.10.0
httpx==0.24.1
docker==6.0.1


================================================
File: backend/protocols/conversion/exchange_rate_service.py
================================================
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

================================================
File: backend/src/__init__.py
================================================
# Importing models
from .models.User import User
from .models.Transaction import Transaction
from .models.Wallet import Wallet
from .models.Trade import Trade
from .models.TradeHistory import TradeHistory

# Importing controllers
# Removed UserController import as it is not defined
from .controllers.transactionController import TransactionController
from .controllers.tradeController import TradeController

# Importing utilities
from .utils import some_utility_function  # Replace with actual utility functions as needed


================================================
File: backend/src/main.py
================================================
# main.py
from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from routers import user_router
from routers import transaction_router
from routers import trade_router
from .database import engine, Base
from .models import User, Transaction, Wallet, TradeHistory
from .config import settings
import uvicorn

# Create the FastAPI app instance
app = FastAPI()

# Add CORS middleware to allow requests from all origins (you can restrict it later)
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],  # Allow all origins for now
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Include the routers for users, transactions, and trades
app.include_router(user_router.router, prefix="/users", tags=["users"])
app.include_router(transaction_router.router, prefix="/transactions", tags=["transactions"])
app.include_router(trade_router.router, prefix="/trades", tags=["trades"])

# Initialize the database and create tables
Base.metadata.create_all(bind=engine)

# Startup event (runs when the application starts)
@app.on_event("startup")
async def startup():
    # You can add startup logic here if needed, such as initializing services or logging
    pass

# Shutdown event (runs when the application stops)
@app.on_event("shutdown")
async def shutdown():
    # You can add shutdown logic here, like closing database connections
    pass

# Root endpoint for health checks or testing the server
@app.get("/")
async def root():
    return {"message": "Welcome to Maya Exchange API"}

# Run the application using Uvicorn (if this file is executed directly)
if __name__ == "__main__":
    uvicorn.run(app, host=settings.APP_HOST, port=settings.APP_PORT)


================================================
File: backend/src/utils.py
================================================
import bcrypt

def hash_password(password: str) -> str:
    """Hash a password using bcrypt."""
    salt = bcrypt.gensalt()
    hashed = bcrypt.hashpw(password.encode('utf-8'), salt)
    return hashed.decode('utf-8')

def verify_password(plain_password: str, hashed_password: str) -> bool:
    """Verify a hashed password against a plain password."""
    return bcrypt.checkpw(plain_password.encode('utf-8'), hashed_password.encode('utf-8'))


================================================
File: backend/src/config/config.py
================================================
# config.py

import os
from dotenv import load_dotenv

# Load environment variables from a .env file (if present)
load_dotenv()

# Database URL (PostgreSQL example)
DATABASE_URL = os.getenv("DATABASE_URL", "postgresql://user:password@localhost/dbname")

# Secret key for JWT authentication (used for encoding/decoding tokens)
SECRET_KEY = os.getenv("SECRET_KEY", "your-secret-key")
ALGORITHM = os.getenv("ALGORITHM", "HS256")
ACCESS_TOKEN_EXPIRE_MINUTES = int(os.getenv("ACCESS_TOKEN_EXPIRE_MINUTES", 30))  # JWT expiration time

# Configuration for the external KYC service (example)
KYC_API_URL = os.getenv("KYC_API_URL", "https://api.kycservice.com")

# UPI API URL (example)
UPI_API_URL = os.getenv("UPI_API_URL", "https://api.upiservice.com")

# Crypto API URL (example)
CRYPTO_API_URL = os.getenv("CRYPTO_API_URL", "https://api.cryptoservice.com")

# AWS Credentials for S3 bucket (example, if you're using AWS)
AWS_ACCESS_KEY_ID = os.getenv("AWS_ACCESS_KEY_ID", "your-access-key")
AWS_SECRET_ACCESS_KEY = os.getenv("AWS_SECRET_ACCESS_KEY", "your-secret-key")
AWS_S3_BUCKET_NAME = os.getenv("AWS_S3_BUCKET_NAME", "your-bucket-name")

# Server configuration
HOST = os.getenv("HOST", "0.0.0.0")
PORT = int(os.getenv("PORT", 8000))

# Enable or disable debugging mode (for development)
DEBUG = bool(os.getenv("DEBUG", True))


================================================
File: backend/src/config/database.py
================================================
# database.py
from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
from .config import DATABASE_URL

# Create a database engine using the URL from the config
engine = create_engine(DATABASE_URL, echo=True)

# SessionLocal is a factory for creating new session instances
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

# Base class for defining models
Base = declarative_base()

# Dependency to get the database session
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


================================================
File: backend/src/controllers/dependencies.py
================================================
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker, Session
from typing import Generator  # Importing Generator
from ..config.database import DATABASE_URL

# Create a new SQLAlchemy engine instance
engine = create_engine(DATABASE_URL)
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

def get_db() -> Generator[Session, None, None]:
    """Provide a database session."""
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

================================================
File: backend/src/controllers/tradeController.py
================================================
from fastapi import APIRouter, HTTPException, Depends  # Ensure correct import
from sqlalchemy.orm import Session  # Import Session for type hinting
from pydantic import BaseModel
from ..services import trade_service
from .dependencies import get_db

router = APIRouter()


class TradeRequest(BaseModel):
    user_id: int
    from_currency: str
    to_currency: str
    amount: float
    trade_type: str  # 'spot', 'margin', 'futures', etc.


class TradeResponse(BaseModel):
    trade_id: int
    status: str
    from_currency: str
    to_currency: str
    amount: float
    price: float
    timestamp: str


@router.post("/trade", response_model=TradeResponse)
async def create_trade(request: TradeRequest, db: Session = Depends(get_db)):
    trade_data = {
        "user_id": request.user_id,
        "from_currency": request.from_currency,
        "to_currency": request.to_currency,
        "amount": request.amount,
        "trade_type": request.trade_type,
    }

    trade = await trade_service.create_trade(db, trade_data)

    if not trade:
        raise HTTPException(status_code=400, detail="Trade could not be completed")

    return TradeResponse(
        trade_id=trade.id,
        status=trade.status,
        from_currency=trade.from_currency,
        to_currency=trade.to_currency,
        amount=trade.amount,
        price=trade.price,
        timestamp=trade.timestamp,
    )


@router.get("/trade/{trade_id}", response_model=TradeResponse)
async def get_trade(trade_id: int, db: Session = Depends(get_db)):
    trade = await trade_service.get_trade_by_id(db, trade_id)

    if not trade:
        raise HTTPException(status_code=404, detail="Trade not found")

    return TradeResponse(
        trade_id=trade.id,
        status=trade.status,
        from_currency=trade.from_currency,
        to_currency=trade.to_currency,
        amount=trade.amount,
        price=trade.price,
        timestamp=trade.timestamp,
    )


================================================
File: backend/src/controllers/transactionController.py
================================================
# transactionController.py
from fastapi import APIRouter, HTTPException, Depends, status
from pydantic import BaseModel
from typing import List, Literal
from sqlalchemy.orm import Session
from ..models import Transaction
from ..services import transaction_service  # Corrected to reference the services module
from .dependencies import get_db

router = APIRouter()

class TransactionRequest(BaseModel):
    user_id: int
    amount: float
    currency: str
    transaction_type: str  # 'deposit', 'withdrawal', 'internal_transfer'

class TransactionResponse(BaseModel):
    transaction_id: int
    user_id: int
    amount: float
    currency: str
    transaction_type: str
    status: str
    timestamp: str

@router.post("/transaction", response_model=TransactionResponse)
async def create_transaction(request: TransactionRequest, db: Session = Depends(get_db)) -> TransactionResponse:
    transaction_data = {
        "user_id": request.user_id,
        "amount": request.amount,
        "currency": request.currency,
        "transaction_type": request.transaction_type,
    }

    transaction = await transaction_service.create_transaction(db, transaction_data)

    if not transaction:
        raise HTTPException(status_code=400, detail="Transaction could not be processed")

    return TransactionResponse(
        transaction_id=transaction.id,
        user_id=transaction.user_id,
        amount=transaction.amount,
        currency=transaction.currency,
        transaction_type=transaction.transaction_type,
        status=transaction.status,
        timestamp=transaction.timestamp,
    )

@router.get("/transaction/{transaction_id}", response_model=TransactionResponse)
async def get_transaction(transaction_id: int, db: Session = Depends(get_db)) -> TransactionResponse:
    transaction = await transaction_service.get_transaction_by_id(db, transaction_id)

    if not transaction:
        raise HTTPException(status_code=404, detail="Transaction not found")

    return TransactionResponse(
        transaction_id=transaction.id,
        user_id=transaction.user_id,
        amount=transaction.amount,
        currency=transaction.currency,
        transaction_type=transaction.transaction_type,
        status=transaction.status,
        timestamp=transaction.timestamp,
    )


================================================
File: backend/src/controllers/userController.py
================================================
from fastapi import APIRouter, HTTPException, Depends
from sqlalchemy.orm import Session
from pydantic import BaseModel
from typing import List
from ..database import get_db
from ..models.User import User
from ..services import user_service

router = APIRouter()

@router.post("/users/")
def create_user(email: str, password: str, db: Session = Depends(get_db)):
    db_user = User(email=email, hashed_password=password)
    db.add(db_user)
    db.commit()
    db.refresh(db_user)
    return db_user

class UserRegistrationRequest(BaseModel):
    username: str
    email: str
    password: str
    phone: str

class UserProfileResponse(BaseModel):
    user_id: int
    username: str
    email: str
    phone: str
    kyc_verified: bool

@router.post("/register", response_model=UserProfileResponse)
async def register_user(request: UserRegistrationRequest, db: Session = Depends(get_db)):
    user_data = {
        "username": request.username,
        "email": request.email,
        "password": request.password,
        "phone": request.phone,
    }

    user = await user_service.register_user(db, user_data)

    if not user:
        raise HTTPException(status_code=400, detail="User registration failed")

    return UserProfileResponse(
        user_id=user.id,
        username=user.username,
        email=user.email,
        phone=user.phone,
        kyc_verified=user.kyc_verified,
    )

@router.post("/kyc-verify/{user_id}")
async def verify_kyc(user_id: int, db: Session = Depends(get_db)):
    user = await user_service.verify_kyc(db, user_id)

    if not user:
        raise HTTPException(status_code=400, detail="User KYC verification failed")

    return {"message": "KYC verification successful"}

@router.get("/user/{user_id}", response_model=UserProfileResponse)
async def get_user_profile(user_id: int, db: Session = Depends(get_db)):
    user = await user_service.get_user_by_id(db, user_id)

    if not user:
        raise HTTPException(status_code=404, detail="User not found")

    return UserProfileResponse(
        user_id=user.id,
        username=user.username,
        email=user.email,
        phone=user.phone,
        kyc_verified=user.kyc_verified,
    )

================================================
File: backend/src/database/__init__.py
================================================
# backend/src/database/__init__.py
from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
import os

# Database URL, defaulting to an environment variable or a local database
DATABASE_URL = os.getenv("DATABASE_URL", "postgresql://user:password@localhost/dbname")

# Set up the SQLAlchemy engine
engine = create_engine(DATABASE_URL, connect_args={"check_same_thread": False})

# SessionLocal for dependency injection
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

# Base class for models
Base = declarative_base()

# Dependency to get the session (used in FastAPI routes)
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


================================================
File: backend/src/database/config.py
================================================
# backend/src/database/config.py
import os

# You can use environment variables to securely store your database URL
DATABASE_URL = os.getenv("DATABASE_URL", "postgresql://user:password@localhost/dbname")


================================================
File: backend/src/database/migrations/env.py
================================================
# backend/src/database/migrations/env.py
from logging.config import fileConfig
from sqlalchemy import engine_from_config, pool
from sqlalchemy.ext.declarative import declarative_base
from alembic import context
from database import Base  # Import the Base class from the database module

# This is the Alembic configuration object
config = context.config

# Setup for Alembic migration scripts
target_metadata = Base.metadata

# Database connection configuration
def run_migrations_online():
    # Get the URL from the config file (or use an env variable)
    config.set_main_option("sqlalchemy.url", "postgresql://user:password@localhost/dbname")

    # Create engine and connection
    engine = engine_from_config(
        config.get_section(config.config_ini_section),
        prefix="sqlalchemy.",
        poolclass=pool.NullPool,
    )

    # Run migrations using the engine
    with engine.connect() as connection:
        context.configure(connection=connection, target_metadata=target_metadata)
        with context.begin_transaction():
            context.run_migrations()

run_migrations_online()


================================================
File: backend/src/database/models/Transaction.py
================================================
# backend/src/database/models/Transaction.py
from sqlalchemy import Column, Integer, Float, DateTime, ForeignKey, String
from sqlalchemy.orm import relationship
from database import Base

class Transaction(Base):
    __tablename__ = 'transactions'

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey('users.id'))
    amount = Column(Float)
    transaction_type = Column(String)  # e.g., 'deposit', 'withdrawal'
    timestamp = Column(DateTime)

    user = relationship("User", back_populates="transactions")


================================================
File: backend/src/database/models/User.py
================================================
# backend/src/database/models/User.py
from sqlalchemy import Column, Integer, String
from sqlalchemy.orm import relationship
from backend.src.database import Base

class User(Base):
    __tablename__ = 'users'

    id = Column(Integer, primary_key=True, index=True)
    email = Column(String, unique=True, index=True)
    hashed_password = Column(String)

    # Add other fields as necessary (e.g., name, date_created, etc.)


================================================
File: backend/src/database/queries/transaction_queries.py
================================================
# backend/src/database/queries/transaction_queries.py
from sqlalchemy import text
from database import engine

def get_transactions_by_user(user_id):
    sql_query = text("SELECT * FROM transactions WHERE user_id = :user_id")
    with engine.connect() as connection:
        result = connection.execute(sql_query, {"user_id": user_id})
        return result.fetchall()


================================================
File: backend/src/models/Trade.py
================================================
from sqlalchemy import Column, Integer, Float, String, ForeignKey
from sqlalchemy.orm import relationship
from backend.src.database import Base

class Trade(Base):
    __tablename__ = "trades"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    from_currency = Column(String)
    to_currency = Column(String)
    amount = Column(Float)
    price = Column(Float)
    timestamp = Column(String)  # Consider using a datetime type

    # Relationships
    user = relationship("User", back_populates="trades")

    def __repr__(self):
        return f"<Trade(id={self.id}, user_id={self.user_id}, amount={self.amount})>"


================================================
File: backend/src/models/TradeHistory.py
================================================
# TradeHistory.py
from sqlalchemy import Column, Integer, Float, String, ForeignKey
from sqlalchemy.orm import relationship
from ..database import Base

class TradeHistory(Base):
    __tablename__ = "trade_history"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    from_currency = Column(String)
    to_currency = Column(String)
    amount = Column(Float)
    price = Column(Float)
    timestamp = Column(String)  # Consider using a datetime type
    trade_type = Column(String)  # e.g., spot, margin, futures

    # Relationships
    user = relationship("User", back_populates="trades")

    def __repr__(self):
        return f"<TradeHistory(id={self.id}, user_id={self.user_id}, from_currency={self.from_currency}, to_currency={self.to_currency}, amount={self.amount}, price={self.price})>"


================================================
File: backend/src/models/Transaction.py
================================================
# Transaction.py
from sqlalchemy import Column, Integer, Float, String, ForeignKey, Enum, DateTime
from sqlalchemy.orm import relationship, validates  # Added validates import
from ..database import Base  # Corrected to reference the database module
from enum import Enum as PyEnum

class TransactionType(PyEnum):
    DEPOSIT = "deposit"
    WITHDRAWAL = "withdrawal"
    INTERNAL_TRANSFER = "internal_transfer"

class Transaction(Base):
    __tablename__ = "transactions"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    amount = Column(Float)
    currency = Column(String)
    transaction_type = Column(Enum(TransactionType))
    status = Column(String, default="pending")
    from datetime import datetime
    from datetime import datetime

    timestamp = Column(DateTime, default=datetime.utcnow)  # Set default to current time

    # Relationships
    user = relationship("User", back_populates="transactions")

    @validates('amount')
    def validate_amount(self, key, amount):
        if amount <= 0:
            raise ValueError("Amount must be positive")
        return amount

    @validates('currency')
    def validate_currency(self, key, currency):
        valid_currencies = ["USD", "EUR", "GBP"]  # Add more valid currencies as needed
        if currency not in valid_currencies:
            raise ValueError(f"Currency must be one of {valid_currencies}")
        return currency

    def __repr__(self):
        return f"<Transaction(id={self.id}, user_id={self.user_id}, amount={self.amount}, status={self.status})>"


================================================
File: backend/src/models/User.py
================================================
# User.py
from sqlalchemy import Column, Integer, String, Boolean
from sqlalchemy.orm import relationship
from ..database import Base

class User(Base):
    # Add the following methods to the User class

    def check_password(self, password: str) -> bool:
        """Check if the provided password matches the stored password."""
        return self.password == password  # This should ideally use a hashed comparison

    def update_kyc_status(self, status: str):
        """Update the KYC status of the user."""
        self.kyc_verified = (status.lower() == "verified")
    __tablename__ = "users"

    id = Column(Integer, primary_key=True, index=True)
    username = Column(String, unique=True, index=True)
    email = Column(String, unique=True, index=True)
    password = Column(String)
    phone = Column(String, unique=True)
    kyc_verified = Column(Boolean, default=False)

    # Relationships
    transactions = relationship("Transaction", back_populates="user")
    trades = relationship("TradeHistory", back_populates="user")
    wallet = relationship("Wallet", back_populates="user", uselist=False)
    
    def __repr__(self):
        return f"<User(id={self.id}, username={self.username}, email={self.email})>"


================================================
File: backend/src/models/Wallet.py
================================================
# Wallet.py
from sqlalchemy import Column, Integer, Float, String, ForeignKey
from sqlalchemy.orm import relationship
from ..database import Base

class Wallet(Base):
    __tablename__ = "wallets"

    id = Column(Integer, primary_key=True, index=True)
    user_id = Column(Integer, ForeignKey("users.id"))
    balance = Column(Float, default=0.0)
    currency = Column(String)

    # Relationships
    user = relationship("User", back_populates="wallet")

    def __repr__(self):
        return f"<Wallet(id={self.id}, user_id={self.user_id}, balance={self.balance}, currency={self.currency})>"


================================================
File: backend/src/models/__init__.py
================================================
# This file makes the models directory a package


================================================
File: backend/src/routers/conversion_routes.py
================================================
const express = require("express");
const { cryptoToFiat, fiatToCrypto } = require("../protocols/conversion");

const router = express.Router();

router.post("/crypto-to-fiat", cryptoToFiat);
router.post("/fiat-to-crypto", fiatToCrypto);

module.exports = router;


================================================
File: backend/src/routers/user_router.py
================================================
from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session
from typing import List
from ..controllers.userController import create_user, register_user, get_user_profile, verify_kyc, UserProfileResponse
from ..database import get_db

router = APIRouter()

# Define user-related routes here
@router.get("/", response_model=List[UserProfileResponse])  # Assuming UserProfileResponse is the correct model
async def get_users(db: Session = Depends(get_db)):
    return await get_user_profile(db)

# Add more user routes as needed


================================================
File: backend/src/services/CryptoService.py
================================================
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


================================================
File: backend/src/services/KYCService.py
================================================
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


================================================
File: backend/src/services/UPIService.py
================================================
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


================================================
File: backend/src/services/trade_service.py
================================================
from ..models.Trade import Trade  # Corrected to use a relative import

async def create_trade(db, trade_data):
    trade = Trade(**trade_data)
    db.add(trade)
    await db.commit()
    await db.refresh(trade)
    return trade

async def get_trade_by_id(db, trade_id):
    return await db.query(Trade).filter(Trade.id == trade_id).first()


================================================
File: backend/src/services/user_service.py
================================================
from fastapi import HTTPException
from sqlalchemy.orm import Session
from ..models.User import User
from ..utils import hash_password, verify_password  # Assuming these utility functions exist

class UserService:
    def create_user(self, db: Session, email: str, password: str) -> User:
        # Check if the user already exists
        existing_user = db.query(User).filter(User.email == email).first()
        if existing_user:
            raise HTTPException(status_code=400, detail="Email already registered")

        # Create a new user
        hashed_password = hash_password(password)
        new_user = User(email=email, password=hashed_password)
        db.add(new_user)
        db.commit()
        db.refresh(new_user)
        return new_user

    def get_kyc_status(self, db: Session, user_id: int) -> str:
        # Retrieve the KYC status of the user
        user = db.query(User).filter(User.id == user_id).first()
        if not user:
            raise HTTPException(status_code=404, detail="User not found")
        return "PENDING" if not user.kyc_verified else "VERIFIED"

    def login_user(self, db: Session, email: str, password: str) -> User:
        # Authenticate the user
        user = db.query(User).filter(User.email == email).first()
        if not user or not verify_password(password, user.password):
            raise HTTPException(status_code=401, detail="Invalid credentials")
        return user


================================================
File: backend/src/tests/test_trade.py
================================================
# test_trade.py
import pytest
from fastapi.testclient import TestClient
from backend.src.main import app
from backend.src.models.TradeHistory import TradeHistory  # Change to absolute import
from backend.src.models.User import User  # Change to absolute import
from backend.src.database import SessionLocal, engine  # Change to absolute import

client = TestClient(app)

@pytest.fixture(scope="function")
def test_db():
    db = SessionLocal()
    yield db
    db.close()

def test_spot_trade(test_db):
    # Test spot trading
    user = User(email="testtrader@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    # Simulate a spot trade
    response = client.post("/trades/spot", json={"user_id": user.id, "from_currency": "USD", "to_currency": "BTC", "amount": 100})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"
    assert data["from_currency"] == "USD"
    assert data["to_currency"] == "BTC"
    assert data["amount"] == 100

def test_margin_trade(test_db):
    # Test margin trading
    user = User(email="testmargintrader@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    # Simulate margin trade
    response = client.post("/trades/margin", json={"user_id": user.id, "currency": "ETH", "amount": 10, "leverage": 2})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"
    assert data["currency"] == "ETH"
    assert data["amount"] == 10

def test_trade_history(test_db):
    # Test fetching trade history
    user = User(email="tradehistory@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    response = client.get(f"/users/{user.id}/trade-history")
    assert response.status_code == 200
    data = response.json()
    assert isinstance(data, list)


================================================
File: backend/src/tests/test_transaction.py
================================================
import pytest
from fastapi.testclient import TestClient
from backend.src.main import app  # Change to absolute import
from backend.src.models.Transaction import Transaction  # Change to absolute import
from backend.src.database import SessionLocal, engine  # Change to absolute import

client = TestClient(app)

@pytest.fixture(scope="function")
def test_db():
    db = SessionLocal()
    yield db
    db.close()

def test_create_transaction(test_db):
    # Test transaction creation
    response = client.post("/transactions/", json={"user_id": 1, "amount": 100, "currency": "USD", "type": "deposit"})
    assert response.status_code == 201
    data = response.json()
    assert data["amount"] == 100
    assert data["currency"] == "USD"
    assert data["type"] == "deposit"

def test_transaction_status(test_db):
    # Test transaction status update
    response = client.post("/transactions/", json={"user_id": 1, "amount": 100, "currency": "USD", "type": "deposit"})
    transaction_id = response.json()["id"]
    
    # Update transaction status
    response = client.put(f"/transactions/{transaction_id}/status", json={"status": "completed"})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"

def test_internal_transfer(test_db):
    # Test internal transfer between users
    response = client.post("/users/", json={"email": "user1@example.com", "password": "password"})
    user1_id = response.json()["id"]
    
    response = client.post("/users/", json={"email": "user2@example.com", "password": "password"})
    user2_id = response.json()["id"]
    
    response = client.post("/transactions/", json={"user_id": user1_id, "amount": 100, "currency": "USD", "type": "deposit"})
    transaction_id = response.json()["id"]
    
    # Perform internal transfer
    response = client.post("/transactions/transfer", json={"from_user_id": user1_id, "to_user_id": user2_id, "amount": 50})
    assert response.status_code == 200
    data = response.json()
    assert data["status"] == "completed"
    assert data["amount"] == 50


================================================
File: backend/src/tests/test_user.py
================================================
import pytest
from fastapi.testclient import TestClient
from backend.src.main import app  # Change to absolute import
from backend.src.models.User import User  # Change to absolute import
from backend.src.services.KYCService import KYCService  # Change to absolute import
from backend.src.database import SessionLocal, engine  # Change to absolute import

# Initialize TestClient for making requests to FastAPI
client = TestClient(app)

@pytest.fixture(scope="function")
def test_db():
    # Set up the database for testing
    db = SessionLocal()
    yield db
    db.close()

def test_create_user(test_db):
    # Test user creation
    response = client.post("/users/", json={"email": "testuser@example.com", "password": "securepassword"})
    assert response.status_code == 201
    data = response.json()
    assert data["email"] == "testuser@example.com"
    assert "id" in data

def test_user_kyc_status(test_db):
    # Test KYC status retrieval
    user = User(email="testuser@example.com", password="securepassword")
    test_db.add(user)
    test_db.commit()
    test_db.refresh(user)
    
    # Assume KYC is pending for new users
    kyc_status = KYCService.get_kyc_status(user.id)
    assert kyc_status == "PENDING"

def test_user_login(test_db):
    # Test user login
    client.post("/users/", json={"email": "testuser@example.com", "password": "securepassword"})
    response = client.post("/login", data={"username": "testuser@example.com", "password": "securepassword"})
    assert response.status_code == 200
    assert "access_token" in response.json()


================================================
File: deployment/aws/ec2-setup.sh
================================================
#!/bin/bash

# Update system
sudo apt-get update -y
sudo apt-get upgrade -y

# Install dependencies
sudo apt-get install -y git curl unzip

# Install Node.js (required for the frontend)
curl -sL https://deb.nodesource.com/setup_18.x | sudo -E bash -
sudo apt-get install -y nodejs

# Install Docker (for containerization)
sudo apt-get install -y docker.io
sudo systemctl enable --now docker

# Install Docker Compose (for managing multi-container Docker applications)
sudo curl -L "https://github.com/docker/compose/releases/download/1.29.2/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
sudo chmod +x /usr/local/bin/docker-compose

# Install Python (for the backend)
sudo apt-get install -y python3-pip python3-dev
sudo apt-get install -y python3-venv

# Install AWS CLI (to interact with AWS services)
sudo apt-get install -y awscli

# Install Nginx (for reverse proxy)
sudo apt-get install -y nginx
sudo systemctl enable nginx
sudo systemctl start nginx

# Set up project directory
cd /home/ubuntu
git clone https://github.com/yourusername/maya-exchange.git
cd maya-exchange

# Set up the backend
cd backend
python3 -m venv venv
source venv/bin/activate
pip install -r requirements.txt

# Run backend server (e.g., using Gunicorn)
gunicorn --workers 3 src.main:app --bind 0.0.0.0:8000 &

# Set up the frontend
cd ../frontend
npm install
npm run build

# Set up Nginx to serve the frontend build
sudo cp -r dist/* /var/www/html/

# Restart Nginx to apply changes
sudo systemctl restart nginx

# Set up automatic updates
sudo apt-get install -y unattended-upgrades
sudo dpkg-reconfigure --priority=low unattended-upgrades

echo "EC2 setup completed successfully!"


================================================
File: deployment/aws/s3-setup.sh
================================================
#!/bin/bash

# Ensure AWS CLI is installed
if ! command -v aws &> /dev/null
then
    echo "AWS CLI not found. Installing..."
    sudo apt-get install -y awscli
fi

# Set AWS CLI configuration (replace with your credentials)
aws configure set aws_access_key_id YOUR_AWS_ACCESS_KEY
aws configure set aws_secret_access_key YOUR_AWS_SECRET_KEY
aws configure set default.region us-east-1

# Create an S3 bucket
echo "Creating S3 bucket..."
BUCKET_NAME="maya-exchange-assets-$(date +%s)"
aws s3 mb s3://$BUCKET_NAME

# Set up bucket policy to allow public read access (for static assets like images)
echo "Setting up bucket policy..."
cat <<EOF > bucket-policy.json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Sid": "PublicReadGetObject",
      "Effect": "Allow",
      "Principal": "*",
      "Action": "s3:GetObject",
      "Resource": "arn:aws:s3:::$BUCKET_NAME/*"
    }
  ]
}
EOF

aws s3api put-bucket-policy --bucket $BUCKET_NAME --policy file://bucket-policy.json

# Upload files to S3 bucket (replace with your actual file paths)
echo "Uploading assets to S3..."
aws s3 cp /path/to/your/static/assets s3://$BUCKET_NAME/ --recursive

echo "S3 setup completed successfully! Your bucket is: s3://$BUCKET_NAME"


================================================
File: deployment/ci-cd/build.sh
================================================
#!/bin/bash

# Frontend Build Process
echo "Starting frontend build..."
cd frontend
npm install
npm run build
echo "Frontend build completed."

# Backend Build Process (including creating a virtual environment and installing dependencies)
echo "Starting backend build..."
cd ../backend
python3 -m venv venv
source venv/bin/activate
pip install -r requirements.txt
echo "Backend build completed."

# Run tests for both frontend and backend
echo "Running frontend tests..."
cd ../frontend
npm run test

echo "Running backend tests..."
cd ../backend
source venv/bin/activate
pytest tests

echo "Build and test process completed successfully."


================================================
File: deployment/ci-cd/pipeline.yml
================================================
stages:
  - name: build
  - name: test
  - name: deploy

# Define build job
build:
  stage: build
  image: node:18 # Use the appropriate Node.js version for your frontend
  script:
    - echo "Building the frontend"
    - cd frontend
    - npm install
    - npm run build
    - echo "Building the backend"
    - cd ../backend
    - python3 -m venv venv
    - source venv/bin/activate
    - pip install -r requirements.txt
  artifacts:
    paths:
      - frontend/dist
      - backend/venv
    expire_in: 1 hour

# Define test job
test:
  stage: test
  image: python:3.9
  script:
    - echo "Running backend tests"
    - cd backend
    - source venv/bin/activate
    - pytest tests
    - echo "Running frontend tests"
    - cd ../frontend
    - npm run test

# Define deploy job
deploy:
  stage: deploy
  image: node:18
  script:
    - echo "Deploying to AWS EC2 and S3"
    - ./scripts/deploy.sh
  only:
    - master  # Trigger deploy only on the master branch


================================================
File: documentation/api/api-endpoints.md
================================================
# Maya Exchange API Endpoints

## Overview
This document lists the API endpoints available for Maya Exchange, grouped by functionality.

---

## **User Management**

### **Register a New User**
- **Endpoint**: `/api/v1/users/register`
- **Method**: `POST`
- **Description**: Registers a new user with KYC information.
- **Request Body**:
  ```json
  {
    "name": "John Doe",
    "email": "john.doe@example.com",
    "password": "securepassword",
    "mobile": "9876543210"
  }


================================================
File: documentation/api/authentication.md
================================================
# Maya Exchange API Authentication

## Overview
Maya Exchange uses **JSON Web Tokens (JWT)** for securing API endpoints. Each user must authenticate with the platform to receive a token that grants access to protected resources.

---

## **How Authentication Works**

1. **User Login**:
   - The user submits their email and password to the `/api/v1/users/login` endpoint.
   - Upon successful authentication, the server responds with a JWT token and its expiration time.

2. **Token Usage**:
   - The client includes the JWT in the `Authorization` header for all subsequent API requests.
   - Example:
     ```
     Authorization: Bearer <JWT_TOKEN>
     ```

3. **Token Validation**:
   - The backend verifies the token’s signature and expiration before granting access to the requested resource.

---

## **Login Flow**

1. **Request**:
   - **Endpoint**: `/api/v1/users/login`
   - **Method**: `POST`
   - **Body**:
     ```json
     {
       "email": "john.doe@example.com",
       "password": "securepassword"
     }
     ```

2. **Response**:
   ```json
   {
     "token": "jwt_token",
     "expires_in": 3600
   }


================================================
File: documentation/developer/contributing.md
================================================
# Contributing to Maya Exchange

Thank you for considering contributing to Maya Exchange! This document outlines the guidelines for contributing to the project.

---

## How to Contribute

1. **Fork the Repository**:
   - Navigate to the repository and click on the `Fork` button.

2. **Clone the Fork**:
   ```bash
   git clone https://github.com/your-username/maya-exchange.git
   cd maya-exchange


================================================
File: documentation/developer/setup-guide.md
================================================
# Maya Exchange Setup Guide

## Overview
This guide provides step-by-step instructions to set up the Maya Exchange project for local development. Ensure you have the required tools installed and follow the steps for both frontend and backend components.

---

## Prerequisites

1. **Node.js**:
   - Version: `20.x` (use [NVM](https://github.com/nvm-sh/nvm) if managing multiple versions).
   - Check: `node -v`

2. **Python**:
   - Version: `3.10+`
   - Check: `python3 --version`

3. **Database**:
   - PostgreSQL (Version: 14+)
   - Ensure the database is running and accessible.

4. **Docker** (Optional but recommended):
   - Version: `20.x`
   - Check: `docker --version`

5. **Additional Tools**:
   - `npm`, `pip`, and `virtualenv` for dependency management.
   - Kubernetes CLI (`kubectl`) for infrastructure deployment testing.

---

## Project Structure



================================================
File: documentation/frontend/app-architecture.md
================================================
# Maya Exchange App Architecture

This document provides an overview of the architecture for the frontend of Maya Exchange.

---

## Key Design Principles

1. **Modularization**:
   - Separation of concerns between components, pages, and utilities.
   - Reusable and testable code.

2. **State Management**:
   - Centralized state using Redux Toolkit.
   - Local component state for UI-specific behavior.

3. **API Integration**:
   - Asynchronous calls managed with Redux Thunks.
   - Error handling and loading states for improved UX.

4. **Responsive Design**:
   - Mobile-first approach using media queries.
   - Cross-platform support for web and mobile via React Native.

---

## Directory Structure



================================================
File: documentation/frontend/ui-components.md
================================================
# Maya Exchange UI Components

This document describes the key reusable UI components in the Maya Exchange frontend and their intended functionality.

---

## Component Overview

1. **Header**
   - Location: `src/components/Header.tsx`
   - Purpose: Displays the navigation bar, logo, and user-related actions like login/logout.

2. **Footer**
   - Location: `src/components/Footer.tsx`
   - Purpose: Provides links to important pages, social media, and company details.

3. **Button**
   - Location: `src/components/Button.tsx`
   - Purpose: A customizable button component used across the application.

4. **Input**
   - Location: `src/components/Input.tsx`
   - Purpose: A reusable input field for forms.

5. **Modal**
   - Location: `src/components/Modal.tsx`
   - Purpose: Displays overlay dialogs for actions like KYC verification and transaction confirmations.

6. **Card**
   - Location: `src/components/Card.tsx`
   - Purpose: Represents data visually (e.g., cryptocurrency prices, transaction summaries).

7. **Loader**
   - Location: `src/components/Loader.tsx`
   - Purpose: A loading spinner for asynchronous operations.

8. **Table**
   - Location: `src/components/Table.tsx`
   - Purpose: Displays tabular data (e.g., trade history, wallet balances).

---

## Component Guidelines

- **Styling**:
  - Follow a consistent theme defined in `src/styles/theme.ts`.
  - Use modular SCSS or styled-components for encapsulation.

- **State Management**:
  - Use `useState` or connect to the Redux store for state-driven behavior.

- **Testing**:
  - Ensure each component has unit tests in `src/__tests__/components/`.

---


================================================
File: documentation/frontend/user-guide.md
================================================
# Maya Exchange User Guide

This guide walks you through the features of the Maya Exchange platform and how to use them.

---

## Getting Started

1. **Sign Up**:
   - Navigate to [Maya Exchange](https://maya-exchange.example.com).
   - Click on **Sign Up** and complete the registration form.
   - Complete the KYC process for full access.

2. **Log In**:
   - Use your registered email and password to log in.

3. **Dashboard**:
   - After logging in, access your account summary, wallet balance, and recent transactions.

---

## Features

### Wallet
- **View Balances**: Check your fiat and crypto holdings.
- **Deposit**: Add funds via UPI or other supported payment methods.
- **Withdraw**: Transfer funds to your bank account.

### Trading
- **Spot Trading**:
  - Buy and sell cryptocurrencies at real-time prices.
  - Access live market charts and order books.

- **Margin Trading**:
  - Trade with leverage to maximize potential returns.
  - Ensure you understand the risks before trading.

- **Staking**:
  - Lock your cryptocurrencies and earn rewards over time.

### P2P Transactions
- Buy and sell crypto directly with other users.
- Use the built-in chat feature for seamless communication.

---

## Security

1. **Two-Factor Authentication (2FA)**:
   - Enable 2FA in the settings for an added layer of security.

2. **Transaction Alerts**:
   - Receive email and SMS notifications for all account activities.

3. **Password Reset**:
   - Reset your password securely using the "Forgot Password" feature.

---

## Help & Support

- **FAQs**:
  - Visit the [FAQ Page](https://maya-exchange.example.com/faq) for common questions.
  
- **Support Team**:
  - Email: support@maya-exchange.co.in
  - Phone: +91xxxxxxxxxx

---


================================================
File: frontend/declarations.d.ts
================================================
declare module '*.png' {
  const src: string;
  export default src;
}

declare module '*.jpg' {
  const src: string;
  export default src;
}

// Add more formats as needed

================================================
File: frontend/package.json
================================================
{
    "name": "maya-exchange",
    "version": "1.0.0",
    "description": "A cryptocurrency exchange platform with UPI payments integration",
    "main": "src/index.tsx",
    "scripts": {
      "start": "react-scripts start",
      "build": "react-scripts build",
      "test": "react-scripts test",
      "eject": "react-scripts eject",
      "lint": "eslint 'src/**/*.{ts,tsx}' --fix"
    },
    "dependencies": {
      "axios": "^1.4.0",
      "react": "^18.2.0",
      "react-dom": "^18.2.0",
      "react-redux": "^8.0.5",
      "react-router-dom": "^6.6.1",
      "redux": "^4.2.2",
      "redux-thunk": "^2.4.2",
      "react-scripts": "^5.0.1",
      "redux-devtools-extension": "^2.13.9",
      "typescript": "^4.6.4",
      "eslint": "^8.16.0",
      "eslint-plugin-react": "^7.31.0",
      "react-icons": "^4.6.0",
      "react-query": "^3.39.2",
      "moment": "^2.29.1",
      "react-hook-form": "^7.31.0"
    },
    "devDependencies": {
      "@types/react": "^18.0.26",
      "@types/react-dom": "^18.0.9",
      "@types/redux-thunk": "^2.1.0",
      "@typescript-eslint/eslint-plugin": "^5.2.0",
      "@typescript-eslint/parser": "^5.2.0",
      "eslint-config-airbnb-typescript": "^16.0.0",
      "eslint-plugin-import": "^2.25.3",
      "eslint-plugin-jsx-a11y": "^6.6.1",
      "eslint-plugin-react-hooks": "^4.6.0",
      "prettier": "^2.8.0"
    },
    "eslintConfig": {
      "extends": [
        "react-app",
        "react-app/jest",
        "airbnb-typescript",
        "plugin:react/recommended",
        "plugin:react-hooks/recommended",
        "plugin:jsx-a11y/recommended",
        "plugin:import/errors",
        "plugin:import/warnings"
      ],
      "parserOptions": {
        "project": "./tsconfig.json"
      }
    },
    "browserslist": {
      "production": [
        ">0.2%",
        "not dead",
        "not op_mini all"
      ],
      "development": [
        "last 1 chrome version",
        "last 1 firefox version",
        "last 1 safari version"
      ]
    }
  }
  

================================================
File: frontend/assets/styles.css
================================================
.crypto-list {
    display: flex;
    flex-direction: column;
    gap: 20px;
  }
  
  .crypto-card {
    display: flex;
    align-items: center;
    gap: 10px;
  }
  
  .crypto-icon {
    width: 30px;
    height: 30px;
  }

  /* Define the font-face for Roboto-Regular */
@font-face {
    font-family: 'Roboto';
    src: url('./assets/fonts/Roboto-Regular.ttf') format('truetype');
    font-weight: normal;
    font-style: normal;
  }
  
  /* Define the font-face for Montserrat-Bold */
  @font-face {
    font-family: 'Montserrat';
    src: url('./assets/fonts/Montserrat-Bold.ttf') format('truetype');
    font-weight: bold;
    font-style: normal;
  }
  
  /* Apply the fonts globally */
  body {
    font-family: 'Roboto', sans-serif;
  }
  
  /* Example of using Montserrat-Bold for headings */
  h1, h2, h3 {
    font-family: 'Montserrat', sans-serif;
  }
  

================================================
File: frontend/public/index.html
================================================
<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Maya Exchange</title>
  <link rel="icon" href="/favicon.ico" type="image/x-icon">
  <!-- Meta Tags for SEO -->
  <meta name="description" content="Maya Exchange - The platform for seamless crypto trading and payments">
  <meta name="keywords" content="crypto, exchange, bitcoin, ethereum, UPI, trading">
  <meta name="author" content="Maya Exchange">

  <!-- Open Graph for Social Media Preview -->
  <meta property="og:title" content="Maya Exchange" />
  <meta property="og:description" content="Maya Exchange - The platform for seamless crypto trading and payments" />
  <meta property="og:image" content="https://example.com/og-image.jpg" />
  <meta property="og:url" content="https://maya-exchange.com" />

  <!-- Apple Touch Icon for iOS Devices -->
  <link rel="apple-touch-icon" href="/apple-touch-icon.png">

  <!-- CSS File Link -->
  <link rel="stylesheet" href="/styles.css">
</head>

<body>
  <div id="root"></div>

  <!-- Scripts -->
  <script src="/bundle.js"></script> <!-- Bundled JS file -->
</body>

</html>


================================================
File: frontend/public/manifest.json
================================================
{
    "short_name": "Maya Exchange",
    "name": "Maya Exchange - Cryptocurrency Trading Platform",
    "description": "The most reliable exchange for crypto trading and payments",
    "icons": [
      {
        "src": "icons/icon-192x192.png",
        "sizes": "192x192",
        "type": "image/png"
      },
      {
        "src": "icons/icon-512x512.png",
        "sizes": "512x512",
        "type": "image/png"
      }
    ],
    "start_url": "/",
    "background_color": "#ffffff",
    "theme_color": "#4CAF50",
    "display": "standalone"
  }
  

================================================
File: frontend/public/robots.txt
================================================
User-agent: *
Disallow: /admin/
Disallow: /private/
Allow: /public/


================================================
File: frontend/public/styles.css
================================================
/* styles.css */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }
  
  body {
    font-family: Arial, sans-serif;
    background-color: #f4f4f4;
    color: #333;
  }
  
  h1, h2, h3, h4 {
    font-weight: bold;
  }
  
  a {
    text-decoration: none;
    color: inherit;
  }
  
  #root {
    padding: 20px;
  }
  

================================================
File: frontend/src/images.d.ts
================================================
declare module '*.png' {
  const src: string;
  export default src;
}declare module '*.jpg' {
  const src: string;
  export default src;
}

================================================
File: frontend/src/tsconfig.json
================================================
{
  "compilerOptions": {
    "esModuleInterop": true,
    "skipLibCheck": true,
    // other options...
    "jsx": "react"
  },
  "include": ["**/*"]
}

================================================
File: frontend/src/components/CryptoCard.tsx
================================================
import React from 'react';

interface CryptoCardProps {
  name: string;
  symbol: string;
  price: number;
  change: number;
}

const CryptoCard: React.FC<CryptoCardProps> = ({ name, symbol, price, change }) => {
  const formattedPrice = price.toLocaleString(); // Format price with commas

  return (
    <div className="crypto-card">
      <h3>{name} ({symbol})</h3>
      <p>Price: ${formattedPrice}</p>
      <p>24h Change: {change > 0 ? `+${change}%` : `${change}%`}</p>
    </div>
  );
};

export default CryptoCard;


================================================
File: frontend/src/components/CryptoList.tsx
================================================
import React, { FC } from 'react';
import CryptoCard from './CryptoCard';
import btcIcon from '../assets/images/crypto-icons/btc.png';
import ethIcon from '../assets/images/crypto-icons/eth.png';

const CryptoList: FC = () => {
  const cryptoData = [
    { name: 'Bitcoin', symbol: 'BTC', price: 55000, change: 2.5, icon: btcIcon },
    { name: 'Ethereum', symbol: 'ETH', price: 4000, change: -1.2, icon: ethIcon },
    // Add more cryptocurrencies as needed
  ];

  return (
    <div className="crypto-list">
      <h2>Popular Cryptocurrencies</h2>
      {cryptoData.map((crypto) => (
        <div key={crypto.symbol} className="crypto-card">
          <img src={crypto.icon} alt={crypto.name} className="crypto-icon" />
          <CryptoCard
            name={crypto.name}
            symbol={crypto.symbol}
            price={crypto.price}
            change={crypto.change}
          />
        </div>
      ))}
    </div>
  );
};

export default CryptoList;

================================================
File: frontend/src/components/Dashboard.tsx
================================================
import React from 'react';
import { Link } from 'react-router-dom';

const Dashboard: React.FunctionComponent = () => {
  return (
    <div className="dashboard">
      <h2>Welcome to Your Dashboard</h2>
      <div className="stats">
        <div className="stat">
          <h3>Current Balance</h3>
          <p>$5000</p>
        </div>
        <div className="stat">
          <h3>Portfolio Value</h3>
          <p>$12000</p>
        </div>
        <div className="stat">
          <h3>Active Trades</h3>
          <p>2</p>
        </div>
      </div>
      <Link to="/trade">Start Trading</Link>
    </div>
  );
};

export default Dashboard;


================================================
File: frontend/src/components/Footer.tsx
================================================
import React from 'react';

const Footer: React.FC = () => {
  return (
    <footer>
      <div className="footer-content">
        <p>© 2024 Maya Exchange. All rights reserved.</p>
        <div className="social-links">
          <a href="https://twitter.com" target="_blank" rel="noopener noreferrer">Twitter</a>
          <a href="https://linkedin.com" target="_blank" rel="noopener noreferrer">LinkedIn</a>
        </div>
      </div>
    </footer>
  );
};

export default Footer;


================================================
File: frontend/src/components/Header.tsx
================================================
import React from 'react';
import { Link } from 'react-router-dom';
import logo from '/home/kali/Desktop/Maya-Exchange/frontend/assets/images/logo.png'; // Import logo from assets folder

const Header: React.FC = () => {
  return (
    <header>
      <div className="logo">
        <img src={logo} alt="Maya Exchange Logo" /> {/* Updated to use imported logo */}
      </div>
      <nav>
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/trade">Trade</Link></li>
          <li><Link to="/wallet">Wallet</Link></li>
          <li><Link to="/profile">Profile</Link></li>
          <li><Link to="/login">Login</Link></li>
        </ul>
      </nav>
    </header>
  );
};

export default Header;


================================================
File: frontend/src/components/UserProfile.tsx
================================================
import React, { useState } from 'react';

const UserProfile: React.FC = () => {
  const [user, setUser] = useState({
    name: 'John Doe',
    email: 'johndoe@example.com',
    kycStatus: 'Verified',
  });

  return (
    <div className="user-profile">
      <h2>User Profile</h2>
      <div className="profile-info">
        <p>Name: {user.name}</p>
        <p>Email: {user.email}</p>
        <p>KYC Status: {user.kycStatus}</p>
      </div>
      <button>Edit Profile</button>
    </div>
  );
};

export default UserProfile;


================================================
File: frontend/src/pages/Dashboard.tsx
================================================
import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const Dashboard: React.FC = () => {
  const [userData, setUserData] = useState({
    name: 'John Doe',
    balance: 5000,
    portfolioValue: 12000,
    activeTrades: 2,
  });

  useEffect(() => {
    // Fetch user data from the API
    // Example: fetchUserData().then(data => setUserData(data));
  }, []);

  return (
    <div className="dashboard">
      <h2>Welcome, {userData.name}</h2>
      <div className="stats">
        <div className="stat">
          <h3>Balance</h3>
          <p>${userData.balance}</p>
        </div>
        <div className="stat">
          <h3>Portfolio Value</h3>
          <p>${userData.portfolioValue}</p>
        </div>
        <div className="stat">
          <h3>Active Trades</h3>
          <p>{userData.activeTrades}</p>
        </div>
      </div>
      <Link to="/trade">Start Trading</Link>
    </div>
  );
};

export default Dashboard;


================================================
File: frontend/src/pages/Home.tsx
================================================
import React from 'react';
import CryptoCard from '../components/CryptoCard';
import { Link } from 'react-router-dom';

const Home: React.FC = () => {
  // Sample data for cryptocurrencies
  const cryptos = [
    { name: 'Bitcoin', symbol: 'BTC', price: 35000, change: 2.5 },
    { name: 'Ethereum', symbol: 'ETH', price: 2000, change: -1.2 },
    { name: 'Ripple', symbol: 'XRP', price: 1.2, change: 0.8 },
  ];

  return (
    <div className="home">
      <h1>Welcome to Maya Exchange</h1>
      <p>Your gateway to seamless cryptocurrency trading and payments.</p>
      <div className="crypto-list">
        {cryptos.map((crypto, index) => (
          <CryptoCard
            key={index}
            name={crypto.name}
            symbol={crypto.symbol}
            price={crypto.price}
            change={crypto.change}
          />
        ))}
      </div>
      <Link to="/trade">Start Trading</Link>
    </div>
  );
};

export default Home;


================================================
File: frontend/src/pages/Login.tsx
================================================
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Login: React.FC = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Add your authentication logic here
    console.log('Logging in with:', email, password);
    // Redirect to dashboard or home page upon success
    navigate('/dashboard');
  };

  return (
    <div className="login">
      <h2>Login to Maya Exchange</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Email:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button type="submit">Login</button>
      </form>
      <p>
        Don't have an account? <a href="/signup">Sign up</a>
      </p>
    </div>
  );
};

export default Login;


================================================
File: frontend/src/pages/SignUp.tsx
================================================
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const SignUp: React.FC = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Add your sign-up logic here
    console.log('Signing up with:', name, email, password);
    // Redirect to login page or dashboard upon success
    navigate('/login');
  };

  return (
    <div className="signup">
      <h2>Create a New Account</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Name:</label>
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Email:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button type="submit">Sign Up</button>
      </form>
      <p>
        Already have an account? <a href="/login">Login</a>
      </p>
    </div>
  );
};

export default SignUp;


================================================
File: frontend/src/pages/Trade.tsx
================================================
import React, { useState } from 'react';

const Trade: React.FC = () => {
  const [selectedCrypto, setSelectedCrypto] = useState('BTC');
  const [amount, setAmount] = useState(0);

  const handleTrade = () => {
    // Add trade logic here (e.g., call API to process trade)
    console.log(`Trading ${amount} ${selectedCrypto}`);
  };

  return (
    <div className="trade">
      <h2>Trade Cryptocurrencies</h2>
      <div className="trade-form">
        <div>
          <label>Select Cryptocurrency:</label>
          <select value={selectedCrypto} onChange={(e) => setSelectedCrypto(e.target.value)}>
            <option value="BTC">Bitcoin (BTC)</option>
            <option value="ETH">Ethereum (ETH)</option>
            <option value="XRP">Ripple (XRP)</option>
          </select>
        </div>
        <div>
          <label>Amount:</label>
          <input
            type="number"
            value={amount}
            onChange={(e) => setAmount(parseFloat(e.target.value))}
            min="0"
            step="any"
          />
        </div>
        <button onClick={handleTrade}>Execute Trade</button>
      </div>
    </div>
  );
};

export default Trade;


================================================
File: frontend/src/pages/Wallet.tsx
================================================
import React from 'react';
import { Link } from 'react-router-dom';

const Wallet: React.FC = () => {
  return (
    <div className="wallet">
      <h2>Your Wallet</h2>
      <p>Manage your funds here.</p>
      <div className="wallet-balance">
        <h3>Fiat Balance</h3>
        <p>$5000</p>
      </div>
      <div className="wallet-balance">
        <h3>Crypto Balance</h3>
        <p>0.5 BTC</p>
      </div>
      <Link to="/deposit">Deposit Funds</Link>
      <Link to="/withdraw">Withdraw Funds</Link>
    </div>
  );
};

export default Wallet;


================================================
File: frontend/src/redux/actions.ts
================================================
// action.ts
export const SET_USER = 'SET_USER';
export const SET_BALANCE = 'SET_BALANCE';
export const SET_CRYPTO_BALANCE = 'SET_CRYPTO_BALANCE';
export const SET_TRADE_HISTORY = 'SET_TRADE_HISTORY';

// User Action
export const setUser = (user: { name: string; email: string; kycStatus: string }) => ({
  type: SET_USER,
  payload: user,
});

// Wallet Action
export const setBalance = (balance: number) => ({
  type: SET_BALANCE,
  payload: balance,
});

export const setCryptoBalance = (cryptoBalance: number) => ({
  type: SET_CRYPTO_BALANCE,
  payload: cryptoBalance,
});

// Trade Action
export const setTradeHistory = (tradeHistory: any[]) => ({
  type: SET_TRADE_HISTORY,
  payload: tradeHistory,
});


================================================
File: frontend/src/redux/reducers.ts
================================================
// reducers.ts
import { combineReducers } from 'redux';
export const SET_USER = 'SET_USER';
export const SET_BALANCE = 'SET_BALANCE';
export const SET_CRYPTO_BALANCE = 'SET_CRYPTO_BALANCE';
export const SET_TRADE_HISTORY = 'SET_TRADE_HISTORY';

interface UserState {
  name: string;
  email: string;
  kycStatus: string;
}

interface WalletState {
  balance: number;
  cryptoBalance: number;
}

interface TradeState {
  tradeHistory: any[];
}

const initialUserState: UserState = {
  name: '',
  email: '',
  kycStatus: '',
};

const initialWalletState: WalletState = {
  balance: 0,
  cryptoBalance: 0,
};

const initialTradeState: TradeState = {
  tradeHistory: [],
};

// User Reducer
const userReducer = (state = initialUserState, action: any): UserState => {
  switch (action.type) {
    case SET_USER:
      return {
        ...state,
        ...action.payload,
      };
    default:
      return state;
  }
};

// Wallet Reducer
const walletReducer = (state = initialWalletState, action: any): WalletState => {
  switch (action.type) {
    case SET_BALANCE:
      return {
        ...state,
        balance: action.payload,
      };
    case SET_CRYPTO_BALANCE:
      return {
        ...state,
        cryptoBalance: action.payload,
      };
    default:
      return state;
  }
};

// Trade Reducer
const tradeReducer = (state = initialTradeState, action: any): TradeState => {
  switch (action.type) {
    case SET_TRADE_HISTORY:
      return {
        ...state,
        tradeHistory: action.payload,
      };
    default:
      return state;
  }
};

// Combine reducers
const rootReducer = combineReducers({
  user: userReducer,
  wallet: walletReducer,
  trade: tradeReducer,
});

export default rootReducer;


================================================
File: frontend/src/redux/store.ts
================================================
import { createStore, applyMiddleware, Middleware } from 'redux';
import rootReducer from './reducers';
import thunk, { ThunkMiddleware } from 'redux-thunk';

const middleware: Middleware[] = [(thunk as unknown) as ThunkMiddleware];

const store = createStore(rootReducer, applyMiddleware(...middleware));

export default store;

================================================
File: frontend/src/utils/api.ts
================================================
// api.ts
const API_URL = 'https://api.maya-exchange.com'; // Replace with your actual API base URL

// Generic API request handler
const apiRequest = async (url: string, method: string = 'GET', body: any = null) => {
  try {
    const headers: any = {
      'Content-Type': 'application/json',
    };

    let options: RequestInit = {
      method,
      headers,
    };

    if (body) {
      options.body = JSON.stringify(body);
    }

    const response = await fetch(`${API_URL}${url}`, options);

    if (!response.ok) {
      throw new Error(`API request failed with status ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error('API Error:', error);
    throw error;
  }
};

// Example API functions
export const getUser = (userId: string) => apiRequest(`/users/${userId}`);

export const updateUser = (userId: string, userData: object) =>
  apiRequest(`/users/${userId}`, 'PUT', userData);

export const getBalance = (userId: string) => apiRequest(`/wallet/${userId}/balance`);

export const getTradeHistory = (userId: string) =>
  apiRequest(`/trades/${userId}/history`);


================================================
File: frontend/src/utils/formatCurrency.ts
================================================
// formatCurrency.ts
export const formatCurrency = (amount: number, currency: string = 'USD'): string => {
    return new Intl.NumberFormat('en-US', {
      style: 'currency',
      currency,
    }).format(amount);
  };
  
  // Example usage of formatting for different currencies
  export const formatFiatCurrency = (amount: number): string => formatCurrency(amount, 'USD');
  export const formatCryptoCurrency = (amount: number): string => formatCurrency(amount, 'BTC');
  

================================================
File: frontend/src/utils/validateForm.ts
================================================
export const isEmpty = (value: string): boolean => {
    return !value || value.trim().length === 0;
  };
  
  // Validate email format
  export const isValidEmail = (email: string): boolean => {
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    return emailRegex.test(email);
  };
  
  // Validate password (at least 8 characters, at least one letter and one number)
  export const isValidPassword = (password: string): boolean => {
    const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
    return passwordRegex.test(password);
  };
  
  // Example of usage for a registration form
  export const validateRegistrationForm = (email: string, password: string): string[] => {
    const errors: string[] = [];
  
    if (isEmpty(email)) {
      errors.push('Email is required');
    } else if (!isValidEmail(email)) {
      errors.push('Please enter a valid email address');
    }
  
    if (isEmpty(password)) {
      errors.push('Password is required');
    } else if (!isValidPassword(password)) {
      errors.push('Password must be at least 8 characters long and include at least one letter and one number');
    }
  
    return errors;
  };
  

================================================
File: infrastructure/docker/Dockerfile
================================================
# Base image for Python
FROM python:3.10-slim

# Set environment variables to avoid interactive prompts
ENV PYTHONUNBUFFERED 1

# Set the working directory in the container
WORKDIR /app

# Copy the backend files into the container
COPY ../../backend/requirements.txt /app/requirements.txt

# Install Python dependencies
RUN pip install --no-cache-dir -r requirements.txt

# Copy the rest of the backend code into the container
COPY /home/kali/Desktop/Maya-Exchange/backend/requirements.txt /app

# Expose the backend service port
EXPOSE 8000

# Start the FastAPI backend service
CMD ["uvicorn", "main:app", "--host", "0.0.0.0", "--port", "8000"]


================================================
File: infrastructure/docker/docker-compose.yml
================================================
version: '3.8'

services:
  backend:
    build:
      context: ../../
      dockerfile: infrastructure/docker/Dockerfile
    container_name: maya_backend
    ports:
      - "8000:8000"
    env_file:
      - ../../backend/.env
    depends_on:
      - db
    networks:
      - maya_network

  db:
    image: postgres:15
    container_name: maya_postgres
    ports:
      - "5432:5432"
    environment:
      POSTGRES_USER: admin
      POSTGRES_PASSWORD: adminpassword
      POSTGRES_DB: maya_exchange
    volumes:
      - postgres_data:/var/lib/postgresql/data
    networks:
      - maya_network

volumes:
  postgres_data:

networks:
  maya_network:


================================================
File: infrastructure/kubernetes/deployment.yaml
================================================
apiVersion: apps/v1
kind: Deployment
metadata:
  name: maya-backend-deployment
  labels:
    app: maya-backend
spec:
  replicas: 2
  selector:
    matchLabels:
      app: maya-backend
  template:
    metadata:
      labels:
        app: maya-backend
    spec:
      containers:
        - name: maya-backend
          image: maya-exchange-backend:latest
          ports:
            - containerPort: 8000
          envFrom:
            - configMapRef:
                name: backend-config
            - secretRef:
                name: backend-secrets
          resources:
            requests:
              memory: "512Mi"
              cpu: "500m"
            limits:
              memory: "1Gi"
              cpu: "1"
        - name: maya-db
          image: postgres:15
          ports:
            - containerPort: 5432
          env:
            - name: POSTGRES_USER
              valueFrom:
                secretKeyRef:
                  name: db-secrets
                  key: username
            - name: POSTGRES_PASSWORD
              valueFrom:
                secretKeyRef:
                  name: db-secrets
                  key: password
            - name: POSTGRES_DB
              value: maya_exchange
          resources:
            requests:
              memory: "256Mi"
              cpu: "250m"
            limits:
              memory: "512Mi"
              cpu: "500m"


================================================
File: infrastructure/kubernetes/ingress.yaml
================================================
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: maya-exchange-ingress
  annotations:
    nginx.ingress.kubernetes.io/rewrite-target: /
    nginx.ingress.kubernetes.io/proxy-body-size: "10m"
    nginx.ingress.kubernetes.io/ssl-redirect: "true"
spec:
  rules:
    - host: maya-exchange.local
      http:
        paths:
          - path: /
            pathType: Prefix
            backend:
              service:
                name: maya-backend-service
                port:
                  number: 80
  tls:
    - hosts:
        - maya-exchange.local
      secretName: maya-exchange-tls


================================================
File: infrastructure/kubernetes/service.yaml
================================================
apiVersion: v1
kind: Service
metadata:
  name: maya-backend-service
  labels:
    app: maya-backend
spec:
  selector:
    app: maya-backend
  ports:
    - protocol: TCP
      port: 80
      targetPort: 8000
  type: ClusterIP

---
apiVersion: v1
kind: Service
metadata:
  name: maya-db-service
  labels:
    app: maya-db
spec:
  selector:
    app: maya-db
  ports:
    - protocol: TCP
      port: 5432
      targetPort: 5432
  type: ClusterIP


================================================
File: testing/run_tests.sh
================================================
#!/bin/bash

# Set the PYTHONPATH to include the backend/src directory
export PYTHONPATH=$PYTHONPATH:$(pwd)/backend

# Run the unit tests
python3 -m unittest discover -s testing/unit -p "*.py"


================================================
File: testing/integration/test_crypto_service.py
================================================
import unittest
from fastapi.testclient import TestClient
import sys
import os
sys.path.insert(0, os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))
from main import app  # Adjust the import based on your project structure

class TestCryptoServiceIntegration(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.user_data = {
            "name": "Bob",
            "email": "bob@example.com",
            "password": "complexpassword"
        }
        self.client.post("/auth/register", json=self.user_data)
        login_response = self.client.post("/auth/login", json={
            "email": self.user_data["email"],
            "password": self.user_data["password"]
        })
        self.token = login_response.json().get("access_token")
        self.headers = {"Authorization": f"Bearer {self.token}"}

    def test_crypto_purchase(self):
        purchase_data = {
            "crypto": "BTC",
            "amount": 0.01,
            "currency": "USD",
            "price": 30000  # Assume a fixed price for testing
        }
        response = self.client.post("/crypto/purchase", json=purchase_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Completed")

    def test_crypto_sale(self):
        sale_data = {
            "crypto": "ETH",
            "amount": 0.5,
            "currency": "USD",
            "price": 2000  # Assume a fixed price for testing
        }
        response = self.client.post("/crypto/sell", json=sale_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Completed")

    def test_crypto_balance(self):
        response = self.client.get("/crypto/balance", headers=self.headers)
        self.assertEqual(response.status_code, 200)
        self.assertIsInstance(response.json(), dict)
        self.assertIn("BTC", response.json())
        self.assertIn("ETH", response.json())

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/integration/test_transaction_flow.py
================================================
import unittest
from fastapi.testclient import TestClient
from src.main import app

class TestTransactionFlowIntegration(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.user_data = {
            "name": "Alice",
            "email": "alice@example.com",
            "password": "strongpassword"
        }
        self.client.post("/auth/register", json=self.user_data)
        login_response = self.client.post("/auth/login", json={
            "email": self.user_data["email"],
            "password": self.user_data["password"]
        })
        self.token = login_response.json().get("access_token")
        self.headers = {"Authorization": f"Bearer {self.token}"}

    def test_deposit_transaction(self):
        deposit_data = {
            "type": "Deposit",
            "amount": 1000,
            "currency": "USD"
        }
        response = self.client.post("/transactions/deposit", json=deposit_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Completed")

    def test_withdraw_transaction(self):
        withdraw_data = {
            "type": "Withdraw",
            "amount": 500,
            "currency": "USD"
        }
        response = self.client.post("/transactions/withdraw", json=withdraw_data, headers=self.headers)
        self.assertEqual(response.status_code, 201)
        self.assertIn("transaction_id", response.json())
        self.assertEqual(response.json()["status"], "Pending")

    def test_transaction_history(self):
        response = self.client.get("/transactions/history", headers=self.headers)
        self.assertEqual(response.status_code, 200)
        self.assertIsInstance(response.json(), list)

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/integration/test_user_auth.py
================================================
import unittest
from fastapi.testclient import TestClient
from src.main import app

class TestUserAuthIntegration(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.test_user = {
            "name": "Jane Doe",
            "email": "jane.doe@example.com",
            "password": "securepassword123"
        }

    def test_user_registration(self):
        response = self.client.post("/auth/register", json=self.test_user)
        self.assertEqual(response.status_code, 201)
        self.assertIn("message", response.json())
        self.assertIn("user_id", response.json())

    def test_user_login(self):
        # First, register the user
        self.client.post("/auth/register", json=self.test_user)
        
        # Attempt login
        login_data = {
            "email": self.test_user["email"],
            "password": self.test_user["password"]
        }
        response = self.client.post("/auth/login", json=login_data)
        self.assertEqual(response.status_code, 200)
        self.assertIn("access_token", response.json())

    def test_protected_route_access(self):
        # Register and login to get token
        self.client.post("/auth/register", json=self.test_user)
        login_response = self.client.post("/auth/login", json={
            "email": self.test_user["email"],
            "password": self.test_user["password"]
        })
        token = login_response.json().get("access_token")
        
        # Access protected route
        headers = {"Authorization": f"Bearer {token}"}
        response = self.client.get("/protected", headers=headers)
        self.assertEqual(response.status_code, 200)
        self.assertIn("message", response.json())

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/load/test_load_signups.py
================================================
import unittest
import time
from fastapi.testclient import TestClient
from src.main import app

class TestLoadSignups(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)

    def test_signup_load(self):
        start_time = time.time()
        for i in range(100):  # Simulating 100 user signups
            signup_data = {
                "name": f"TestUser{i}",
                "email": f"testuser{i}@example.com",
                "password": "password123"
            }
            response = self.client.post("/auth/register", json=signup_data)
            self.assertEqual(response.status_code, 201)
            self.assertIn("user_id", response.json())
            self.assertIn("message", response.json())

        end_time = time.time()
        print(f"Processed 100 signups in {end_time - start_time:.2f} seconds.")

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/load/test_load_transactions.py
================================================
import unittest
import time
from fastapi.testclient import TestClient
from src.main import app

class TestLoadTransactions(unittest.TestCase):

    def setUp(self):
        self.client = TestClient(app)
        self.user_data = {
            "name": "Load Tester",
            "email": "loadtester@example.com",
            "password": "testpassword123"
        }
        # Register and login the test user
        self.client.post("/auth/register", json=self.user_data)
        login_response = self.client.post("/auth/login", json={
            "email": self.user_data["email"],
            "password": self.user_data["password"]
        })
        self.token = login_response.json().get("access_token")
        self.headers = {"Authorization": f"Bearer {self.token}"}

    def test_transaction_load(self):
        start_time = time.time()
        for i in range(100):  # Simulating 100 transactions
            transaction_data = {
                "type": "Deposit" if i % 2 == 0 else "Withdraw",
                "amount": 10 + i,  # Increment amount for variety
                "currency": "USD"
            }
            response = self.client.post("/transactions/create", json=transaction_data, headers=self.headers)
            self.assertEqual(response.status_code, 201)
            self.assertIn("transaction_id", response.json())
            self.assertIn("status", response.json())

        end_time = time.time()
        print(f"Processed 100 transactions in {end_time - start_time:.2f} seconds.")

if __name__ == "__main__":
    unittest.main()


================================================
File: testing/unit/test_transaction_model.py
================================================
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


================================================
File: testing/unit/test_upi_service.py
================================================
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


================================================
File: testing/unit/test_user_model.py
================================================
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


================================================
File: .github/workflows/codeql.yml
================================================
# For most projects, this workflow file will not need changing; you simply need
# to commit it to your repository.
#
# You may wish to alter this file to override the set of languages analyzed,
# or to provide custom queries or build logic.
#
# ******** NOTE ********
# We have attempted to detect the languages in your repository. Please check
# the `language` matrix defined below to confirm you have the correct set of
# supported CodeQL languages.
#
name: "CodeQL Advanced"

on:
  push:
    branches: [ "main" ]
  pull_request:
    branches: [ "main" ]
  schedule:
    - cron: '21 20 * * 0'

jobs:
  analyze:
    name: Analyze (${{ matrix.language }})
    # Runner size impacts CodeQL analysis time. To learn more, please see:
    #   - https://gh.io/recommended-hardware-resources-for-running-codeql
    #   - https://gh.io/supported-runners-and-hardware-resources
    #   - https://gh.io/using-larger-runners (GitHub.com only)
    # Consider using larger runners or machines with greater resources for possible analysis time improvements.
    runs-on: ${{ (matrix.language == 'swift' && 'macos-latest') || 'ubuntu-latest' }}
    permissions:
      # required for all workflows
      security-events: write

      # required to fetch internal or private CodeQL packs
      packages: read

      # only required for workflows in private repositories
      actions: read
      contents: read

    strategy:
      fail-fast: false
      matrix:
        include:
        - language: javascript-typescript
          build-mode: none
        - language: python
          build-mode: none
        # CodeQL supports the following values keywords for 'language': 'c-cpp', 'csharp', 'go', 'java-kotlin', 'javascript-typescript', 'python', 'ruby', 'swift'
        # Use `c-cpp` to analyze code written in C, C++ or both
        # Use 'java-kotlin' to analyze code written in Java, Kotlin or both
        # Use 'javascript-typescript' to analyze code written in JavaScript, TypeScript or both
        # To learn more about changing the languages that are analyzed or customizing the build mode for your analysis,
        # see https://docs.github.com/en/code-security/code-scanning/creating-an-advanced-setup-for-code-scanning/customizing-your-advanced-setup-for-code-scanning.
        # If you are analyzing a compiled language, you can modify the 'build-mode' for that language to customize how
        # your codebase is analyzed, see https://docs.github.com/en/code-security/code-scanning/creating-an-advanced-setup-for-code-scanning/codeql-code-scanning-for-compiled-languages
    steps:
    - name: Checkout repository
      uses: actions/checkout@v4

    # Initializes the CodeQL tools for scanning.
    - name: Initialize CodeQL
      uses: github/codeql-action/init@v3
      with:
        languages: ${{ matrix.language }}
        build-mode: ${{ matrix.build-mode }}
        # If you wish to specify custom queries, you can do so here or in a config file.
        # By default, queries listed here will override any specified in a config file.
        # Prefix the list here with "+" to use these queries and those in the config file.

        # For more details on CodeQL's query packs, refer to: https://docs.github.com/en/code-security/code-scanning/automatically-scanning-your-code-for-vulnerabilities-and-errors/configuring-code-scanning#using-queries-in-ql-packs
        # queries: security-extended,security-and-quality

    # If the analyze step fails for one of the languages you are analyzing with
    # "We were unable to automatically build your code", modify the matrix above
    # to set the build mode to "manual" for that language. Then modify this step
    # to build your code.
    # ℹ️ Command-line programs to run using the OS shell.
    # 📚 See https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idstepsrun
    - if: matrix.build-mode == 'manual'
      shell: bash
      run: |
        echo 'If you are using a "manual" build mode for one or more of the' \
          'languages you are analyzing, replace this with the commands to build' \
          'your code, for example:'
        echo '  make bootstrap'
        echo '  make release'
        exit 1

    - name: Perform CodeQL Analysis
      uses: github/codeql-action/analyze@v3
      with:
        category: "/language:${{matrix.language}}"


================================================
File: .github/workflows/docker-image.yml
================================================
name: Docker Image CI

on:
  push:
    branches: [ "main" ]
  pull_request:
    branches: [ "main" ]

jobs:

  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v4
    - name: Build the Docker image
      run: docker build . --file Dockerfile --tag my-image-name:$(date +%s)
