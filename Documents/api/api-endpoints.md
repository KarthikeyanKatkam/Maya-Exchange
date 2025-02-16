# Maya Exchange API Endpoints

## Overview
This document lists the API endpoints available for Maya Exchange, grouped by functionality.

---

## **User Management**

### **Register a New User**
- **Endpoint**: `/api/v1/users/register`
- **Method**: `POST`
- **Description**: Registers a new user with KYC information.
- **Request Body**:
  ```json
  {
    "name": "John Doe",
    "email": "john.doe@example.com",
    "password": "securepassword",
    "mobile": "9876543210"
  }
