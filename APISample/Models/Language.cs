using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace APISample.Models
{
    [DataContract]
    public class Language
    {
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Display(Name = "Language Name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [Required]
        [DataMember]
        [Display(Name = "Possible Purposes")]
        [JsonPropertyName("purpose")]
        public string Purpose { get; set; }
        [DataMember]
        [Display(Name = "Object Oriented")]
        [JsonPropertyName("objectOriented")]
        public bool ObjectOriented { get; set; }
        [DataMember]
        [Display(Name = "Event Driven")]
        [JsonPropertyName("eventDriven")]
        public bool EventDriven { get; set; }

    }
}
