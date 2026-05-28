# INVENTARIO
Prueba tecnica

<img width="1342" height="564" alt="image" src="https://github.com/user-attachments/assets/16d57727-76af-4eda-8288-9085d9399072" />



Scripts de base de datos:
La base de datos se creo con postgresql y neon.

////////////////////////////////////////////////

CREATE TABLE PRODUCTOS (
  empId INTEGER PRIMARY KEY,
  NOMBRE TEXT NOT NULL,
  CANTIDAD INT NOT NULL
);


INSERT INTO PRODUCTOS VALUES (2, 'Banano', 5);
INSERT INTO PRODUCTOS VALUES (3, 'Patilla', 14);
INSERT INTO PRODUCTOS VALUES (4, 'Cereza', 14);

CREATE TABLE USUARIOS (
  empId INTEGER PRIMARY KEY,
  USUARIO TEXT NOT NULL,
  CONTRASENA TEXT NOT NULL
);


INSERT INTO USUARIOS VALUES (0001, 'Diego', '12345');
INSERT INTO USUARIOS VALUES (0002, 'Daniela', '12345');



