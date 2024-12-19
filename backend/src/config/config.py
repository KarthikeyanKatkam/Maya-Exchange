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
