using System.Collections.Generic;
using Domain;
using Domain.Exceptions;
using Xunit;

namespace Tests
{
    public class ClassroomEventTest
    {
        [Fact]
        public void Should_Create_A_Classroom()
        {
          //Given
          var newClassroom = new ClassroomEvent("Red", 10);
          //When
          
          //Then
          Assert.NotNull(newClassroom);
        }

        [Fact]
        public void Should_Be_10_Vaccancy_In_Classroom()
        {
          //Given
					var newClassroom = new ClassroomEvent("Blue", 10);
          
					//When
					var capacity = newClassroom.Capacity;
        	
					//Then
					Assert.Equal(10, capacity);

        }

				[Fact]
				public void Should_Subscribe_9_Students_In_A_Classroom()
				{
					//Given
					var newClassroom = new ClassroomEvent("Green", 10);

					newClassroom.AddStudentsAtClassroom(
						new List<Student>()
						{
							new Student("Marcos", "Alves"),
							new Student("Camila", "Rocha"),
							new Student("Rafaela", "Cândido"),
							new Student("Guilherme", "Silva"),
							new Student("Alberto", "Santos"),
							new Student("Eren", "Totsuo"),
							new Student("Aline", "Camargo"),
							new Student("Ana Carolina", "Davi"),
							new Student("Leonardo", "Torrens"),
						}
					);

					//When
					var quantityOfStudents = newClassroom.Students.Count;
					
					//Then
					Assert.Equal(9, quantityOfStudents);

				}

				[Fact]
				public void Should_Throw_An_Exception_If_Exceed_Room_Capacity()
				{
					//Given
					var newClassroom = new ClassroomEvent("Grey", 10);


					//When
					
					//Then
					var errorMessage = Assert.Throws<CapacityException>(
						() => newClassroom.AddStudentsAtClassroom(
							new List<Student>()
							{
								new Student("Marcos", "Alves"),
								new Student("Camila", "Rocha"),
								new Student("Rafaela", "Cândido"),
								new Student("Guilherme", "Silva"),
								new Student("Alberto", "Santos"),
								new Student("Eren", "Totsuo"),
								new Student("Aline", "Camargo"),
								new Student("Ana Carolina", "Davi"),
								new Student("Leonardo", "Torrens"),
								new Student("Lucas", "Brigda"),
								new Student("Sasuke", "Uchiha"),
							}
					));

					Assert.Equal("This quantity of student exceed the capacity's room. This room has a capacity to support 10 students", errorMessage.Message);
				}
    }
}