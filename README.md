# Exercie 1
Added Simple pyhton script and implimented the Check function, simply run the script using any python env
# Exercies 2 & 3
## How to run
ASP.net core project, Requirments : Any SQLServer instance, .net dev enviroment.<br/>
Please go to appsettings.json and put your connection string in place of the base connection string there.<br/>
Open an ef console and type "add-migration init" followed by "update-database" to generate the database in your own SQLServer instance.<br/>
SimpleRun the project (As http or httpS) and you will be gereeted with a SWAGGER interface detailing the existing APIs <br/>
## Choice of architecture
I used Dependancy injection along with the factory pattern, I also implemented a simple Service and repositories for each entity.
### Reason for repositories:
Currently I am using Entity frame work core, if we want to change to a different ORM, we sipply can change the repository files.
### Reasons for factory:
I used the factory because creating a task ivolves checking if a priority level/category is valid, therefor the factory checks it for you and creates the task using the proper repository.
### Reasons for Depandancy injection:
I am using the service/Repos/factories all over the place, in controllers or even in defining each other there for adding a DI is curucial.
