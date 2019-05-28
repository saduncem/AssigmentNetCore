Create an ASP.NET MVC or ASP.NET Core MVC application that allows end users to select their desired origin
& destination & departure date and lists available journeys for the specified query.

Wireframe & Design


The application consists of two pages

• Index (first wireframe)

• Journey Index (second wireframe)

Functional Requirements

Application-wide requirements

• All requests made to .com business API should be coded in the MVC application backend (no client
side requests should be made directly to .com business api, any client side requests implemented
should be made to the application backend. )
• A session should be created and maintained for each different end user visiting the application using the
GetSession method of .com business API. (see the API documentation) Each user should use his/her
own session information in the subsequent API requests made by the application on behalf of that user.
Index
• All possible bus locations available should fetched from the .com business API GetBusLocations
method (see the API documentation) and be listed as available origins and destinations.
• Default values for origin and destination fields should be set according to the default sorting provided
by GetBusLocations method response.
• Default value for the Departure Date field should be tomorrow.
• Users should be able to perform text-based search on origin and destination fields. The search keyword user
enters should be used in order to fetch related bus locations from the .com business API
GetBusLocations method (see the API documentation).
• Users should be able to swap selected origin and destination locations using the swap button shown in
the design.
• Quick selection buttons for setting the date to “Today” and “Tomorrow” should setting the value of
the departure date field properly.
• Following validations & limitations should be implemented with respective error messages.
o Users can not select same location as both origin and destination.
o Minimum valid date for departure date is Today.
• Search button should redirect user to the journey index page with the specified origin, destination
and departure date information.
• Last queried origin, destination and departure date values should be stored on client side. Whenever a user
revisits the application, existing origin, destination and departure date values should be set as default
values, if available.
