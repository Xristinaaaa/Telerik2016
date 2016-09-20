namespace SchoolClasses.School
{
    using System;
    using System.Collections.Generic;
    using SchoolClasses.School.Classes;
    using SchoolClasses.School.Disciplines;
    using SchoolClasses.School.People;

    public class School
    {
        List<Class> classes;

        public School()
        {
            this.classes = new List<Class>();
        }

        public List<Class> Classes
        {
            get
            {
                return new List<Class>(this.classes);
            }
            private set
            {
                this.classes = value;
            }
        }

        public void AddClass(Class cl)
        {
            this.Classes.Add(cl);
        }

        public void RemoveClass(Class cl)
        {
            this.Classes.Remove(cl);
        }
    }
}
