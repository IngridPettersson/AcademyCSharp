Hela Scaffold-command inklusive rätt connection string:

Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MemoryDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Models/Entities" -Context "MyContext" -Force


Min connection string:

Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MemoryDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False