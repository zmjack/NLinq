﻿using LinqSharp.EFCore.Design;
using LinqSharp.EFCore.Facades;
using LinqSharp.EFCore.Test;
using LinqSharp.EFCore.Test.DbFuncProviders;
using LinqSharp.EFCore.Translators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Northwnd;
using Northwnd.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LinqSharp.EFCore.Data.Test;

public class ApplicationDbContext : NorthwndContext, IConcurrencyResolvableContext, IUserTraceable, IRowLockable
{
    public int MaxConcurrencyRetry => 2;
    public bool IgnoreRowLock { get; set; }

    public const string DatabaseName = "linqsharp";

    public static ApplicationDbContext UseMySql(Action<MySqlDbContextOptionsBuilder> mySqlOptionsAction = null)
    {
        var connectionString = $"server=127.0.0.1;database={DatabaseName};AllowLoadLocalInfile=true";
#if EFCORE5_0_OR_GREATER
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptionsAction).Options;
#else
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySql(connectionString, mySqlOptionsAction).Options;
#endif
        return new ApplicationDbContext(options);
    }

    public static ApplicationDbContext UseSqlServer(Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
    {
        var connectionString = $@"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database={DatabaseName}";
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connectionString, sqlServerOptionsAction).Options;
        return new ApplicationDbContext(options);
    }

    public static ApplicationDbContext UseSqlite(Action<SqliteDbContextOptionsBuilder> sqliteOptionsAction = null)
    {
        var connectionString = $"filename={DatabaseName}.db";
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connectionString, sqliteOptionsAction).Options;
        return new ApplicationDbContext(options);
    }

    private readonly EntityMonitoringFacade _facade;
    public override DatabaseFacade Database => _facade;

    public string CurrentUser { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options, "@n")
    {
        _facade = new EntityMonitoringFacade(this, true);
        _facade.OnCommitted += Facade_OnCommitted;
        _facade.OnRollbacked += Facade_OnRollbacked;
        _facade.OnDisposing += Facade_OnDisposing;
    }

    public string LastChanged;
    private void Facade_OnCommitted(EntityMonitoringFacade.FacadeState state)
    {
        var addedOrUpdatedEntries = state.Entries<FacadeModel>(EntityState.Added, EntityState.Modified);
        if (addedOrUpdatedEntries.Any())
        {
            var first = addedOrUpdatedEntries.First().Entity as FacadeModel;
            LastChanged = $"Added or Updated: {first.Id} with {first.Name}";
        }

        var deletedEntries = state.Entries<FacadeModel>(EntityState.Deleted);
        if (deletedEntries.Any())
        {
            var first = deletedEntries.First().Entity as FacadeModel;
            LastChanged = $"Deleted: {first.Id} with {first.Name}";
        }
    }

    private void Facade_OnRollbacked(EntityMonitoringFacade.FacadeState state)
    {
        LastChanged = "Rollbacked";
    }

    private void Facade_OnDisposing(EntityMonitoringFacade.FacadeState state)
    {
        LastChanged = null;
    }

    public override DbSet<Category> Categories { get; set; }
    public override DbSet<CustomerDemographic> CustomerDemographics { get; set; }
    public override DbSet<Customer> Customers { get; set; }
    public override DbSet<Employee> Employees { get; set; }
    public override DbSet<OrderDetail> OrderDetails { get; set; }
    public override DbSet<Order> Orders { get; set; }
    public override DbSet<Product> Products { get; set; }
    public override DbSet<Region> Regions { get; set; }
    public override DbSet<Shipper> Shippers { get; set; }
    public override DbSet<Supplier> Suppliers { get; set; }
    public override DbSet<Territory> Territories { get; set; }
    public override DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
    public override DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

    public DbSet<AppRegistryEntity> AppRegistries { get; set; }
    public DbSet<AutoModel> AutoModels { get; set; }
    public DbSet<EntityMonitorModel> EntityMonitorModels { get; set; }
    public DbSet<SimpleModel> SimpleModels { get; set; }
    public DbSet<CPKeyModel> CompositeKeyModels { get; set; }
    public DbSet<AuditRoot> AuditRoots { get; set; }
    public DbSet<AuditLevel> AuditLevels { get; set; }
    public DbSet<AuditValue> AuditValues { get; set; }
    public DbSet<ConcurrencyModel> ConcurrencyModels { get; set; }
    public DbSet<YearMonthModel> YearMonthModels { get; set; }

    public DbSet<LS_Provider> LS_Providers { get; set; }
    public DbSet<LS_Index> LS_Indices { get; set; }
    public DbSet<LS_Name> LS_Names { get; set; }

    public DbSet<BulkTestModel> BulkTestModels { get; set; }
    public DbSet<SimpleRow> SimpleRows { get; set; }
    public DbSet<FacadeModel> FacadeModels { get; set; }

    public DbSet<Client> Clients { get; set; }
    public DbSet<RowLockModel> RowLockModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        LinqSharpEF.OnModelCreating(this, modelBuilder);

        LinqSharpEF.UseTranslator<DbRandom>(this, modelBuilder);
        LinqSharpEF.UseTranslator<DbConcat>(this, modelBuilder);
        LinqSharpEF.UseTranslator<DbDouble>(this, modelBuilder);
        LinqSharpEF.UseTranslator<DbDateTime>(this, modelBuilder);
        LinqSharpEF.UseTranslator<DbYearMonthNumber>(this, modelBuilder);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        return LinqSharpEF.SaveChanges(this, base.SaveChanges, acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        return LinqSharpEF.SaveChangesAsync(this, base.SaveChangesAsync, acceptAllChangesOnSuccess, cancellationToken);
    }

}
