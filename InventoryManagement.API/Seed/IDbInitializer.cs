namespace InventoryManagement.API.Seed
{
    public interface IDbInitializer
    {
        Task SeedRolesAndUsers();
    }
}
