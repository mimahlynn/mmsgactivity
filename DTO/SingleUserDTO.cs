using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.DTO
{
    public class SingleUserDTO
     {
            public Data Data { get; set; }
            public Support Support { get; set; }
     }

    public class DataSingleUser
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri Avatar { get; set; }
    }

    public class Support
    {
        public Uri Url { get; set; }
        public string Text { get; set; }
    }
    
}
