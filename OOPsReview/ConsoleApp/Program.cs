using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a instance of the Window class using the default constructor
            //the system calls your class constructor, your code NEVER calls the constructor directly
            //the "new" will use the indicated constructor
            //the "new" actually makes the call to the constructor and returns the instance of the class

            //call to the default constructor
            Window myInstance = new Window();

            //results of the constructor
            Console.WriteLine($"Width {myInstance.Width}; Height {myInstance.Height}; Number of Panes {myInstance.NumberOfPanes}" +
                $"; Manufacturer >{myInstance.Manufacturer}<");

            //to place data within the new instance (object) of the class 
            //use the properties
            //to reference a property within an instance , use the dot (.) operator
            myInstance.Width = 1.2m;
            myInstance.Height = 1.2m;
            myInstance.NumberOfPanes = 3;
            myInstance.Manufacturer = "All-Weather Windows";

            Console.WriteLine($"Width {myInstance.Width}; Height {myInstance.Height}; Number of Panes {myInstance.NumberOfPanes}" +
                $"; Manufacturer >{myInstance.Manufacturer}<");

            Window myGreedyInstance = new Window(1.6m, 3.3m, 3, "Fancy Windows");

            Console.WriteLine($"Width {myGreedyInstance.Width}; Height {myGreedyInstance.Height}; Number of Panes {myGreedyInstance.NumberOfPanes}" +
                $"; Manufacturer >{myGreedyInstance.Manufacturer}<");

            Door theDoor = new Door(1.2m, 1.9m, "Wood", "L");

            Console.WriteLine($"Width {theDoor.Width}; Height {theDoor.Height}; Swing Direction {theDoor.SwingDirection}" +
                $"; Material >{theDoor.Material}<");

            Console.WriteLine("\n\n");

            UsingClasses();
            Console.ReadKey();
        }
        static void UsingClasses()
        {
            //the purpose of this method is to calculate the cost of painting a room
            //the room will have several windows and walls with a single door
            //all data for windows, walls, and doors will be collected and stored in an instance of room.

            //What does room need?
            //declare a set of List<T> for the components of the room
            List<Wall> walls = new List<Wall>();
            List<Door> doors = new List<Door>();
            List<Window> windows = new List<Window>();
            Room room = new Room(); // Default constructor

            //create a reuseable pointer variable to each component of the Room
            //these pointers are created outside of the loop

            Wall wall = null;
            Door door = null;
            Window window = null;
            //collect the data for all of the walls in the room
            //loop of prompt/input/validating for each wall
            //loop
            // after validation of data, create an instance of your class
            wall = new Wall();
            // load the incoming data into the instance of your class
            wall.Width = 6.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //end of loop

            //assume the loop collected and stored the following
            //pass 2
            wall = new Wall();
            // load the incoming data into the instance of your class
            wall.Width = 6.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //pass 3
            wall = new Wall();
            // load the incoming data into the instance of your class
            wall.Width = 5.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //pass 4
            wall = new Wall();
            // load the incoming data into the instance of your class
            wall.Width = 5.6m;
            wall.Height = 3.1m;
            //add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //door loop
            //promt/input/validate
            //store
            //assume in this example that the literals were actually in variables
            //door = new Door(inputWidth, inputHeight, inputMaterial, inputSwingDirection);
            door = new Door(0.85m, 2m, "Composite Pressed Wood", "R");
            doors.Add(door);
            //end of loop

            //window loop
            //prompt/input/validate
            //store
            window = new Window(1.3m, 1.3m, 2, "Fancy Windows");
            windows.Add(window);
            //end of loop

            //pass2
            window = new Window(1.3m, 1.3m, 2, "Fancy Windows");
            windows.Add(window);

            //at this point you would have 3 lists to load to the Room
            room.Doors = doors; //load the complete List<T>
            room.Walls = walls;
            room.Windows = windows;
            room.Name = "Master Bedroom";

            //calculate the number of cans of paint needed to paint the room
            //assume the can of paint covers 27.87 sq m 

            //determine the area of wall surface to paint
            //Area of the wall
            //Area of the openings
            //paintable surface = area of the wall - area of the openings
            //cans = paintable surface / 27.87

            //calculate the total area of the walls
            decimal wallArea = 0.0m;
            //foreach controls the traverse of the collection (List<T>)
            //item is a placeholder for the instance in the collection
            //item terminates at the end of the loop (local variable)
            foreach (Wall item in room.Walls)
            {
                wallArea += item.WallArea();
            }

            //calculate total area of doors
            //for review lets us the for(int i = 0;. end condition; increment){....} loop
            decimal doorArea = 0.0m;
            for (int i = 0; i < room.Doors.Count(); i++)
            {
                doorArea += room.Doors[i].DoorArea();
            }

            //calculate total area of windows
            //var datatype gets resolved at execution time
            //does not change datatype while within the loop
            decimal windowArea = 0.0m;
            foreach(var item in room.Windows)
            {
                windowArea += item.WindowArea();
            }

            //paintable surface
            decimal netWallArea = wallArea - (doorArea + windowArea);

            //calculate the number of cans of paint required
            decimal cansOfPaint = netWallArea / 27.87m;

            //output results
            Console.WriteLine($"Wall area is:\t{wallArea:0.00}");
            Console.WriteLine($"Door area is:\t{doorArea:0.00}");
            Console.WriteLine($"Window area is:\t{windowArea:0.00}");
            Console.WriteLine($"Net Wall area is:\t{netWallArea:0.00}");
            Console.WriteLine($"Required number of paint cans is:\t{cansOfPaint:0.00}");
        }
    }
}
