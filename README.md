# FourthStar

## A Server side capstone for Nashville Software School, May 2019

##### Building an ASP.NET MVC Web Application using Visual Studio on Windows, using SQL Server as the database engine

##### Entity Framework/Identity Framework for user authentication

## Getting Started
The following instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

## Prerequisites
What things you need to install the software and how to install them

Visual Studio
Microsoft SQL Server Management Studio

## Installing & Running
A step by step series of examples that tell you how to get a development environment running

Fork a copy of this Repository

Download or Clone the Repo to your local machine

In appsettings.json,  replace the "connectionStrings" values as follows: 

```
"ConnectionStrings": {
   "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=FourthStar1;Trusted_Connection=True;MultipleActiveResultSets=true"
 }
 
```

Navigate to Tools menu at top of Visual Studio, then NuGet Package Manager, at the command prompt type: "add-migration Database", hit enter, then type "update-database" hit enter.  you can verify that you have a fresh database in SSMS

Look at the top bar and find the green arrow "play button", and make sure FourthStar1 is selected and click the arrow.  This should spin up the project.

Enjoy!

#### Built With
C#
.Net

### Author
Grady Robbins

### Acknowledgments
Special thanks to Andy Collins, Leah Hoeffling, Madi Peper, Emily Lemmon, Shu Sajid, Dejan Stepjanovic, Andy Herring, Brenda Long, Steve Brownlee, Brenda Long, Meg Ducharme, Jenna Solis, John Wark & Nashville Software School
