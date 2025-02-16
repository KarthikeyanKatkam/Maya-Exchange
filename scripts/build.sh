#!/bin/bash

# Function to set up the frontend
setup_frontend() {
    echo "Navigating to frontend directory..."
    cd frontend || exit
    echo "Installing frontend dependencies..."
    npm install
    echo "Starting frontend application..."
    npm start
}

# Function to set up the backend
setup_backend() {
    echo "Navigating to backend directory..."
    cd ../backend || exit
    echo "Restoring backend dependencies..."
    dotnet restore
    echo "Building backend application..."
    dotnet build
    echo "Running backend application..."
    dotnet run
}

# Function to set up the database
setup_database() {
    echo "Ensure MongoDB, MySQL, PostgreSQL, and other required databases are installed and running."
    echo "Configuring database connections in backend/src/config/dbConfig.cs."
}

# Function to run tests
run_tests() {
    echo "Navigating to tests directory..."
    cd tests || exit
    echo "Running unit tests..."
    dotnet test --filter TestCategory=Unit
    echo "Running integration tests..."
    dotnet test --filter TestCategory=Integration
}

# Main script execution
echo "Starting build process..."
setup_frontend
setup_backend
setup_database
run_tests
echo "Build process completed."
