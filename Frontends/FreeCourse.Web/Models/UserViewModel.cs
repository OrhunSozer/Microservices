using System.Collections.Generic;

namespace FreeCourse.Web.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string City { get; set; }

        public IEnumerable<string> GetUserProps()
        {
            yield return UserName;
            yield return EMail;
            yield return City;
        }
    }
}
