using Application.Domain.Entities;
using Application.Drivens.MainDatabase;
using Application.Drivens.MainDatabase.Repositories;
using Database.EntityConfigurations;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class MainDbContext : DbContext, IMainDbContext
{
    #region DbSets

    public required DbSet<Organization> Organizations { get; init; }
    public required DbSet<OrgMember> OrgMembers { get; init; }
    public required DbSet<ClassRoom> ClassRooms { get; init; }
    public required DbSet<ClassMember> ClassMembers { get; init; }

    #endregion

    #region Repositories

    public required IOrganizationRepository OrganizationRepo { get; init; }
    public required IOrgMemberRepository OrgMemberRepo { get; init; }
    public required IClassRoomRepository ClassRoomRepo { get; init; }
    public required IClassMemberRepository ClassMemberRepo { get; init; }

    #endregion
    
    public MainDbContext(DbContextOptions options) : base(options)
    {
        OrganizationRepo = new OrganizationRepository(this);
        OrgMemberRepo = new OrgMemberRepository(this);
        ClassRoomRepo = new ClassRoomRepository(this);
        ClassMemberRepo = new ClassMemberRepository(this);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<,>).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}