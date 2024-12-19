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
