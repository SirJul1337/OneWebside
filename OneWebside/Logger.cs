using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWebside
{
    public static class Log
    {
        public static ILogger Logger = new LoggerConfiguration()
        .WriteTo.File("log.txt")
        .CreateLogger();
    }
}
