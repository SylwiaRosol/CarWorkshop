🚗 Car Workshop

Car Workshop is a web application designed for browsing and managing car workshops. It allows users to view, add, and edit workshop information in a structured and user-friendly way.

📌 Features
-> Browse available car workshops
-> Add new workshops
-> Edit existing workshop data
-> Pre-seeded database with sample data
-> Data validation before saving
-> Role-based access control:
-> User
-> Moderator

🛠️ Technologies
- ASP.NET Core
- ASP.NET MVC
- ASP.NET Identity
- Entity Framework Core
- FluentValidation
- CQRS (Command Query Responsibility Segregation)
  
🧪 Testing
-> Unit tests implemented using xUnit
-> API endpoints tested with Postman

⚙️ CI/CD
Integrated with GitHub Actions for automated build and testing

🗄️ Database
Data is validated before being stored
Initial data is seeded automatically

🚀 Getting Started

Clone the repository:

git clone https://github.com/your-username/car-workshop.git

Navigate to the project folder:

cd car-workshop
Update database connection string in appsettings.json

Apply migrations:

dotnet ef database update

Run the application:

dotnet run

🔐 Authentication & Authorization

The application uses ASP.NET Identity for authentication and role management.

Available roles:
User – can browse workshops
Moderator – can manage (add/edit) workshops

📄 Notes
The project follows CQRS architecture for better separation of concerns
Clean and scalable structure
Ready for deployment and further extension
