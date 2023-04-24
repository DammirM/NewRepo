using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLabb.Models
{
    public class Subject // Ämne Databas
    {

       

        public int ID { get; set; }

        public string SubjectName { get; set; }

        public Course Course { get; set; }

        public ICollection<Teacher> Teachers { get; set; }


    }
}
