# Marauder
3-Tier architecture with ASP.Net MVC using   
Entity Framework, Repository pattern and Unit of Work  
AutoMapper, Autofac, Nlog, PagedList.

===================

PL   - Presentation layer  
BLL  - Business logic layer    
DAL  - Data access layer  

Project structure
-------------------
PL   - UI,bussiness flow  
BLL  - business logic  
DAL  - Data access  
Help - Common library  
Tests - Unit test

dependency
-------------
PL -> BLL  
BLL -> DAL
