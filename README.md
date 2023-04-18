# Prueba de fullstack
## _Sebastian Gomez_

Crear la base de datos "RecaudoVehiculos" con usuario "prueba" y password "prueba", teniendo en cuenta que se debe hacer cambio del motor de base de datos.
Ejacutar los siguientes comandos:
```sh
add-migration InitialCreate -p Recaudo.Repository -c RecaudoContext -o Migrations -s Recaudo.Repository
update-database -p Recaudo.Repository -s Recaudo.Repository
```
La prueba se desarrolló pensada en arquitectura limpia(hexagonal), y de cómo es interacción con las diferentes reglas de negocio, para dar un buen mantenimiento a futuro, respetando fuertemente los principios SOLID. La base de datos de realizo por CodeFirst
A continuación, se presenta el cómo se implementó a nivel de código en la solución

![image](https://user-images.githubusercontent.com/4923760/227661712-7a86906d-7121-4377-9f5d-d0d4c8eb96ba.png)

En el siguiente archivo se debe ingresar el puerto del proyecto en back https://github.com/sebasez/RecaudosF2xPrueba/blob/master/src/Recaudo.WebAppAngular/angular/src/app/api.service.ts
```ts 
private apiUrl = 'https://localhost:<<puerto>>/api/';
```
La documentación del swagger esta en la URL https://localhost:puerto/swagger/index.html
para la ejecución de la consulta de los datos del servidor externo se puede realizar con swagger en el api o del navegador con la siguiente URL:
https://localhost:puerto/api/Proceso
y para detenerlo con la siguiente url
https://localhost:puerto/api/Proceso/Detener

El proyecto de angular esta en esta carpeta /Recaudo.WebAppAngular/angular
