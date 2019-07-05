namespace P04_Hospital
{
    public class Room
    {
        public Room(int number)
        {
            this.Number = number;

            this.Beds = new string[3];
        }

        public int Number { get; private set; }

        public string[] Beds { get; }

        public override bool Equals(object obj)
        {
            return obj is Room room &&
                   Number == room.Number;
        }

        public override int GetHashCode()
        {
            return 187193536 + Number.GetHashCode();
        }

        public void PlacePatient(string patient)
        {
            for (int i = 0; i < this.Beds.Length; i++)
            {
                if (this.Beds[i] == null)
                {
                    this.Beds[i] = patient;
                    break;
                }
            }
        }
    }
}
