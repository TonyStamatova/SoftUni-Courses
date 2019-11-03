namespace SoftUni.Data.Results
{
    public class EmployeeSalaryResultModel
    {
        public string FirstName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} - {this.Salary:f2}";
        }
    }
}
