using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace DanialCMS.EndPoints.WebUI.Infrastructures
{
    public static class TextLoggerExtensions
    {
        private static string fileName = "ErrorLogs.txt";
        private static string logPath =
            Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", fileName);

        public static ILogger TextLog(this ILogger logger, LogLevel logLevel, EventId eventId, Exception exception, string message, params object[] args)
        {
            var lines = $"{DateTime.Now.ToString("%yy-%M-%d %h:%m:%s")} " +
                $"{logLevel}[{eventId}] " +
                $"{string.Format(message, args)} " +
                ((exception == null)? "\n": $"With Exception : '{exception.Message}'\n");

            File.AppendAllText(logPath, lines);
            return logger;
        }
        
        public static ILogger TextLog(this ILogger logger, LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, logLevel, new EventId(0), exception, message, args);
        }
        public static ILogger TextLog(this ILogger logger, LogLevel logLevel, EventId eventId, string message, params object[] args)
        {
            return TextLog(logger, logLevel, eventId, null, message, args);
        }
        public static ILogger TextLog(this ILogger logger, LogLevel logLevel, string message, params object[] args)
        {
            return logger.TextLog(logLevel, new EventId(0), null, message, args); ;
        }



        public static ILogger TextLogWarning(this ILogger logger, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Warning, message, args);
        }
        public static ILogger TextLogWarning(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Warning, eventId, message, args);
        }
        public static ILogger TextLogWarning(this ILogger logger, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Warning, exception, message, args);
        }
        public static ILogger TextLogWarning(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Warning, eventId, exception, message, args);
        }

        public static ILogger TextLogTrace(this ILogger logger, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Trace, message, args);
        }
        public static ILogger TextLogTrace(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Trace, eventId, message, args);
        }
        public static ILogger TextLogTrace(this ILogger logger, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Trace, exception, message, args);
        }
        public static ILogger TextLogTrace(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Trace, eventId, exception, message, args);
        }

        public static ILogger TextLogCritical(this ILogger logger, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Critical, message, args);
        }
        public static ILogger TextLogCritical(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Critical, eventId, message, args);
        }
        public static ILogger TextLogCritical(this ILogger logger, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Critical, exception, message, args);
        }
        public static ILogger TextLogCritical(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Critical, eventId, exception, message, args);
        }

        public static ILogger TextLogInformation(this ILogger logger, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Information, message, args);
        }
        public static ILogger TextLogInformation(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Information, eventId, message, args);
        }
        public static ILogger TextLogInformation(this ILogger logger, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Information, exception, message, args);
        }
        public static ILogger TextLogInformation(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Information, eventId, exception, message, args);
        }
        
        public static ILogger TextLogError(this ILogger logger, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Error, message, args);
        }
        public static ILogger TextLogError(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Error, eventId, message, args);
        }
        public static ILogger TextLogError(this ILogger logger, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Error, exception, message, args);
        }
        public static ILogger TextLogError(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Error, eventId, exception, message, args);
        }

        public static ILogger TextLogDebug(this ILogger logger, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Debug, message, args);
        }
        public static ILogger TextLogDebug(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Debug, eventId, message, args);
        }
        public static ILogger TextLogDebug(this ILogger logger, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Debug, exception, message, args);
        }
        public static ILogger TextLogDebug(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            return TextLog(logger, LogLevel.Debug, eventId, exception, message, args);
        }

                     
    }

}
