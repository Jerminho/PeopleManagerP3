using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Dto.Requests
{
    public class OrganizationRequest
    {
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
