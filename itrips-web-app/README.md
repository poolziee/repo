
 						Project Technical Description

	As the project is already described at the VersioningTable.pdf, here is a more technical description of it.
	The application serves 1 main user types:
						-Booker
						-Hotel Manager

	At the end, I have to deploy a complete system for each of the above mentioned roles.
	My task is to develop a scalable Spring back-end RESTful API service with Angular front-end client.
	The initial goal of this projecct is to show how well I can implement a variety of new methods and technologies, such as:
		
		- Docker to manage my database, client, server and version control
	 	- Spring Security for authorization and authentication with JWT
		- Spring Data JPA to implement an ORM framework.
		- Web sockets to provide a persistent connection between the server and the client
		- Mapstruct library to map DTO objects to JPA entities, in order to provide the requested JSON result, based on the API endpoint
		- React to build a scalable one page application working with the API
	
	The final product is expected to meet all the requirements that are necessary for passing all learning outcomes.

 						    Build instructions
backend (Spring Boot):
	-open the InteliJ project 'iTrips' from the backend folder
	-host a mysql database with the specified settings from the application.properties file
	-run the application

frontend (React):
	-run the command 'npm start' inside the project 'itrips' from the frontend folder

                                                  Remote Info Links

Backlog:  https://poolziee.atlassian.net/jira/software/projects/IT/boards/1/backlog