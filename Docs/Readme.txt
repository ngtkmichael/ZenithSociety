•	First Name		: Thow Kwon Michael
•	Last Name		: Ng Tat Mew
•	Student number	: A01003377
•	Email address	: ng.tkmichael@yahoo.ca

•	What you have and what you have not completed
1. Create ZenithSociety solution

2. Create ZenithWebSite project

3. Add ZenithDataLib project to the solution

4. Create folder ZenithDataLib.Models.Zenith

5. Add the classes Activity & Event in ZenithDataLib.Models.Zenith

6. Modify ApplicationDbContext in ZenithDataLib.Models.IdentityModel
- Access to Activity & Event tables
- Insert data in Activity table

7. Create folder ZenithWebSite.Docs

8. Add the text files Migrations.txt & Readme.txt in ZenithWebSite.Docs

9. Execute the following command in Package Manager Console:
Enable-Migrations -ContextProjectName ZenithDataLib -ContextTypeName ApplicationDbContext -MigrationsDirectory Migrations\Identity

10. Modify the file ZenithWebSite.Migrations.Identity.Configuration.cs to add users & data in Activity & Event tables.
Username	Email				Password		Security Role
a			a@a.a				P@$$w0rd		Admin
m			m@m.m				P@$$w0rd		Member
jdoe		doe1@Zenith.org		doe1@Zenith		Admin

11. Execute the following command in Package Manager Console:
add-migration -ConfigurationTypeName ZenithWebSite.Migrations.Identity.Configuration "InitialIdentity"

12. Add the following fields to the creation of the table AspNetUsers in the file 201702210408147_InitialIdentity.cs
FirstName = c.String(maxLength: 256),
LastName = c.String(maxLength: 256),

13. Execute the following command in Package Manager Console:
update-database -ConfigurationTypeName ZenithWebSite.Migrations.Identity.Configuration

14. Include the Database to ZenithWebSite.App_Data & rename it, ZenithSociety

15. Add controllers (EF scaffolding):
ZenithWebSite.Controllers.ActivitiesController
EventsController

16. Edit the action methods:
- ActivitiesController.Create
- EventsController.Create

17. Editing the views:
- Activities.Create
- Activities.Delete
- Activities.Details
- Activities.Edit
- Activities.index
- Events.Create
- Events.Delete
- Events.Details
- Events.Edit
- Events.index

18. Editing so that Registration capture Username, Email, Password, FirstName, and LastName:
- AccountViewModels.cs:
	- Add properties to ApplicationUser class in IdentityModel.cs:
		- FirstName
		- LastName
- Modify action method Register in AccountController.cs:
	- User property UserName as UserName when creating the user object (.NET MVC by default use the property Email).
	- Save the values of properties FirstName & LastName when creating the user object.

19. Editing so that Username & Password are used of login:
- Edit AccountViewModels.cs:
	- Add property Username in LoginViewModel
	- Comment out property Email in LoginViewModel
- Edit action method Login in AccountController.cs
	- User the property UserName instead of Email to login.
- Edit the Views.Account.Login to use UserName instead of Email to login. 

20. Modify Views.Shared._Layout so as only when user log in as Admin, has access to the Activity & Event menues.

21. Deploy ZenithWebSite to Azure via GitHub.

•	The URL of your assignment 1 deployment on Azure.

•	Any major challenges
- Working with the jquery UI.
- Working with the date & time properties through out the development of the project.
