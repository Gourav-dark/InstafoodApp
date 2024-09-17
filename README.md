# InstaFood - Blazor Web Assembly Food Delivery Application

## Overview
InstaFood is a sophisticated food delivery application developed using Blazor Web Assembly and .NET 8. The application caters to both customers and administrators, providing a seamless and efficient platform for ordering and managing food products.

## Features

### Home Page
- **Product Listing**: Displays a comprehensive list of all available products.
- **Customer Options**: Allows customers (both authenticated and non-authenticated) to add products to their cart.
- **Purchase Options**: "Buy" and "Add to Cart" functionalities for customers.
- **Admin Controls**: Enables administrators to delete products, toggle their availability status, and add new products directly from the home page.
- **Search Functionality**: Provides a search bar for users to find products by name.

### Authentication
- **Login and Registration**: Dedicated pages for user login and registration.
- **Admin Registration**: Requires an access key for enhanced security during admin registration.

### Customer Pages
- **Cart Page**: Displays items added to the cart by the customer.
- **Order Page**: Shows all orders placed by the customer, along with their statuses.

### Admin Pages
- **Order Management Page**: Allows administrators to view and update the status of orders.

## Technical Stack
- **Frontend**: Blazor Web Assembly
- **Backend**: .NET 8 with Web API
- **Database**: SQL Server

## User Roles
- **Customer**: Can browse products, add items to the cart, place orders, and view order history.
- **Admin**: Can manage products, view and update order statuses, and perform other administrative tasks.

## Additional Notes
- **Responsive Design**: Ensure the application is responsive and provides a seamless experience across various devices.
- **Security**: Implement best practices for authentication and data handling to ensure user data is secure.
- **Scalability**: Design the application to handle a large number of products and orders efficiently.
