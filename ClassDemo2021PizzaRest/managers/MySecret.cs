using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassDemo2021PizzaRest.managers
{
    public class MySecret
    {
        public static String ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PeleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static String ConnectionStringAzure = @"Data Source=pele-zealand-dbserver.database.windows.net;Initial Catalog=pele-zealand-db;User ID=pele-admin;Password=Secret1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    }
}
