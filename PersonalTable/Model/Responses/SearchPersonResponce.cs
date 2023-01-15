using PersonalTable.Model.Entity;

namespace PersonalTable.Model.Responses
{
    public class SearchPersonResponce
    {
        public IEnumerable<Person> Persons { get; set; }

        public int PageCount { get; set; }
    }
}
