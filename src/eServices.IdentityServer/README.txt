1. Identity Server Database Migration (Code-First):

Add-Migration InitialPersisteenceDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb

Add-Migration InitialConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb

Add-Migration InitialIdentityDbMigration -c ApplicationAuthDbContext -o Data/Migrations/AspNetIdentity/AspNetIdentityDb

Update-Database -Context PersistedGrantDbContext

Update-Database -Context ConfigurationDbContext

Update-Database -Context ApplicationAuthDbContext