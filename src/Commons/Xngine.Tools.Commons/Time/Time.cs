using System;
using System.Collections.Generic;
using System.Text;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Tools.Commons.Time
{
    public interface ITime
    {
        DateTime Now();
        DateTime NowUTC();
    }

    [Dependency]
    class Time : ITime
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime NowUTC()
        {
            return DateTime.UtcNow;
        }
    }
}
