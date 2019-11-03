namespace SoftUni.Data.Results
{
    using System;
    using System.Globalization;

    public class ProjectsResultModel
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public override string ToString()
        {
             return $"--{this.Name} -" +
                $" {this.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - " +
                $"{(this.EndDate == null ? "not finished" : this.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}";         
        }
    }
}
