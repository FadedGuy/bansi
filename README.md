# Bansi
La aplicación está estructurada en capas, consta de 4 en total:

- Base de datos SQL (BdiExamen): 
	- Capa que representa la base de datos.
	- Aquí se almacena toda la información relacionada con los exámenes

- WebApi (WebService): 
	- Capa que expone 4 endpoints para realizar operaciones CRUD (Create, Read, Update, Delete)
	- Se utiliza Entity Framework para modelar la base de datos y establecer comunicación con la misma.
	- Los endpoints reciben solicitudes via HTTPS

DLL (Dll): 
	- Capa que representa una biblioteca de clases actuando como intermediario entre el front y el back.
	- Utiliza Stored Procedures o los endpoints para realizar las operaciones CRUD.

Frontend (Frontend): 
	- Capa que representa la interfaz de usuario de la aplicacion, desarrollada en Windows Forms.
	- Utiliza el DLL mencionado anteriormente para realizar todas las acciones necesarias con la base de datos.
	- Proporciona una interfaz intuitiva para el usuario.


