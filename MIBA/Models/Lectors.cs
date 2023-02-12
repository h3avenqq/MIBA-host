﻿using System.ComponentModel.DataAnnotations;

namespace MIBA.Models
{
    public class Lectors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string? About { get; set; }
        public virtual ICollection<Studies>? Studies { get; set; }
        public Lectors()
        {
            Studies = new List<Studies>();
        }
    }
}
