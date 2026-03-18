# Order Management System

An enhanced Order Management System built with ASP.NET Core Web API. This system allows customers to place orders, view their order history, and enables administrators to manage orders, products, and invoices. It includes robust business logic for discounts, inventory management, and security via JWT authentication and Role-Based Access Control (RBAC).

## 🚀 Features

- **User Management:** Registration and login with JWT authentication.
- **Role-Based Access Control (RBAC):** Distinct permissions for `Admin` and `Customer` roles.
- **Order Processing:** Place orders, view order history, and track order status.
- **Inventory Management:** Real-time stock validation and updates.
- **Tiered Discounts:** Automatic discount application based on order total:
  - 5% off for orders over $100
  - 10% off for orders over $200
- **Invoicing:** Automatic invoice generation upon order placement.
- **Multiple Payment Methods:** Support for Credit Card, PayPal, etc.
- **Notifications:** Email notifications triggered on order status changes.
- **API Documentation:** Fully documented using Swagger/OpenAPI.

## 🛠 Tech Stack

- **Framework:** ASP.NET Core Web API
- **Database:** Entity Framework Core (In-Memory Database for simplicity)
- **Authentication:** JWT (JSON Web Tokens)
- **Documentation:** Swagger UI
- **Testing:** Unit Tests for critical business logic

## 📋 Prerequisites

- .NET 8.0 SDK or higher
- Visual Studio 2022 or VS Code
- Postman (optional, for API testing)

## ⚙️ Installation & Setup

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd OrderManagementSystem
