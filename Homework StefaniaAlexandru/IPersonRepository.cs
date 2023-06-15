namespace Homework
{
    public interface IPersonRepository
    {
        List<Person> GetByFirstName(string firstName);
        List<Person> GetByLastName(string lastName);
        Person GetById(string id);
        bool Add(Person person);

    }
}
