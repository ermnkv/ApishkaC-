using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsApi.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83FD758E07C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id_car = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<long>(type: "bigint", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.id_car);
                    table.ForeignKey(
                        name: "FK_cars_users",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "channels",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    owner_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__channels__3213E83FF13B4603", x => x.id);
                    table.ForeignKey(
                        name: "FKc6sorav30ddgywp6vt99wen6x",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id_event = table.Column<long>(type: "bigint", nullable: false),
                    id_user = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id_event);
                    table.ForeignKey(
                        name: "FK_events_users",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    id_trip = table.Column<long>(type: "bigint", nullable: false),
                    id_user = table.Column<long>(type: "bigint", nullable: false),
                    start_data = table.Column<DateTime>(type: "datetime", nullable: false),
                    end_data = table.Column<DateTime>(type: "datetime", nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.id_trip);
                    table.ForeignKey(
                        name: "FK_trips_users",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "followers",
                columns: table => new
                {
                    id_user = table.Column<long>(type: "bigint", nullable: false),
                    id_channel = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followers", x => new { x.id_user, x.id_channel });
                    table.ForeignKey(
                        name: "FK_followers_channels",
                        column: x => x.id_channel,
                        principalTable: "channels",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_followers_users",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "ntext", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset(6)", precision: 6, nullable: false),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    channel_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__posts__3213E83F79A02219", x => x.id);
                    table.ForeignKey(
                        name: "FK5d144ba1aao7dgdj6ksonkp32",
                        column: x => x.channel_id,
                        principalTable: "channels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tripsparticipation",
                columns: table => new
                {
                    id_trip = table.Column<long>(type: "bigint", nullable: false),
                    id_user = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tripsparticipation", x => new { x.id_trip, x.id_user });
                    table.ForeignKey(
                        name: "FK_tripsparticipation_trips",
                        column: x => x.id_trip,
                        principalTable: "trips",
                        principalColumn: "id_trip");
                    table.ForeignKey(
                        name: "FK_tripsparticipation_users",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id_com = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<long>(type: "bigint", nullable: false),
                    com_post = table.Column<long>(type: "bigint", nullable: false),
                    content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id_com);
                    table.ForeignKey(
                        name: "FK_comment_posts",
                        column: x => x.com_post,
                        principalTable: "posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_comment_users",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    like_post = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => new { x.id, x.like_post });
                    table.ForeignKey(
                        name: "FK_likes_posts",
                        column: x => x.like_post,
                        principalTable: "posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_likes_users",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_id",
                table: "cars",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_channels_owner_id",
                table: "channels",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_com_post",
                table: "comment",
                column: "com_post");

            migrationBuilder.CreateIndex(
                name: "IX_comment_id",
                table: "comment",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_events_id_user",
                table: "events",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_followers_id_channel",
                table: "followers",
                column: "id_channel");

            migrationBuilder.CreateIndex(
                name: "IX_likes_like_post",
                table: "likes",
                column: "like_post");

            migrationBuilder.CreateIndex(
                name: "IX_posts_channel_id",
                table: "posts",
                column: "channel_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_id_user",
                table: "trips",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_tripsparticipation_id_user",
                table: "tripsparticipation",
                column: "id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "followers");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "tripsparticipation");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "channels");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
