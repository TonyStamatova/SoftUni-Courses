namespace SoftUni.Data.Results
{
    using System.Collections.Generic;
    using System.Text;

    public class EmployeeProjectResultModel
    {
        public string EmployeeName { get; set; }

        public string ManagerName { get; set; }

        public IEnumerable<ProjectsResultModel> Projects { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.EmployeeName} - Manager: {this.ManagerName}");

            foreach (var project in this.Projects)
            {
                sb.AppendLine(project.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
