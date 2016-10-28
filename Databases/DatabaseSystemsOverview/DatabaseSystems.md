1.What database models do you know?
- Hierarchical database model
- Network model
- Relational model
- Entity–relationship model
- Object-oriented model

2.Which are the main functions performed by a Relational Database Management System (RDBMS)?

- Provides data to be stored in tables
- Persists data in the form of rows and columns
- Provides facility primary key, to uniquely identify the rows
- Creates indexes for quicker data retrieval
- Provides a virtual table creation in which sensitive data can be stored and simplified query can be applied.(views)
- Sharing a common column in two or more tables(primary key and foreign key)
- Provides multi user accessibility that can be controlled by individual users.

3.Define what is "table" in database terms.
- A table is a data structure used to organize information, just as it is on paper.
- It organizes the information about a single topic into rows and columns. 
- Each single piece of data is a field in the table. 
- A column consists of all the entries in a single field, such as the telephone numbers of all the customers. 
- Fields, in turn, are organized as records, which are complete sets of information, each of which comprises a row. 
- The process of normalization determines how data will be most effectively organized into tables.

4.Explain the difference between a primary and a foreign key.
- Primary key uniquely identify a record in the table.	
- Foreign key is a field in the table that is primary key in another table.
- Primary Key can't accept null values.	
- Foreign key can accept multiple null value.
- By default, Primary key is clustered index and data in the database table is physically organized in the sequence of clustered index.	
- Foreign key do not automatically create an index, clustered or non-clustered. You can manually create an index on foreign key.
- We can have only one Primary key in a table.	
- We can have more than one foreign key in a table.

5.Explain the different kinds of relationships between tables in relational databases.
- one-to-one 
  (Both tables can have only one record on either side of the relationship. Each primary key value relates to only one record in the related table.)
- one-to-many
  (The primary key table contains only one record that relates to none, one, or many records in the related table. You have only one mother, but your mother may have several children.)
- many-to-many
  (Each record in both tables can relate to any number of records in the other table. For instance, if you have several siblings, so do your siblings.)

6.When is a certain database schema normalized?
- Normalization is to design a database schema such that duplicate and redundant data is avoided. 

Advantages of normalization
1. Smaller database: By eliminating duplicate data, you will be able to reduce the overall size of the database.
2. Better performance:
	a. Narrow tables allows your tables to have less columns and allows you to fit more records per data page.
	b. Fewer indexes per table mean faster maintenance tasks such as index rebuilds.
	c. Only join tables that you need.

7.What are database integrity constraints and when are they used?
- Integrity constraints provide a way of ensuring that changes made to the database by authorized users do not result in a loss of data consistency.
- Data integrity is handled in a relational database through the concept of referential integrity.

8.Point out the pros and cons of using indexes in a database.
- The advantages of indexes are as follows:
	Their use in queries usually results in much better performance.
	Quickly retrieve (fetch) data.
	They can be used for sorting. A post-fetch-sort operation can be eliminated.
	Unique indexes guarantee uniquely identifiable records in the database.
-The disadvantages of indexes are as follows:
	Decrease performance on inserts, updates and deletes.
	Take up space (this increases with the number of fields used and the length of the fields).
	Some databases will monocase values in fields that are indexed.

9.What's the main purpose of the SQL language?
-SQL is a computer language for storing, manipulating and retrieving data stored in relational database.
-Allows users to:
	- access data in relational database management systems
	- describe the data
	- define the data in database and manipulate that data
	- embed within other languages using SQL modules, libraries & pre-compilers.
	- create and drop databases and tables.
	- create view, stored procedure, functions in a database.
	- set permissions on tables, procedures, and views

10.What are transactions used for?
- A transaction is a way of representing a state change. 
- It is a unit of work that is performed against a database.
- It is important to control transactions to ensure data integrity and to handle database errors.
- For example, if you are creating, updating or deleting a record from the table, then you are performing transaction on the table.

11.What is a NoSQL database?
- NoSQL is an approach to databases that represents a shift away from traditional RDBMS. 
- NoSQL databases do not rely on SQL structures and use more flexible data models.
- NoSQL is particularly useful for storing unstructured data, which is growing far more rapidly than structured data and does not fit the relational schemas of RDBMS. 
- Common types of unstructured data include: user and session data; 
					     chat, messaging, and log data; 
					     time series data such as IoT and device data; 
					     large objects such as video and images.
12.Explain the classical non-relational data models.
- A non-relational database is a database that does not incorporate the table/key model that RDBMS promote. 
  These kinds of databases require data manipulation techniques and processes designed to provide solutions to big data problems that big companies face.
  The most popular emerging non-relational database is called NoSQL (Not Only SQL).

13.Give few examples of NoSQL databases and their pros and cons.
- MongoDB, Redis, Cassandra, Scylla, MonetDB, Cloudata
- Pros:
	SQL is pretty standard and code can be reused across different databases
	Joins and other useful ways of mangling data for analytical queries are usually much better
	Transactions
	
 