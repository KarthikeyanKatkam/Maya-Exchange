# Base image for Python
FROM python:3.10-slim

# Set environment variables to avoid interactive prompts
ENV PYTHONUNBUFFERED 1

# Set the working directory in the container
WORKDIR /app

# Copy the backend files into the container
COPY ../../backend/requirements.txt /app/requirements.txt

# Install Python dependencies
RUN pip install --no-cache-dir -r requirements.txt

# Copy the rest of the backend code into the container
COPY /home/kali/Desktop/Maya-Exchange/backend/requirements.txt /app

# Expose the backend service port
EXPOSE 8000

# Start the FastAPI backend service
CMD ["uvicorn", "main:app", "--host", "0.0.0.0", "--port", "8000"]
