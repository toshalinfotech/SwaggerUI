using System;
using System.ComponentModel.DataAnnotations;

namespace SwaggerUI.Models
{
    public class UserInfo
    {
        [Required]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [StringLength(10)]
        public string DisplayName { get; set; }

        public Types Type { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "000-000-0000")]
        [Phone]
        public string Phone { get; set; }

        [DisplayFormat(DataFormatString = "0:dd-MM-yyyy")]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [RegularExpression("^[A-Z][a-z]+$")]
        public string EnvironmentName { get; set; }

    }

    public enum Types
    {
        EndUser = 1,
        Admin = 2
    }
}
