# Sistema de Gestión para Supermercado

Aplicación de escritorio desarrollada en C# y Windows Forms para administrar las operaciones principales de un supermercado: ventas, clientes, productos, categorías, usuarios, reportes y copias de seguridad de la base de datos.

El sistema utiliza acceso por roles para separar las pantallas y las operaciones disponibles para cada tipo de usuario. La solución está organizada en capas para separar la interfaz, las reglas de negocio y el acceso a SQL Server.

> **Estado de la documentación:** este README describe las funcionalidades que se encuentran implementadas en el código de la rama `master` revisado. Las pantallas que todavía son estructuras vacías o incompletas se identifican expresamente para no presentarlas como funcionalidades terminadas.

---

## 1. Tecnologías utilizadas

- **Lenguaje:** C#.
- **Interfaz de escritorio:** Windows Forms.
- **Plataforma:** .NET 10 para Windows (`net10.0-windows`).
- **Base de datos:** Microsoft SQL Server.
- **Acceso a datos:** `Microsoft.Data.SqlClient`.
- **Generación de documentos PDF:** QuestPDF.
- **Entorno de desarrollo:** Visual Studio Community.
- **Administración de base de datos:** SQL Server Management Studio (SSMS).

Paquetes NuGet declarados actualmente en el proyecto:

| Paquete | Versión |
|---|---:|
| `Microsoft.Data.SqlClient` | 7.0.3 |
| `QuestPDF` | 2026.9.1 |

La aplicación establece la cultura `es-AR` al iniciarse, por lo que los importes monetarios se presentan con el formato regional argentino.

---

## 2. Roles del sistema

El sistema utiliza cuatro roles. Los identificadores que se manejan en la navegación actual son los siguientes:

| ID de rol | Rol | Función principal |
|---:|---|---|
| 1 | Administrador | Administración de usuarios y copias de seguridad. |
| 2 | Cajero | Registro de ventas, clientes e historial de sus propias ventas. |
| 3 | Inventario | Administración de productos, categorías, precios y stock. |
| 4 | Supervisor | Consulta de reportes y autorización de operaciones especiales. |

La pantalla de inicio de sesión obtiene el rol del usuario autenticado y abre el menú correspondiente. La separación por roles se implementa principalmente mediante la navegación a las distintas vistas y validaciones específicas en las operaciones que requieren autorización.

---

## 3. Funcionalidades implementadas

### 3.1. Inicio de sesión

La aplicación comienza en `MenuPrincipal`, donde el usuario ingresa su nombre de usuario y contraseña.

El proceso de autenticación:

1. Comprueba que ambos campos estén completos.
2. Calcula el hash SHA-256 de la contraseña ingresada.
3. Compara el usuario y el hash con los datos almacenados en la tabla `usuarios`, verificando que la cuenta no esté eliminada.
4. Recupera el identificador, el rol y el nombre de usuario.
5. Guarda los datos mínimos del usuario autenticado en `Sesion.UsuarioActual`.
6. Abre el menú correspondiente al rol.

Al cerrar la vista abierta, la aplicación vuelve a mostrar la pantalla de inicio de sesión y limpia los campos.

**Nota de seguridad:** el código actual utiliza SHA-256 sin una sal individual por contraseña. Es una implementación funcional para el proyecto, pero se recomienda migrar a un algoritmo específico para almacenamiento de contraseñas, como PBKDF2, bcrypt o Argon2, antes de utilizar el sistema en un entorno real.

### 3.2. Módulo de cajero

La vista principal del cajero permite gestionar una venta y consultar las operaciones realizadas por el usuario autenticado.

#### Registro de ventas

- Inicia una venta seleccionando un cliente registrado.
- Permite buscar clientes por nombre, apellido o DNI.
- Permite buscar productos y abrir un selector con búsqueda por descripción, código de barras y categoría.
- Agrega productos al detalle de la venta y permite modificar las cantidades desde la grilla.
- Calcula subtotales y el total de la compra.
- Verifica el stock disponible antes de agregar o modificar cantidades.
- Permite seleccionar el medio de pago mediante el formulario de pago.
- Confirma y registra la venta en la base de datos.
- Genera automáticamente un ticket en PDF al finalizar la venta.

