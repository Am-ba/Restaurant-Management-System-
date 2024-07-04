# Restaurant Management System

This C# application is designed to manage a restaurant's menu and orders. The program features both an admin section for managing the menu and a customer section for placing and viewing orders.

## Features

### Admin Section
- **View total sales**: Displays the total sales.
- **Add new items in the order menu**: Allows the admin to add new food items to the menu.
- **Delete items from the order menu**: Allows the admin to delete food items from the menu.
- **Display order menu**: Displays the current food items on the menu.

### Customer Section
- **Place your order**: Allows customers to place orders from the menu.
- **View your ordered items**: Displays the items the customer has ordered.
- **Delete an item from order**: Allows customers to remove an item from their order.
- **Display final bill**: Shows the final bill for the customer's order.

## Class and Methods Overview

### Class: Node
Represents a food item or an order with the following attributes:
- `foodname`: Name of the food item.
- `quantity`: Quantity of the food item.
- `price`: Price of the food item.
- `data`: Unique identifier for the food item.
- `prev`: Pointer to the previous node.
- `next`: Pointer to the next node.

### Methods
- **AdminMenu()**: Displays the admin menu.
- **CustomerMenu()**: Displays the customer menu.
- **CreateAdmin(Node head, int data, string foodname, float price)**: Adds a new food item to the admin menu.
- **CreateCustomer(Node head, int data, int quantity)**: Creates a new order for the customer.
- **DisplayList(Node head)**: Displays the list of food items or orders.
- **TotalSales(int data, int quantity)**: Calculates the total sales.
- **CalculateTotalSales()**: Aggregates the total sales.
- **Delete(int data, Node head, Node tail)**: Deletes a node from a list.
- **DeleteAdmin()**: Deletes a food item from the admin menu.
- **DeleteCustomer()**: Deletes an item from the customer's order.
- **DisplayBill()**: Displays the final bill for the customer.
- **DeleteList(Node head)**: Deletes the entire list.
- **Admin()**: Handles the admin operations.
- **Customer()**: Handles the customer operations.
- **MainMenu()**: Displays the main menu.
- **Main(string[] args)**: The entry point of the program.

## How to Run

1. **Compile the code** using a C# compiler.
2. **Run the executable** generated after compilation.
3. **Follow the on-screen instructions** to navigate through the admin and customer sections.

This program uses a linked list to manage menu items and customer orders, providing an efficient way to dynamically add, delete, and display items.
