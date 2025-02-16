#!/bin/bash

# Function to run all tests
run_all_tests() {
    echo "Running all tests..."

    # Navigate to the tests directory
    cd tests || exit

    # Run unit tests
    echo "Running unit tests..."
    dotnet test --filter TestCategory=Unit

    # Run integration tests
    echo "Running integration tests..."
    dotnet test --filter TestCategory=Integration

    echo "All tests completed."
}

# Main script execution
echo "Starting test process..."
run_all_tests
echo "Test process completed successfully."
