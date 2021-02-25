You can restore DB from .bak file or create new from Package Management Console:
add-migration  Savills 
update-database –verbose

You can run integration tests or use SavillsSender which will simply send .json files to Web API Server(you need to start server first).

