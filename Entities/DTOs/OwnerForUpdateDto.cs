using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    /// <summary>
    /// OwnerForUpdateDto class
    /// </summary>
    public class OwnerForUpdateDto
    {
        /// <summary>
        /// Name property
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        /// <summary>
        /// DateOfBirth property
        /// </summary>
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Address property
        /// </summary>
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be loner then 100 characters")]
        public string Address { get; set; }
    }
}
