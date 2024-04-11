To run this web application successfully, you need 2 SQL Server databases

-Steps to set up the store and identity databases:

1. Open SSMS and connect to an account
2. Click New Query
3. Paste the script inside "H60Assignment3DB_avh_script.sql"
4. Click Execute
5. Repeat step 2 to 4 for "H60Assignment3Identity_avh_script.sql"

It should create 2 databases: H60Assignment3DB_avh_rc and H60Assignment3Identity_avh_rc

-Change values of User id and password to yours in:

avhH60A03\avhH60Store\avhH60Store\appsettings.json
avhH60A03\avhH60Store\avhH60Services\appsettings.json
avhH60A03\avhH60Store\avhH60Customer\appsettings.json

Everything should be running smoothly

See the file "Account credentials.txt" to login with different roles