# INVENTARIO
Prueba tecnica

1. Login

<img width="1305" height="580" alt="image" src="https://github.com/user-attachments/assets/e6530dd9-3d38-442b-8f0f-306f5d229f5b" />
<img width="1214" height="460" alt="image" src="https://github.com/user-attachments/assets/441f9235-323f-4580-9e67-0b9f930b4017" />

2. respuesta con token JWT
<img width="1298" height="603" alt="image" src="https://github.com/user-attachments/assets/3b4fdd38-cffb-46ac-becd-28a6f1010aaa" />
<img width="1092" height="392" alt="image" src="https://github.com/user-attachments/assets/d0372dfc-e905-4cf5-833d-127858269d9c" />


3.Listado de productos
<img width="1298" height="582" alt="image" src="https://github.com/user-attachments/assets/191c7759-9e4c-4eba-b0b3-c0fd0dd423d5" />


4. Productos en base de datos POstgresql
<img width="1334" height="636" alt="image" src="https://github.com/user-attachments/assets/9840d11f-038d-43a1-99fb-affcb73c4379" />



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



