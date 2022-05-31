what you can do so far:
- checks all nodes running
- checks if a queue has X consumers and is of a specific type
- send alerts via webhook

```json
{
    "rabbitmq":{
        "url" : "http://localhost:15672",
        "interval": 60000,
        "user": "admin",
        "password" : "admin"
    },
    "webhook":{
        "url": "https://webhook.site/06ccda95-83ad-4702-9b96-e969e2675458",
        "headers": [
            {
                "name" : "foo",
                "value" : "bar"
            }
        ]
    },
    "nodes":{
        "allRunning": true
    },
    "queues":[
        {
            "name": "foo.queue",
            "consumers": 2,
            "type": "quorum"
        },
        {
            "name": "bar.queue",
            "consumers": 1,
            "type": "durable"
        }
    ]
}
```
webhook raw content example

```json
{
  "Message": "queue foo.queue doesn't have 2 consumers"
}
```