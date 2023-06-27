# Bansi
Aplicacion hecha por capas, contiene 4 en total
- Base de datos SQL (BdiExamen)
- WebApi (WebService)
	- Contiene 4 endpoints basados en CRUD
	- Se utilizo EntityFramework para modelizar la db
- DLL (Dll)
	- Utiliza StoredProcedures o la WebApi para realizar las operaciones CRUD
	- Sirve como intermediario entre el frontend y el backend
- Frontend (Frontend)
	- Windows Forms 
	- Carga el Dll para realizar todas las acciones necesarias

## TODO
Try/catch de campos en el frontend

