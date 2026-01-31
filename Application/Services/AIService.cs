using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AIService
    {
        private readonly IncubatorDbContext _context;

        public AIService(IncubatorDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetResponseAsync(string question)
        {
            string lowerQuestion = question.ToLower();

            if (lowerQuestion.Contains("doanh thu"))
            {
                //var totalRevenue = await _context.sales_orders.SumAsync(o => o.total_amount ?? 0);
                //return $"📊 Tổng doanh thu hiện tại là {totalRevenue:N0} VNĐ. Dữ liệu được cập nhật từ hệ thống quản lý đơn hàng.";
            }
            else if (lowerQuestion.Contains("thiết bị") || lowerQuestion.Contains("lỗi"))
            {
                var warningDevices = await _context.incubators.CountAsync(i => i.status == "warning");
                var maintenanceDevices = await _context.incubators.CountAsync(i => i.status == "maintenance");
                return $"⚠️ Hiện có {warningDevices} thiết bị đang cảnh báo và {maintenanceDevices} thiết bị đang bảo trì.";
            }
            else if (lowerQuestion.Contains("đơn hàng"))
            {
                var orderCount = await _context.sales_orders.CountAsync();
                return $"📦 Hệ thống ghi nhận tổng cộng {orderCount} đơn hàng đã và đang được xử lý.";
            }

            return "🤖 Tôi là trợ lý ảo EggCompany. Tôi có thể cung cấp thông tin về doanh thu, tình trạng thiết bị và đơn hàng. Bạn muốn biết gì?";
        }
    }
}
