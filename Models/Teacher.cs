using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLabb.Models
{
    public class Teacher
    {
       
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Course> Courses { get; set; }



    }
}
