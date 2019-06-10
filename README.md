# Smart House

## Project Objectives

We were taske to create a complete and fully functional web based project with database intacted. The project was to cover two months period of development in four people group. After initial brainstorming we settled to create a smarthouse app allowing the user to directly monitor and change smat device states of real life devices. User should be able to access the app both through mobile app and website. As the project continued we chose to implement virtual house model in Unity to better ensure control over devices and to freely change and update their states.

## Diagram of dependencies between system modules

![alt text](https://raw.githubusercontent.com/Korag/Smart_House/master/SmartHouse_API/Diagrams/smarthouse_components_diagram.png "Diagram of modules dependencies")

## Diagram of database collections

![alt text](https://github.com/Korag/Smart_House/blob/master/SmartHouse_API/Diagrams/smarthouse_database_diagram.png "Diagram of database collections")

## Diagram of app draft

![alt text](https://github.com/Korag/Smart_House/blob/master/SmartHouse_API/Diagrams/appdraft.png "Diagram of app draft
")

## Authorization MongoDB provider

In order to support the authorization and identification, which includes the user's login, Asp.Identity was used. Our project uses a non-relational MongoDB database, which is why standard Asp.Identity mechanisms working with SQL database had to be modified to work with MongoDB. For this purpose, the "MongoDB.AspNet.Identity" provider created by the "maxiomtech" user was used. This provider enables the use of the benefits of the Asp.Identity package in combination with the use of MongoDB. Instead of using relational database tables to store identity and attribution data, collections of non-relational MongoDB database are used.

Link to the project: 
https://github.com/maxiomtech/MongoDB.AspNet.Identity

## Application Interface

The application interface is made in ASP.NET Framework MVC 5.2 Web Api. Individual methods of the SmartDevicesController are protected against unauthorized access by Asp.Identity using the MongoDB provider. Documentation of individual API methods is included in SwaggerUI, which was attached to the project. 

The documentation can be found at the address: 
https://smarthouseapiswagger.azurewebsites.net/swagger/ui/index#/SmartDevices

## Technology used

Overall in our project we used follownig nuget packages:

- All of the preinstalled ASP.Net MVC packages
- Mongo DB nuget packages v2.80

Apart from visual packeges to create virtual house model and visualisation we used:
- Blender 2.8 for modelling assets
- Unity 2018.3.9f1 for visualisation

In FrontEnd Part
- Vue.js
- Vuetify
- Vuex

There's probably more I missed so ...

## Contact us if you have any questions

If you want to contact us, you can do so via github or email address vertisio.com@gmail.com.

If you would like to develop our project and add new functionalities, we are open to any suggestions. We will consider every push to the remote repository

## About Vertisio group

We are a group of students currently consisting of 4 members. 


+ Kamil (`KaHa`): Unity / Backend developer [Unity scripts / BDD testing specialist]
+ Łukasz (`Korag`): Web Api / Backend developer [MongoDB / API / Azure deployment specialist / UnitTests and IntegrationTests]
+ Konrad(`Whoudini`): Graphic / Frontend developer [Unity modelling]
+ Bartosz(`Owner`): Frontend developer [Vue.js scripting specialist / Structure of website]

Project was finished in less then 2 months. Despite the tasking much of work was done interchangable beetween team members.

_Vertisio Team 2019_
