Shop-Smart
=========
Welcome to the **ShopSmart** Page.
![Logo](https://raw.github.com/turner11/ShopSmart/master/Images/ShopSmart_Logo.PNG)

For Any consumer
who Shop at a supermarket
the ShopSmart
is a Tool
that Saves him time.

For more details about SOW, please refer to the link below.

This is part of the Software engineering project. [cours page](https://github.com/jce-il/se-class)


## קישורים

* [Project vision - חזון הפרויקט](SOW)
* [Project Inception - אתחול הפרויקט](https://github.com/turner11/ShopSmart/wiki/Inception)
* [SRS - מפרט דרישות תכנה](https://github.com/turner11/ShopSmart/wiki/SRS)
* [SDS - מפרט תיכון תכנה](https://github.com/turner11/ShopSmart/wiki/1.-SDS---%D7%9E%D7%A4%D7%A8%D7%98-%D7%AA%D7%99%D7%9B%D7%95%D7%9F-%D7%AA%D7%9B%D7%A0%D7%94)
* [Main risk handling](https://github.com/turner11/ShopSmart/wiki/Main-risk-handling)
* [Client Relations](https://github.com/turner11/ShopSmart/wiki/Client-relations)
* [Tutorial for working environment](https://github.com/turner11/ShopSmart/wiki/Environment-Tutorial)
* [Shop-Smart Code](https://github.com/turner11/ShopSmart/tree/master/Code/ShopSmart-Solution)
* [Shop-Smart Installaion](https://github.com/turner11/ShopSmart/tree/master/Installation_And_usage)
* [User Documentation](https://github.com/turner11/ShopSmart/wiki/User Documentation)
* [Iteration 1](https://github.com/turner11/ShopSmart/wiki/Iteration1)
* [Iteration 2](https://github.com/turner11/ShopSmart/wiki/Iteration2)
* [Iteration 3](https://github.com/turner11/ShopSmart/wiki/Iteration3)
* [Iteration 4](https://github.com/turner11/ShopSmart/wiki/Iteration4)
 
## Developers documentation - תיעוד למפתחים

#Repository URL:
https://github.com/turner11/ShopSmart/ 

 You may check out the latest version (or any other version...) using github tools (e.g. Github for windows / Github Shell) .

#License:  
This project is open source under BSD licensing, with any restrictions JCE Azrieli college might have. 

#Structure: 
The system is built of a client and a server.
The Client has a GUI module and a communication component.
The server holds:
 1. Another communication component which "talks" with client
 2. A business logic module.
 3. An SQL Server.
For communicating with DB we are using Entity Framework.

###Note: 
The software relays on a database. In order to build the database, you can run the script available [here](https://raw.github.com/turner11/ShopSmart/master/Code/BuildDbScript.sql) on an MS SQL Server
This script assumes you do not have an existing ShopSmart db on your server

#Building the program
For building the program, pull the solution out of repository. The built sequence is part of the sln file.

# Testing
This is not implemented yet. 
The plan is to have a test project with unit tests.

#New versions
For new new versions the following is required:
 1. Documenting all changes.
 2. If applicable: creating / modifying Unit test for changes.
 3. Committing all changes (and document commit).
 4. Syncing commit with github.

#Github issues
For adding Issues , please go to the [issues page](https://github.com/turner11/ShopSmart/issues?state=open).
If you want to work on an open issue, please add the request in the bug note, or directly contact us on develop@smartshop.com

#General
You might also be interested in the [User Documentation](https://github.com/turner11/ShopSmart/wiki/User%20Documentation) page and the [Shop-Smart Binaries](https://github.com/turner11/ShopSmart/blob/master/Code/ShopSmart-Solution/Deploy/Deploy.zip?raw=true) (to be implemented...)

#Progress
![Issue Graph](https://raw.github.com/turner11/ShopSmart/master/Iteration3/Graph.PNG)
