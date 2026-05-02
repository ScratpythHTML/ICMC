# Local database

Create a local database with the following command:

```
docker run --name {choose_a_db_name} -e POSTGRES_PASSWORD={choose_a_password} -p 5432:5432 -d postgres:latest
```

Then, create a 'appsettings.Local.json' file in the same directory and with the template of `appsettings.json` then fill in the credentials.