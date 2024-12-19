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

