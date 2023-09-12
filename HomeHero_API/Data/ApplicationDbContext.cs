using HomeHero_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeHero_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Application> Application { get; set; }
        public DbSet<Aptitude> Aptitude { get; set; }
        public DbSet<Aptitude_User> Aptitude_User { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<AttentionRequest> AttentionRequest { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Doubt> Doubt { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<PaymentRecord> PaymentRecord { get; set; }
        public DbSet<PayMethod> PayMethod { get; set; }
        public DbSet<Qualification> Qualification { get; set; }

        public DbSet<Request> Request { get; set; }
        public DbSet<Request_Area> Request_Area { get; set; }

        public DbSet<State> State { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tutorial> Tutorial { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .Property(p => p.QualificationUser)
               .HasDefaultValue(0);
            modelBuilder.Entity<AttentionRequest>()
                .Property(p => p.AttentionRequest_StateID)
                .HasDefaultValue(1);
            modelBuilder.Entity<User>()
                .Property(p => p.VolunteerPermises)
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
               .Property(p => p.RoleID_User)
               .HasDefaultValue(2);
            modelBuilder.Entity<Complaint>()
                .HasOne(q => q.AttenderUser)
                .WithMany(a => a.AttenderUsers)
                .HasForeignKey(q => q.AttenderUserID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Complaint>()
                .HasOne(q => q.UnsatisfiedUser)
                .WithMany(a => a.UnsatisfiedUsers)
                .HasForeignKey(q => q.UnsatisfiedUserID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Complaint>()
                .HasOne(q => q.ComplaintedUser)
                .WithMany(a => a.ComplaintedUsers)
                .HasForeignKey(q => q.ComplaintedUserID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Complaint>()
               .HasOne(q => q.RequestComplaint)
               .WithMany(a => a.ReqComplaints)
               .HasForeignKey(q => q.RequestComplaintID)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Doubt>()
                 .HasOne(d => d.Questioner)
                 .WithMany(u => u.Doubts)
                 .HasForeignKey(d => d.QuestionerID)
                 .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Doubt>()
                .HasOne(d => d.Responder)
                .WithMany()
                .HasForeignKey(d => d.ResponderID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Qualification>()
               .HasOne(q => q.ApplicantUser)
               .WithMany()
               .HasForeignKey(q => q.ApplicantUserID);
            modelBuilder.Entity<Request>()
               .HasOne(r => r.UserRequest)
               .WithMany(a => a.Requests)
               .HasForeignKey(r => r.UserId_Request)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Qualification>()
               .HasOne(r => r.ApplicantUser)
               .WithMany(a => a.Qualifications)
               .HasForeignKey(r => r.ApplicantUserID)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Qualification>()
               .HasOne(r => r.HelperUser)
               .WithMany()
               .HasForeignKey(r => r.HelperUserID)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Application>()
               .HasOne(cu => cu.Request_Application)
               .WithMany(uc => uc.Applications)
               .HasForeignKey(cu => cu.RequestID_Application)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Application>()
               .HasOne(cu => cu.User_Application)
               .WithMany(uc => uc.Applications)
               .HasForeignKey(cu => cu.RequestID_Application)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AttentionRequest>()
              .HasOne(cu => cu.Request_AttentionRequest)
              .WithMany(a => a.AttentionRequests)
              .HasForeignKey(cu => cu.RequestID_AttentionRequest)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Chat>()
             .HasOne(cu => cu.Request_Chat)
             .WithMany(a => a.Chats)
             .HasForeignKey(cu => cu.RequestID_Chat)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Qualification>()
            .Property(q => q.QualificationNumber)
            .HasColumnType("decimal(10,4)");
            modelBuilder.Entity<AttentionRequest>()
            .Property(a => a.AttentionReqValue)
            .HasColumnType("decimal(10,4)");
            modelBuilder.Entity<Application>()
                .Property(a => a.RequestedPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleID = 1,
                    NameRole = "Admon"
                },
                new Role
                {
                    RoleID = 2,
                    NameRole = "User"
                }, new Role
                {
                    RoleID = 3,
                    NameRole = "PUser"
                }, new Role
                {
                    RoleID = 4,
                    NameRole = "Reviewer"
                }, new Role
                {
                    RoleID = 5,
                    NameRole = "TSupport"
                }
                );
            modelBuilder.Entity<State>().HasData(
                new State
                {
                    StateID = 1,
                    NameState = "Preparado"
                },
                new State
                {
                    StateID = 2,
                    NameState = "Progreso"
                },
                new State
                {
                    StateID = 3,
                    NameState = "Evaluacion"
                },
                new State
                {
                    StateID = 4,
                    NameState = "Pagado"
                },
                new State
                {
                    StateID = 5,
                    NameState = "PagoConfirmado"
                },
                new State
                {
                    StateID = 6,
                    NameState = "Terminado"
                }
                );
            modelBuilder.Entity<Location>().HasData(
                new Location { LocationID = 1, City = "AGUA DE DIOS" },
                new Location { LocationID = 2, City = "ALBAN" },
                new Location { LocationID = 3, City = "ANAPOIMA" }
                );
        }
    }
}
