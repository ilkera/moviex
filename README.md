# Cinerch Web App


Cinerch is a web application that shows on a map where movies have been filmed in San Francisco. User is able to filter the view using auto completion search.

##### Chosen Track
Full Stack (BackEnd + FrontEnd)

##### Front-End
Technologies used:  Backbone.js, Underscore, JQuery/HTML5/CSS

##### Back-End
Technologies used: ASP.NET WEB API, MSSQL Server 


##### Where is Cinerch Hosted ? 
Web site and web service are hosted on Windows Azure. Here is the endpoints;

* Cinerch Web Host: http://cinerchweb.azurewebsites.net
* Cinerch Web Service: http://cinerchwebservice.azurewebsites.net

##### Things got done for v1:
	• Functional web site that meets requirements.
	• User can search movie and filter it using the view. (Autocomplete)
	• User can see movie locations on map
    	• Clicking on a marker on google map shows a fun fact about a location (if location has a fun fact)
	• Single web page (index.html) with MVC pattern applied
    	• Used underscore templates in index.html to dynamically generate content based on model
	• API Documentation
	• Javascript/CSS minified (Production)
	• Static files (JS, CSS, Images) are compressed and cached
	• LatLng batching - used [this site](http://www.findlatitudeandlongitude.com/batch-geocode/) geocode all the locations listed in [SF Data](https://data.sfgov.org/Arts-Culture-and-Recreation-/Film-Locations-in-San-Francisco/yitu-d5am)
	• Database scripts (create database, table schema generation, and data insertion scripts)
  	• Testing for XSS

##### Things left for v2 (Missing):
	•  Movie Details and Images (using rottentomatoes/imdb API) : Nice to see movie pictures and other details such as Actor information or photos from location/or get directions.

	•  Unit and functional test automation: Unit testing and functional testing left for v2 as needed to ramp up on JS unit testing frameworks such as Qunit or Selenium (functional)

	•  Logging: Used console.log aggressively while testing. Need to implement a global logger on the client side.

	•  Geocoding (Currently map shows San Francisco by default on startup) Considered using geocoding to find out user location and set maps location based on user location. 
   
	• Considered using [Haversine Algorithm](http://en.wikipedia.org/wiki/Haversine_formula) to find out the closest movie locations to the user based on user's current location

	• Loading underscore templates from external html files and enable caching for them

	•  Memcache: Each request to server goes to database whenever client requests data from server (movie info, movie locations). Memcache is required to avoid these costly calls.

	•  Autocomplete currently fetches all movies (first request) from web service and caches it in the client. Move this logic to server with paginated data when # of movie increases
    
		• Mobile web site (CSS resize)
		• Web API Key and versioning 
		• Instrumentation
		• Globalization/Localization 

##### Technical Choices
	• For front-end, Backbone.js is chosen as it's a very lightweight JS MVC framework and also recommended by challenge.

	•  For web API, ASP.NET Web API is chosen as I have the familiarity with C# and ASP.NET. 

	•  For back-end, relational database (SQL) is chosen as we need a transactional data and querying by index. (movieId).

	•  Used an external Jquery autocomplete library since I didn't have experience too much with JQuery. (Source:[JQuery AutoComplete]( http://www.devbridge.com/projects/autocomplete/jquery/)

	•  I parsed the movie data and did a batch geocode on all locations. The other option would be on querying geocoding service on-demand which is an extra call to an external API. Also, a cache is required on server to serve the longitude and latitude if available upon request. Therefore, server doesn't hit the external service all the time. However, pre-batched latitude and longitude was a better decision to avoid extra calls and caching setup/testing cost. 


####Code files that I wrote (skipping generated code files)
	1. Web Service: ${ROOT}\moviex\src\server\Server\MovieWebService\Controllers
		○ MovieController.cs
		○ MovieLocationController.cs
	2. Model (Core): ${ROOT}\moviex\src\server\Server\Model
		○ Movie.cs
		○ Location.cs
	3. ServiceModel: ${ROOT}\moviex\src\server\Server\ServiceModel
		○ Configuration.cs
		○ IMovieDataStore.cs
		○ IMovieLocationRepository.cs
		○ IMovieRepository.cs
		○ MovieDataStore.cs
		○ MovieDSchemaConstants.cs
		○ MovieLocationRepository.cs
		○ MovieRepository.cs
	4. Movie.Web
		○ Index.html
		○ Styles\Style.css
		○ Scripts\cinerch.model.js
		○ Scripts\cinerch.views.js
		○ Scripts\cinerch.config.js
	5. SQL Scripts
		○ Schema_create.sql
		○ Movies.sql
		○ Locations.sql
		○ Movie_locations.sql
	
####Experience:
######Timeframe: Took 4 days

I had limited experience with front-end development especially with Javascript/CSS. The majority of the time has been spent on learning new framework (Backbone.js) and JQuery.  I was totally new to those framework but it was a wonderful experience for me. I have hit many major/minor issues and was able to solve them via playing with code and researching. I have some experience with Python language. I started developing the web API with Python when I first started the project. I found [Falcon Framework](http://falconframework.org/) to be a very light-weight, easy to learn WSGI framework to learn. However, it also took 1 day for me to learn all those APIs and test them. Then, I switched to ASP.NET where I am more comfortable with. I was more rapidly developing compared to Python. This helped me to focus focus on mostly front-end UI problems. Although, I have left a lot of things for v2, I think v1 is a good start and can be iterated over. 

I learned a ton! It was a great hack and learning experience!

######For questions: Send me email! Ilker.acar@gmail.com 

