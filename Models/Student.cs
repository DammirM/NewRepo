using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLabb.Models
{
    public class Student
    {

        public int ID { get; set; }

        public string StudentName { get; set; }   
        
        public ICollection<Course> Courses { get; set; }
    }
}
