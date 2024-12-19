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