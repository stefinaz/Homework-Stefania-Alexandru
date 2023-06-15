namespace Homework
{
    public class PersonRepository : IPersonRepository
    {
        public List<Person> People;


        public PersonRepository(List<Person> people)
        {
            this.People = people;
        }

        public List<Person> GetByFirstName(string firstName)
        {
            List<Person> result = new List<Person>();
            foreach (Person person in People)
            {
                if (person.FirstName == firstName)
                {
                    result.Add(person);
                }
            }
            return result;
        }

        public List<Person> GetByLastName(string lastName)
        {
            List<Person> result = new List<Person>();
            foreach (Person person in People)
            {
                if (person.LastName == lastName)
                {
                    result.Add(person);
                }
            }
            return result;

        }

        public Person GetById(string id)
        {
            foreach (Person person in People)
            {
                if (person.ID == id)
                    return person;
            }
            return null;
        }

        public bool Add(Person person)
        {
            foreach (Person existingPerson in People)
            {
                if (existingPerson.FirstName == person.FirstName || existingPerson.LastName == person.LastName || existingPerson.ID == person.ID)
                {
                    return false;
                }
            }

            People.Add(person);
            return true;
        }

    }
}
