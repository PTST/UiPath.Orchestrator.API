using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PTST.UiPath.Orchestrator.Models
{
    public class QueueItem : IUipathResponseSingle
    {
        [JsonPropertyName("QueueDefinitionId")]
        public long? QueueDefinitionId { get; set; }

        [JsonPropertyName("Encrypted")]
        public bool Encrypted { get; set; }

        [JsonPropertyName("OutputData")]
        public string OutputData { get; set; }

        [JsonPropertyName("AnalyticsData")]
        public string AnalyticsData { get; set; }

        [JsonPropertyName("Status")]
        public QueueItemStatus Status { get; set; }

        [JsonPropertyName("ReviewStatus")]
        public QueueItemReviewStatus ReviewStatus { get; set; }

        [JsonPropertyName("ReviewerUserId")]
        public long? ReviewerUserId { get; set; }

        [JsonPropertyName("Key")]
        public Guid Key { get; set; }

        [JsonPropertyName("Reference")]
        public string Reference { get; set; }

        [JsonPropertyName("ProcessingExceptionType")]
        public QueueItemProcessingExceptionType? ProcessingExceptionType { get; set; }

        [JsonPropertyName("DueDate")]
        public DateTimeOffset? DueDate { get; set; }

        [JsonPropertyName("RiskSlaDate")]
        public DateTimeOffset? RiskSlaDate { get; set; }

        [JsonPropertyName("Priority")]
        public QueueItemPriority Priority { get; set; }

        [JsonPropertyName("DeferDate")]
        public DateTimeOffset? DeferDate { get; set; }

        [JsonPropertyName("StartProcessing")]
        public DateTimeOffset? StartProcessing { get; set; }

        [JsonPropertyName("EndProcessing")]
        public DateTimeOffset? EndProcessing { get; set; }

        [JsonPropertyName("SecondsInPreviousAttempts")]
        public long? SecondsInPreviousAttempts { get; set; }

        [JsonPropertyName("AncestorId")]
        public long? AncestorId { get; set; }

        [JsonPropertyName("RetryNumber")]
        public long? RetryNumber { get; set; }

        [JsonPropertyName("SpecificData")]
        public string SpecificData { get; set; }

        [JsonPropertyName("CreationTime")]
        public DateTimeOffset CreationTime { get; set; }

        [JsonPropertyName("Progress")]
        public string Progress { get; set; }

        [JsonPropertyName("RowVersion")]
        public string RowVersion { get; set; }

        [JsonPropertyName("OrganizationUnitId")]
        public long? OrganizationUnitId { get; set; }

        [JsonPropertyName("OrganizationUnitFullyQualifiedName")]
        public string OrganizationUnitFullyQualifiedName { get; set; }

        [JsonPropertyName("Id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long Id { get; set; }

        [JsonPropertyName("ProcessingException")]
        public ProcessingException ProcessingException { get; set; }

        [JsonPropertyName("SpecificContent")]
        public Dictionary<string, object>? SpecificContent { get; set; }

        [JsonPropertyName("Output")]
        public Dictionary<string, object>? Output { get; set; }

        [JsonPropertyName("Analytics")]
        public Dictionary<string, object>? Analytics { get; set; }
    }

    public partial class ProcessingException
    {
        [JsonPropertyName("Reason")]
        public string Reason { get; set; }

        [JsonPropertyName("Details")]
        public string Details { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("AssociatedImageFilePath")]
        public string AssociatedImageFilePath { get; set; }

        [JsonPropertyName("CreationTime")]
        public DateTimeOffset CreationTime { get; set; }
    }
}
