using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarWashSystem.Models
{
    public class WashPackageDetails
    {
        [Key]
        public int PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        [JsonIgnore]
        public IEnumerable<AddOn> AddOn { set; get; }
        
    }
}
