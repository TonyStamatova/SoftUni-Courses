namespace _07.CustomException
{
    public class Student
    {
        private string name;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                foreach (var character in value)
                {
                    if (!char.IsLetter(character) && !char.IsWhiteSpace(character))
                    {
                        throw new InvalidPersonNameException();
                    }
                }

                this.name = value;
            }
        }

        public string Email { get; private set; }
    }
}
