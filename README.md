## Overview
Task Management System is an application that helps users organize, track and manage personal and team tasks or projects effectively. The application provides intuitive and easy-to-use features to optimize workflow, increase productivity and improve collaboration among team members.
## Features
- Authentication & Authorization
- Department management
- Staff management
- Task management
- Notification 
## Built with
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) 
  ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Sever-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)
![TailwindCSS](https://img.shields.io/badge/tailwindcss-%2338B2AC.svg?style=for-the-badge&logo=tailwind-css&logoColor=white)
## Run project
### Requierment
- Dotnet version 8 or later
- Nodejs v20.15.0 or later
### Installation
1. Clone this project
```bash
git clone https://github.com/maivantai2003/Job_assignment_management.git
```
2. Run server (You can do this step on IDE like Visual Studio)
Change connectionString on Job_assignment_management.Api/appsettings.json
```json
{
"ConnectionStrings": {
    "Connection": "Data Source=[YOUR_SERVER_NAME];Initial Catalog=FinalAssignmentManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"
  }
```
If your use user-password server
```json
    "ConnectionStrings":  {
"Connection":  "Data Source=[YOUR_SERVER_NAME];Initial Catalog=TestJobAssignmentManagement;User Id=sa;Password=[YOUR_PASSWORD];Encrypt=True;Trust Server Certificate=True"

},
```

  Migration & run
```bash
#install dotnet-ef if you don not have
dotnet tool install --global dotnet-ef 

#migration
dotnet ef migrations add [migration-name] --project Job_assignment_management.Infrastructure/Job_assignment_management.Infrastructure.csproj --startup-project Job_assignment_management.Api/Job_assignment_management.Api.csproj -o Job_assignment_management.Infrastructure/Migrations
dotnet ef database update --project Job_assignment_management.Infrastructure/Job_assignment_management.Infrastructure.csproj --startup-project Job_assignment_management.Api/Job_assignment_management.Api.csproj

#restore pakages
dotnet restore

#build
dotnet build

#run
dotnet run
```
3. Run Client (Different Project)

Clone the `QLPB` project from GitHub:
```bash
git clone https://github.com/Khoadangdo123/QLPB.git
```

Install dependencies and run app:
```bash
cd client

npm install

npm run dev
```

## Demo
**Task management**
<img src="./demo_image/task.png" >
<img src="./demo_image/task2.png" >
<img src="./demo_image/create_task.png" >
<img src="./demo_image/gant.png" >
**Project management**
<img src="./demo_image/project.png" >
<img src="./demo_image/job_change.png" >
<img src="./demo_image/job_history.png" >
<img src="./demo_image/job_submitted.png" >
**Department management**
<img src="./demo_image/department.png" >
<img src="./demo_image/create_department.png" >
**Employee management**
<img src="./demo_image/staff.png" >
<img src="./demo_image/create-staff.png" >
**Account management**
<img src="./demo_image/account.png" >
<img src="./demo_image/authorization.png" >


#### Any question you can contact with us


Author:

| Leader          | Member         | Member         | Member            | Member           | Member         |
|-----------------|----------------|----------------|-------------------|------------------|----------------|
|Mai Văn Tài      | Lê Ngọc Giàu   | Đỗ Minh Quân   | Nguyễn Thanh Sang | Nguyễn Quốc Toàn | Trần Quốc Sĩ   |


#### Contact email:
- [vantai0812200@gmail.com](mailto:vantai0812200@gmail.com)
- [lengocgiau2k3@gmail.com](mailto:lengocgiau2k3@gmail.com)
- [dominhquan15623@gmail.com](mailto:dominhquan15623@gmail.com)
- [sangthanhnguyen2910@gmail.com](mailto:sangthanhnguyen2910@gmail.com)
- [ngquoctoan2001@gmail.com](mailto:ngquoctoan2001@gmail.com)
- [quocsi014@gmail.com](mailto:quocsi014@gmail.com)