Travel And Accommodation Booking Platform Project Documentation

System Architecture :
This system use the 3 layered arch , where there is 3 layers as : 
•	Data Access Layer : class library project having the DB entities , repositories , migrations , configurations and Application DB Context .
•	Business Layer : class library project having the system services that implement the business logic , Dto’s for update/create and display , Validators and profiles .
•	Presentation Layer : ASP.NET core web api project having the Api’s End Points and Controllers that define the routes and actions for your API. These controllers handle HTTP requests, process the business logic using services from the Business Layer, and return responses.
