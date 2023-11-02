# CheapBuyWebStore
 This is a full webpage CRUD (Create/Read/Update/Delete) project containing a Next.js 14 React App, a .NET 8 API and SQL Server as relational database.
 
 The main page displays a list of Products. We are able to edit, delete and add new products.
 ![image](https://github.com/rogersampaio/CheapBuyWebStore/assets/21226627/2c1cd5ab-35ce-4ecb-8a7f-f46a30379190)

On the add/edit pages we can type the id, name, price (integer only) and select an existing brand (which was manually added to the database).

![image](https://github.com/rogersampaio/CheapBuyWebStore/assets/21226627/581292ec-de9b-456e-9615-99c953512c80)

On the API side, we have 6 endpoints, 1 to get all the brands and 5 to manipulate the Product.
![image](https://github.com/rogersampaio/CheapBuyWebStore/assets/21226627/e52d5236-5374-4b14-b829-8ebce8e0f1ca)

The database was created using .Net Migrations commands. The back-end was developed using code-first approach. There's also MS Unit Tests covering the API. Repository Pattern was added to remove the direct connection of the Database layer (EntityFramework) with the controller. It's also better to test as we can mock the repository. Unit of Work Pattern was not added as we don't have concurrency issues on this small example.

![image](https://github.com/rogersampaio/CheapBuyWebStore/assets/21226627/8ac00762-0f25-438b-a192-bd9184950255)



I'll try to keep it up-to-date with latest Next.js and .Net versions.
