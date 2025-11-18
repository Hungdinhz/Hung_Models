using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hung_Models.Migrations.pdhDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaKhachHang = table.Column<string>(type: "text", nullable: true),
                    HoTenKhachHang = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    MaKhau = table.Column<string>(type: "text", nullable: true),
                    DienThoai = table.Column<string>(type: "text", nullable: true),
                    DiaChi = table.Column<string>(type: "text", nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TrangThai = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaLoai = table.Column<string>(type: "text", nullable: true),
                    TenLoai = table.Column<string>(type: "text", nullable: true),
                    TrangThai = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaHoaDon = table.Column<string>(type: "text", nullable: true),
                    MaKhaHang = table.Column<int>(type: "integer", nullable: true),
                    NgayHoaDon = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    HoTenKhachHang = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    DienThoai = table.Column<string>(type: "text", nullable: true),
                    DiaChi = table.Column<string>(type: "text", nullable: true),
                    TongTriGia = table.Column<double>(type: "double precision", nullable: true),
                    TrangThai = table.Column<byte>(type: "smallint", nullable: true),
                    MaKhaHangNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_MaKhaHangNavigationId",
                        column: x => x.MaKhaHangNavigationId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaSanPham = table.Column<string>(type: "text", nullable: true),
                    TenSanPham = table.Column<string>(type: "text", nullable: true),
                    HinhAnh = table.Column<string>(type: "text", nullable: true),
                    SoLuong = table.Column<int>(type: "integer", nullable: true),
                    DonGia = table.Column<double>(type: "double precision", nullable: true),
                    MaLoai = table.Column<int>(type: "integer", nullable: true),
                    TrangThai = table.Column<byte>(type: "smallint", nullable: true),
                    MaLoaiNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_MaLoaiNavigationId",
                        column: x => x.MaLoaiNavigationId,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CtHoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoaDonId = table.Column<int>(type: "integer", nullable: true),
                    SanPhamId = table.Column<int>(type: "integer", nullable: true),
                    SoLuongMua = table.Column<int>(type: "integer", nullable: true),
                    DonGiaMua = table.Column<double>(type: "double precision", nullable: true),
                    ThanhTien = table.Column<double>(type: "double precision", nullable: true),
                    TrangThai = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CtHoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CtHoaDons_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CtHoaDons_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CtHoaDons_HoaDonId",
                table: "CtHoaDons",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_CtHoaDons_SanPhamId",
                table: "CtHoaDons",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaKhaHangNavigationId",
                table: "HoaDons",
                column: "MaKhaHangNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaLoaiNavigationId",
                table: "SanPhams",
                column: "MaLoaiNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CtHoaDons");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");
        }
    }
}
