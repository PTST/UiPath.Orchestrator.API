using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Macross.Json.Extensions;

namespace PTST.UiPath.Orchestrator.Models
{
    public class Folder : IUipathResponseSingle
    {
        [JsonPropertyName("Key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public Guid Key { get; set; }

        [JsonPropertyName("DisplayName")]

        public string DisplayName { get; set; }

        [JsonPropertyName("FullyQualifiedName")]

        public string FullyQualifiedName { get; set; }

        [JsonPropertyName("Description")]

        public string Description { get; set; }

        [JsonPropertyName("IsPersonal")]
        public bool? IsPersonal { get; set; }

        [JsonPropertyName("ProvisionType")]
        public FolderProvisionType? ProvisionType { get; set; }

        [JsonPropertyName("PermissionModel")]
        public FolderPermissionModel? PermissionModel { get; set; }

        [JsonPropertyName("ParentId")]
        public long? ParentId { get; set; }

        [JsonPropertyName("ParentKey")]
        public Guid? ParentKey { get; set; }

        [JsonPropertyName("FeedType")]
        public FolderFeedType? FeedType { get; set; }

        [JsonPropertyName("Id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long Id { get; set; }

        [JsonPropertyName("IsActive")]
        public bool? IsActive { get; set; }
    }
}
