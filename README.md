# E-Library Management System API

## Overview

The **E-Library Management System API** is a RESTful API built with **.NET 8** to manage an online library. Users can browse, borrow, and return books, while admins manage the catalog and user roles. The system includes **real-time notifications**, **user authentication** via **Google OAuth2**, and **advanced book search and filtering**.

## Features

### User Features:
- Browse, search, and filter books.
- Borrow and return books, with tracking of overdue items and fines.
- Real-time notifications for book availability and overdue status.
- Rate and review books.
- Personalized book recommendations.

### Admin Features:
- Manage the book catalog (add, update, delete books).
- View and manage user borrowing records.
- Track overdue items and generate reports.

## Technologies Used
- **Backend**: .NET 8, ASP.NET Core API
- **Database**: SQL Server
- **Authentication**: Google OAuth2, Identity Framework
- **Real-Time Communication**: SignalR
- **ORM**: Entity Framework Core
- **API Documentation**: Swagger

## Setup Instructions

### Prerequisites:
- .NET 8 SDK
- SQL Server (local or cloud-based)
- Google Developer Account for OAuth2 authentication

