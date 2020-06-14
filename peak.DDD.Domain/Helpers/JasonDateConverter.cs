using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace peak.DDD.Domain.Helpers
{
    class JasonDateConverter : IsoDateTimeConverter
    {

        public JasonDateConverter()
        {
            DateTimeFormat = "dd/MM/yyyy hh:mm:ss";
        }
    }
}
