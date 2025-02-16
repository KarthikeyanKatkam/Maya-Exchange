# Function to start the application
start_application() {
    echo "Starting the frontend and backend applications..."
    # Start frontend
    (cd frontend && npm start) &
    # Start backend
    (cd backend && dotnet run) &
    
    # Wait for both applications to start
    wait
}

# Main script execution
echo "Starting application..."
start_application
echo "Application started successfully."
