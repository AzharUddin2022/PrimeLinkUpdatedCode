using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Common.Implementation
{
    public static class Extension
    {
        
        public static DateTime ToLocalTime(this DateTimeOffset? dateTime)
        {

            DateTime localTime = new DateTime();
            try
            {
                if (dateTime.HasValue)
                {
                    DateTime? utcTime = Convert.ToDateTime(Convert.ToString(dateTime));
                    var dt = DateTime.SpecifyKind(utcTime.Value, DateTimeKind.Local);
                    localTime = utcTime.Value.ToLocalTime();
                }
            }
            catch
            {
            }
            return localTime;
        }
    }
}
