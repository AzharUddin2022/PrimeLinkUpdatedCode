using PrimLink.LoggingFiles.Interface;
using NLog;

namespace PrimLink.LoggingFiles.Implementation
{
    public class Log :ILog
    {

        public static NLog.ILogger _logger = LogManager.GetLogger("App");//LogManager.GetCurrentClassLogger();

        public Log(Logger logger)
        {
            _logger = logger;
        }
        public void Debuging(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string ex)
        {
            _logger.Error(ex);
        }

        public void Information(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }
    }
}
