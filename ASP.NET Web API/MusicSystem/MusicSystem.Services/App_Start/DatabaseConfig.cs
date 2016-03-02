namespace MusicSystem.Services.App_Start
{
    using System.Data.Entity;
    using MusicSystem.Data;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicSystemDbContext, Configuration>());
        }
    }
}