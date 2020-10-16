using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AbpAuditLogs",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ApplicationName = table.Column<string>(maxLength: 96, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    TenantName = table.Column<string>(nullable: true),
                    ImpersonatorUserId = table.Column<Guid>(nullable: true),
                    ImpersonatorTenantId = table.Column<Guid>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    ClientId = table.Column<string>(maxLength: 64, nullable: true),
                    CorrelationId = table.Column<string>(maxLength: 64, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    HttpMethod = table.Column<string>(maxLength: 16, nullable: true),
                    Url = table.Column<string>(maxLength: 256, nullable: true),
                    Exceptions = table.Column<string>(maxLength: 4000, nullable: true),
                    Comments = table.Column<string>(maxLength: 256, nullable: true),
                    HttpStatusCode = table.Column<int>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpAuditLogs", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpBackgroundJobs",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    JobName = table.Column<string>(maxLength: 128, nullable: false),
                    JobArgs = table.Column<string>(maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>(nullable: false, defaultValue: (short) 0),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    NextTryTime = table.Column<DateTime>(nullable: false),
                    LastTryTime = table.Column<DateTime>(nullable: true),
                    IsAbandoned = table.Column<bool>(nullable: false, defaultValue: false),
                    Priority = table.Column<byte>(nullable: false, defaultValue: (byte) 15)
                },
                constraints: table => { table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpClaimTypes",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    Regex = table.Column<string>(maxLength: 512, nullable: true),
                    RegexDescription = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    ValueType = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpClaimTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpFeatureValues",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpFeatureValues", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpPermissionGrants",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpPermissionGrants", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpRoles",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpSettings",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2048, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpSettings", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpTenants",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpTenants", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUsers",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Surname = table.Column<string>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    PasswordHash = table.Column<string>(maxLength: 256, nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 16, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    AccessFailedCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table => { table.PrimaryKey("PK_AbpUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                "IdentityServerApiResources",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerApiResources", x => x.Id); });

            migrationBuilder.CreateTable(
                "IdentityServerClients",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    ProtocolType = table.Column<string>(maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(nullable: false),
                    RequireConsent = table.Column<bool>(nullable: false),
                    AllowRememberConsent = table.Column<bool>(nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    RequirePkce = table.Column<bool>(nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    IdentityTokenLifetime = table.Column<int>(nullable: false),
                    AccessTokenLifetime = table.Column<int>(nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(nullable: false),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false),
                    RefreshTokenUsage = table.Column<int>(nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false),
                    AccessTokenType = table.Column<int>(nullable: false),
                    EnableLocalLogin = table.Column<bool>(nullable: false),
                    IncludeJwtId = table.Column<bool>(nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerClients", x => x.Id); });

            migrationBuilder.CreateTable(
                "IdentityServerDeviceFlowCodes",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerDeviceFlowCodes", x => x.Id); });

            migrationBuilder.CreateTable(
                "IdentityServerIdentityResources",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerIdentityResources", x => x.Id); });

            migrationBuilder.CreateTable(
                "IdentityServerPersistedGrants",
                table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_IdentityServerPersistedGrants", x => x.Key); });

            migrationBuilder.CreateTable(
                "SoMall_ProductCategory",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_SoMall_ProductCategory", x => x.Id); });

            migrationBuilder.CreateTable(
                "SoMall_Shops",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ShortName = table.Column<string>(maxLength: 16, nullable: false),
                    LogoImage = table.Column<string>(maxLength: 255, nullable: false),
                    CoverImage = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_SoMall_Shops", x => x.Id); });

            migrationBuilder.CreateTable(
                "Visitor_Credentials",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Data = table.Column<string>(maxLength: 255, nullable: false),
                    UseTimes = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Visitor_Credentials", x => x.Id); });

            migrationBuilder.CreateTable(
                "Visitor_Forms",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Theme = table.Column<int>(nullable: false, defaultValue: 0),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Visitor_Forms", x => x.Id); });

            migrationBuilder.CreateTable(
                "Weixin_WechatUserinfos",
                table => new
                {
                    appid = table.Column<string>(maxLength: 32, nullable: false),
                    openid = table.Column<string>(maxLength: 32, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    unionid = table.Column<string>(maxLength: 32, nullable: true),
                    nickname = table.Column<string>(maxLength: 32, nullable: true),
                    headimgurl = table.Column<string>(maxLength: 255, nullable: true),
                    city = table.Column<string>(maxLength: 255, nullable: true),
                    province = table.Column<string>(maxLength: 255, nullable: true),
                    country = table.Column<string>(maxLength: 255, nullable: true),
                    sex = table.Column<int>(nullable: false),
                    FromClient = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Weixin_WechatUserinfos", x => new {x.openid, x.appid}); });

            migrationBuilder.CreateTable(
                "AbpAuditLogActions",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 128, nullable: true),
                    Parameters = table.Column<string>(maxLength: 2000, nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogActions", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpAuditLogActions_AbpAuditLogs_AuditLogId",
                        x => x.AuditLogId,
                        "AbpAuditLogs",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpEntityChanges",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityTenantId = table.Column<Guid>(nullable: true),
                    EntityId = table.Column<string>(maxLength: 128, nullable: false),
                    EntityTypeFullName = table.Column<string>(maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpEntityChanges_AbpAuditLogs_AuditLogId",
                        x => x.AuditLogId,
                        "AbpAuditLogs",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpRoleClaims",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(maxLength: 1024, nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpRoleClaims_AbpRoles_RoleId",
                        x => x.RoleId,
                        "AbpRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpTenantConnectionStrings",
                table => new
                {
                    TenantId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenantConnectionStrings", x => new {x.TenantId, x.Name});
                    table.ForeignKey(
                        "FK_AbpTenantConnectionStrings_AbpTenants_TenantId",
                        x => x.TenantId,
                        "AbpTenants",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserClaims",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(maxLength: 1024, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserClaims_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserLogins",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 196, nullable: false),
                    ProviderDisplayName = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLogins", x => new {x.UserId, x.LoginProvider});
                    table.ForeignKey(
                        "FK_AbpUserLogins_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserRoles",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AbpUserRoles_AbpRoles_RoleId",
                        x => x.RoleId,
                        "AbpRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AbpUserRoles_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserTokens",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AbpUserTokens_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerApiClaims",
                table => new
                {
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiClaims", x => new {x.ApiResourceId, x.Type});
                    table.ForeignKey(
                        "FK_IdentityServerApiClaims_IdentityServerApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "IdentityServerApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerApiScopes",
                table => new
                {
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiScopes", x => new {x.ApiResourceId, x.Name});
                    table.ForeignKey(
                        "FK_IdentityServerApiScopes_IdentityServerApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "IdentityServerApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerApiSecrets",
                table => new
                {
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiSecrets", x => new {x.ApiResourceId, x.Type, x.Value});
                    table.ForeignKey(
                        "FK_IdentityServerApiSecrets_IdentityServerApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        "IdentityServerApiResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientClaims",
                table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientClaims", x => new {x.ClientId, x.Type, x.Value});
                    table.ForeignKey(
                        "FK_IdentityServerClientClaims_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientCorsOrigins",
                table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Origin = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientCorsOrigins", x => new {x.ClientId, x.Origin});
                    table.ForeignKey(
                        "FK_IdentityServerClientCorsOrigins_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientGrantTypes",
                table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    GrantType = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientGrantTypes", x => new {x.ClientId, x.GrantType});
                    table.ForeignKey(
                        "FK_IdentityServerClientGrantTypes_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientIdPRestrictions",
                table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Provider = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientIdPRestrictions", x => new {x.ClientId, x.Provider});
                    table.ForeignKey(
                        "FK_IdentityServerClientIdPRestrictions_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientPostLogoutRedirectUris",
                table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientPostLogoutRedirectUris", x => new {x.ClientId, x.PostLogoutRedirectUri});
                    table.ForeignKey(
                        "FK_IdentityServerClientPostLogoutRedirectUris_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientProperties",
                table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientProperties", x => new {x.ClientId, x.Key});
                    table.ForeignKey(
                        "FK_IdentityServerClientProperties_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientRedirectUris",
                table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    RedirectUri = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientRedirectUris", x => new {x.ClientId, x.RedirectUri});
                    table.ForeignKey(
                        "FK_IdentityServerClientRedirectUris_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientScopes",
                table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    Scope = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientScopes", x => new {x.ClientId, x.Scope});
                    table.ForeignKey(
                        "FK_IdentityServerClientScopes_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerClientSecrets",
                table => new
                {
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerClientSecrets", x => new {x.ClientId, x.Type, x.Value});
                    table.ForeignKey(
                        "FK_IdentityServerClientSecrets_IdentityServerClients_ClientId",
                        x => x.ClientId,
                        "IdentityServerClients",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerIdentityClaims",
                table => new
                {
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    IdentityResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerIdentityClaims", x => new {x.IdentityResourceId, x.Type});
                    table.ForeignKey(
                        "FK_IdentityServerIdentityClaims_IdentityServerIdentityResources_IdentityResourceId",
                        x => x.IdentityResourceId,
                        "IdentityServerIdentityResources",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SoMall_ProductSpu",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoMall_ProductSpu", x => x.Id);
                    table.ForeignKey(
                        "FK_SoMall_ProductSpu_SoMall_ProductCategory_CategoryId",
                        x => x.CategoryId,
                        "SoMall_ProductCategory",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Visitor_FormItems",
                table => new
                {
                    FormId = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Label = table.Column<string>(maxLength: 64, nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    PlaceHolder = table.Column<string>(maxLength: 64, nullable: false),
                    DefaultValue = table.Column<string>(maxLength: 64, nullable: true),
                    ErrorText = table.Column<string>(maxLength: 64, nullable: true),
                    IsRequired = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDisable = table.Column<bool>(nullable: false, defaultValue: false),
                    IsMulti = table.Column<bool>(nullable: false, defaultValue: false),
                    SelectionJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor_FormItems", x => new {x.FormId, x.ItemId});
                    table.ForeignKey(
                        "FK_Visitor_FormItems_Visitor_Forms_FormId",
                        x => x.FormId,
                        "Visitor_Forms",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Visitor_ShopForms",
                table => new
                {
                    FormId = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor_ShopForms", x => new {x.FormId, x.ShopId});
                    table.ForeignKey(
                        "FK_Visitor_ShopForms_Visitor_Forms_FormId",
                        x => x.FormId,
                        "Visitor_Forms",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Visitor_ShopForms_SoMall_Shops_ShopId",
                        x => x.ShopId,
                        "SoMall_Shops",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Visitor_VisitorLogs",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    FormId = table.Column<Guid>(nullable: false),
                    FormJson = table.Column<string>(nullable: true),
                    CredentialId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor_VisitorLogs", x => x.Id);
                    table.ForeignKey(
                        "FK_Visitor_VisitorLogs_Visitor_Credentials_CredentialId",
                        x => x.CredentialId,
                        "Visitor_Credentials",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Visitor_VisitorLogs_Visitor_Forms_FormId",
                        x => x.FormId,
                        "Visitor_Forms",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpEntityPropertyChanges",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    EntityChangeId = table.Column<Guid>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 128, nullable: false),
                    PropertyTypeFullName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        x => x.EntityChangeId,
                        "AbpEntityChanges",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityServerApiScopeClaims",
                table => new
                {
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityServerApiScopeClaims", x => new {x.ApiResourceId, x.Name, x.Type});
                    table.ForeignKey(
                        "FK_IdentityServerApiScopeClaims_IdentityServerApiScopes_ApiResourceId_Name",
                        x => new {x.ApiResourceId, x.Name},
                        "IdentityServerApiScopes",
                        new[] {"ApiResourceId", "Name"},
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SoMall_ProductSku",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    SpuId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoMall_ProductSku", x => x.Id);
                    table.ForeignKey(
                        "FK_SoMall_ProductSku_SoMall_ProductSpu_SpuId",
                        x => x.SpuId,
                        "SoMall_ProductSpu",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogActions_AuditLogId",
                "AbpAuditLogActions",
                "AuditLogId");

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_ExecutionTime",
                "AbpAuditLogActions",
                new[] {"TenantId", "ServiceName", "MethodName", "ExecutionTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_ExecutionTime",
                "AbpAuditLogs",
                new[] {"TenantId", "ExecutionTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_UserId_ExecutionTime",
                "AbpAuditLogs",
                new[] {"TenantId", "UserId", "ExecutionTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
                "AbpBackgroundJobs",
                new[] {"IsAbandoned", "NextTryTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChanges_AuditLogId",
                "AbpEntityChanges",
                "AuditLogId");

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId",
                "AbpEntityChanges",
                new[] {"TenantId", "EntityTypeFullName", "EntityId"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityPropertyChanges_EntityChangeId",
                "AbpEntityPropertyChanges",
                "EntityChangeId");

            migrationBuilder.CreateIndex(
                "IX_AbpFeatureValues_Name_ProviderName_ProviderKey",
                "AbpFeatureValues",
                new[] {"Name", "ProviderName", "ProviderKey"});

            migrationBuilder.CreateIndex(
                "IX_AbpPermissionGrants_Name_ProviderName_ProviderKey",
                "AbpPermissionGrants",
                new[] {"Name", "ProviderName", "ProviderKey"});

            migrationBuilder.CreateIndex(
                "IX_AbpRoleClaims_RoleId",
                "AbpRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_NormalizedName",
                "AbpRoles",
                "NormalizedName");

            migrationBuilder.CreateIndex(
                "IX_AbpSettings_Name_ProviderName_ProviderKey",
                "AbpSettings",
                new[] {"Name", "ProviderName", "ProviderKey"});

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_Name",
                "AbpTenants",
                "Name");

            migrationBuilder.CreateIndex(
                "IX_AbpUserClaims_UserId",
                "AbpUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserLogins_LoginProvider_ProviderKey",
                "AbpUserLogins",
                new[] {"LoginProvider", "ProviderKey"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserRoles_RoleId_UserId",
                "AbpUserRoles",
                new[] {"RoleId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_Email",
                "AbpUsers",
                "Email");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_NormalizedEmail",
                "AbpUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_NormalizedUserName",
                "AbpUsers",
                "NormalizedUserName");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_UserName",
                "AbpUsers",
                "UserName");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerClients_ClientId",
                "IdentityServerClients",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerDeviceFlowCodes_DeviceCode",
                "IdentityServerDeviceFlowCodes",
                "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_IdentityServerDeviceFlowCodes_Expiration",
                "IdentityServerDeviceFlowCodes",
                "Expiration");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerDeviceFlowCodes_UserCode",
                "IdentityServerDeviceFlowCodes",
                "UserCode",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_IdentityServerPersistedGrants_Expiration",
                "IdentityServerPersistedGrants",
                "Expiration");

            migrationBuilder.CreateIndex(
                "IX_IdentityServerPersistedGrants_SubjectId_ClientId_Type",
                "IdentityServerPersistedGrants",
                new[] {"SubjectId", "ClientId", "Type"});

            migrationBuilder.CreateIndex(
                "IX_SoMall_ProductSku_SpuId",
                "SoMall_ProductSku",
                "SpuId");

            migrationBuilder.CreateIndex(
                "IX_SoMall_ProductSpu_CategoryId",
                "SoMall_ProductSpu",
                "CategoryId");

            migrationBuilder.CreateIndex(
                "IX_Visitor_ShopForms_ShopId",
                "Visitor_ShopForms",
                "ShopId");

            migrationBuilder.CreateIndex(
                "IX_Visitor_VisitorLogs_CredentialId",
                "Visitor_VisitorLogs",
                "CredentialId");

            migrationBuilder.CreateIndex(
                "IX_Visitor_VisitorLogs_FormId",
                "Visitor_VisitorLogs",
                "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AbpAuditLogActions");

            migrationBuilder.DropTable(
                "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                "AbpClaimTypes");

            migrationBuilder.DropTable(
                "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                "AbpFeatureValues");

            migrationBuilder.DropTable(
                "AbpPermissionGrants");

            migrationBuilder.DropTable(
                "AbpRoleClaims");

            migrationBuilder.DropTable(
                "AbpSettings");

            migrationBuilder.DropTable(
                "AbpTenantConnectionStrings");

            migrationBuilder.DropTable(
                "AbpUserClaims");

            migrationBuilder.DropTable(
                "AbpUserLogins");

            migrationBuilder.DropTable(
                "AbpUserRoles");

            migrationBuilder.DropTable(
                "AbpUserTokens");

            migrationBuilder.DropTable(
                "IdentityServerApiClaims");

            migrationBuilder.DropTable(
                "IdentityServerApiScopeClaims");

            migrationBuilder.DropTable(
                "IdentityServerApiSecrets");

            migrationBuilder.DropTable(
                "IdentityServerClientClaims");

            migrationBuilder.DropTable(
                "IdentityServerClientCorsOrigins");

            migrationBuilder.DropTable(
                "IdentityServerClientGrantTypes");

            migrationBuilder.DropTable(
                "IdentityServerClientIdPRestrictions");

            migrationBuilder.DropTable(
                "IdentityServerClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                "IdentityServerClientProperties");

            migrationBuilder.DropTable(
                "IdentityServerClientRedirectUris");

            migrationBuilder.DropTable(
                "IdentityServerClientScopes");

            migrationBuilder.DropTable(
                "IdentityServerClientSecrets");

            migrationBuilder.DropTable(
                "IdentityServerDeviceFlowCodes");

            migrationBuilder.DropTable(
                "IdentityServerIdentityClaims");

            migrationBuilder.DropTable(
                "IdentityServerPersistedGrants");

            migrationBuilder.DropTable(
                "SoMall_ProductSku");

            migrationBuilder.DropTable(
                "Visitor_FormItems");

            migrationBuilder.DropTable(
                "Visitor_ShopForms");

            migrationBuilder.DropTable(
                "Visitor_VisitorLogs");

            migrationBuilder.DropTable(
                "Weixin_WechatUserinfos");

            migrationBuilder.DropTable(
                "AbpEntityChanges");

            migrationBuilder.DropTable(
                "AbpTenants");

            migrationBuilder.DropTable(
                "AbpRoles");

            migrationBuilder.DropTable(
                "AbpUsers");

            migrationBuilder.DropTable(
                "IdentityServerApiScopes");

            migrationBuilder.DropTable(
                "IdentityServerClients");

            migrationBuilder.DropTable(
                "IdentityServerIdentityResources");

            migrationBuilder.DropTable(
                "SoMall_ProductSpu");

            migrationBuilder.DropTable(
                "SoMall_Shops");

            migrationBuilder.DropTable(
                "Visitor_Credentials");

            migrationBuilder.DropTable(
                "Visitor_Forms");

            migrationBuilder.DropTable(
                "AbpAuditLogs");

            migrationBuilder.DropTable(
                "IdentityServerApiResources");

            migrationBuilder.DropTable(
                "SoMall_ProductCategory");
        }
    }
}