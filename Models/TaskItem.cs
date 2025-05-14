using System;
using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models {
    public class TaskItem {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public required string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public bool isCompleted { get; set; }
    }
}