using System;
using System.Collections.Generic;

namespace Entities.DTOs
{
    /// <summary>
    /// OwnerDto class
    /// </summary>
    public class OwnerDto
    {
        /// <summary>
        /// Id property
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DateOfBirth property
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Address property
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Accounts property
        /// </summary>
        public IEnumerable<AccountDto> Accounts { get; set; }
    }
}
