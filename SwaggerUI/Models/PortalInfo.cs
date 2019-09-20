using System.ComponentModel.DataAnnotations;

namespace SwaggerUI.Models
{
    public class PortalInfo
    {
        [Required]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

    }
}
