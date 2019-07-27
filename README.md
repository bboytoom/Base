# Base

## Pre-requisitos

_Son necesarias las siguientes herramientas para poder desarrollar y compilar el sistema base

* [VisualVisual Studio ( community )](https://visualstudio.microsoft.com/es/vs/) - Entorno de desarrollo
* [Sql Server ( 2017 )](https://www.microsoft.com/es-mx/sql-server/sql-server-editions-express) - Sistema de gestion de base de datos
* [Node js ( 10.16.0 LTS )](https://nodejs.org/es/) - Se utiliza el gestor de paquetes de Node
* [GIT ( 2.22.0 )](https://git-scm.com/) - Sistema de control de versiones
* _Crear una base de de datos vacía en el SGBD

## Instalación

1. Clonar el repositorio con el siguiente comando:
```
git clone https://github.com/bboytoom/Base.git
```

2. Restaurar paquetes NuGet

3. Configurar las connectionStrings* que se encuentran en los Web.config de los siguientes proyectos  Administrator,* Administrator.Service*
```xml
<connectionStrings>
    <add	name="DataModels" 
			connectionString="data source=SERVIDOR;initial catalog=NOMBREBASE;user id=sa;password=mipassword;multipleactiveresultsets=True;application name=EntityFramework"
			providerName="System.Data.SqlClient" />
  </connectionStrings>
```

4. En la consola de administración de paquetes dentro del Visual Studio, agrega el comando
```
update-database
```

5. Agregar el siguiente comando en la raíz del proyecto
```
npm install
```

6. Agregar el siguiente comando en la raíz del proyecto
```
npm start
```

***Nota:*** _En caso de aparecer el siguiente error `No se puede encontrar una parte de la ruta de acceso: PATH\bin\roslyn\csc.exe` agregar el siguiente comando en la consola de administrador de paquetes
```
update-package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
```

## Desarrollado con las siguientes tecnologías

* .Net framework 4.6.1 - Framework principal.
* [WCF ( REST )](https://docs.microsoft.com/en-us/dotnet/framework/wcf/) - Servicios necesarios para la comunicación interna del portal.
* Javascript ( Es6 ) - Estándar utilizado para mejorar la interacción entre eventos.
* [NPM ( 6.9.0 )](https://www.npmjs.com/) - Se utiliza para automatizar tareas.
* [Gulp ( 4.0.0 )](https://gulpjs.com/) - Se utiliza para automatizar tareas.
* Bootstrap, Material Design Lite, Sass - e utilizan como conjunto de herramientas de diseño web
* HTML  - Como lenguaje de maquetado


## Licencia

Este proyecto está bajo la Licencia MIT 