#wait for the SQL Server to come up
sleep 90s

#run the setup script to create the DB and the schema in the DB
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -d master -i create-db.sql