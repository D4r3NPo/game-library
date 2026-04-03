#!/bin/sh

curl -X POST http://localhost:5059/api/games \
    -H "Content-Type: application/json" \
    -d '{
            "Id": "celeste",
            "Title": "Celeste",
            "Platforms": ["Windows"],
            "Genres": ["RPG"],
            "Status": "ToDo",
            "Rating": null
        }'
