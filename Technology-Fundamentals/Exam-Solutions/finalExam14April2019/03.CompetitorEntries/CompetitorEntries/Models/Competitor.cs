using System.ComponentModel.DataAnnotations;

namespace CompetitorEntries.Models
{
    public class Competitor
    {
        //       •	name – non-empty text
        //•	age – non-null integer number
        //•	team – non-empty text
        //•	category – non-empty text
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Team { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
