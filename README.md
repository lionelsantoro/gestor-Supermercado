# Sistema de Gestión para Supermercado

## Descripción del Proyecto
Aplicación de escritorio diseñada para gestionar las operaciones de una marca de supermercado que opera en una única sucursal. El sistema está optimizado para agilizar el flujo de trabajo en diferentes áreas del negocio, garantizando la seguridad y el control de la información mediante un sistema de roles y permisos bien definido.

## Roles y Funcionalidades
El sistema cuenta con un control de acceso basado en roles, asegurando que cada empleado solo tenga acceso a las herramientas necesarias para su trabajo:

*   🛒 **Cajeros:** 
    *   Registran las compras de los clientes.
    *   Generan los tickets de venta.
    *   Modifican la cantidad de productos en una venta en curso.
*   📦 **Personal de Inventarios:** 
    *   Gestionan el stock y actualizan los precios de los productos.
    *   Crean, modifican y eliminan productos y categorías.
*   ⚙️ **Administración:** 
    *   Gestión de usuarios del sistema.
    *   Acceso exclusivo a formularios de creación, modificación y eliminación de usuarios.
*   🔑 **Supervisor de Caja:** 
    *   Autorización especial para limpiar la venta de un cajero sin eliminarla.
    *   Generación de reportes.

## Arquitectura en Capas y Estructura de Archivos

El proyecto está desarrollado utilizando una **Arquitectura en Capas** para separar las responsabilidades, mejorar la mantenibilidad y escalar el código fácilmente. El proyecto se divide principalmente en: `Vistas` (Elementos visuales), `ReglasNegocio` (Validaciones) y `Datos` (Acceso a base de datos).

A continuación se detalla la relación de los archivos principales agrupados por su entidad. 

*   **Módulo de Inicio de sesion**
    *   🖥️ **DASHBOARDS/Vista:** `MenuPrincipal.cs`
    *   ⚙️ **Negocio:** `LoginNegocio.cs`
    *   💾 **Datos:** `LoginDatos.cs`

*   **Módulo de Cajero**
    *   🖥️ **DASHBOARDS/Vista:** `VistaCajero.cs`
    *   ⚙️ **Negocio:** `ProductoNegocio.cs`
    *   💾 **Datos:** `ProductoDatos.cs`

*   **Módulo de Usuarios Administradores**
    *   🖥️ **DASHBOARDS/Vista:** `MenuGeneralAdmin.cs`
    *   ⚙️ **Negocio:** `UsuarioAdminNegocio.cs`
    *   💾 **Datos:** `UsuarioAdminDatos.cs`

*   **Módulo de Supervisor**
    *   🖥️ **DASHBOARDS/Vista:** `VistaSupervisor.cs`
    *   ⚙️ **Negocio:** `RolNegocio.cs` y `UsuarioNegocio.cs`
    *   💾 **Datos:** `RolDatos.cs` y `UsuarioDatos.cs`

*   **Módulo de Supervisor**
    *   🖥️ **DASHBOARDS/Vista:** `MenuGeneralInventario.cs`
    * 
### Archivos importantes
*   **Conexión a Base de Datos:** `Conexion.cs` (Ubicado en la carpeta datos)
*   **Punto de Entrada:** `Program.cs`
*   **Ejecucion:** `DesktopAppSupermercado.slnx`

## 🗄️ Base de Datos
El proyecto incluye scripts SQL listos para la configuración del entorno en la carpeta `ConsultasSQL`:
*   `Estructuras_Tablas.sql`: Script para la creación de las tablas, relaciones y arquitectura de la base de datos.
*   `Datos_Usuarios.sql`: Script para la inserción de datos referido a los roles y usuarios
