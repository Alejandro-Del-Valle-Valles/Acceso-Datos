using Test_JSON.Model;

namespace Test_JSON.Data
{
    internal static class PersonsRepository
    {
        private static List<Person>? persons = null;

        public static List<Person> GetPersons()
        {
            if (persons == null)
            {
                persons = new List<Person>();
                persons.Add(new Person("Alejandro", 19));
                persons.Add(new Person("Miguel", 21));
                persons.Add(new Person("Roberto", 20));
            }
            return persons;
        }
    }
}
