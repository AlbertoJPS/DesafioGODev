using Domain;
using Domain.Exceptions;
using Xunit;

namespace Tests
{
    public class TechnicalInstitutionTest
    {
        [Fact]
        public void Should_Create_A_Technical_Institution()
        {
            //Given
            var newTechnicalInstitution = new TechnicalInstitution();

            //When
            
            //Then
            Assert.NotNull(newTechnicalInstitution);
        }

        [Fact]
        public void Should_Insert_A_Classroom_In_Technical_Institutuion()
        {
            //Given
            var newTechnicalInstitution = new TechnicalInstitution();
            
            //When
            var newClassroom = new ClassroomEvent("Black", 10);
            newTechnicalInstitution.AddClassroomInInstitution(newClassroom);

            //Then
            Assert.Contains(newClassroom, newTechnicalInstitution.Classrooms);
        }

        [Fact]
        public void Should_Not_Insert_The_Same_Classroom_Twice()
        {
            //Given
            var newTechnicalInstitution = new TechnicalInstitution();
            
            //When
            var newClassroom = new ClassroomEvent("Black", 10);
            newTechnicalInstitution.AddClassroomInInstitution(newClassroom);

            //Then
            Assert.Throws<NotAllowedToInsertClassroomException>(() => newTechnicalInstitution.AddClassroomInInstitution(newClassroom));
        }

        [Fact]
        public void Should_Insert_Two_Classrooms()
        {
            //Given
            var newTechnicalInstitution = new TechnicalInstitution();
            
            //When
            var newClassroom = new ClassroomEvent("Black", 10);
            var anotherClassroom = new ClassroomEvent("Yellow", 10);
            newTechnicalInstitution.AddClassroomInInstitution(newClassroom);
            newTechnicalInstitution.AddClassroomInInstitution(anotherClassroom);

            //Then
            Assert.Contains(newClassroom, newTechnicalInstitution.Classrooms);
            Assert.Contains(anotherClassroom, newTechnicalInstitution.Classrooms);
        }

        [Fact]
        public void Should_Insert_A_CoffeeBreakRoom_In_Technical_Institutuion()
        {
            //Given
            var newTechnicalInstitution = new TechnicalInstitution();
            
            //When
            var newCoffeeBreakRoom = new CoffeeBreakRoom("Room 1");
            newTechnicalInstitution.AddCoffeeBreakRoomInInstitution(newCoffeeBreakRoom);

            //Then
            Assert.Contains(newCoffeeBreakRoom, newTechnicalInstitution.CoffeeBreakRooms);
        }
    }
}