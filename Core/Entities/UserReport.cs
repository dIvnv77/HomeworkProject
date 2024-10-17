using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{

    public class UserReport : BaseEntity
        {
            [Required]
            public string StudentId { get; set; }

            public ApplicationUser Student { get; set; }

            [Required]
            public string ReportId { get; set; }

            public Report Report { get; set; }
    }
}
