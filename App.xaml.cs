using DoAnCSharp_WPF.Models;
using System.Configuration;
using System.Data;
using System.Windows;
using Serilog;

namespace DoAnCSharp_WPF
{ 
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    path: @"D:\Tool\Visual Studio\Project\DoAnCSharp_WPF\log.txt",
                    fileSizeLimitBytes: 1 * 1024 * 1024, // 1MB
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: 5,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] - {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            Log.Information("Ứng dụng Quản lý Sinh viên bắt đầu khởi chạy trên nền tảng WPF.");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Log.Information("Ứng dụng kết thúc.");
            Log.CloseAndFlush();
            base.OnExit(e);
        }
    }

}
