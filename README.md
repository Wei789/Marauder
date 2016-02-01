# Marauder
3-Tier architecture with ASP.Net MVC 5 and Web API 2.2 using   
Entity Framework, Repository pattern and Unit of Work  
AutoMapper, Autofac, Nlog, PagedList, Quartz.net, Swagger.

<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Overview_of_a_three-tier_application_vectorVersion.svg/593px-Overview_of_a_three-tier_application_vectorVersion.svg.png">

===================

Project structure
-------------------
Presentation layer     - UI,bussiness flow  
Business logic layer  - business logic  
Data access layer  - Stored and retrieved from a database or file system
Task  -  Windows service
Help - Common library  
Tests - Unit test

dependency
-------------
PL depends on BLL  
BLL depends on DAL
