# FourthStar

## A Server side capstone for Nashville Software School, May 2019

##### Building an ASP.NET MVC Web Application using Visual Studio on Windows, using SQL Server as the database engine

##### Entity Framework/Identity Framework for user authentication

##### ERD 
Here is a link to the google document with my ERD:

https://docs.google.com/document/d/1NguTM-2AqzTCaf0kycH6MYCr-eL9xfmL5ga5PHqujW4/edit?usp=sharing

## Getting Started
The following instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

## Prerequisites
What things you need to install the software and how to install them

- [ ] Visual Studio
- [ ] Microsoft SQL Server Management Studio

## Installing & Running
A step by step series of examples that tell you how to get a development environment running

1. Fork a copy of this Repository

1. Download or Clone the Repo to your local machine

1. In appsettings.json,  verify that the "ConnectionStrings" values are as follows: 

```
"ConnectionStrings": {
   "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=FourthStar1;Trusted_Connection=True;MultipleActiveResultSets=true"
 }
 
```

1. Navigate to Tools menu at top of Visual Studio, then NuGet Package Manager, at the command prompt type: "add-migration Database", hit enter, then type "update-database" hit enter.  Verify that you have a fresh database in SSMS

1. Look at the top bar of Visual Studio and find the green arrow "play button", and make sure FourthStar1 is selected and click the arrow.  This should spin up the project.

Enjoy!

#### Built With
C#
.Net

### Author
Grady Robbins

### Acknowledgments
Special thanks to Julie Jones, Andy Collins, Jisie David, Brenda Long, Steve 'Coach' Brownlee, Meg Ducharme, Leah Hoeffling, Madi Peper, Emily Lemmon, Shu Sajid, Dejan Stepjanovic, Andrew Herring, Jenna Solis (Mahalo), John Wark & Nashville Software School Cohorts 25, 26, 27, 28 and 29!
