# **Proceso de DreamAir**

## **Contexto**

El sistema está diseñado para conectar a usuarios con aerolíneas a fin de que puedan buscar vuelos, adquirir pasajes y gestionar su historial de viajes. Las aerolíneas tienen la capacidad de agregar, modificar y eliminar vuelos disponibles, así como gestionar la disponibilidad de asientos y la venta de pasajes. El sistema debe ser intuitivo y permitir tanto a usuarios como a aerolíneas gestionar sus necesidades de manera eficiente.

## **Usuarios del Sistema**

Existen dos tipos principales de usuarios en el sistema:

1. **Usuarios Clientes**: Son los pasajeros que buscan y compran pasajes para volar.
2. **Usuarios Aerolíneas**: Organizaciones que gestionan y operan vuelos. Tienen la capacidad de gestionar los vuelos y su disponibilidad.

**Flujo del Sistema**

El sistema tiene varios flujos principales que definen la interacción entre los **clientes** (usuarios pasajeros) y las **aerolíneas**. A continuación se detallan los pasos clave:

### **1\. Registro e Inicio de Sesión**

#### **Para Clientes:**

- Los usuarios al momento de querer comprar un vuelo ingresan a la página de inicio de sesión, donde se les ofrece la opción de **Registrarse** o **Iniciar sesión**.
- Para el registro, los usuarios deben completar un formulario con los siguientes campos:
  - Nombre completo
  - Correo electrónico
  - Contraseña
  - Número de teléfono
  - Nacionalidad
  - Documento de identidad
  - Edad
- Si ya tienen una cuenta, pueden iniciar sesión ingresando su correo electrónico y contraseña.

#### **Para Aerolíneas:**

- Las aerolíneas se registran a través del superAdmin con las siguientes peticiones:
  - Nombre de la aerolínea
  - Correo electrónico corporativo
  - Contraseña

### **2\. Búsqueda de Vuelos**

Una vez que los usuarios han iniciado sesión, tienen acceso a un **motor de búsqueda de vuelos**, donde pueden ingresar los siguientes parámetros:

- **Origen**: Ciudad desde donde quieren partir.
- **Destino**: Ciudad a donde desean volar.
- **Fecha de salida**: La fecha en la que desean viajar.
- **Fecha de vuelta:** La fecha en la que desean volver (Si eligió viajes de ida y vuelta).
- **Cantidad de pasajeros**: Número de adultos y/o niños.

El sistema muestra una lista de vuelos disponibles que coinciden con los parámetros ingresados, destacando información como:

- Horarios de salida y llegada
- Aerolíneas
- Precio del pasaje por persona
- Origen y destino

Los usuarios pueden ordenar los resultados por precio.

### **3\. Selección y Compra de Pasajes**

Después de que el usuario selecciona un vuelo, el sistema redirige a una página de detalles del vuelo, donde se muestran:

- La aerolínea
- Detalles del vuelo (origen, destino, fechas, horarios)
- Opciones de asientos (dependiendo de la clase seleccionada)
- Cancelación del viaje
- Precio total del pasaje (incluyendo tasas e impuestos)

### **4\. Gestión de Vuelos por Aerolíneas**

Las aerolíneas, una vez que han iniciado sesión, pueden acceder a su **panel de administración de vuelos**, donde tienen las siguientes opciones:

- **Agregar nuevo vuelo**: La aerolínea introduce los detalles del vuelo, tales como:
  - Origen y destino
  - Modalidad (Ida o Ida y vuelta)
  - Fecha y horarios de salida y llegada
  - Capacidad total de asientos (Económicos y Primera clase)
  - Precio base por vuelo
- **Ver estado de pasajes vendidos**: Las aerolíneas pueden ver un informe de cuántos pasajes han sido vendidos por vuelo y cuántos asientos están aún disponibles.

### **5\. Visualización de Vuelos y Pasajes (Clientes)**

Los usuarios pueden acceder a su perfil y ver la sección de **"Mis Vuelos"**, donde tienen acceso a los siguientes elementos:

- **Vuelos próximos**: Muestra una lista de los vuelos que el usuario ha comprado y que están pendientes de realizarse.
- **Historial de vuelos**: Muestra todos los vuelos pasados en los que el usuario ha viajado, con la opción de descargar o imprimir los pasajes correspondientes.
- **Gestión de pasajes**: Desde la lista de vuelos próximos, el usuario puede hacer lo siguiente:
  - **Cancelar pasaje**: El usuario puede solicitar la cancelación del pasaje.

---

## **Estados de los Pasajes**

Cada pasaje representa un asiento del vuelo respectivo, y cada uno tendrá un estado con dos opciones:

- **Activo**: Pasaje que todavía no expiró.
- **Inactivo**: Pasaje expirado.
