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
