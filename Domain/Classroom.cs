using System.Collections.Generic;

namespace Domain
{
    public abstract class Classroom : Entity
    {
        public string Name { get;}
        public List<Student> Students;
        public int Capacity { get; set; }

        public Classroom(string name)
        {
            Name = name;
            Students = new List<Student>();
        }
        
        public abstract void AddStudentsAtClassroom(List<Student> students);

        
        public override string ToString()
        {
            var studentsName = "";
            
            foreach (var student in Students)
            {
                studentsName += $" {student.FirstName}{student.LastName} ";    
            }
            return $"Classroom: {Name} - Vaccancy: {Capacity} - Students:{studentsName}";
        }
    }
}