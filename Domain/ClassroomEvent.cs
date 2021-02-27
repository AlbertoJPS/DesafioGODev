using System;
using System.Collections.Generic;
using Domain.Exceptions;

namespace Domain
{
    public class ClassroomEvent : Classroom
    {
        public ClassroomEvent(string name, int capacity) : base(name)
        {
            Id = Guid.NewGuid();
            Capacity = capacity;
        }

        public override void AddStudentsAtClassroom(List<Student> students)
        {
            if (students.Count > Capacity)
            {
                throw new CapacityException($"This quantity of student exceed the capacity's room. This room has a capacity to support {Capacity} students");
            }
            
            foreach (var student in students)
            {
                student.ClassroomInFirstStage = this;
                Students.Add(student);
            }
            
        }

        public override bool Equals(object obj)
        {
            var classroom = obj as ClassroomEvent;
            if (classroom == null) return false;
            if (this.Name.ToLower().Equals(classroom.Name)) return true;

            return this.Id.Equals(classroom.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}