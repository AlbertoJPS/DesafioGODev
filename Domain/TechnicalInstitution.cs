using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;

namespace Domain
{
    public class TechnicalInstitution : Entity
    {
        public List<ClassroomEvent> Classrooms;
        public List<CoffeeBreakRoom> CoffeeBreakRooms;


        public TechnicalInstitution()
        {
            Classrooms = new List<ClassroomEvent>();
            CoffeeBreakRooms = new List<CoffeeBreakRoom>();
        }

        public void AddClassroomInInstitution(ClassroomEvent room)
        {
            var isThereTheSameClassroom = Classrooms.Where(x => x.Id == room.Id).FirstOrDefault();
            
            if (isThereTheSameClassroom != null)
            {
                throw new NotAllowedToInsertClassroomException("There's the same classroom in this institution");    
            }

            Classrooms.Add(room);
        }

        public void AddCoffeeBreakRoomInInstitution(CoffeeBreakRoom room)
        {
            if (CoffeeBreakRooms.Count < 2)
            {
                CoffeeBreakRooms.Add(room);
            }
        }

        public void AddStudentsAtClassroomEvent(List<Student> students)
        {
            if (Classrooms.Count == 1)
            {
                try
                {
                    Classrooms[0].AddStudentsAtClassroom(students);
                }
                catch (CapacityException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return;
            }
            
            for (int i = 1; i < Classrooms.Count; i++)
            {
                if (Classrooms[i] == null)
                {
                    throw new NotFindAClassroomException("There's no classroom with this id");
                }


                if (!IsAllowedToSubscribeMoreStudents(students))
                {
                    throw new NotAllowedToSubscribeStudentsException($"There's a difference in quantity of students in {Classrooms[i].Name} classroom");
                }

                Classrooms[i].AddStudentsAtClassroom(students);
                
            }
            ChangeStudentsBetweenClassrooms();
            

        }     

        public void ChangeStudentsBetweenClassrooms()
        {
            if(Classrooms.Count < 2) return;
            for (int i = 0; i < Classrooms.Count; i +=2)
            {
                if (i + 1 > Classrooms.Count) return;
                
                var auxiliaryList = new List<Student>();
                
                auxiliaryList.AddRange(Classrooms[i].Students.TakeLast(Classrooms[i].Students.Count / 2));
                Classrooms[i].Students.RemoveRange(Classrooms[i].Students.Count / 2, Classrooms[i].Students.Count - 1);
                
                foreach (var student in Classrooms[i].Students)
                {
                    student.ClassroomInSecondStage = Classrooms[i];
                }

                auxiliaryList.AddRange(Classrooms[i + 1].Students.Take(Classrooms[i + 1].Students.Count / 2));
                Classrooms[i + 1].Students.RemoveRange(0, Classrooms[i + 1].Students.Count - 1);

                foreach (var student in Classrooms[i + 1].Students)
                {
                    student.ClassroomInSecondStage = Classrooms[i + 1];
                }
                
                Classrooms[i].Students.AddRange(auxiliaryList.TakeLast((auxiliaryList.Count / 2) - 1));
                
                foreach (var student in Classrooms[i].Students.TakeLast((auxiliaryList.Count / 2) - 1))
                {
                    student.ClassroomInSecondStage = Classrooms[i];    
                }

                Classrooms[i + 1].Students.AddRange(auxiliaryList.Take(auxiliaryList.Count / 2));
                foreach (var student in Classrooms[i + 1].Students.TakeLast(auxiliaryList.Count / 2))
                {
                    student.ClassroomInSecondStage = Classrooms[i + 1];
                }
            }
        }

        private bool IsAllowedToSubscribeMoreStudents(List<Student> students)
        {
            foreach (var classroom in Classrooms)
            {
                var differenceInQuantityOfStudentsBetweenClassrooms = students.Count - classroom.Students.Count;
                if (differenceInQuantityOfStudentsBetweenClassrooms > 1 || differenceInQuantityOfStudentsBetweenClassrooms < -1)
                {
                    return false;
                }
            }
            return true;
        }

    }


}