using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeHero_API.Migrations
{
    /// <inheritdoc />
    public partial class InitProjetWithModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aptitude",
                columns: table => new
                {
                    AptitudeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AptitudeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AptitudeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aptitude", x => x.AptitudeID);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "PayMethod",
                columns: table => new
                {
                    PMethodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethod", x => x.PMethodID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameState = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID_User = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    RealUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamesUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurnamesUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    VolunteerVoucher = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    QualificationUser = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LocationResidenceID = table.Column<int>(type: "int", nullable: false),
                    SexUser = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Curriculum = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    VolunteerPermises = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Location_LocationResidenceID",
                        column: x => x.LocationResidenceID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleID_User",
                        column: x => x.RoleID_User,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aptitude_User",
                columns: table => new
                {
                    UserApID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AptitudeID_Aptitude_User = table.Column<int>(type: "int", nullable: false),
                    UserID_Aptitude_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aptitude_User", x => x.UserApID);
                    table.ForeignKey(
                        name: "FK_Aptitude_User_Aptitude_AptitudeID_Aptitude_User",
                        column: x => x.AptitudeID_Aptitude_User,
                        principalTable: "Aptitude",
                        principalColumn: "AptitudeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aptitude_User_User_UserID_Aptitude_User",
                        column: x => x.UserID_Aptitude_User,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID_Contact = table.Column<int>(type: "int", nullable: false),
                    NumPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_Contact_User_UserID_Contact",
                        column: x => x.UserID_Contact,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doubt",
                columns: table => new
                {
                    DoubtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionerID = table.Column<int>(type: "int", nullable: false),
                    ResponderID = table.Column<int>(type: "int", nullable: false),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doubt", x => x.DoubtID);
                    table.ForeignKey(
                        name: "FK_Doubt_User_QuestionerID",
                        column: x => x.QuestionerID,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Doubt_User_ResponderID",
                        column: x => x.ResponderID,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationServiceID = table.Column<int>(type: "int", nullable: false),
                    UserId_Request = table.Column<int>(type: "int", nullable: false),
                    RequestContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationReqDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReqStateID_Request = table.Column<int>(type: "int", nullable: false),
                    MembersNeeded = table.Column<int>(type: "int", nullable: false),
                    RequestPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_Request_Location_LocationServiceID",
                        column: x => x.LocationServiceID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_State_ReqStateID_Request",
                        column: x => x.ReqStateID_Request,
                        principalTable: "State",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_User_UserId_Request",
                        column: x => x.UserId_Request,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Tutorial",
                columns: table => new
                {
                    TutorialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorialLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorialIPDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorial", x => x.TutorialID);
                    table.ForeignKey(
                        name: "FK_Tutorial_User_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID_Application = table.Column<int>(type: "int", nullable: false),
                    RequestID_Application = table.Column<int>(type: "int", nullable: false),
                    RequestedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Application_Request_RequestID_Application",
                        column: x => x.RequestID_Application,
                        principalTable: "Request",
                        principalColumn: "RequestID");
                    table.ForeignKey(
                        name: "FK_Application_User_RequestID_Application",
                        column: x => x.RequestID_Application,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "AttentionRequest",
                columns: table => new
                {
                    AttentionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID_AttentionRequest = table.Column<int>(type: "int", nullable: false),
                    HelperUserID = table.Column<int>(type: "int", nullable: false),
                    AttentionRequest_StateID = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    AttentionReqValue = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    AttentionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttentionRequest", x => x.AttentionID);
                    table.ForeignKey(
                        name: "FK_AttentionRequest_Request_RequestID_AttentionRequest",
                        column: x => x.RequestID_AttentionRequest,
                        principalTable: "Request",
                        principalColumn: "RequestID");
                    table.ForeignKey(
                        name: "FK_AttentionRequest_State_AttentionRequest_StateID",
                        column: x => x.AttentionRequest_StateID,
                        principalTable: "State",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttentionRequest_User_HelperUserID",
                        column: x => x.HelperUserID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID_Chat = table.Column<int>(type: "int", nullable: false),
                    ChatCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatID);
                    table.ForeignKey(
                        name: "FK_Chat_Request_RequestID_Chat",
                        column: x => x.RequestID_Chat,
                        principalTable: "Request",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ComplaintID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnsatisfiedUserID = table.Column<int>(type: "int", nullable: false),
                    AttenderUserID = table.Column<int>(type: "int", nullable: false),
                    ComplaintedUserID = table.Column<int>(type: "int", nullable: false),
                    RequestComplaintID = table.Column<int>(type: "int", nullable: false),
                    ComplaintMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaimentState = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ComplaintID);
                    table.ForeignKey(
                        name: "FK_Complaint_Request_RequestComplaintID",
                        column: x => x.RequestComplaintID,
                        principalTable: "Request",
                        principalColumn: "RequestID");
                    table.ForeignKey(
                        name: "FK_Complaint_User_AttenderUserID",
                        column: x => x.AttenderUserID,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Complaint_User_ComplaintedUserID",
                        column: x => x.ComplaintedUserID,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Complaint_User_UnsatisfiedUserID",
                        column: x => x.UnsatisfiedUserID,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    QualificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationNumber = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    HelperUserID = table.Column<int>(type: "int", nullable: false),
                    ApplicantUserID = table.Column<int>(type: "int", nullable: false),
                    RequestID_Qualification = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.QualificationID);
                    table.ForeignKey(
                        name: "FK_Qualification_Request_RequestID_Qualification",
                        column: x => x.RequestID_Qualification,
                        principalTable: "Request",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Qualification_User_ApplicantUserID",
                        column: x => x.ApplicantUserID,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Qualification_User_HelperUserID",
                        column: x => x.HelperUserID,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Request_Area",
                columns: table => new
                {
                    RequestAreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID_Request = table.Column<int>(type: "int", nullable: false),
                    AreaID_Request = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_Area", x => x.RequestAreaID);
                    table.ForeignKey(
                        name: "FK_Request_Area_Area_AreaID_Request",
                        column: x => x.AreaID_Request,
                        principalTable: "Area",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Area_Request_RequestID_Request",
                        column: x => x.RequestID_Request,
                        principalTable: "Request",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecord",
                columns: table => new
                {
                    PRecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PMethodID_PaymentRecord = table.Column<int>(type: "int", nullable: false),
                    PaymentReceipt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttentionRequestAttentionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecord", x => x.PRecordID);
                    table.ForeignKey(
                        name: "FK_PaymentRecord_AttentionRequest_AttentionRequestAttentionID",
                        column: x => x.AttentionRequestAttentionID,
                        principalTable: "AttentionRequest",
                        principalColumn: "AttentionID");
                    table.ForeignKey(
                        name: "FK_PaymentRecord_PayMethod_PMethodID_PaymentRecord",
                        column: x => x.PMethodID_PaymentRecord,
                        principalTable: "PayMethod",
                        principalColumn: "PMethodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MesaggeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatID_Message = table.Column<int>(type: "int", nullable: false),
                    UserChatID = table.Column<int>(type: "int", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateMessage = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MesaggeID);
                    table.ForeignKey(
                        name: "FK_Message_Chat_ChatID_Message",
                        column: x => x.ChatID_Message,
                        principalTable: "Chat",
                        principalColumn: "ChatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_User_UserChatID",
                        column: x => x.UserChatID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationID", "Address", "City" },
                values: new object[,]
                {
                    { 1, null, "AGUA DE DIOS" },
                    { 2, null, "ALBAN" },
                    { 3, null, "ANAPOIMA" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "NameRole" },
                values: new object[,]
                {
                    { 1, "Admon" },
                    { 2, "User" },
                    { 3, "PUser" },
                    { 4, "Reviewer" },
                    { 5, "TSupport" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "StateID", "NameState" },
                values: new object[,]
                {
                    { 1, "Preparado" },
                    { 2, "Progreso" },
                    { 3, "Evaluacion" },
                    { 4, "Pagado" },
                    { 5, "PagoConfirmado" },
                    { 6, "Terminado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_RequestID_Application",
                table: "Application",
                column: "RequestID_Application");

            migrationBuilder.CreateIndex(
                name: "IX_Aptitude_User_AptitudeID_Aptitude_User",
                table: "Aptitude_User",
                column: "AptitudeID_Aptitude_User");

            migrationBuilder.CreateIndex(
                name: "IX_Aptitude_User_UserID_Aptitude_User",
                table: "Aptitude_User",
                column: "UserID_Aptitude_User");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequest_AttentionRequest_StateID",
                table: "AttentionRequest",
                column: "AttentionRequest_StateID");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequest_HelperUserID",
                table: "AttentionRequest",
                column: "HelperUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionRequest_RequestID_AttentionRequest",
                table: "AttentionRequest",
                column: "RequestID_AttentionRequest");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_RequestID_Chat",
                table: "Chat",
                column: "RequestID_Chat");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_AttenderUserID",
                table: "Complaint",
                column: "AttenderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_ComplaintedUserID",
                table: "Complaint",
                column: "ComplaintedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_RequestComplaintID",
                table: "Complaint",
                column: "RequestComplaintID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_UnsatisfiedUserID",
                table: "Complaint",
                column: "UnsatisfiedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserID_Contact",
                table: "Contact",
                column: "UserID_Contact");

            migrationBuilder.CreateIndex(
                name: "IX_Doubt_QuestionerID",
                table: "Doubt",
                column: "QuestionerID");

            migrationBuilder.CreateIndex(
                name: "IX_Doubt_ResponderID",
                table: "Doubt",
                column: "ResponderID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatID_Message",
                table: "Message",
                column: "ChatID_Message");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserChatID",
                table: "Message",
                column: "UserChatID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecord_AttentionRequestAttentionID",
                table: "PaymentRecord",
                column: "AttentionRequestAttentionID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecord_PMethodID_PaymentRecord",
                table: "PaymentRecord",
                column: "PMethodID_PaymentRecord");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_ApplicantUserID",
                table: "Qualification",
                column: "ApplicantUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_HelperUserID",
                table: "Qualification",
                column: "HelperUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_RequestID_Qualification",
                table: "Qualification",
                column: "RequestID_Qualification");

            migrationBuilder.CreateIndex(
                name: "IX_Request_LocationServiceID",
                table: "Request",
                column: "LocationServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ReqStateID_Request",
                table: "Request",
                column: "ReqStateID_Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserId_Request",
                table: "Request",
                column: "UserId_Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Area_AreaID_Request",
                table: "Request_Area",
                column: "AreaID_Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Area_RequestID_Request",
                table: "Request_Area",
                column: "RequestID_Request");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorial_CreatorID",
                table: "Tutorial",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_User_LocationResidenceID",
                table: "User",
                column: "LocationResidenceID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID_User",
                table: "User",
                column: "RoleID_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Aptitude_User");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Doubt");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "PaymentRecord");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Request_Area");

            migrationBuilder.DropTable(
                name: "Tutorial");

            migrationBuilder.DropTable(
                name: "Aptitude");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "AttentionRequest");

            migrationBuilder.DropTable(
                name: "PayMethod");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
