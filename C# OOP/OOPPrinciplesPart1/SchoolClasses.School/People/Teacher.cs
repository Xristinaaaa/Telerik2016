namespace SchoolClasses.School.People
{
    using System;
    using System.Collections.Generic;
    using SchoolClasses.School.Disciplines;

    public class Teacher : Person
    {
        private List<Discipline> disciplines;
        
        public Teacher(string nameOfPerson, params Discipline[] disciplines)
            :base(nameOfPerson)
        {
            this.disciplines = new List<Discipline>();

            foreach (var discipline in disciplines)
            {
                this.disciplines.Add(discipline);
            }
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return new List<Discipline>(this.disciplines);
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }

        public override string ToString()
        {
            return string.Format("{0} teaches {1} disciplines", this.Name, string.Join(", ", this.Disciplines);
            
        }

    }
}
