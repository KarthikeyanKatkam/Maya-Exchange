#!/bin/bash

# Function to deploy the application using Kubernetes
deploy_kubernetes() {
    echo "Navigating to Kubernetes directory..."
    cd ../../kubernetes || exit
    echo "Deploying application using Kubernetes..."
    kubectl apply -f .
}

# Function to deploy the application using Podman
deploy_podman() {
    echo "Navigating to Podman directory..."
    cd ../podman || exit
    echo "Building and running the application using Podman..."
    podman-compose up -d
}

# Main script execution
echo "Starting deployment process..."
deploy_kubernetes
deploy_podman
echo "Deployment process completed."
