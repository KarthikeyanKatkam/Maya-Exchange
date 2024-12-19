# backend/src/database/config.py
import os

# You can use environment variables to securely store your database URL
DATABASE_URL = os.getenv("DATABASE_URL", "postgresql://user:password@localhost/dbname")