Las ventas pendientes se mantienen en memoria mientras el cajero prepara el carrito. La escritura definitiva en la base de datos se realiza al confirmar el pago. El registro de la venta, sus detalles, la numeración del ticket y la actualización del stock se procesan dentro de una transacción SQL para evitar guardar una venta incompleta.

#### Productos por kilogramo y por unidad

El sistema distingue productos cuya unidad de medida es `Kg` de aquellos vendidos por `Unidad`:

- Para productos por kilogramo, el cajero ingresa la cantidad en gramos.
- El stock de estos productos se administra en kilogramos.
- El precio se interpreta como precio por kilogramo.
- Para productos por unidad, la cantidad se ingresa en unidades.

#### Cancelación de una venta pendiente

El cajero puede descartar una venta que todavía no fue confirmada. Para realizar esta acción debe ingresar un código de autorización de supervisor. Descartar el carrito no registra una venta ni modifica el stock en la base de datos.

#### Ticket PDF

Una vez confirmada la operación, el sistema genera un archivo PDF con los datos de la venta, el cliente, el cajero, los productos, las cantidades, los precios y el importe total. Los archivos se guardan en la carpeta `Documentos/DesktopAppSupermercado/Tickets` del usuario de Windows.

#### Historial de ventas del cajero

La pantalla `Historial` permite:

- Consultar las ventas del cajero que inició sesión.
- Filtrar las ventas mediante fechas desde/hasta.
- Buscar por número de ticket.
- Seleccionar una venta para consultar los productos, cantidades, precios unitarios y subtotales que la componen.

El historial está limitado al identificador del usuario autenticado; no es el listado general de ventas del supermercado.

#### Gestión de clientes

Desde `FormRegistro`, el cajero puede:

- Consultar y buscar clientes registrados.
- Registrar nuevos clientes.
- Seleccionar un cliente para modificar sus datos.
- Dar de baja clientes mediante eliminación lógica.
- Validar datos personales antes de guardar.

Los datos personales se almacenan en `persona` y la relación de cliente se gestiona mediante `clientes`.

### 3.3. Módulo de inventario

La vista `VistaGestionInventario` permite administrar productos y categorías.

#### Gestión de productos

- Listar productos activos y mostrar su categoría, precio, stock y unidad de medida.
- Crear productos.
- Modificar productos existentes.
- Dar de baja productos mediante eliminación lógica.
- Asignar una categoría y una unidad de medida (`Unidad` o `Kg`).
- Registrar precio, stock y código de barras.
- Validar los campos obligatorios y los valores numéricos.
- Validar el formato de seis dígitos del código de barras y controlar que no esté repetido en otro producto activo.
- Buscar y filtrar productos por texto, categoría y rangos de stock.

#### Gestión de categorías

- Listar categorías activas.
- Crear categorías.
- Modificar el nombre de una categoría.
- Dar de baja categorías mediante eliminación lógica.
- Impedir la baja o modificación de categorías cuando tienen productos activos asociados, según las reglas implementadas.

Los filtros de la grilla se aplican sobre los datos cargados en memoria para evitar consultar la base de datos en cada cambio de filtro.

### 3.4. Módulo de administración

El menú de administración contiene las opciones de usuarios, copias de seguridad y reportes.

#### Gestión de usuarios

La vista `VistaUsuariosAdmin` permite:

- Listar usuarios activos e inactivos.
- Buscar por nombre o apellido.
- Filtrar por rol.
- Aplicar filtros por fechas.
- Registrar usuarios asociados a una persona y un rol.
- Modificar los datos de una persona o cuenta existente.
- Dar de baja usuarios mediante eliminación lógica.
- Validar DNI y nombre de usuario para evitar duplicados.
- Validar campos personales, correo y otros datos del formulario.
- Generar códigos de autorización para usuarios con rol de supervisor cuando corresponde.

