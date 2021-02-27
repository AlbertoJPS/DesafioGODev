using Domain;
using Xunit;

namespace Tests
{
    public class StudentTest
    {
        [Fact]
        public void Should_Create_A_Student()
        {
            //Given
            var newStudent = new Student("Marcos", "Alves");
            
            //Then
            Assert.NotNull(newStudent);
        }

        [Fact]
        public void Should_Substribe_A_Student_In_A_Classroom()
        {
            //Given
            var newStudent = new Student("Marcos", "Alves");
            
            //When
            newStudent.ClassroomInFirstStage = new ClassroomEvent("Yellow", 15);
            //Then
            Assert.NotNull(newStudent.ClassroomInFirstStage);
        }

        [Fact]
        public void Should_Substribe_A_Student_In_A_CoffeeBreakRoom()
        {
            //Given
            var newStudent = new Student("Marcos", "Alves");
            
            //When
            newStudent.CoffeeBreakRoom = new CoffeeBreakRoom("Fire Place");
            //Then
            Assert.NotNull(newStudent.CoffeeBreakRoom);
        }
        [Fact]
        public void Should_Substribe_A_Student_In_A_SecondStageClassroom()
        {
            //Given
            var newStudent = new Student("Marcos", "Alves");
            
            //When
            newStudent.ClassroomInSecondStage = new ClassroomEvent("Purple", 10);
            //Then
            Assert.NotNull(newStudent.ClassroomInSecondStage);
        }

    }
}
