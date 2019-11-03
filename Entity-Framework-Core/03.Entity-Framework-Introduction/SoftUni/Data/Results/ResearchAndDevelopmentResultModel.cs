namespace SoftUni.Data.Results
{
    public class ResearchAndDevelopmentResultModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DepartmentName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} from {this.DepartmentName} - ${this.Salary:f2}";
        }
    }
}
