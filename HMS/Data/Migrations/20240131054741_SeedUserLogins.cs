using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace HMS.Data.Migrations
{
    public partial class SeedUserLogins : Migration
    {
        const string ADMIN_ROLE_GUID = "7920335d-3493-44fb-b1ab-b28425c3ca2d";
        const string SM_ROLE_GUID = "8217f310-44aa-46bc-8354-06221709b436\r\n";
        const string SR_ROLE_GUID = "42f661d7-9d9a-43b9-9cd3-40704859b6a7";

        const string ADMIN_USER_GUID = "a0a9da34-4d71-4303-8428-73e382dd716d";
        const string SM_USER_GUID = "1a1cbea6-35f9-4482-8718-f4360d3dbef1";
        const string SR1_USER_GUID = "61543ee8-a722-4ae3-8b77-292dacc652d3";



        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var passwordHash = hasher.HashPassword(null, "Password1!");

            AddUser(migrationBuilder, "admin@medicare.com", passwordHash, ADMIN_USER_GUID);

            AddUser(migrationBuilder, "rakesh@medicare.com", passwordHash, SM_USER_GUID);


            AddUser(migrationBuilder, "ankii@medicare.com", passwordHash, SR1_USER_GUID);


            AddRole(migrationBuilder, "Admin", ADMIN_ROLE_GUID);
            AddRole(migrationBuilder, "SM", SM_ROLE_GUID);

            AddRole(migrationBuilder, "SR", SR_ROLE_GUID);

            AddUserToRole(migrationBuilder, ADMIN_USER_GUID, ADMIN_ROLE_GUID);
            AddUserToRole(migrationBuilder, SM_USER_GUID, SM_ROLE_GUID);

            AddUserToRole(migrationBuilder, SR1_USER_GUID, SR_ROLE_GUID);

        }
        private void AddUser(MigrationBuilder migrationBuilder, string email, string passwordHash, string userGuid)
        {
            StringBuilder sb = new StringBuilder();

            string emailCaps = email.ToUpper();

            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{userGuid}'");
            sb.AppendLine($",'{email}'");
            sb.AppendLine($",'{emailCaps}'");
            sb.AppendLine($",'{email}'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine($",'{emailCaps}'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());
        }
        private void AddRole(MigrationBuilder migrationBuilder, string roleName, string roleGuid)
        {
            string roleNameCaps = roleName.ToUpper();

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{roleGuid}','{roleName}','{roleNameCaps}')");


        }

        private void AddUserToRole(MigrationBuilder migrationBuilder, string userGuid, string roleGuid)
        {
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{userGuid}','{roleGuid}')");


        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            RemoveUser(migrationBuilder, ADMIN_USER_GUID, ADMIN_ROLE_GUID);
            RemoveUser(migrationBuilder, SM_USER_GUID, SM_ROLE_GUID);

            RemoveUser(migrationBuilder, SR1_USER_GUID, SR_ROLE_GUID);


            RemoveRole(migrationBuilder, ADMIN_ROLE_GUID);
            RemoveRole(migrationBuilder, SM_ROLE_GUID);

            RemoveRole(migrationBuilder, SR_ROLE_GUID);
        }
        private void RemoveUser(MigrationBuilder migrationBuilder, string userGuid, string roleGuid)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{userGuid}' AND RoleId = '{roleGuid}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{userGuid}'");
        }
        private void RemoveRole(MigrationBuilder migrationBuilder, string roleGuid)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{roleGuid}'");
        }
    }
}