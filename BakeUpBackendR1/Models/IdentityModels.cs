using System.Data.Entity;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using BakeUpBackendR1.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BakeUpBackendR1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    internal class DbInitializer : MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration> //DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DbInitializer());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ingrediente> Ingredienti { get; set; }
        public DbSet<IngredienteRicetta> IngredientiRicette { get; set; }
        public DbSet<Ricetta> Ricette { get; set; }
        public DbSet<SysPar> SysPars { get; set; }
    }
}