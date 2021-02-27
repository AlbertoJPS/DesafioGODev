using System;

namespace Domain
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ClassroomEvent ClassroomInFirstStage { get; set; }
        public ClassroomEvent ClassroomInSecondStage { get; set; }
        public CoffeeBreakRoom CoffeeBreakRoom {get; set;} 

        public Student(string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{Id} - Student:{FirstName}{LastName} - Classrooms: 1º Stage{ClassroomInFirstStage} / 2ª Stage{ClassroomInSecondStage} - Coffee Break Room: {CoffeeBreakRoom}";
        }
    }
}