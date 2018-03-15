using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Lathorva.Common.Utils
{
    public static class LoggingExtensions
    {
        public static void LogInformationObject(this ILogger logger, object obj)
        {
            logger.LogInformation(JsonConvert.SerializeObject(obj));
        }

        public static void LogErrorObject(this ILogger logger, object obj)
        {
            logger.LogError(JsonConvert.SerializeObject(obj));
        }
    }
}
