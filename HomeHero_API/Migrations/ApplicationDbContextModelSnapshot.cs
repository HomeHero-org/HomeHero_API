﻿// <auto-generated />
using System;
using HomeHero_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeHero_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomeHero_API.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationID"));

                    b.Property<int>("RequestID_Application")
                        .HasColumnType("int");

                    b.Property<decimal>("RequestedPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("UserID_Application")
                        .HasColumnType("int");

                    b.HasKey("ApplicationID");

                    b.HasIndex("RequestID_Application");

                    b.HasIndex("UserID_Application");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("HomeHero_API.Models.Aptitude", b =>
                {
                    b.Property<int>("AptitudeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AptitudeID"));

                    b.Property<string>("AptitudeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AptitudeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AptitudeID");

                    b.ToTable("Aptitude");
                });

            modelBuilder.Entity("HomeHero_API.Models.Aptitude_User", b =>
                {
                    b.Property<int>("UserApID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserApID"));

                    b.Property<int>("AptitudeID_Aptitude_User")
                        .HasColumnType("int");

                    b.Property<int>("UserID_Aptitude_User")
                        .HasColumnType("int");

                    b.HasKey("UserApID");

                    b.HasIndex("AptitudeID_Aptitude_User");

                    b.HasIndex("UserID_Aptitude_User");

                    b.ToTable("Aptitude_User");
                });

            modelBuilder.Entity("HomeHero_API.Models.Area", b =>
                {
                    b.Property<int>("AreaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaID"));

                    b.Property<string>("NameArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaID");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("HomeHero_API.Models.AttentionRequest", b =>
                {
                    b.Property<int>("AttentionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttentionID"));

                    b.Property<DateTime>("AttentionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("AttentionReqValue")
                        .HasColumnType("decimal(10,4)");

                    b.Property<int>("AttentionRequest_StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("HelperUserID")
                        .HasColumnType("int");

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.Property<int>("RequestID_AttentionRequest")
                        .HasColumnType("int");

                    b.HasKey("AttentionID");

                    b.HasIndex("AttentionRequest_StateID");

                    b.HasIndex("HelperUserID");

                    b.HasIndex("RequestID_AttentionRequest");

                    b.ToTable("AttentionRequest");
                });

            modelBuilder.Entity("HomeHero_API.Models.Chat", b =>
                {
                    b.Property<int>("ChatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatID"));

                    b.Property<DateTime>("ChatCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestID_Chat")
                        .HasColumnType("int");

                    b.HasKey("ChatID");

                    b.HasIndex("RequestID_Chat");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("HomeHero_API.Models.Complaint", b =>
                {
                    b.Property<int>("ComplaintID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplaintID"));

                    b.Property<int>("AttenderUserID")
                        .HasColumnType("int");

                    b.Property<string>("ComplaimentState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComplaintMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ComplaintedUserID")
                        .HasColumnType("int");

                    b.Property<int>("RequestComplaintID")
                        .HasColumnType("int");

                    b.Property<int>("UnsatisfiedUserID")
                        .HasColumnType("int");

                    b.HasKey("ComplaintID");

                    b.HasIndex("AttenderUserID");

                    b.HasIndex("ComplaintedUserID");

                    b.HasIndex("RequestComplaintID");

                    b.HasIndex("UnsatisfiedUserID");

                    b.ToTable("Complaint");
                });

            modelBuilder.Entity("HomeHero_API.Models.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<string>("NumPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID_Contact")
                        .HasColumnType("int");

                    b.HasKey("ContactID");

                    b.HasIndex("UserID_Contact");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("HomeHero_API.Models.Doubt", b =>
                {
                    b.Property<int>("DoubtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoubtID"));

                    b.Property<string>("AnswerContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AnswerDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuestionContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("QuestionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuestionerID")
                        .HasColumnType("int");

                    b.Property<int>("ResponderID")
                        .HasColumnType("int");

                    b.HasKey("DoubtID");

                    b.HasIndex("QuestionerID");

                    b.HasIndex("ResponderID");

                    b.ToTable("Doubt");
                });

            modelBuilder.Entity("HomeHero_API.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.HasKey("LocationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("HomeHero_API.Models.Message", b =>
                {
                    b.Property<int>("MesaggeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MesaggeID"));

                    b.Property<int>("ChatID_Message")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMessage")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserChatID")
                        .HasColumnType("int");

                    b.HasKey("MesaggeID");

                    b.HasIndex("ChatID_Message");

                    b.HasIndex("UserChatID");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("HomeHero_API.Models.PayMethod", b =>
                {
                    b.Property<int>("PMethodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PMethodID"));

                    b.Property<string>("NamePMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PMethodID");

                    b.ToTable("PayMethod");
                });

            modelBuilder.Entity("HomeHero_API.Models.PaymentRecord", b =>
                {
                    b.Property<int>("PRecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PRecordID"));

                    b.Property<int?>("AttentionRequestAttentionID")
                        .HasColumnType("int");

                    b.Property<int>("PMethodID_PaymentRecord")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PaymentReceipt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PRecordID");

                    b.HasIndex("AttentionRequestAttentionID");

                    b.HasIndex("PMethodID_PaymentRecord");

                    b.ToTable("PaymentRecord");
                });

            modelBuilder.Entity("HomeHero_API.Models.Qualification", b =>
                {
                    b.Property<int>("QualificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QualificationID"));

                    b.Property<int>("ApplicantUserID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HelperUserID")
                        .HasColumnType("int");

                    b.Property<decimal>("QualificationNumber")
                        .HasColumnType("decimal(10,4)");

                    b.Property<int>("RequestID_Qualification")
                        .HasColumnType("int");

                    b.HasKey("QualificationID");

                    b.HasIndex("ApplicantUserID");

                    b.HasIndex("HelperUserID");

                    b.HasIndex("RequestID_Qualification");

                    b.ToTable("Qualification");
                });

            modelBuilder.Entity("HomeHero_API.Models.Request", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestID"));

                    b.Property<int>("AreaID_Request")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationServiceID")
                        .HasColumnType("int");

                    b.Property<int>("MembersNeeded")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationReqDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReqStateID_Request")
                        .HasColumnType("int");

                    b.Property<string>("RequestContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RequestPicture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RequestTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId_Request")
                        .HasColumnType("int");

                    b.HasKey("RequestID");

                    b.HasIndex("AreaID_Request");

                    b.HasIndex("LocationServiceID");

                    b.HasIndex("ReqStateID_Request");

                    b.HasIndex("UserId_Request");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("HomeHero_API.Models.Request_Area", b =>
                {
                    b.Property<int>("RequestAreaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestAreaID"));

                    b.Property<int>("AreaID_Request")
                        .HasColumnType("int");

                    b.Property<int>("RequestID_Request")
                        .HasColumnType("int");

                    b.HasKey("RequestAreaID");

                    b.HasIndex("AreaID_Request");

                    b.HasIndex("RequestID_Request");

                    b.ToTable("Request_Area");
                });

            modelBuilder.Entity("HomeHero_API.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<int>("CodeRole")
                        .HasColumnType("int");

                    b.Property<string>("NameRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("HomeHero_API.Models.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateID"));

                    b.Property<string>("NameState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateID");

                    b.ToTable("State");
                });

            modelBuilder.Entity("HomeHero_API.Models.Tutorial", b =>
                {
                    b.Property<int>("TutorialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorialID"));

                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TutorialIPDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TutorialLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TutorialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TutorialID");

                    b.HasIndex("CreatorID");

                    b.ToTable("Tutorial");
                });

            modelBuilder.Entity("HomeHero_API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<byte[]>("Curriculum")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationResidenceID")
                        .HasColumnType("int");

                    b.Property<string>("NamesUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("QualificationUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("RealUserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<string>("SexUser")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("SurnamesUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("VolunteerPermises")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<byte[]>("VolunteerVoucher")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("UserId");

                    b.HasIndex("LocationResidenceID");

                    b.HasIndex("RoleID_User");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HomeHero_API.Models.Application", b =>
                {
                    b.HasOne("HomeHero_API.Models.Request", "Request_Application")
                        .WithMany("Applications")
                        .HasForeignKey("RequestID_Application")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.User", "User_Application")
                        .WithMany("Applications")
                        .HasForeignKey("UserID_Application")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Request_Application");

                    b.Navigation("User_Application");
                });

            modelBuilder.Entity("HomeHero_API.Models.Aptitude_User", b =>
                {
                    b.HasOne("HomeHero_API.Models.Aptitude", "Aptitude_Aptitude_User")
                        .WithMany("Aptitude_Users")
                        .HasForeignKey("AptitudeID_Aptitude_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.User", "User_Aptitude_User")
                        .WithMany("Aptitude_Users")
                        .HasForeignKey("UserID_Aptitude_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aptitude_Aptitude_User");

                    b.Navigation("User_Aptitude_User");
                });

            modelBuilder.Entity("HomeHero_API.Models.AttentionRequest", b =>
                {
                    b.HasOne("HomeHero_API.Models.State", "AttentionRequest_State")
                        .WithMany("AttentionRequests")
                        .HasForeignKey("AttentionRequest_StateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.User", "HelperUser")
                        .WithMany("AttentionRequests")
                        .HasForeignKey("HelperUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.Request", "Request_AttentionRequest")
                        .WithMany("AttentionRequests")
                        .HasForeignKey("RequestID_AttentionRequest")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AttentionRequest_State");

                    b.Navigation("HelperUser");

                    b.Navigation("Request_AttentionRequest");
                });

            modelBuilder.Entity("HomeHero_API.Models.Chat", b =>
                {
                    b.HasOne("HomeHero_API.Models.Request", "Request_Chat")
                        .WithMany("Chats")
                        .HasForeignKey("RequestID_Chat")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Request_Chat");
                });

            modelBuilder.Entity("HomeHero_API.Models.Complaint", b =>
                {
                    b.HasOne("HomeHero_API.Models.User", "AttenderUser")
                        .WithMany("AttenderUsers")
                        .HasForeignKey("AttenderUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.User", "ComplaintedUser")
                        .WithMany("ComplaintedUsers")
                        .HasForeignKey("ComplaintedUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.Request", "RequestComplaint")
                        .WithMany("ReqComplaints")
                        .HasForeignKey("RequestComplaintID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.User", "UnsatisfiedUser")
                        .WithMany("UnsatisfiedUsers")
                        .HasForeignKey("UnsatisfiedUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AttenderUser");

                    b.Navigation("ComplaintedUser");

                    b.Navigation("RequestComplaint");

                    b.Navigation("UnsatisfiedUser");
                });

            modelBuilder.Entity("HomeHero_API.Models.Contact", b =>
                {
                    b.HasOne("HomeHero_API.Models.User", "User_Contact")
                        .WithMany("Contacts")
                        .HasForeignKey("UserID_Contact")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User_Contact");
                });

            modelBuilder.Entity("HomeHero_API.Models.Doubt", b =>
                {
                    b.HasOne("HomeHero_API.Models.User", "Questioner")
                        .WithMany("Doubts")
                        .HasForeignKey("QuestionerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.User", "Responder")
                        .WithMany()
                        .HasForeignKey("ResponderID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Questioner");

                    b.Navigation("Responder");
                });

            modelBuilder.Entity("HomeHero_API.Models.Message", b =>
                {
                    b.HasOne("HomeHero_API.Models.Chat", "Chat_Message")
                        .WithMany("Messages")
                        .HasForeignKey("ChatID_Message")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.User", "User_Message")
                        .WithMany("Messages")
                        .HasForeignKey("UserChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat_Message");

                    b.Navigation("User_Message");
                });

            modelBuilder.Entity("HomeHero_API.Models.PaymentRecord", b =>
                {
                    b.HasOne("HomeHero_API.Models.AttentionRequest", null)
                        .WithMany("PaymentRecords")
                        .HasForeignKey("AttentionRequestAttentionID");

                    b.HasOne("HomeHero_API.Models.PayMethod", "PayMethod_PaymentRecord")
                        .WithMany("PaymentRecords")
                        .HasForeignKey("PMethodID_PaymentRecord")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PayMethod_PaymentRecord");
                });

            modelBuilder.Entity("HomeHero_API.Models.Qualification", b =>
                {
                    b.HasOne("HomeHero_API.Models.User", "ApplicantUser")
                        .WithMany("Qualifications")
                        .HasForeignKey("ApplicantUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.User", "HelperUser")
                        .WithMany()
                        .HasForeignKey("HelperUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.Request", "Request_Qualification")
                        .WithMany("Qualifications")
                        .HasForeignKey("RequestID_Qualification")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicantUser");

                    b.Navigation("HelperUser");

                    b.Navigation("Request_Qualification");
                });

            modelBuilder.Entity("HomeHero_API.Models.Request", b =>
                {
                    b.HasOne("HomeHero_API.Models.Area", "AreaOfRequest")
                        .WithMany("Request_Areas")
                        .HasForeignKey("AreaID_Request")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.Location", "Location_Request")
                        .WithMany("Requests")
                        .HasForeignKey("LocationServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.State", "RequestState")
                        .WithMany("Requests")
                        .HasForeignKey("ReqStateID_Request")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.User", "UserRequest")
                        .WithMany("Requests")
                        .HasForeignKey("UserId_Request")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AreaOfRequest");

                    b.Navigation("Location_Request");

                    b.Navigation("RequestState");

                    b.Navigation("UserRequest");
                });

            modelBuilder.Entity("HomeHero_API.Models.Request_Area", b =>
                {
                    b.HasOne("HomeHero_API.Models.Area", "Area_RA")
                        .WithMany()
                        .HasForeignKey("AreaID_Request")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.Request", "Request_RA")
                        .WithMany("Request_Areas")
                        .HasForeignKey("RequestID_Request")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area_RA");

                    b.Navigation("Request_RA");
                });

            modelBuilder.Entity("HomeHero_API.Models.Tutorial", b =>
                {
                    b.HasOne("HomeHero_API.Models.User", "Creator")
                        .WithMany("Tutorials")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("HomeHero_API.Models.User", b =>
                {
                    b.HasOne("HomeHero_API.Models.Location", "LocationResidence")
                        .WithMany("Users")
                        .HasForeignKey("LocationResidenceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeHero_API.Models.Role", "Role_User")
                        .WithMany("Users")
                        .HasForeignKey("RoleID_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationResidence");

                    b.Navigation("Role_User");
                });

            modelBuilder.Entity("HomeHero_API.Models.Aptitude", b =>
                {
                    b.Navigation("Aptitude_Users");
                });

            modelBuilder.Entity("HomeHero_API.Models.Area", b =>
                {
                    b.Navigation("Request_Areas");
                });

            modelBuilder.Entity("HomeHero_API.Models.AttentionRequest", b =>
                {
                    b.Navigation("PaymentRecords");
                });

            modelBuilder.Entity("HomeHero_API.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("HomeHero_API.Models.Location", b =>
                {
                    b.Navigation("Requests");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HomeHero_API.Models.PayMethod", b =>
                {
                    b.Navigation("PaymentRecords");
                });

            modelBuilder.Entity("HomeHero_API.Models.Request", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("AttentionRequests");

                    b.Navigation("Chats");

                    b.Navigation("Qualifications");

                    b.Navigation("ReqComplaints");

                    b.Navigation("Request_Areas");
                });

            modelBuilder.Entity("HomeHero_API.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("HomeHero_API.Models.State", b =>
                {
                    b.Navigation("AttentionRequests");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("HomeHero_API.Models.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Aptitude_Users");

                    b.Navigation("AttenderUsers");

                    b.Navigation("AttentionRequests");

                    b.Navigation("ComplaintedUsers");

                    b.Navigation("Contacts");

                    b.Navigation("Doubts");

                    b.Navigation("Messages");

                    b.Navigation("Qualifications");

                    b.Navigation("Requests");

                    b.Navigation("Tutorials");

                    b.Navigation("UnsatisfiedUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
