using System;
using System.Collections.Generic;
using Domain;
using Domain.Exceptions;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=============================================");
                Console.WriteLine("=============================================");
                Console.WriteLine(" Wellcome to Training Tech management system ");
                Console.WriteLine("=============================================");
                Console.WriteLine("=============================================");
                Console.WriteLine("==================== Menu ===================");
                Console.WriteLine("1 - Create a classroom                     ||");
                Console.WriteLine("2 - Create a coffeebreak room              ||");
                Console.WriteLine("3 - Create students                        ||");
                Console.WriteLine("4 - Consult a student                      ||");
                Console.WriteLine("5 - Consult a classroom                    ||");
                Console.WriteLine("6 - Consult a coffeebreak room             ||");
                Console.WriteLine("=============================================");
                Console.WriteLine("=============================================");
                Console.WriteLine(" Choose an option: ");
                var option = Int32.Parse(Console.ReadLine());
                var technicalInstitution = new TechnicalInstitution();
                var studentList = new List<Student>();

                if (option == 1)
                {
                    char middleOption = 'y';

                    while (middleOption != 'n')
                    {

                        Console.WriteLine("Digit a classroom's name: ");
                        var classroomName = Console.ReadLine();
                        Console.WriteLine("Digit classroom's capacity: ");
                        var classroomCapacity = Int32.Parse(Console.ReadLine());

                        try
                        {
                            technicalInstitution.AddClassroomInInstitution(new ClassroomEvent(classroomName, classroomCapacity));
                        }
                        catch (NotAllowedToInsertClassroomException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("Classroom inserted succefully!!");
                        Console.WriteLine("Would you like to insert more one classroom ? Digit 'y' for yes or 'n' to get back to menu \n");
                        middleOption = Console.ReadLine()[0];   

                        while (middleOption != 'n' && middleOption != 'y')
                        {
                            Console.WriteLine("\nPlease digit only 'y or 'n': ");
                            middleOption = Console.ReadLine()[0]; 
                        }
                    }

                    continue;
                }
                
                if (option == 2)
                {
                    char middleOption = 'y';

                    while (middleOption != 'n')
                    {

                        Console.WriteLine("Digit a coffeebreak room's name: ");
                        var coffeeBreakRoomName = Console.ReadLine();
                        Console.WriteLine("Digit coffeebreak room's capacity: ");
                        var coffeeBreakRoomCapacity = Int32.Parse(Console.ReadLine());

                        var newCoffeeBreakRoom = new CoffeeBreakRoom(coffeeBreakRoomName);
                        newCoffeeBreakRoom.Capacity = coffeeBreakRoomCapacity;

                        try
                        {
                            technicalInstitution.AddCoffeeBreakRoomInInstitution(newCoffeeBreakRoom);
                        }
                        catch (NotAllowedToInsertClassroomException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("Coffeebreak room inserted succefully!!");
                        Console.WriteLine("Would you like to insert more one room ? Digit 'y' for yes or 'n' to get back to menu \n");

                        middleOption = Console.ReadLine()[0];   

                        while (middleOption != 'n' && middleOption != 'y')
                        {
                            Console.WriteLine("\nPlease digit only 'y or 'n': ");
                            middleOption = Console.ReadLine()[0]; 
                        }
                    }

                    continue;
                }

                   
                if (option == 3)
                {
                    char middleOption = 'y';

                    while (middleOption != 'n')
                    {

                        Console.WriteLine("Digit the student's first name: ");
                        var studentFirstName = Console.ReadLine();
                        Console.WriteLine("Digit the student's last name: ");
                        var studentLastName = Console.ReadLine();
                        studentList.Add(new Student(studentFirstName, studentLastName));
                        
                        Console.WriteLine("Would you like to insert one more student ? Digit 'y' for yes or 'n' to get back to menu \n");
                        middleOption = Console.ReadLine()[0];   
                        
                        while (middleOption != 'n' && middleOption != 'y')
                        {
                            Console.WriteLine("\nPlease digit only 'y or 'n': ");
                            middleOption = Console.ReadLine()[0]; 
                        }
                      
                    }

                    continue;
                }

            }
        }
    }
}
