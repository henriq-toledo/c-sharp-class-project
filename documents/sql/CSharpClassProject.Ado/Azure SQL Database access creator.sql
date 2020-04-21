use master

CREATE LOGIN [username] 
WITH PASSWORD='password';  
  
-- add user 
CREATE USER [username] 
FROM LOGIN [username] 
WITH DEFAULT_SCHEMA=dbo; 
  
-- add user to role(s) in db 
ALTER ROLE db_datareader ADD MEMBER [username]; 
ALTER ROLE db_datawriter ADD MEMBER [username]; 

GO

-- use another connection to execute the command below

use Employees

ALTER ROLE db_owner ADD MEMBER [username]; 

GO