Las contraseñas ingresadas se transforman a hash SHA-256 antes de guardarse. La pantalla no muestra el código de autorización del supervisor como un dato ordinario del usuario; el código se entrega mediante el mecanismo de consulta de autorización del supervisor.

#### Copias de seguridad y restauración

La vista `VistaBackupAdmin` permite:

- Consultar el nombre de la base de datos configurada.
- Crear una copia de seguridad de SQL Server en un archivo `.bak`.
- Elegir la ubicación de destino mediante el explorador de archivos.
- Consultar el historial de copias de seguridad.
- Filtrar el historial por fechas.
- Identificar copias disponibles, no encontradas o reemplazadas.
- Seleccionar una copia y solicitar su restauración.
- Confirmar la operación y validar un código de autorización de supervisor antes de restaurar.

La restauración reemplaza el estado actual de la base de datos por el contenido de la copia seleccionada. Debe realizarse con precaución y solamente después de verificar que el archivo corresponde a la base correcta.

#### Reportes del administrador

El menú contiene una opción llamada Reportes y existe la vista `VistaReportesAdmin`, pero actualmente su evento de carga no contiene lógica de reportes. Por lo tanto, **no se considera una funcionalidad de reportes administrativos implementada**.

### 3.5. Módulo de supervisor

La vista `VistaSupervisor` permite consultar información de ventas, productos, categorías y clientes dentro de un período seleccionado.

Las grillas se actualizan al cambiar las fechas y ofrecen búsqueda textual según la pestaña activa.

#### Ventas realizadas

- Lista las ventas del período seleccionado.
- Muestra número de ticket, importe y fecha de creación.
- Incluye un resumen de la cantidad de operaciones y el importe recaudado por cajero.
- Permite buscar ventas por número de ticket y cajeros por nombre.
- Genera un reporte PDF con el detalle de las ventas y el rendimiento de los cajeros.

#### Productos y categorías

- Resume las cantidades vendidas por producto.
- Muestra el stock actual de los productos.
- Calcula los importes asociados a los productos y categorías en el período.
- Permite buscar productos y categorías.
- Genera un PDF con información detallada de productos y categorías, incluyendo productos sin ventas durante el período.

#### Clientes

- Lista clientes registrados.
- Muestra cantidad de ventas e importe recaudado en el período.
- Incluye clientes sin ventas asociadas dentro del período.
- Permite buscar clientes por nombre.
- Genera un reporte PDF con métricas y detalle de clientes.

**Aclaración sobre los importes:** en los reportes, los campos denominados `Ganancia Generada` suman los subtotales de las ventas. Representan importes vendidos o recaudados, no una ganancia neta contable, ya que el sistema no descuenta costos de adquisición ni otros gastos.

#### Autorización y consulta del código

El supervisor puede consultar su propio código de autorización mediante `FormConsultarCodigoAutorizacion`. Para ello, el sistema verifica que exista una sesión de supervisor y solicita DNI y contraseña antes de recuperar el código asociado a esa cuenta.

Ese código se utiliza en operaciones que requieren autorización, como descartar una venta pendiente desde la vista del cajero y restaurar una copia de seguridad desde el módulo de administración.

---

## 4. Arquitectura y organización del proyecto

La solución utiliza una arquitectura en capas. Las carpetas principales se encuentran dentro de `DesktopAppSupermercado/`.

| Carpeta | Responsabilidad |
|---|---|
| `Vistas/` | Formularios Windows Forms, controles y eventos de interfaz. |
| `ReglasNegocio/` | Validaciones, reglas del sistema y coordinación entre la vista y los datos. |
| `Datos/` | Consultas SQL y operaciones de lectura/escritura en SQL Server. |
| `Entidades/` | Clases que representan los datos utilizados por la aplicación y la sesión actual. |
| `ConsultasSQL/` | Scripts SQL de estructura, datos de demostración y ajustes de la base de datos. |

### Organización de las vistas

