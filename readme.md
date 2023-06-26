<div id="top"></div>

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://www.insttantt.com/">
    <img src="images/logo.png" alt="Logo" width="200" height="50">
  </a>

  <h1 align="center">Backend Developer</h1>

  <p align="center">
    Prueba Backend Developer.
    <br />
    <a href="https://www.insttantt.com/"><strong>INSTTANTT »</strong></a>
    <br />
    <br />
  </p>
</div>

<!-- ABOUT THE PROJECT -->
## Acerca del proyecto Prueba - 2023

![Product Name Screen Shot][product-screenshot]

Se requiere desarrollar una Aplicación para ejecutar flujos y eres el encargado de realizar el API de la
aplicación. Un Flujo es un proceso que tiene un propósito específico, por ejemplo, solicitar un producto
financiero. Un Flujo es la unidad funcional más grande y puede estar compuesto de múltiples Pasos. Un
Paso, es una unidad funcional básica que realiza una o varias acciones dentro de un flujo en el orden en
el que ha sido asignado.
En la Aplicación a desarrollar, intervienen Pasos que tienen entradas que pueden depender de uno o
varios Pasos, es decir, algunos podrían ejecutarse en paralelo y otros podrían ejecutarse una vez
finalizado el paso anterior. A continuación te hacemos una representación gráfica de posibles opciones a las que se puede enfrentar la Aplicación:
* Flujo Sencuencial
* Flujo Simultaneo

### Los endpoints necesarios son:
![Product Name Screen Shot][screen01]

## Requisitos 
* C#
* Asp.Net Core
* API REST
* ORM Entity Framework, Dapper u otro de buen performance
* Patrones de diseño
* Algún modelo de arquitectura
* Paralelismo 

# Creacion de Base de datos
Para crear la base de datos, debe ejecutar el proyecto Insttantt.CreateDatabase. Solo revise que la cadena de conexción en appsettings.json tenga los privilegios necesarios para crear la base de datos, el proyecto ejecutar la creacion de esquemas y datos. 

Cuando ejecute el proyecto, le saldra una ventana donde se le informara si se ha podido crear la base de datos.
![Product Name Screen Shot][screen03]

# Pasos para Ejecutar el Aplicativo
### Ejecutarlo con Visual Studio 2022
* Debera tener instalado el SDK de NET Core 6.0

  <a href="https://dotnet.microsoft.com/en-us/download/dotnet/6.0/">Instalar SDK</a>

* Puede Abrir la Solucion Insttantt.Workflow.sln, compilar y ejecutar en Visual Studio 2022.


### Ejecutarlo desde la Linea de comandos
* Si prefiere la linea de comandos , puede ejecutar en la carpeta raiz de la solucion, los siguientes
comandos

```cs
    dotnet restore
    dotnet build --configuration Release
    dotnet Insttantt.Workflow.dll
 ```
El ultimo comando se ejecuta en la ruta del compilado.

### Ejecutarlo con Docker

* Si utilizas docker, encuentra el archivo DockerFile en la raiz de la solucion y ejecuta los 
siguientes comandos.

```cs
    docker build . -t insttantt
    docker run -p 8080:80 insttantt
 ```
Una vez construido la imagen y el contenedor docker, puede abrir el navegador en la url:
<a href="http://localhost:8080/swagger/index.html">http://localhost:8080/swagger/index.html</a>


# Estructura Proyecto de Worklflow
## Insttantt.Workflow.Core
* Contiene los Endpoints para el manejo del Api.

## Insttantt.Workflow.Core
* Manejo de workflows, algunos patrones que se usaron son visitor, composite,observer,builder,state, construir un workflow resulta ser una tarea de alta complejidad.

## Insttantt.Workflow.CQRService
* Esta capa es la encargada de orquestar las reglas de negocio y persistencia, se apoya del patron Mediator, para separar las responsabilidades.

## Insttantt.Workflow.Dtos
* Capa que contiene Data Transfer Objects, para reducir el acoplamiento, y simplificar la comunicación.

## Insttantt.Workflow.Models
* Contiene los Modelos del dominio., en este caso son entidades muy simples.

## Insttantt.Workflow.EntityFramework
* Capa utilizada para establecer los contextos de Entity Framework.

## Insttantt.Workflow.Repositories
* Capa utilizada para la persistencia de datos.

## Insttantt.Workflow.Rules
* Contiene toda la logica del negocio de los distintos modelos o flujos.


## Insttantt.Workflow.Shared
* Datos compartidos entre los distintos proyectos.


## Realizado por
* Francisco Javier Areas Rios

<!-- MARKDOWN LINKS & IMAGES -->
[product-screenshot]: images/logo.png
[screen01]: images/screen01.png
[screen02]: images/screen02.png
[screen03]: images/database.png