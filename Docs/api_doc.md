# Api endpoints and examples

## /session

### Create new Session

POST `api/session/create`

Creates a new session with ID and adds necessary entries in the database. The request returns the id which is to be used when sending images.

#### New session request

```json
{
  "session_name": "name"
}
```

### Get Sessions

GET `api/session/sessions`

Returns the list of the registered sessions and information regarding them.

#### Response

```json
{
    "sessions" :
        {
            "session_name": "Session_1",
            "session_id": guid,
            "no_of_images": number,
            "processed_indices":["ndvi", "gndvi"],
            "metrics" :{
                "healthy_land" : number,
                "unhealthy_land": number,
            }
        }
    ]
}
```

## /image

### Add a new image

POST `api/image/`

When a new image is added to the system, it must be registered here. The response is an ID that is then used in the system to refer to this image.

### Register Request

```json
{
    "file_name" : "Image_001.jpg",
    "session_id" : guid,
    "
}

```
