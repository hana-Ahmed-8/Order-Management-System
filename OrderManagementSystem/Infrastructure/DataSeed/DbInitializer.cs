using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using OrderManagementSystem.Core.Entities;
using OrderManagementSystem.Infrastructure.Data;


namespace OrderManagementSystem.Infrastructure.DataSeed
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ApplicationDbContext context)
        {
            // 1. Seed roles
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new ApplicationRole("Admin"));

            if (!await roleManager.RoleExistsAsync("Customer"))
                await roleManager.CreateAsync(new ApplicationRole("Customer"));

            // 2. Seed Admin user
            if (await userManager.FindByNameAsync("admin") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true // optional
                };
                await userManager.CreateAsync(adminUser, "Admin@123"); // Password
                await userManager.AddToRoleAsync(adminUser, "Admin");

                // Create Admin entity
                var admin = new Admin
                {
                    Id = adminUser.Id,
                    ApplicationUser = adminUser
                };
                context.Admins.Add(admin);
            }

            // 3. Seed Customer user
            if (await userManager.FindByNameAsync("customer") == null)
            {
                var customerUser = new ApplicationUser
                {
                    UserName = "customer",
                    Email = "customer@example.com",
                    EmailConfirmed = true // optional
                };
                await userManager.CreateAsync(customerUser, "Customer@123");
                await userManager.AddToRoleAsync(customerUser, "Customer");

                // Create Customer entity
                var customer = new Customer
                {
                    Id = customerUser.Id,
                    Name = "Test Customer",
                    ApplicationUser = customerUser
                };
                context.Customers.Add(customer);
            }

            // 4. Seed sample products
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Laptop", Price = 999.99m, Stock = 50 },
                    new Product { Name = "Mouse", Price = 25.99m, Stock = 100 },
                    new Product { Name = "Keyboard", Price = 75.99m, Stock = 75 },
                    new Product { Name = "Monitor", Price = 299.99m, Stock = 30 },
                    new Product { Name = "Headphones", Price = 149.99m, Stock = 60 }
                };

                context.Products.AddRange(products);
            }

            await context.SaveChangesAsync();
        }
    }
}
