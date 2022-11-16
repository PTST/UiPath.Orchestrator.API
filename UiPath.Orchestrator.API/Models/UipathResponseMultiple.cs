using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PTST.UiPath.Orchestrator.Models
{
public class UipathResponseMultiple<T> : IUipathResponseMultiple<T> where T: IUipathResponseSingle
    {
        [JsonPropertyName("@odata.context")]
        public Uri OdataContext { get; set; }

        [JsonPropertyName("@odata.count")]
        public long OdataCount { get; set; }

        [JsonPropertyName("value")]
        public T[] Value { get; set; }
    }
}