- `Vistas/DASHBOARDS/`: pantalla principal, menús de administración e inventario, vista de cajero y vista de supervisor.
- `Vistas/VISTASADMIN/`: gestión de usuarios, copias de seguridad y pantalla de reportes administrativos.
- `Vistas/VISTASCAJERO/`: formularios de pago, clientes, búsqueda de productos, autorización para cancelar y el historial.
- `Vistas/VISTASINVENTARIO/`: gestión de productos y categorías.

### Organización de reglas de negocio

- `ReglasNegocio/InicioSesion/`: autenticación, usuarios y roles.
- `ReglasNegocio/Supervisor_Cajero/`: ventas, productos y clientes utilizados por cajeros.
- `ReglasNegocio/Cajero/`: medios de pago, autorización y generación del ticket PDF.
- `ReglasNegocio/Inventario/`: validaciones de productos y categorías.
- `ReglasNegocio/Admin/`: administración de usuarios y copias de seguridad.
- `ReglasNegocio/Supervisor/`: reportes, gráficos y consulta de códigos de autorización.

### Organización de acceso a datos

La carpeta `Datos/` está dividida siguiendo los mismos módulos. Cada clase de datos se ocupa de las consultas SQL correspondientes a su funcionalidad. La clase `Conexion` crea las conexiones utilizadas por las demás clases.

### Punto de entrada

`Program.cs` configura QuestPDF, establece la cultura regional `es-AR` e inicia la aplicación mostrando `MenuPrincipal`.

---

## 5. Base de datos

La aplicación utiliza una base de datos llamada `SupermercadoDB`. El código actual trabaja con las siguientes tablas principales:

| Tabla | Uso |
|---|---|
| `persona` | Datos personales de empleados y clientes. |
| `roles` | Roles disponibles en el sistema. |
| `usuarios` | Cuentas de acceso, rol y estado del usuario. |
| `categorias` | Categorías de productos. |
| `productos` | Descripción, precio, stock, unidad de medida y código de barras. |
| `clientes` | Relación entre una persona y su condición de cliente. |
| `medios_de_pago` | Medios de pago disponibles. |
| `ventas` | Cabecera de cada operación de venta. |
| `detalle_venta` | Productos, cantidades, precios y subtotales de cada venta. |
| `ControlNumeracionTicket` | Control del último número de ticket asignado. |

### Scripts SQL disponibles

Los scripts se encuentran en `DesktopAppSupermercado/ConsultasSQL/`:

| Archivo | Propósito actual |
|---|---|
| `Estructuras_Tablas.sql` | Crea las tablas base de personas, roles, categorías, medios de pago, usuarios, productos, ventas y detalles. |
| `Datos_Usuarios.sql` | Agrega datos personales complementarios a `persona` e inserta roles, personas y usuarios de demostración. |
| `Datos_Productos.sql` | Prepara e inserta datos de demostración para categorías y productos. |
| `Clientes.sql` | Ajusta y migra la estructura de clientes para relacionarla con `persona`. |
| `Ventas.sql` | Incorpora `numero_ticket`, establece su unicidad y prepara `ControlNumeracionTicket`. |
| `Restore.sql` | Crea el índice único filtrado de códigos de autorización y asigna códigos a supervisores activos que todavía no tengan uno. |

> **Importante: revisar antes de instalar desde cero.** Estos scripts reflejan distintas etapas de evolución de la base de datos; no forman actualmente un instalador lineal y autónomo para una base vacía. Por ejemplo, `Estructuras_Tablas.sql` no crea la tabla `clientes`, mientras que `Clientes.sql` espera que esa tabla ya exista. Además, la estructura inicial de productos conserva definiciones antiguas que deben contrastarse con las columnas y tipos que utiliza el código actual. Antes de desplegar una instalación nueva, es necesario consolidar y probar un único script de estructura actualizado. No ejecutes scripts de migración sobre una base con información importante sin realizar previamente una copia de seguridad.

### Conexión a SQL Server

La cadena de conexión está configurada actualmente en:

`DesktopAppSupermercado/Datos/Conexion.cs`

