Buen día, 

El proyecto está hecho en .NET Core 5 y está dividido en dos partes:

La primera, consta del proyecto CreateBd\Weelo.App.Api.EF, que es el proyecto que crea la bd en  base a entity framework, lo dividi por facilidad, por lo que es necesario de tener una instancia de sql ejecutándose y una base de dato creada con el nombre ‘Weelo’ y modificar el metodo OnConfiguring con el ConnectionStrings de la BD creada.

La segunda parte , es el proyecto completo, que está en la carpeta weelo.app.api, es una solución que consta de 6 proyectos y que con la bd creada en el paso anterior funciona correctamente, el proyecto Weelo.App.Api tiene un archivo de schemas para manejar las propiedad en este existe una sección llamada ConnectionStrings que es la que se debe modificar en base a la bd creada anteriormente, el api la documente con la versión 3 de swagger para mejor el manejo.
