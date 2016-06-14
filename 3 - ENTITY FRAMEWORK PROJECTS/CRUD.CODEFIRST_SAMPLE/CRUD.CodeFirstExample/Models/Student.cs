using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.CodeFirstExample.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}