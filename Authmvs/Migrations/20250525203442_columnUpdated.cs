using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authmvs.Migrations
{
    /// <inheritdoc />
    public partial class columnUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // COMENTA TODAS LAS LÍNEAS DE DROPFOREIGNKEY
    // migrationBuilder.DropForeignKey(
    //     name: "FK_OccupationUsers_Occupations_OccupationId",
    //     table: "OccupationUsers");

    // migrationBuilder.DropForeignKey(
    //     name: "FK_OccupationUsers_UserProfiles_UserProfilesId",
    //     table: "OccupationUsers");

    // migrationBuilder.DropForeignKey(
    //     name: "FK_ThemeUsers_Themes_ThemeId",
    //     table: "ThemeUsers");

    // migrationBuilder.DropForeignKey(
    //     name: "FK_ThemeUsers_UserProfiles_UserProfilesId",
    //     table: "ThemeUsers");

    // migrationBuilder.DropForeignKey(
    //     name: "FK_UserProfiles_Users_UserId",
    //     table: "UserProfiles");

    // migrationBuilder.DropForeignKey(
    //     name: "FK_UserSchedules_UserProfiles_UserProfilesId",
    //     table: "UserSchedules");

    // COMENTA TODAS LAS LÍNEAS DE DROPINDEX
    // migrationBuilder.DropIndex(
    //     name: "IX_UserSchedules_UserProfilesId",
    //     table: "UserSchedules");

    // migrationBuilder.DropIndex(
    //     name: "IX_UserProfiles_UserId",
    //     table: "UserProfiles");

    // migrationBuilder.DropIndex(
    //     name: "IX_ThemeUsers_ThemeId",
    //     table: "ThemeUsers");

    // migrationBuilder.DropIndex(
    //     name: "IX_ThemeUsers_UserProfilesId",
    //     table: "ThemeUsers");

    // migrationBuilder.DropIndex(
    //     name: "IX_OccupationUsers_OccupationId",
    //     table: "OccupationUsers");

    // migrationBuilder.DropIndex(
    //     name: "IX_OccupationUsers_UserProfilesId",
    //     table: "OccupationUsers");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "UserSchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "UserSchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "UserSchedules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "UserSchedules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.CreateIndex(
                name: "IX_UserSchedules_UserProfilesId",
                table: "UserSchedules",
                column: "UserProfilesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThemeUsers_ThemeId",
                table: "ThemeUsers",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeUsers_UserProfilesId",
                table: "ThemeUsers",
                column: "UserProfilesId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationUsers_OccupationId",
                table: "OccupationUsers",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationUsers_UserProfilesId",
                table: "OccupationUsers",
                column: "UserProfilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_OccupationUsers_Occupations_OccupationId",
                table: "OccupationUsers",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "OccupationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OccupationUsers_UserProfiles_UserProfilesId",
                table: "OccupationUsers",
                column: "UserProfilesId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfilesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThemeUsers_Themes_ThemeId",
                table: "ThemeUsers",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "ThemeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThemeUsers_UserProfiles_UserProfilesId",
                table: "ThemeUsers",
                column: "UserProfilesId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfilesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchedules_UserProfiles_UserProfilesId",
                table: "UserSchedules",
                column: "UserProfilesId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfilesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