El valor incluido en el repositorio apunta a una instancia local de SQL Server LocalDB y a la base `SupermercadoDB`:

```csharp
Server=(localdb)\MSSQLLocalDB; Database=SupermercadoDB; Integrated Security=True;
```

Si se utiliza otra instancia de SQL Server, debe modificarse la cadena de conexión para que coincida con el servidor, la base de datos y el método de autenticación del entorno. En un despliegue real se recomienda externalizar la cadena de conexión en la configuración y no dejarla fija en el código fuente.

---

## 6. Requisitos para ejecutar el proyecto

- Windows compatible con Windows Forms.
- .NET 10 SDK y runtime para Windows.
- Visual Studio con soporte para desarrollo de escritorio .NET.
- SQL Server o SQL Server LocalDB.
- SQL Server Management Studio (opcional, recomendado para administrar la base y ejecutar scripts).

### Pasos generales

1. Clonar o descargar este repositorio.
2. Abrir `DesktopAppSupermercado.slnx` en Visual Studio.
3. Verificar que el proyecto `DesktopAppSupermercado` restaure los paquetes NuGet.
4. Configurar la cadena de conexión de `Datos/Conexion.cs` para la instancia de SQL Server disponible.
5. Preparar la base `SupermercadoDB` con una estructura compatible con el código actual. Revisar previamente la advertencia de los scripts SQL del apartado anterior.
6. Ejecutar el proyecto desde Visual Studio.

La aplicación inicia en la pantalla de inicio de sesión. Para probar los módulos se necesitan cuentas de usuario activas con los roles correspondientes y datos coherentes en las tablas relacionadas.

---

## 7. Estado y aspectos pendientes

Las siguientes cuestiones deben tenerse presentes al evaluar el alcance actual del sistema:

- La pantalla `VistaReportesAdmin` existe y se abre desde el menú de administración, pero todavía no implementa reportes.
- `ViistaVentasInventario` existe como formulario, pero sus eventos actuales están vacíos; no debe considerarse un módulo de reportes de ventas de inventario terminado.
- Los scripts SQL de `ConsultasSQL` necesitan consolidarse para que una instalación nueva reproduzca sin pasos manuales la estructura que requiere el código.
- La autenticación utiliza SHA-256 sin sal individual. Es recomendable migrar a un algoritmo de hash de contraseñas más adecuado.
- La cadena de conexión está escrita directamente en `Conexion.cs`; conviene externalizarla para facilitar la configuración por entorno.
- Se recomienda revisar el cierre de sesión para asegurarse de limpiar `Sesion.UsuarioActual` al abandonar una sesión.
- Los importes identificados como ganancia en los reportes representan sumas de ventas, no utilidad neta.

---

## 8. Estructura resumida del repositorio

```text
 gestor-Supermercado/
 ├── DesktopAppSupermercado.slnx
 ├── README.md
 └── DesktopAppSupermercado/
     ├── ConsultasSQL/
     ├── Datos/
     │   ├── Admin/
     │   ├── Cajero/
     │   ├── InicioSesion/
     │   ├── Inventario/
     │   ├── Supervisor/
     │   └── Supervisor_Cajero/
     ├── Entidades/
     ├── ReglasNegocio/
     │   ├── Admin/
     │   ├── Cajero/
     │   ├── InicioSesion/
     │   ├── Inventario/
     │   ├── Supervisor/
     │   └── Supervisor_Cajero/
     ├── Vistas/
     │   ├── DASHBOARDS/
     │   ├── VISTASADMIN/
     │   ├── VISTASCAJERO/
     │   └── VISTASINVENTARIO/
     ├── Properties/
     ├── Resources/
     ├── Program.cs
     └── DesktopAppSupermercado.csproj
```

---

## 9. Observación final

Este proyecto constituye un sistema de gestión de supermercado de escritorio en desarrollo. Las funcionalidades documentadas corresponden a las clases y formularios presentes en el repositorio; las mejoras indicadas en el apartado de pendientes no deben interpretarse como características ya terminadas.
