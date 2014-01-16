Google Analytics Service Account Sample
=========
Console application written in C# to demonstrate accessing Google Analytics Data via a Service Account and OAuth 2.0. 
Judging from the documentation, it appears methods and libraries for accessing Google Apis change constantly,
but this application was working as of January 2014.

## Building the Application
In order to build the application, you will need to add values to the following keys in the App.config appSettings section:

1. ServiceAccountEmail: Created in the Google Developers Console under the application from which you will pull analytics
 data. Currently, you
navigate to APIs & auth > Credentials > OAuth > CREATE NEW CLIENT ID. You also need to add this address to the Admin section
of your Google Analytics dashboard under User Management for your application. The account will need "Read & Analyze" access. 
2. CertificateName: The name of the certificate you downloaded upon creation of the Service Account. I have configured
the application to look in the current user's Windows account under the (hidden) AppData/Roaming folder.
3. ApplicationName: The name you gave your application in the Google Developers Console.
4. ProfileId: This is the nine-digit number at the end of the URL on the Google Analytics page for your
 application, following the letter "p". Yes, I realize this is obscure, but I did not come across a straightforward way to find 
this attribute.


## MIT License

Copyright 2013 Chris Sherman under the [MIT License](LICENSE).
