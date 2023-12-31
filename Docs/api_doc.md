# Api endpoints and examples

## /session

### Create new Session

POST `api/session/`

Creates a new session with ID and adds necessary entries in the database. The request returns the id which is to be used when sending images.

#### New session request

```json
{
  "session_name": "name"
}
```

#### Response

```json
{
  "session_id": "GUID"
}
```

### Get Sessions

GET `api/session/`

Returns the list of the registered sessions and information regarding them.

#### Response

```json
{
  [
    {
        "session_name": "Session_1",
        "session_id": "SESSION_GUID",
        "no_of_images": "NUMBER",
        "date_created": "DATETIME"
    },
    {
        "session_name": "Session_2",
        "session_id": "SESSION_GUID",
        "no_of_images": "NUMBER",
        "date_created": "DATETIME"
    }
  ]
}
```

### Get Session metrics

GET `api/session/metric/{session_id}`

Gets the processing results of the session for healthy and unhealthy plants.

```json
{
  "total_healthy_percent": "NUMBER",
  "total_unhealthy_percent": "NUMBER",
  "date_created": "DATE_TIME"
}
```

### Get Session Images

GET `api/session/{session_id}/images?pagenumber=1&pagesize=2`

#### Response

```json
[
  {
    "image_id": "GUID",
    "file_name": "image.jpg",
    "healthy_percent": "NUMBER",
    "unhealthy_percent": "NUMBER"
  },
  {
    "image_id": "GUID",
    "file_name": "image_2.jpg",
    "healthy_percent": "NUMBER",
    "unhealthy_percent": "NUMBER"
  }
]
```

## /image

### Add a new image

POST `api/image`

When a new image is added to the system, it must be registered here. The response is an ID that is then used in the system to refer to this image.

#### Register Request

```json
{
  "file_name": "Image_001.jpg",
  "session_id": "SESSION_GUID"
}
```

#### Response

```json
{ "image_id": "GUID" }
```

### Modify image

PUT `api/image/{id}`

Used to update image information through the different processing phases.

#### Request

```json
{
  "is_processed": "BOOL",
  "is_analyzed": "BOOL"
}
```

#### Response

```json
{
  "id": "GUID"
}
```

### Get Image

GET `api/Image/{id}`

Returns image path and properties of the image

#### Response

```json
{
  "is_processed": "BOOL",
  "is_metrics_extracted": "BOOL",
  "image_path": "STRING",
  "metrics": [
    {
      "index_name": "ndvi",
      "healthy_percent": "NUMBER",
      "unhealthy_percent": "NUMBER"
    }
  ]
}
```

### Add Image Metric

Post `api/Image/metric/{id}`

Used to add an entry for image metrics.

#### Request

```json
{
  "index_type": "ENUM",
  "healthy_percent": "FLOAT",
  "unhealthy_percent": "FLOAT"
}
```

#### Response

```json
{
  "id": "GUID"
}
```
