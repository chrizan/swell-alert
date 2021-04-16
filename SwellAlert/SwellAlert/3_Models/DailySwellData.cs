using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SwellAlert.Models
{
    [Serializable]
    public sealed class DailySwellData : Dictionary<ForecastHour, HourlySwellData>
    {
        public DailySwellData() { }

        private DailySwellData(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public string Date { get; set; }
    }
}
