using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace crm_tgui.Infrastructure
{
    // Class này chỉ thức dậy khi gõ lệnh dotnet ef, chạy app thật nó sẽ ngủ đông
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Bê y nguyên logic đường dẫn cực chuẩn của bạn sang đây
            var dbPath = PathHelper.GetPath();

            // Nặn ra cái DbContext Options để dỗ dành EF Core
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite($"DataSource={dbPath}");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}