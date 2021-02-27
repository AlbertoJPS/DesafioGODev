using System;
using System.Collections.Generic;
using Domain.Exceptions;

namespace Domain
{
    public class CoffeeBreakRoom : Classroom
    {
        public CoffeeBreakRoom(string name) : base(name)
        {
            Id = Guid.NewGuid();
        }

        public override void AddStudentsAtClassroom(List<Student> students)
        {
            if (students.Count > Capacity)
            {
                throw new CapacityException($"This quantity of student exceed the capacity's room. This room has a capacity to support {Capacity} students");
            }
            
            foreach (var student in students)
            {
                student.CoffeeBreakRoom = this;
                Students.Add(student);
            }
        }

        public override bool Equals(object obj)
        {
            var coffeeBreakRoom = obj as CoffeeBreakRoom;
            if (coffeeBreakRoom == null) return false;
            if (this.Name.ToLower().Equals(coffeeBreakRoom.Name)) return true;

            return this.Id.Equals(coffeeBreakRoom.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}