using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLabb.Models
{
    public class Course // SUT 22
    {

        public int ID { get; set; }

        public string CourseName { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Teacher> Teachers { get; set; }

    }
}
