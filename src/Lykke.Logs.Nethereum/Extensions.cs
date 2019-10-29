using System;
using Lykke.Common.Log;
using LogLevel = Common.Logging.LogLevel;

namespace Lykke.Logs.Nethereum
{
    public static class Extensions
    {
        public static NethereumLog CreateNethereumLog<TComponent>(this ILogFactory logFactory, TComponent component, LogLevel logLevel = LogLevel.All)
        {
            if (logFactory == null)
            {
                throw new ArgumentNullException(nameof(logFactory));
            }

            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            var lykkeLog = logFactory.CreateLog(component);
            
            return new NethereumLog(lykkeLog, logLevel);
        }
    }
}