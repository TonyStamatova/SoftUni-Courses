namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}
