<div align="center">
  
# **Load-Balancer**
###### Project created for the course "Elements of Software Development" at the Faculty of Technical Sciences in Novi Sad
  
</div>

### Collaborators:

| Index Number | First Name | Last Name |
|--------------|------------|-----------|
|PR 60/2020    |Luka        |Đelić      |
|PR 68/2020    |Stefan      |Milovanović|
|PR 69/2020    |Momčilo     |Micić      |
|PR 76/2020    |Dušan       |Paripović  |

## General Information

A load balancer in computing is a service that ensures even distribution of tasks across worker units. In our implementation, we will simulate data entry into a database, the flow of which will be monitored by the Load Balancer.

### Used Technologies

- The project was created using the .NET Framework, so you will need [Visual Studio 2017 or newer](https://visualstudio.microsoft.com/free-developer-offers/) with the .NET Framework development tools installed. The project includes 3 console applications that communicate with each other using the WCF Framework to establish communication over the local network.
- For the database, we used [Oracle RDBMS 11g Express Edition](https://www.oracle.com/database/technologies/xe-prior-release-downloads.html), and SQLDeveloper was used for monitoring the data.
- The database was implemented using the ADO_NET API to connect C# applications with various database management systems and other data sources.

## Operation Principle

The operation principle of all four components is described: Writer, Load Balancer, Worker, and Reader. The Workers and Load Balancer have their interfaces to communicate with their superior components via the WCF Framework.

Additionally, each component has a Logger that monitors and logs events during the program’s execution. Both the Load Balancer and Worker have their own separate relational databases where they write to or read from.

Detailed information about the main components and the data structures they operate with is provided below.

<details>
  <summary> Load Balancer Components </summary>
  
## Writer
  
  This component simulates incoming user requests by generating a random Item every two seconds and sending it to the Load Balancer. A schematic representation of the Item class is shown below:
  
  |Item|
  |----|
  |Code|
  |Value|
  
  **Code** can have one of the following values:
  + CODE_ANALOG
  + CODE_DIGITAL
  + CODE_CUSTOM
  + CODE_LIMITSET
  + CODE_SINGLENODE
  + CODE_MULTIPLENODE
  + CODE_CONSUMER
  + CODE_SOURCE
  
  **Value** is of type int and can range from 1 to 10000.
  
## Load Balancer
  
The Load Balancer distributes the received Item to one of its Descriptions. One Description corresponds to one dataset, so the Item’s CODE determines which dataset and Description it belongs to. After a certain period, the Load Balancer sends a Description with all its Items to a Worker, selected by the Round Robin principle.
  
|Description|
|-----------|
|ID|
|List of Items whose CODE matches the Dataset|
|Dataset|
  
## Worker

Upon receiving a Description, the Worker repackages the Items into WorkerProperties, stores them in a Historical Collection list, and waits for both CODEs that match one dataset. After both CODEs arrive, the first pair of WorkerProperties from the Historical Collection is taken, and the data is written into the database.
  
|CollectionDescription|
|---------------------|
|ID|
|Dataset|
|HistoricalCollection (repackaged list of Items from the Description)|
  
## Reader
  
The Reader component is used for reading and displaying data from the database. It allows you to retrieve Items by a specific code within a certain time interval from a particular Worker. This component is implemented in the Worker application menu (since it communicates with it).

</details>

## Installation / Usage Instructions

In the main folder, there is a file *Common.sln* that should be opened in Visual Studio. The console applications for the Client, Worker, and Load Balancer can be run in any order, as our implementation allows safe execution. Once a successful connection is established between the applications, user interaction in the Client application is enabled.

In the Client, it is possible to enable/disable the generation and sending of Items to the Load Balancer, as well as to increase or decrease the number of Workers.

The Worker application includes the aforementioned Reader, through which you can print data from a specific Worker, for a given CODE in a certain time interval.
