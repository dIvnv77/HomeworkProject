﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.CreatedClasses = new HashSet<Class>();
            this.EnrolledClasses = new HashSet<UserClass>();
            this.HomeworkSubmissions = new HashSet<HomeworkSubmission>();
            this.CreatedReports = new HashSet<Report>();
            this.EnrolledReports = new HashSet<UserReport>();
            this.Attachments = new HashSet<Attachment>();
        }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Class> CreatedClasses { get; set; }

        public ICollection<UserClass> EnrolledClasses { get; set; }

        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }

        public ICollection<Report> CreatedReports { get; set; }

        public ICollection<UserReport> EnrolledReports { get; set; }

        public ICollection<Attachment> Attachments { get; set; }
    }
}
