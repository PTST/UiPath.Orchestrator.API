using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PTST.UiPath.Orchestrator.Models
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FolderProvisionType
    {
        Manual = 0,
        Automatic = 1
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FolderPermissionModel
    {
        InheritFromTenant = 0,
        FineGrained = 1
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FolderFeedType
    {
        Undefined = 0,
        Processes = 1,
        Libraries = 2,
        PersonalWorkspace = 3,
        FolderHierarchy = 4
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum QueueItemStatus
    {
        New = 0,
        InProgress = 1,
        Failed = 2,
        Successful = 3,
        Abandoned = 4,
        Retried = 5,
        Deleted = 6
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum QueueItemReviewStatus
    {
        None = 0,
        InReview = 1,
        Verified = 2,
        Retried = 3
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum QueueItemProcessingExceptionType
    {
        ApplicationException = 0,
        BusinessException = 1
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum QueueItemPriority
    {
        High = 0,
        Normal = 1,
        Low = 2
    }
}
