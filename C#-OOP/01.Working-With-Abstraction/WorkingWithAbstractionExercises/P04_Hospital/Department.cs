namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Department
    {
        public Department(string name)
        {
            this.Name = name;

            this.Rooms = new Room[20];

            for (int i = 0; i < this.Rooms.Length; i++)
            {
                this.Rooms[i] = new Room(i + 1);
            }
        }

        public string Name { get; private set; }

        public Room[] Rooms { get; }

        public string GetAllPatients()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var room in this.Rooms)
            {
                bool noMorePatients = false;

                foreach (var bed in room.Beds)
                {
                    if (bed == null)
                    {
                        noMorePatients = true;
                        break;
                    }

                    builder.AppendLine(bed);
                }

                if (noMorePatients)
                {
                    break;
                }
            }

            return builder.ToString().TrimEnd();
        }

        public string GetPatientsInRoom(int number)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var bed in this.Rooms
                .FirstOrDefault(r => r.Number == number)
                .Beds
                .OrderBy(p => p))
            {
                if (bed == null)
                {
                    break;
                }

                builder.AppendLine(bed);
            }

            return builder.ToString().TrimEnd();
        }

        public override bool Equals(object obj)
        {
            return obj is Department department &&
                   Name == department.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
