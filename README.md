# NU Entertainment _02/07/2020_

## By _**Nina Potrebich & Uriel Gonzalez**_

### Description

NUE is a live entertainment company that produces and promotes private parties, concerts, music festivals and more. We created a website where general public can navagivate the site and see the current events detail and information about our company. User can log in through NUE or Google, Facebook and Twitter.

Once users log in through social media, they can also comment on events and share their comment along wiht the event site link. Their comments will be displayed on both our website and their social media platform. Users can also request an RSVP confirmation via SMS. The platform we used for SMS is called Twilio.

The web app is built in C#, Html, CSS and Bootstrap. We used data from all the social media incorporated through each of their developer's platform to get user authentication, access to their site, etc. The videos on the main page are embeded links from YouTube with specific settings. Users can create new events on the website but there are default events are static content in the application database context file.

### Prerequisites

* .NET
* MySqlServer
* Twitter app is not working with localhost names. Set name for localhost using instructions: https://bowerwebsolutions.com/how-to-edit-your-local-host-file-for-testing-web-sites/ . Save the name you selected (for example: www.myproject.com).
* Google authentication setting (for more explanation use [reference](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-3.1)):
    ** Create a google account if you haven't.
    ** Navigate to [Integrating Google Sign-In into your web app](https://developers.google.com/identity/sign-in/web/devconsole-project) and select CONFIGURE A PROJECT.
    ** In the Configure your OAuth client dialog, select Web server.
    ** In the Authorized redirect URIs text entry box, set the redirect URIs. If you want to use authentication via Twitter, include also redirect link selected name. For example, https://localhost:5001/signin-google , https://www.myproject.com/sigin-google .
    ** Save the Client ID and Client Secret.
* Facebook authentication setting (for more explanation use [reference](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/facebook-logins?view=aspnetcore-3.1)):
    ** Navigate to the Facebook Developers app page and sign in. If you don't already have a Facebook account, use the Sign up for Facebook link on the login page to create one. Once you have a Facebook account, follow the instructions to register as a Facebook Developer.
    ** From the My Apps menu select Create App to create a new App ID.
    ** Fill out the form and tap the Create App ID button.
    ** On the new App card, select Add a Product. On the Facebook Login card, click Set Up.
    ** The Quickstart wizard launches with Choose a Platform as the first page. Bypass the wizard for now by clicking the FaceBook Login Settings link in the menu on the lower left.
    ** You are presented with the Client OAuth Settings page:
    ** Enter your development URI with /signin-facebook appended into the Valid OAuth Redirect URIs field (for example: https://localhost:5001/signin-facebook, https://www.myproject.com/signin-facebook). The Facebook authentication configured later in this tutorial will automatically handle requests at /signin-facebook route to implement the OAuth flow.
    ** Click Save Changes.
    ** Save your App ID and your App Secret.
* Twitter authentication setting (for more explanation use [reference](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/twitter-logins?view=aspnetcore-3.1))
    ** Navigate to https://apps.twitter.com/ and sign in. If you don't already have a Twitter account, use the Sign up now link to create one.
    ** Select Create an app. Fill out the App name, Application description and public Website URI (this can be temporary until you register the domain name).
    ** Enter your development URI with /signin-twitter appended into the Callback URLs field (for example: https://www.myproject.com/signin-twitter). 
    ** In your project page go to Keys and Tokens tab. Save API key and API secret key.
* Twilio setting:
    ** Go to https://www.twilio.com/ . 
    ** Create account and activate free trial.
    ** Create a new project.
    ** Get free trial number. 
    ** Save account SID and token.

## Setup/Installation Requirements

1. Clone this repository:
```
$ git clone url-of-this-repo
```
2. Start MySql server by using command:
```
mysql start
```
3. Access MySql by executing the command (use your username and password):
```
mysql -uroot -pepicodus
```
4. Go to the project folder (/NUE). Save authentication settings in Secret Manager:
```
dotnet user-secrets set "Authentication:Google:ClientId" "<client id>"
dotnet user-secrets set "Authentication:Google:ClientSecret" "<client secret>"

dotnet user-secrets set Authentication:Facebook:AppId <app-id>
dotnet user-secrets set Authentication:Facebook:AppSecret <app-secret>

dotnet user-secrets set Authentication:Twitter:ConsumerAPIKey <Key>
dotnet user-secrets set Authentication:Twitter:ConsumerSecret <Secret>
```
5. Create in folder Models file EnvironmentVariables.cs and use your Twilio settings:
```
namespace NUE.Models
{
    public static class EnvironmentVariables
    {
        public static string TWILIO_ACCOUNT_SID = "your_twilio_SID";
        public static string TWILIO_AUTH_TOKEN = "your_twilio_token";
    }
}
```
6. Update database using command
```
dotnet ef database update
```
7. Using console of your choice build and run program in Project directory:
```
dotnet run
```
8. Open by browser of your choice :  https://localhost:5001/ (without twitter auth)  or https://www.myproject.com/.

## Specifications

* User is able to see available events on the main page.
* User is able to see available events on the events page.
* User is able to get information about particular event.
* User is able to authenticate and login using their username and password or using social networks (Facebook, Google, Twitter).
* Authorized user is able to RVSP for event. User is able to edit, delete their RVSP.
* Authorized user is able to get confirmation text message on specified phone number.
* Authorized user is able to add, update, delete events.
* Authorized user is able to leave comments in events. Each comment includes name, message body, time, default image (or profile image from social network).
* Authorized is able to go to their account and update their personal information. User is able to connect multiple social networks to one email (in their account).

## Known Bugs

* No bugs at this moment.

## Technologies Used

* C# / .NET / ASP.NET Core MVC / HTML / My SQL / Entity / API / 

## Support and contact details

_Please contact me with questions and comments: ugonzalez86@gmail.com, potrebich@gmail.com_

### License

* *MIT License*

Copyright (c) 2020 **_Nina Potrebich & Uriel Gonzalez_**
