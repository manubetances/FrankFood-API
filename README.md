# Frank Food API

A CRUD REST API from scratch using .NET 6. This API is based on the [Buber Breakfast API project](https://github.com/amantinband/buber-breakfast?tab=readme-ov-file). This API supports Creating, Update, and Deleting food related products.

##API Definition

###Create Breakfast.
```
POST /products
```

```
{
  "name": "Faro Cookies",
  "description": "Salty crackers made on the Dominican Republic",
  "category": "Cookies",
  "vendor": "Importadora Santiago",
  "tags": [
    "Dominican",
    "Snacks",
    "Cookies"
  ]
}
```
