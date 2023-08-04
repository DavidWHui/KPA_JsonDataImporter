using System.ComponentModel.DataAnnotations;

namespace KPA_JsonDataImporter.Models
{
    public class ExampleModel
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Notes { get; set; }
        public int EnvironmentScore { get; set; }
        public int HealthScore { get; set; }
        public int SafetyScore { get; set; }
        public string JsonData { get; set; }
    }
}
