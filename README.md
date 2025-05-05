📝 Documentación de la API - Company & Product Management

.NET 8
ASP.NET Core
ADO.NET

API RESTful para el sistema de gestión de compañías y productos.

🏢 Endpoints de Compañías (Company)
Obtener todas las compañías

GET /api/Company

Respuesta exitosa (200 OK):
json

[
    {
        "id": 1,
        "name": "Tech Solutions Inc."
    },
    {
        "id": 2,
        "name": "Innovative Products LLC"
    }
]

Crear una nueva compañía

POST /api/Company

Body:
json

{
    "name": "Nueva Compañía"
}

Respuesta exitosa (201 Created):
json

{
    "id": 3,
    "name": "Nueva Compañía"
}

Obtener compañía por ID

GET /api/Company/{id}

Respuesta exitosa (200 OK):
json

{
    "id": 1,
    "name": "Tech Solutions Inc."
}

Actualizar compañía

PUT /api/Company/{id}

Body:
json

{
    "id": 1,
    "name": "Tech Solutions Global"
}

Eliminar compañía

DELETE /api/Company/{id}

Respuesta exitosa (204 No Content)
Obtener productos por compañía

GET /api/Company/{companyId}/products

Respuesta exitosa (200 OK):
json

[
    {
        "id": 1,
        "name": "Producto A",
        "companyId": 1
    }
]

📦 Endpoints de Productos (Product)
Obtener todos los productos

GET /api/Product

Respuesta exitosa (200 OK):
json

[
    {
        "id": 1,
        "name": "Producto A",
        "companyId": 1,
        "company": {
            "id": 1,
            "name": "Tech Solutions Inc."
        }
    }
]

Crear nuevo producto

POST /api/Company/{companyId}/products

Body:
json

{
    "name": "Nuevo Producto"
}

Obtener producto por ID

GET /api/Product/{id}

Respuesta exitosa (200 OK):
json

{
    "id": 1,
    "name": "Producto A",
    "companyId": 1
}

Actualizar producto

PUT /api/Product/{id}

Body:
json

{
    "id": 1,
    "name": "Producto A Premium",
    "companyId": 1
}

Eliminar producto

DELETE /api/Product/{id}

Respuesta exitosa (204 No Content)

Instalación

    Clonar el repositorio:
    bash

git clone https://github.com/NicolasMC07/Company.git

Ejecutar la aplicación:
bash

dotnet run
