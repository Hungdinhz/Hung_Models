using Microsoft.EntityFrameworkCore;

namespace Hung_Models.Models
{
    public class pdhDbContext : DbContext
    {
        public pdhDbContext(DbContextOptions<pdhDbContext> options)
            : base(options)
        {


        }

        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

        public DbSet<SanPham> SanPhams { get; set; }

        public DbSet<HoaDon> HoaDons { get; set; }

        public DbSet<CtHoaDon> CtHoaDons { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }


    }
}
