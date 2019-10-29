using System;
using Common.Logging.Factory;
using Lykke.Common.Log;
using ILykkeLog = Common.Log.ILog;
using LogLevel = Common.Logging.LogLevel;

namespace Lykke.Logs.Nethereum
{
    public class NethereumLog : AbstractLogger
    {
        private readonly ILykkeLog _lykkeLog;
        private readonly LogLevel _logLevel;

        private const string LoggerName = nameof(NethereumLog);

        public NethereumLog(ILykkeLog lykkeLog, LogLevel logLevel = LogLevel.All)
        {
            _logLevel = logLevel;
            _lykkeLog = lykkeLog;
        }

        protected override void WriteInternal(LogLevel level, object message, Exception exception)
        {
            var textMessage = message?.ToString();
            
            switch (level)
            {
                case LogLevel.All:
                case LogLevel.Trace:
                    _lykkeLog.Trace(LoggerName, textMessage, exception: exception);
                    break;
                case LogLevel.Debug:
                    _lykkeLog.Debug(LoggerName, textMessage, exception: exception);
                    break;
                case LogLevel.Info:
                    _lykkeLog.Info(LoggerName, textMessage, exception: exception);
                    break;
                case LogLevel.Warn:
                    _lykkeLog.Warning(LoggerName, textMessage, exception);
                    break;
                case LogLevel.Error:
                    _lykkeLog.Error(LoggerName, exception, textMessage);
                    break;
                case LogLevel.Fatal:
                    _lykkeLog.Critical(LoggerName, exception, textMessage);
                    break;
                case LogLevel.Off:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, "Unexpected nethereum log level");
            }
        }

        public override bool IsTraceEnabled => _logLevel <= LogLevel.Trace;

        public override bool IsDebugEnabled => _logLevel <= LogLevel.Debug;

        public override bool IsInfoEnabled => _logLevel <= LogLevel.Info;

        public override bool IsWarnEnabled => _logLevel <= LogLevel.Warn;

        public override bool IsErrorEnabled => _logLevel <= LogLevel.Error;

        public override bool IsFatalEnabled => _logLevel <= LogLevel.Fatal;
    }
}