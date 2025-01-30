# Base image for Python
FROM python:3.10-slim

# Set environment variables to avoid interactive prompts
ENV PYTHONUNBUFFERED 1

# Set the working directory
WORKDIR /app

# Install dependencies
COPY requirements.txt ./
RUN pip install --no-cache-dir -r requirements.txt

# Copy the rest of the application code
COPY . .

# Expose the port
EXPOSE 8000

# Start the FastAPI backend service
CMD ["uvicorn", "main:app", "--host", "0.0.0.0", "--port", "8000"]
