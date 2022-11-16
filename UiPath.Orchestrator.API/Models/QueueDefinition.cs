using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PTST.UiPath.Orchestrator.Models
{
    public partial class QueueDefinition : IUipathResponseSingle
    {
        [JsonPropertyName("Key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Key { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("MaxNumberOfRetries")]
        public long MaxNumberOfRetries { get; set; }

        [JsonPropertyName("AcceptAutomaticallyRetry")]
        public bool AcceptAutomaticallyRetry { get; set; }

        [JsonPropertyName("EnforceUniqueReference")]
        public bool EnforceUniqueReference { get; set; }

        [JsonPropertyName("Encrypted")]
        public bool Encrypted { get; set; }

        [JsonPropertyName("SpecificDataJsonSchema")]
        public string SpecificDataJsonSchema { get; set; }

        [JsonPropertyName("OutputDataJsonSchema")]
        public string OutputDataJsonSchema { get; set; }

        [JsonPropertyName("AnalyticsDataJsonSchema")]
        public string AnalyticsDataJsonSchema { get; set; }

        [JsonPropertyName("CreationTime")]
        public DateTimeOffset CreationTime { get; set; }

        [JsonPropertyName("ProcessScheduleId")]
        public long? ProcessScheduleId { get; set; }

        [JsonPropertyName("SlaInMinutes")]
        public long SlaInMinutes { get; set; }

        [JsonPropertyName("RiskSlaInMinutes")]
        public long RiskSlaInMinutes { get; set; }

        [JsonPropertyName("ReleaseId")]
        public long? ReleaseId { get; set; }

        [JsonPropertyName("IsProcessInCurrentFolder")]
        public bool? IsProcessInCurrentFolder { get; set; }

        [JsonPropertyName("FoldersCount")]
        public long FoldersCount { get; set; }

        [JsonPropertyName("OrganizationUnitId")]
        public long OrganizationUnitId { get; set; }

        [JsonPropertyName("OrganizationUnitFullyQualifiedName")]
        public string OrganizationUnitFullyQualifiedName { get; set; }

        [JsonPropertyName("Tags")]
        public Tag[] Tags { get; set; }

        [JsonPropertyName("Id")]
        [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingDefault)]
        public long Id { get; set; }
    }
}
