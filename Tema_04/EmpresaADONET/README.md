# Ejercicios del Tema 4 de Acceso a Datos
---
> Alejandro del Valle Vallés

## Resumen
Proyecto sobre los ejercicios del Tema 4 de Acceso a Datos.
El tema consisnte en crear una BBDD en PostgreSQL y mediante la librería de ADO.NET, hacer conexión con dicha base de datos<br>
y realizar diferentes operaciones CRUD.<br>
A su vez hay que hacerlo de la manera más eficiente y segura posible, siguiendo levemente los principios S.O.L.I.D haciendo<br>
especial hincapié en la 'S' (Single Responsability)

## Tecnologías y Dependencias Usadas
- .NET 8.0
- ADO.NET Npgsql 9.0.4
- ADO.NET Npgsql.EntityFramework.Core 9.0.4

### Script Usado para la BBDD
```
/* AD_EMPRESA */

CREATE DATABASE empresa;

CREATE TABLE clientes (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(85) NOT NULL,
    email VARCHAR(100),
    fecha_alta DATE NOT NULL DEFAULT CURRENT_DATE,
    activo BOOLEAN NOT NULL DEFAULT TRUE,
    porcentaje_descuento DECIMAL(3,2) NOT NULL DEFAULT 0,
    puntos_fidelidad INT NOT NULL DEFAULT 0,
    CHECK(porcentaje_descuento >= 0),
    CHECK(puntos_fidelidad >= 0)
);



/* AD_DISTRIBUIDOR */

CREATE TABLE IF NOT EXISTS fabricantes
(
    codigo SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS articulos
(
    codigo SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL UNIQUE,
    precio DECIMAL(5,2),
    fabricante INTEGER NOT NULL,
    FOREIGN KEY (fabricante) REFERENCES fabricantes (codigo)
)
```