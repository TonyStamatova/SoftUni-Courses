namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            HashSet<Doctor> doctors = new HashSet<Doctor>();
            HashSet<Department> departments = new HashSet<Department>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Output")
            {
                string[] commandParts = command.Split();

                Department department = new Department(commandParts[0]);
                departments.Add(department);

                Doctor doctor = new Doctor(commandParts[1], commandParts[2]);
                doctors.Add(doctor);

                string patient = commandParts[3];

                Room room = departments
                    .First(x => x.Equals(department))
                    .Rooms
                    .FirstOrDefault(r => r.Beds.Contains(null));

                if (room == null)
                {
                    continue;
                }

                room.PlacePatient(patient);

                doctors.FirstOrDefault(d => d.Equals(doctor)).Patients.Add(patient);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandParts = command.Split();

                if (commandParts.Length == 1)
                {
                    Department department = departments.FirstOrDefault(d => d.Name == commandParts[0]);

                    if (department != null)
                    {
                        Console.WriteLine(department.GetAllPatients());
                    }
                }
                else if (commandParts.Length == 2 && int.TryParse(commandParts[1], out int roomNumber))
                {
                    Department department = departments.FirstOrDefault(d => d.Name == commandParts[0]);

                    Console.WriteLine(department.GetPatientsInRoom(roomNumber));
                }
                else
                {
                    string docName = commandParts[0] + " " + commandParts[1];
                    Doctor doctor = doctors.FirstOrDefault(d => d.Name == docName);

                    if (doctor != null)
                    {
                        Console.WriteLine(doctor.GetPatients());
                    }
                }
            }
        }
    }
}
