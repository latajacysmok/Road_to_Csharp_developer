using NLog;
using NLog.Fluent;

namespace Logger
{
    public class NLogger : ILogger
    {
        private readonly NLog.Logger Logger;
        public NLogger()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Error(Exception exp)
        {
            Logger.Error(exp);
        }
    }
}
