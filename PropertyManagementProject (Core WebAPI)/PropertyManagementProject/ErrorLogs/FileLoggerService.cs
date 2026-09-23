using System;
using System.IO;
using System.Text;

namespace ErrorLogs
{
    namespace FileLogger
    {
        /// <summary>
        /// سرویس لاگ‌گیری ساده که exception ها را در فایل متنی ذخیره می‌کند
        /// </summary>
        public class FileLoggerService
        {
            private readonly string _logDirectory;
            private readonly string _logFilePath;
            private static readonly object _lock = new object();

            /// <summary>
            /// مقداردهی اولیه - اگر مسیر ندهید، پوشه Logs کنار پروژه ساخته می‌شود
            /// </summary>
            /// <param name="logDirectory">مسیر دلخواه برای ذخیره فایل‌های لاگ (اختیاری)</param>
            public FileLoggerService(string? logDirectory = null)
            {
                _logDirectory = logDirectory ?? Path.Combine(AppContext.BaseDirectory, "Logs");

                if (!Directory.Exists(_logDirectory))
                {
                    Directory.CreateDirectory(_logDirectory);
                }

                // فایل لاگ جداگانه برای هر روز
                string fileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
                _logFilePath = Path.Combine(_logDirectory, fileName);
            }

            /// <summary>
            /// ثبت Exception با DateTime، Message و StackTrace
            /// </summary>
            /// <param name="ex">Exception مورد نظر</param>
            /// <param name="additionalMessage">پیام اضافی دلخواه (اختیاری)</param>
            public void LogException(Exception? ex, string? additionalMessage = null)
            {
                try
                {
                    string logEntry = BuildExceptionLogEntry(ex, additionalMessage);

                    lock (_lock)
                    {
                        File.AppendAllText(_logFilePath, logEntry, Encoding.UTF8);
                    }
                }
                catch
                {
                    // عمداً سکوت - لاگ‌گیری نباید باعث crash برنامه شود
                }
            }

            /// <summary>
            /// ثبت پیام ساده متنی
            /// </summary>
            /// <param name="message">متن پیام</param>
            public void LogMessage(string message)
            {
                try
                {
                    string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO\n" +
                                      $"Message   : {message}\n" +
                                      $"{new string('-', 60)}\n\n";

                    lock (_lock)
                    {
                        File.AppendAllText(_logFilePath, logEntry, Encoding.UTF8);
                    }
                }
                catch
                {
                    // عمداً سکوت
                }
            }

            private string BuildExceptionLogEntry(Exception? ex, string? additionalMessage)
            {
                var sb = new StringBuilder();
                sb.AppendLine(new string('=', 60));
                sb.AppendLine($"DateTime   : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                if (!string.IsNullOrWhiteSpace(additionalMessage))
                    sb.AppendLine($"Note       : {additionalMessage}");

                string Mess = ex != null ? ex.Message : "NULL";

                sb.AppendLine($"Message    : {Mess}");

                if (ex?.InnerException != null)
                    sb.AppendLine($"Inner Ex   : {ex.InnerException.Message}");

                sb.AppendLine("StackTrace :");
                sb.AppendLine(ex?.StackTrace ?? "N/A");
                sb.AppendLine(new string('=', 60));
                sb.AppendLine();

                return sb.ToString();
            }

            /// <summary>مسیر فایل لاگ جاری</summary>
            public string LogFilePath => _logFilePath;

            /// <summary>مسیر پوشه لاگ‌ها</summary>
            public string LogDirectory => _logDirectory;
        }
    }

}
