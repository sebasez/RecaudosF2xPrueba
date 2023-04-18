# Prueba de fulstack
## _Sebastian Gomez_

Crear la base de datos "RecaudoVehiculos" con usuario "prueba" y password "prueba", teniendo en cuenta que se debe hacer cambio del motor de base de datos.
Ejacutar los siguientes comandos:
```sh
add-migration InitialCreate -p Recaudo.Repository -c RecaudoContext -o Migrations -s Recaudo.Repository
update-database -p Recaudo.Repository -s Recaudo.Repository
```
La prueba se desarrollo pensada en arquitectura limpia(hexagonal), y de cómo es interacción con las diferentes reglas de negocio, para dar un buen mantenimiento a futuro, respetando fuertemente los principios SOLID. La base de datos de realizo por CodeFirst
A continuación, se presenta el cómo se implementó a nivel de código en la solución

![image](https://user-images.githubusercontent.com/4923760/227661712-7a86906d-7121-4377-9f5d-d0d4c8eb96ba.png)
