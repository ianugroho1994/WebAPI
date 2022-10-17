using System.Runtime.CompilerServices;
using Serilog;

namespace Common.Helpers
{
    public class LogHelper
    {
        private readonly ILogger? _logger;
        
        public LogHelper(ILogger? logger)
        {
            //LogHelper can be set as null for unit and integration test purpose, so we don't need to inject a log helper or create a mock class
            if (logger == null)
            {
                return;
            }
            _logger = logger;
        }

        public void LogInfo(string message, [CallerMemberName] string caller = "", [CallerFilePath] string sourceFilePath = "",
                            [CallerLineNumber] int sourceLineNumber = 0)
        {
            _logger?.Information($"{sourceFilePath} {sourceLineNumber} {caller} {message}");
        }

        public void LogError(string message, [CallerMemberName] string caller = "", [CallerFilePath] string sourceFilePath = "",
                             [CallerLineNumber] int sourceLineNumber = 0)
        {
            _logger?.Error($"{sourceFilePath} {sourceLineNumber} {caller} {message}");
        }

        public void LogDebug(string message, [CallerMemberName] string caller = "", [CallerFilePath] string sourceFilePath = "",
                             [CallerLineNumber] int sourceLineNumber = 0)
        {
            _logger?.Debug($"{sourceFilePath} {sourceLineNumber} {caller} {message}");
        }
    }
}
