# NU Entertainment _02/07/2020_

## By _**Nina Potrbich & Uriel Gonzalez**_

### Description

NUE is a live entertainment company that produces and promotes private parties, concerts, music festivals and more. We created a website where general public can navagivate the site and see the current events detail and information about our company. User can log in through NUE or Google, Facebook and Twitter.

Once users log in through social media, they can also comment on events and share their comment along wiht the event site link. Their comments will be displayed on both our website and their social media platform. Users can also request an RSVP confirmation via SMS. The platform we used for SMS is called Twilio.

The web app is built in C#, Html, CSS and Bootstrap. We used data from all the social media incorporated through each of their developer's platform to get user authentication, access to their site, etc. The videos on the main page are embeded links from YouTube with specific settings. Users can create new events on the website but there are default events are static content in the application database context file.

## Setup/Installation Requirements

* This application requires MySQL.

1. Clone this repository:

  ```sh
  1. git clone https://github.com/Ugonz86/TeamProject.git
  2. cd TeamProject/WebApp2
  3. dotnet restore
  4. dotnet watch run
  ```

2. Open the App Settings file (TeamProject/WebAp2/appsettings.json) and ensure that the MySQL username and password matches your MySQL credentials.

## Database Setup

```sh
* Delete Migrations first then run the following in command line:
1. dotnet restore
2. dotnet ef migrations add Initial
3. dotnet ef database update

```

## Known Bugs

* No bugs at this moment.

## Technologies Used

* C# / .NET / ASP.NET Core MVC / HTML / My SQL / Entity / API / 

## Support and contact details

_Please contact me with questions and comments: ugonzalez86@gmail.com_

### License

* *MIT License*

Copyright (c) 2020 **_Nina Potrebich & Uriel Gonzalez_**