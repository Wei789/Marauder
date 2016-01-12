# Marauder
3-Tier architecture with ASP.Net MVC using   
Entity Framework, Generic Repository pattern and Unit of Work  
AutoMapper, Autofac, Nlog, PagedList.

===================

PL   - UI,bussiness flow  
BLL  - business logic  
DAL  - DB access  

(Help - Common library)

Project structure
-------------------
PL   - UI,bussiness flow  
BLL  - business logic  
DAL  - DB access  
Help - Common library  
Tests - Unit test

dependency
-------------
PL -> BLL  
BLL -> DAL
