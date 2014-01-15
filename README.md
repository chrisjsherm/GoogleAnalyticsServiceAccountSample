Google Analytics Service Account Sample
=========
Console application written in C# to demonstrate accessing Google Analytics Data via a Service Account and OAuth 2.0. 
Judging from the documentation, it appears methods and libraries for accessing Google Apis change constantly,
but this application was working as of January 2014.

## Building the Application
In order to build the application, you will need to add an appSettings section to the App.config file with the following
keys and their associated values:

1. ServiceAccountEmail: Created in the Google Developers Console under the application from which you will pull analytics
 data. Currently, you
navigate to APIs & auth > Credentials > OAuth > CREATE NEW CLIENT ID
2. ApplicationName: Name you gave your application in the Google Developers Console.
3. ProfileId: Currently this is the nine-digit number at the end of the URL on the Google Analytics page for your
 application, following the letter "p".


## MIT License

Copyright 2013 Virginia Tech under the [MIT License](LICENSE).
