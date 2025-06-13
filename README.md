# RaftLabs .NET Developer Assignment

This project is a clean and testable .NET 6+ SDK-style component that interacts with the public [ReqRes API](https://reqres.in). It is developed as part of the RaftLabs .NET Developer Assignment.

---

## Features

- Fetch a single user by ID (`GET /api/users/{id}`)
- Fetch all users across paginated pages (`GET /api/users?page=n`)
- Handles user not found and API failures gracefully
- Uses clean folder structure (Client, Service, Models)
- Unit tests using **xUnit + Moq**
- Optional: Console app to demonstrate working

---

## Project Structure

RaftLabsAssignment/
├── RaftLabs.UserClient/ # SDK: Client, DTOs, Service
├── RaftLabs.UserClient.Tests/ # Unit tests (xUnit + Moq)
├── RaftLabs.ConsoleDemo/ # Optional demo console
├── RaftLabsAssignment.sln
├── README.md # This file


---

##  Features Implemented

- Get a single user by ID
- Get all users with automatic pagination
- ReqRes API wrapped via reusable `ReqResClient`
- `ExternalUserService` exposes high-level SDK methods
- Clean, isolated **unit tests with mocking**
- API key loaded from config (`appsettings.json`)

---

## How to Run the Demo

> Make sure you have [.NET 6+ SDK](https://dotnet.microsoft.com/download) installed.

### Step 1: Clone the Repo

git clone <your-fork-url>
cd RaftLabsAssignment

### Step 2: Provide API Key in appsettings.json
Update the file:
appsettings.json
-   "ApiKey": "reqres-free-v1"   // Replace with your key.
` * Make sure to set the property of the app.settings file to Copy to Output Directory = Copy if newer is set on this file.*`

### Step 3: Run the Console App
### 📷 Console Output Example
Below is a sample output from the Console App after successfully calling the SDK:
![Console Output](screenshots/console-output.png)

