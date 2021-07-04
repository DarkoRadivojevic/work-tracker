# Work Tracker
## A simple API for tracking projects and their tasks

**Getting started**
- Overview
- How to run

## Overview

The Work Tracker API is an easy to use application for tracking projects and progress of its tasks.

### [Five W](https://en.wikipedia.org/wiki/Five_Ws)

#### Who
-[Me](https://www.linkedin.com/in/darko-radivojevic-984a451a0/) aka Darko

#### What
- This project is ASP.NET Core 5 Web API application build wiht an N-layer architecutre containerized using Docker. It provides functionality of creating projects and adding tasks to them.
    - The Web layer is documented with Swagger and prvoides endopoints
        - Helps us achieve the [DI pattern](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0) 
    - The Business layer handles the rules of the project
        - Implements the service pattern 
    - The Data layer stores the data in a __MS SQL__ database
        - Implents the repository pattern

- The app itself is made into a docker image and made a part of our docker composition with the MS SQL server image provided by MS using __Linux containers__. 

#### When 
- When you complete [this](#Steps-to-run) 

#### Where
- [Repo url](https://github.com/DarkoRadivojevic/work-tracker) 

#### Why 
- Code task to represent my skillset.- 

## How to run

The projects uses various open source projects including:

- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0) - Built on top of this framework
- [Docker](https://docs.docker.com/) - Containeraized with Docker 
- [MS SQL](https://hub.docker.com/_/microsoft-mssql-server) - In form of a docker image
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Modern object-database mapper
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) - Swagger tooling built with .NET Core
- [AutoMapper](https://docs.automapper.org/en/stable/Getting-started.html) - Object mapper

And the project itself is open source.

#### Steps to run

1. Clone the repo
    - `git clone <ssh or https>` 
        - [Git clone docs](https://git-scm.com/docs/git-clone) 
2. Install docker for your OS and set it to use Linux containers
    - [Docker](https://www.docker.com/products/docker-desktop) 
3. Build solution
    - If you use [Visual Studio 2019](https://visualstudio.microsoft.com/) IDE your shourtcut for building will be enough, set in `Debug` configuration
4. Run the application
    - If you are using VS, deafult shortcuts are:
        -  Running with debugger  `CTRL + F5`
        -  Without debugger `F5` 
    - If you are not using VS you will have to spin up docker manually 
        - Navigate to the directory where you cloned the project (i.e where `docker-compose.yml` file is located)
        - Open a CLI window in that location 
        - Execute `docker-compose up`
            - [Docker CLI docks](https://docs.docker.com/engine/reference/commandline/cli/) 
5. Check it out
    - The app is setup to run on localhost with port 52001 for https and 52000 for http
    - Link to swagger docs: `https://localhost:52001/swagger/index.html`

## License
MIT
**Free Software**
