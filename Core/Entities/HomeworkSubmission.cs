﻿using Core.Entities.Enums;
using Core.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class HomeworkSubmission : BaseEntity
    {
        public HomeworkSubmission()
        {
            this.Attachments = new HashSet<Attachment>();
        }

        [Required]
        public HomeworkSubmissionStatus Status { get; set; }

        [Required]
        public string StudentId { get; set; }

        public ApplicationUser Student { get; set; }

        [Required]
        public string HomeworkId { get; set; }

        public Homework Homework { get; set; }

        public string GradeId { get; set; }

        public Grade Grade { get; set; }

        public ICollection<Attachment> Attachments { get; set; }
    }
}
