## BTNX Profile App

A small demo with Blazor WebAssembly client and ASP.NET Core Web API. You can view and edit a profile stored in-memory.

### How to run

- **Start the API (port 5283):**

  ```bash
  cd ProfileWebApi && dotnet run
  ```

  - Swagger UI: [http://localhost:5283/swagger](http://localhost:5283/swagger)

- **Start the Blazor client (port 5043):**

  In a second terminal:

  ```bash
  cd ProfileBlazarApp && dotnet run
  ```

  - App URL: [http://localhost:5043](http://localhost:5043)

Notes:

- The client calls the API at `http://localhost:5283`, so start the API first.
