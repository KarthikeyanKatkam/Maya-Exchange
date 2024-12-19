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
