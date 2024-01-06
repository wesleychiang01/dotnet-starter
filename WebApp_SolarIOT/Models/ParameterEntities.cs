using System.ComponentModel.DataAnnotations;

namespace WebApp_SolarIOT.Models
{
    public class ParameterEntities
    {
        [Key]
        public int EventID { get; set; }

        public double? latitude { get; set; }

        public double? longitude { get; set; }

        public double? accuracy { get; set; }

        public double? solar_volt { get; set; }

        public double? solar_amp { get; set; }

        public double? light_intensity { get; set; }

        public double? temperature { get; set; }

        public double? battery_volt { get; set; }

        public double? battery_amp { get; set; }

        public DateTime EventProcessedUtcTime { get; set; }

    }
}
