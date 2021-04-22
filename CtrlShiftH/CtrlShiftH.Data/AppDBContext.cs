using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace CtrlShiftH.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(x => x.UserId);

            //modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }

        //public override int SaveChanges()
        //{
        //    var listLog = new List<ExaminationDetailLog>();
        //    var changedEntities = ChangeTracker.Entries();

        //    foreach (var changedEntity in changedEntities)
        //    {
        //        if (changedEntity.Entity is ExaminationDetail eDetail)
        //        {
        //            var now = DateTime.UtcNow;
        //            var stackTrace = new StackTrace();
        //            var method = stackTrace.GetFrame(1).GetMethod();
        //            var callerInfo = $"{method.DeclaringType.Name}.{method.Name}";
        //            switch (changedEntity.State)
        //            {
        //                case EntityState.Added:
        //                    eDetail.DateCreated = now;
        //                    break;

        //                case EntityState.Modified:
        //                    var modifiedProperties = Entry(eDetail).Properties.Where(e => e.IsModified).ToList();
        //                    var log = JsonConvert.SerializeObject(modifiedProperties.Select(_ => new { _.Metadata.Name, _.CurrentValue }));

        //                    break;
        //            }

        //        }
        //    }
        //    return base.SaveChanges();
        //}
    }
}

//Add-Migration AppDBContext_v30_1 -Context AppDBContext
//add-migration AppDBContext_v3
//update-database -Context AppDBContext –verbose