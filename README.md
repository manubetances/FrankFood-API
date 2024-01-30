# Frank Food API

A CRUD REST API from scratch using .NET 6. This API is based on the [Buber Breakfast API project](https://github.com/amantinband/buber-breakfast?tab=readme-ov-file). This API supports Creating, Reading, Update, and Deleting food related products.

## API Definition.

### Create Product.
### *Create Product Request*
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


### Get Product.
### *Get Product Request*
```
GET /products/{{id}}
```

### Update Product.
### *Update Product Request*
```
PUT /products/{{id}}
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

### Delete Product
### *Delete Product Request*
```
DELETE /product/{{id}}
```

