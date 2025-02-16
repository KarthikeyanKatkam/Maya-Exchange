# Maya Exchange API Authentication

## Overview
Maya Exchange uses **JSON Web Tokens (JWT)** for securing API endpoints. Each user must authenticate with the platform to receive a token that grants access to protected resources.

---

## **How Authentication Works**

1. **User Login**:
   - The user submits their email and password to the `/api/v1/users/login` endpoint.
   - Upon successful authentication, the server responds with a JWT token and its expiration time.

2. **Token Usage**:
   - The client includes the JWT in the `Authorization` header for all subsequent API requests.
   - Example:
     ```
     Authorization: Bearer <JWT_TOKEN>
     ```

3. **Token Validation**:
   - The backend verifies the token’s signature and expiration before granting access to the requested resource.

---

## **Login Flow**

1. **Request**:
   - **Endpoint**: `/api/v1/users/login`
   - **Method**: `POST`
   - **Body**:
     ```json
     {
       "email": "john.doe@example.com",
       "password": "securepassword"
     }
     ```

2. **Response**:
   ```json
   {
     "token": "jwt_token",
     "expires_in": 3600
   }
