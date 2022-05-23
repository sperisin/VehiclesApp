using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesApp.Service.Models
{
    public class VehicleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int vehicleMakeId { get; set; }
        public VehicleMake vehicleMake { get; set; }
    }
}
