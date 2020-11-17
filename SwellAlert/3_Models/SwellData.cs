using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SwellAlert.Models
{
    [Serializable]
    public sealed class SwellData : Dictionary<ForecastDay, DailySwellData>
    {
        public SwellData(){}

        private SwellData(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}
