using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace AglTest.Framework.Logging
{
    public static class AglLogger
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void AddWarningLog(Exception ex, string customMessage = "",params object[] args)
        {
            _logger.Warn(ex, customMessage, args);
        }

        public static void AddErrorLog(Exception ex, string customMessage = "", params object[] args)
        {
            _logger.Error(ex, customMessage, args);
        }

        public static void AddInfoLog(Exception ex, string customMessage = "", params object[] args)
        {
            _logger.Info(ex, customMessage, args);
            
        }
        public static void AddFalalLog(Exception ex, string customMessage = "", params object[] args)
        {
            _logger.Fatal(ex, customMessage, args);

        }
        public static void AddDebugLog(Exception ex, string customMessage = "", params object[] args)
        {
            _logger.Debug(ex, customMessage, args);

        }


    }
}
