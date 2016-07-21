using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDelegatesLambdaLINQ.Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FacultyNum { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public List<double> Marks { get; set; }
        public int GroupNum { get; set; }
        public string FullName { get; }

        //department
        public string GroupNumber { get; set; }

        public Student(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        public Student(string first, string last, int fn, string tel, string email, int gr)
        {
            this.FirstName = first;
            this.LastName = last;
            this.FacultyNum = fn;
            this.Tel = tel;
            this.Email = email;
            this.GroupNum = gr;
        }

        public Student(string first, string last, int fn, string tel, string email, List<double> marks, int gr, string department)
        {
            this.FirstName = first;
            this.LastName = last;
            this.FacultyNum = fn;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.GroupNum = gr;
            this.GroupNumber = department;
        }

        public void AddMarks(double mark1, double mark2)
        {
            Marks.Add(mark1);
            Marks.Add(mark2);
        } 
    }
}
