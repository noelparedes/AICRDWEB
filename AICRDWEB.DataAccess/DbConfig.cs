using AICRDWEB.DataAccess.Migrations;
using AICRDWEB.Models;
using System.Data.Entity;

namespace AICRDWEB
{
    public class DbConfig
    {

        public static void ConfigureDb()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<AICRDWEBDbContext, Configuration>()
                );

        }
    }
}
