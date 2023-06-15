namespace Homework
{
    public class Person
    {
        //baking fields 
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string id;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                bool isLatin = value.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));

                if (value.Length < 1 || value.Length > 30 || !isLatin)
                {
                    throw new Exception("Name is invalid");
                }
                else
                    firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                bool isLatin = value.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));

                if (value.Length < 1 || value.Length > 30 || !isLatin)
                {
                    throw new Exception("Name is invalid");
                }
                else
                    lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value.Date >= DateTime.Today)
                {
                    throw new Exception("Invalid Date of Birth.");
                }
                else
                    dateOfBirth = value;
            }
        }

        public string ID
        {
            get { return id; }
            set
            {
                int digits = 0;

                for (int i = 2; i < value.Length; i++)
                {
                    if (Char.IsDigit(value[i]))
                    {
                        digits++;
                    }
                }
                if (!Char.IsUpper(value[0]) || !Char.IsUpper(value[1]) || digits != 10)
                {
                    throw new Exception("Invalid ID number");
                }
                id = value;
            }
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            ID = id;
        }
        public override string ToString()
        {
            return firstName + " " + lastName + " " + dateOfBirth + " " + id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   firstName == person.firstName &&
                   lastName == person.lastName &&
                   dateOfBirth == person.dateOfBirth &&
                   id == person.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(firstName, lastName, dateOfBirth, id);
        }
    }
}
