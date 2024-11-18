##🌟 SystemManagementMovie
#SystemManagementMovie is a modular content management system designed to handle various content types, including videos, photos, and documents. It follows a modular monolithic architecture with clean coding practices using MediatR, CQRS, and Entity Framework Core.

##🚀 Features
✨ Upload and manage different types of content:
    🎥 Videos | 🖼 Photos | 📄 Documents

##✨ Organized structure using a Vertical Slice Pattern.
##✨ Static file storage and management in wwwroot.
##✨ Seamless database interaction via Entity Framework Core.
##✨ Clean request handling with MediatR (CQRS).

##📂 Project Structure
The project is divided into modules for better organization:

plaintext
Копировать код
##📁 Moduls.Content          # Handles content management (CRUD, static files)
##📁 Moduls.UserIdentity     # Manages user-related operations
##📁 Common                  # Shared components (DbContext, repositories, utilities)
##📁 wwwroot                 # Static file storage (videos, photos, etc.)
##🛠 Technologies Used
ASP.NET Core – Web API Framework
Entity Framework Core – ORM for database access
MediatR – Implements CQRS pattern
SQL Server – Relational database system
IIS/Static Files – Static file hosting
##📝 Getting Started
Prerequisites
Ensure you have the following installed on your system:

✔️ SQL Server
✔️ Postman (optional for testing)