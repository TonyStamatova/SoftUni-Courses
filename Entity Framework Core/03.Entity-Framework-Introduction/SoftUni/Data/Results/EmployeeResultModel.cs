namespace SoftUni.Data.Results
{
    public class EmployeeResultModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string JobTitle { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            string result = $"{this.FirstName} {this.LastName} ";

            if (this.MiddleName != null)
            {
                result += $"{this.MiddleName} ";
            } 
            
            result += $"{this.JobTitle} {this.Salary:F2}";

            return result;
        }
    }
}