Model structure

NationalPark
  int NationalParkId
  string Name
  string Status
  string LatLong
  string State
  int Visits
  string BusySeason
  string Climate
  bool RvServices
  blob Topo

StatePark
  int StateParkId
  string Name
  string Status
  string LatLong
  string State
  int Visits
  string BusySeason
  string Climate
  bool RvServices
  blob Topo



# National Park System: An API

### A Week XIII Epicodus Project, 12 June 2021

_By Jonathan Stull_

## **Description**

This project is an experimental National Park Service API for developers. It does many things.

## **Setup/Installation Requirements**

* Software requirements (internet browser, code editor, etc.)
  1. Internet browser
  2. A code editor like VSCode or Atom to view or edit the codebase

* Download/clone instructions
  1. Download this repository onto your computer by clicking the 'code' button
  2. Open the project folder.

* Open via Bash/GitBash:
  1. Clone this repository onto your computer: `git clone https://github.com/jonathanstull/NationalParkSystem.API.git`
  2. In a terminal window, navigate into the `~/NationalParkSystem.Solution` directory and open in VSCode or preferred text editor with the command `code .`
  3. This project uses C#/.NET. To build and execute the code, first restore all dependencides using `dotnet restore` followed by the command `dotnet run`

* Setting up a MySQL database
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

## **Known Bugs**

* None

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

## **Contact Information**

If you are interested in this work, please reach out to Jonathan at <jonathan.d.stull@gmail.com>.