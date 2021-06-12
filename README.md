# National Park System: An API

### A Week XIII Epicodus Project, 11 June 2021

_By Jonathan Stull_

## **About**

This project is an experimental national and state park system API. It allows users to create, read, update, and delete national and state parks. This version is designed for developers to provide accurate and useful information to users who are interested in outdoor recreation inside of the national and state parks systems.

## **Setup/Installation Requirements**

* Software requirements (internet browser, code editor, etc.)
  1. Internet browser
  2. A code editor like VSCode or Atom to view or edit the codebase

* Download/clone instructions
  1. Download this repository onto your computer by clicking the 'code' button in the GitHub repository
  2. Open the project folder.

* Open via Bash/GitBash:
  1. Clone this repository onto your computer: `git clone https://github.com/jonathanstull/NationalParkSystem.API.git`
  2. In a terminal window, navigate into the `~/NationalParkSystem.Solution` directory and open in VSCode or preferred text editor with the command `code .`
  3. This project uses C#/.NET. To build and execute the code, first restore all dependencides using `dotnet restore` followed by the command `dotnet run`

* Setting up migrations with a MySQL database
  * For more information about migrations, please refer to the [Microsoft EF Core documentation](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations)
  1. Download and install MySQL and MySQLWorkbench in accordance with [this tutorial](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql)
  2. In your cloned repository, navigate to the production directory `~/NationalParkSystem` and restore all dependencies with `dotnet restore`
  3. In the CLI, create a new file with the command `touch .appsettings.json` and apply the settings in the codeblock below to specify the MySQL database (please note that **you must change `[SECRET]`, `[YOUR_DATABASE_NAME]`, `[YOUR_USERNAME]` and `[YOUR_PASSWORD]`** to reflect your user information; see below):
  4. In the CLI, enter the command `dotnet ef database update` to generate the schema and corresponding tables from the existing `Migrations` folder
  
    ```
    {
      "AppSettings": {
        "Secret": "[This is a secret key longer than 32 bits that you can define however you want]"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR_DATABASE_NAME];uid=[YOUR_USERNAME];pwd=[YOUR_PASSWORD];"
      }
    }
    ```

## **Endpoints**

**Testing**

To test this API, [Postman](https://www.postman.com/downloads) is a highly recommended client that allows access to these endpoints with GET, POST, PUT, and DELETE requests alongside a host of others. To test, follow these steps in this example, which will also provide you with the JWT key you will need to access this API's endpoints:

  1. Download and install [Postman](https://www.postman.com/downloads)
  2. Open a new request by selecting the `File` menu or clicking the `+` in the taskbar
  3. Make sure you are running this project by navigating to the production directory at `~/NationalParkSystem` and running, in the following order, the commands `dotnet restore`, `dotnet ef database update`, and `dotnet run`
  3. Select the type of request you would like to make. To retrieve a JWT, select `POST` and enter `http://localhost:5000/api/users/authenticate` into the request URL
  4. In the `Body` tab, select `Raw`, select `Json` in the adjacent dropdown menu, and use the following template to enter user information into the body:

  ```
  {
    "username": "[YOUR_USERNAME]",
    "password": "[YOUR_PASSWORD]"
  }
  ```
    
    * **Note:** Username and password are currently hardcoded into the `_users` property of `UserService.cs` and can be changed as desired
  5. Send the request. If successful, the `200 OK` response will include a JWT token
  6. To make a request to other endpoints, open a new request as in step 2
  7. Complete the fields required by the request type and the endpoint requested
  8. Navigate to the `Authorization` tab and select `Bearer Token` from the `Type` dropdown menu
  9. Copy your JWT token and paste into the corresponding `Token` input field
  10. Send your request!

**Users**
  1. `/api/users/authenticate`: POST serves the username and password to the API to generate a JWT in the response body
    * **NOTE: All API endpoints require authentication from this endpoint for access**

**National Parks**
  * **Note:** You must replace `{id}` with the corresponding national or state park id to enable access to endpoints requiring an id
  1. `/api/nationalparks`: GET general returns all national parks in the database and supports query by name (inclusive and case insensitive) and geographical state location (exact match by state code, e.g. AK, OR, CA)
  2. `/api/nationalparks`: POST adds a national park with all required fields (Name, Status, LatLong, State, Visits, BusySeason, Climate, and RvServices)
  3. `/api/nationalparks/{id}`: GET by id returns a national park by its NationalParkId
  4. `/api/nationalparks/{id}`: PUT updates a national park by NationalParkId with all required fields and any updated information
  5. `/api/nationalparks/{id}`: DELETE deletes a national park by NationalParkId

**State Parks**
  1. `/api/stateparks`: GET general returns all state parks in the database and supports query by name (inclusive and case insensitive) and geographical state location (exact match by state code, e.g. AK, OR, CA)
  2. `/api/stateparks`: POST adds a state park with all required fields (Name, Status, LatLong, State, Visits, BusySeason, Climate, and RvServices)
  3. `/api/stateparks/{id}`: GET by id returns a state park by its StateParkId
  4. `/api/stateparks/{id}`: PUT updates a state park by StateParkId with all required fields and any updated information
  5. `/api/stateparks/{id}`: DELETE deletes a state park by StateParkId

## **Known Bugs**

* version 0.9:
  1. GET query by RvServices boolean returns all parks when the query is empty (i.e., null or not defined, reading as false) and no current solution exists that will accurately evaluate each condition; this functionality is disabled in this version
  2. `dev` branch attempts to implement user registration and fails due to database and migration conflicts; it has not yet been merged to branch `main`

## **Specs**

* This API includes CRUD functionality and successfully returns responses to API calls
* This API also features authentication with JWT
* As of 11 June 2021, this app may also feature versioning, pagination, Swagger documentation
* Application is well-documented, including specific documentation on further exploration and instructions on how to create the appsettings.json and set up the project

## **Technologies Used**

* C#/.NET 5.0 SDK
* MySQL and MySQLWorkbench
* JWT
* HTML/CSS
* VS Code
* Google Chrome/Mozilla Firefox

## **Dependencies**

* Entity Framework Core (5.0.0) and Pomelo (5.0.0-alpha.2)
* Newtonsoft (13.0.1)
* JWT
* Swashbuckle

## **MIT License**

Copyright (c) 2021 Jonathan Stull

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM.cs, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## **Acknowledgements**

This project was developed alongside the [LearnHowToProgram curriculum](learnhowtoprogram.com) at Epicodus, a coding bootcamp in Portland, Oregon. This project would not have been possible without the collaboration of [Nick Reeder](https://github.com/reeder32) and [Jeremy Banka](https://github.com/jeremybanka).

JWT authentication in this app would not have been possible without the tutelage of [Jason Watmore](https://github.com/cornflourblue), whose [JWT tutorials](https://jasonwatmore.com/posts/tag/jwt) are extraordinarily inspiring and insightful. For .NET 5.0 users, refer to [.NET 5.0 - JWT Authentication Tutorial with Example API](https://jasonwatmore.com/post/2021/04/30/net-5-jwt-authentication-tutorial-with-example-api) for this app's implementation.

## **Contact Information**

If you are interested in this work, please reach out to Jonathan at <jonathan.d.stull@gmail.com>.