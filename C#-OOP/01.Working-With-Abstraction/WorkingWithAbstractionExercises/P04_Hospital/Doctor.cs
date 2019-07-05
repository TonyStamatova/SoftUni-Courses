namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            this.Name = firstName + " " + lastName;

            this.Patients = new SortedSet<string>();
        }

        public string Name { get; private set; }

        public SortedSet<string> Patients { get; }

        public override bool Equals(object obj)
        {
            return obj is Doctor doctor &&
                   Name == doctor.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public string GetPatients()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var patient in this.Patients)
            {
                builder.AppendLine(patient);
            }

            return builder.ToString().TrimEnd();
        }
    }
}
