# KPA Json Import Angular .NET Api Project

##### Note seee the example.json for the correct json format

### Development Process

Due to the time constraint, I went ahead and used an ASP.NET Core with Angular project boilerplate from visual studio.  Went ahead and removed the components and controllers that are unnecessary. Added a database context that utilizes inmemory db. Added my ExampleApiController and the needed gets and post for this. 

My understanding was that we wanted to ingest a JSON file and parse.  So in order to parse it we’d need a model to map too. Added the ExampleModel which would represent the fields within the JSON file.  

Added a service to handle the Api Controllers logic and connect the controller to the database with the ExampleService. ExampleService contains ImportJsonData, which is able to parse a JSON file’s contents and map them to an array of ExampleModels or a singular ExampleModel.  This is where the parsing happens. 

Once I was ready with the backend and modified the angular Components to match my needs and added an example-data.service.ts file that would help facilitate any calls to my Api.

Had to learn a bit with the angular side as I typically work with React/Typescript.  Don’t think I fully utilize some of the patterns to their full potential.

### Future Improvements

I had added Swagger to try to figure out an issue, but maybe in the future having something for clearer documentation would be nice.  Also adding unit tests for the ExampleService would be preferable, mainly for the function ImportJsonData.  

Also adding validation, and better error handling would be a clear path to improving the project.  Also adding more functionality to the API, such as deletes, etc. 
