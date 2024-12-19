#!/bin/bash

# Update system
sudo apt-get update -y
sudo apt-get upgrade -y

# Install dependencies
sudo apt-get install -y git curl unzip

# Install Node.js (required for the frontend)
curl -sL https://deb.nodesource.com/setup_18.x | sudo -E bash -
sudo apt-get install -y nodejs

# Install Docker (for containerization)
sudo apt-get install -y docker.io
sudo systemctl enable --now docker

# Install Docker Compose (for managing multi-container Docker applications)
sudo curl -L "https://github.com/docker/compose/releases/download/1.29.2/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
sudo chmod +x /usr/local/bin/docker-compose

# Install Python (for the backend)
sudo apt-get install -y python3-pip python3-dev
sudo apt-get install -y python3-venv

# Install AWS CLI (to interact with AWS services)
sudo apt-get install -y awscli

# Install Nginx (for reverse proxy)
sudo apt-get install -y nginx
sudo systemctl enable nginx
sudo systemctl start nginx

# Set up project directory
cd /home/ubuntu
git clone https://github.com/yourusername/maya-exchange.git
cd maya-exchange

# Set up the backend
cd backend
python3 -m venv venv
source venv/bin/activate
pip install -r requirements.txt

# Run backend server (e.g., using Gunicorn)
gunicorn --workers 3 src.main:app --bind 0.0.0.0:8000 &

# Set up the frontend
cd ../frontend
npm install
npm run build

# Set up Nginx to serve the frontend build
sudo cp -r dist/* /var/www/html/

# Restart Nginx to apply changes
sudo systemctl restart nginx

# Set up automatic updates
sudo apt-get install -y unattended-upgrades
sudo dpkg-reconfigure --priority=low unattended-upgrades

echo "EC2 setup completed successfully!"
