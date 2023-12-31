﻿using HomeHero_API.Models;
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
        public DbSet<Request_Area> Request_Area { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<PaymentRecord> PaymentRecord { get; set; }
        public DbSet<PayMethod> PayMethod { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tutorial> Tutorial { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TokenData> TokenData { get; set; }
        public DbSet<PasswordResetRequest> PasswordResetRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .Property(l => l.LocationID)
                .ValueGeneratedNever();

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
            modelBuilder.Entity<Request>()
                .HasOne(q => q.AreaOfRequest)
                .WithMany(a => a.Request_Areas)
                .HasForeignKey(q => q.AreaID_Request)
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
               .HasForeignKey(cu => cu.UserID_Application)
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

        }
    }
}
