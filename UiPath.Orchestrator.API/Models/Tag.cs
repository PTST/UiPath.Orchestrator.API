using System.Text.Json.Serialization;

namespace PTST.UiPath.Orchestrator.Models
{
    public partial class Tag
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("DisplayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("Value")]
        public string Value { get; set; }

        [JsonPropertyName("DisplayValue")]
        public string DisplayValue { get; set; }
    }
}