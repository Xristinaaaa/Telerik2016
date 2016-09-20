namespace CommonTypeSystem.People
{
    using System;
    public class Student : ICloneable, IComparable
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int ssn;
        private string address;
        private string mobilePhone;
        private string email;
        private int course;

        Student(string f, string m, string l, int ssn, string address, string mobile, string email, int course)
        {
            this.FirstName = f;
            this.MiddleName = m;
            this.LastName = l;
            this.Ssn = ssn;
            this.Address = address;
            this.MobilePhone = mobile;
            this.Email = email;
            this.Course = course;
        }

        public string FirstName { get { return this.firstName; } private set { this.firstName = value; } }
        public string MiddleName { get { return this.middleName; } private set { this.middleName = value; } }
        public string LastName { get { return this.lastName; } private set { this.lastName = value; } }
        public int Ssn { get { return this.ssn; } private set { this.ssn = value; } }
        public string Address { get { return this.address; } private set { this.address = value; } }
        public string MobilePhone { get { return this.mobilePhone; } private set { this.mobilePhone = value; } }
        public string Email { get { return this.email; } private set { this.email = value; } }
        public int Course { get { return this.course; } private set { this.course = value; } }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Student student = obj as Student;
            if ((System.Object)student == null)
            {
                return false;
            }

            return (student == obj);
        }
        public override string ToString()
        {
            return "Student: " + this.FirstName + this.MiddleName + this.LastName;
        }
        public override int GetHashCode()
        {
            return this.Ssn;
        }
        public static bool operator ==(Student x, Student y)
        {
            return x == y;
        }
        public static bool operator !=(Student x, Student y)
        {
            return !(x == y);
        }


        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            if (obj==null)
            {
                return 1;
            }
            Student student = obj as Student;
            if (student != null)
            {
                return this.Ssn.CompareTo(student.Ssn);
            }
            else
            {
                throw new ArgumentException("Bad input");
            }
        }
        
    }
}
