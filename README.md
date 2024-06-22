# PE02 - Coffee Farmers (Semester 2 - Apr 2024)

## Intro

This online coffee store was made using the ASP.NET Core MVC framework. Entity Framework Core was used for CRUD operations.

## Learning objectives

- Create database relationships with Entity Framework using a code-first approach
- Use of Fluent API for attribute and property configuration
- LINQ for mapping to ViewModel objects and filtering search results
- Working with separate areas (user/admin)
- Use of forms and custom server-side form validation
- Learn to use and manipulate routes and their parameters
- Create Partial Views and ViewComponents
- Use Session State to store user and cart data
- Dependency injection

## Account login credentials

### User account:
- Username: bob | Password: password

### Admin account:
- Username: jders | Password: password

## Shopping Cart
The application allows signed in users to add to cart and proceed to checkout.

## Order Manager and email recipient
Admin accounts will be able to confirm unshipped orders via the Order Manager option in the Admin Portal.
Note that this will trigger an email to be sent to the email address currently hard coded in: **Area: Admin > Controller: Order > Action: Confirm**. To test this feature, please change the string variable "recipientEmail" on **line 49** to the desired email address.
