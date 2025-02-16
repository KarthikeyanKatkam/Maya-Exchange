# Start Generation Here

# Maya Exchange Application Setup Instructions

## Prerequisites
- Ensure Node.js and npm are installed.
- Ensure .NET SDK is installed for backend development.
- Ensure AWS CLI is configured if using AWS services.
- Ensure Docker and Kubernetes are installed if using containerization and orchestration.

## Frontend Setup
1. Navigate to the frontend directory:
   ```sh
   cd frontend
   ```

2. Install dependencies:
   ```sh
   npm install
   ```

3. Run the frontend application:
   ```sh
   npm start
   ```

## Backend Setup
1. Navigate to the backend directory:
   ```sh
   cd ../backend
   ```

2. Install dependencies:
   ```sh
   dotnet restore
   ```

3. Build the backend application:
   ```sh
   dotnet build
   ```

4. Run the backend application:
   ```sh
   dotnet run
   ```

## Database Setup
- Ensure you have MongoDB, MySQL, PostgreSQL, and other required databases installed and running locally or via Docker.
- Configure database connections in `backend/src/config/dbConfig.cs`.

## API Endpoints
The following API endpoints are available:
- `/users` - User management
- `/transactions` - Transaction history
- `/send` - Send local currency or crypto
- `/receive` - Receive crypto or local currency
- `/convert` - Convert currency (LCC, CLC, CC)
- `/kyc` - KYC/AML verification

## Middleware
Ensure all middleware components are correctly configured in `backend/src/middleware/`.

## Controllers and Routes
Controllers are located in `backend/src/controllers/` and routes are defined in `backend/src/routes/`.

## Services
Business logic is encapsulated in services located in `backend/src/services/`.

## Utilities
Helper functions and constants are found in `backend/src/utils/`.

## Testing
1. Navigate to the tests directory:
   ```sh
   cd tests
   ```

2. Run unit tests:
   ```sh
   dotnet test --filter TestCategory=Unit
   ```

3. Run integration tests:
   ```sh
   dotnet test --filter TestCategory=Integration
   ```

## Frontend Directory Structure
- `public/` - Public static files.
- `src/` - Source code.
  - `components/` - Reusable UI components.
  - `pages/` - Page components.
  - `services/` - Frontend services for API calls.
  - `styles/` - Global styles and themes.
  - `utils/` - Utility functions and constants.

## Backend Directory Structure
- `src/` - Source code.
  - `app.cs` - Main application entry point.
  - `server.cs` - Server configuration.
  - `config/` - Configuration files.
  - `controllers/` - API controllers.
  - `middleware/` - Middleware components.
  - `models/` - Data models.
  - `routes/` - API routes.
  - `services/` - Business logic services.
  - `utils/` - Utility functions and constants.
- `tests/` - Test files.
  - `integration/` - Integration test files.
  - `unit/` - Unit test files.

## Containerization and Orchestration
1. Navigate to the Kubernetes directory:
   ```sh
   cd ../../kubernetes
   ```

2. Deploy the application using Kubernetes:
   ```sh
   kubectl apply -f .
   ```

3. Navigate to the Podman directory:
   ```sh
   cd ../podman
   ```

4. Build and run the application using Podman:
   ```sh
   podman-compose up
   ```

## Scripts
1. Navigate to the scripts directory:
   ```sh
   cd ../../scripts
   ```

2. Run build script:
   ```sh
   ./build.sh
   ```

3. Run deploy script:
   ```sh
   ./deploy.sh
   ```

4. Run start script:
   ```sh
   ./start.sh
   ```

5. Run test script:
   ```sh
   ./test.sh
   ```

## GitHub Issue Templates
Issue templates for bug reports and feature requests are located in `/.github/ISSUE_TEMPLATE/`.

This completes the setup instructions for developing the Maya Exchange application.

# End Generation Here
