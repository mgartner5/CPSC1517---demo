using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // a class represents the defined characteristics of an item
    // an item can be a physical thing (cellphone), concept (student), a collection of data
    // visual studio creates your class without a specific access type
    // default type for a class is private (they might've changed this)
    // code outside of a private class cannot use the contents of the private class
    // for the class to be used by an outside user (code) it must be public
    public class Window
    {
        //Private Data Members
        //these are variables that arre known ONLY within the class
        //will be used for fully implemented properties
        //will be used for local class only data
        private string _Manufacturer;
        private decimal _Height;

        //Public Data Members
        //these are variables that arre known within the class and outside of the class
        //public data members can be altered by code within and with outside the class
        //it is preferred to use Properties instead of public data members

        //Properties
        //optional
        //properties can be implemented in two ways
        //a) Fully Implemented property
        //   used because there is additional code/logic use
        // in processing the data
        //b) Auto Implemented Property
        //  used when there is no need for additional code/logic
        //  when the data is simply saved/stored

        //Fully Implemented Property
        public string Manufacturer
        {
            //assume the Manufacturer is a nullable string
            //3 possiblities
            // a) there are characters
            // b) string has no data (null)
            // c) there is a physical string BUT NO characters
            // there will be additional code/logic to enusre ONLY a and b
            //exist for the data
            //this requires a private data member to hold the data
            //and a property to manage the data content
            get
            {
                //returns data via the property to the outside user
                //  of the property
                // a  get operates on the right side of an equal sign (assignment statement)
                return _Manufacturer;
            }
            set
            {
                //the set takes incoming data and places that data 
                //into a private data member
                //internal to the propert, incoming data will be placed
                // in a common variable called value
                //a property is associated with a single data member
                //a property has NO parameter list
                //a set operates on the ledt side of an equal sign (assignment statement)
                if (string.IsNullOrEmpty(value))
                {
                    //ensure a null is stored in the private data member
                    // eliminate the c possiblity (string with no characters)
                    _Manufacturer = null;  //case b
                }
                else
                {
                    //ensure the value is strored in the private data member
                    _Manufacturer = value;  //case a
                }

                //alternative coding
                // syntax    recieving field = conditions(s) ? true value : false value;
                // _Manufacturer = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        public decimal Height
        {
            //Height must be greater than 0
            get { return _Height; }
            set
            {
                // the m indicates the value is a decimal
                if (value <= 0.0m)
                {
                    throw new Exception("Height cannot be 0 or less than 0.");
                }
                else
                {
                    _Height = value;
                }
            }

        }
        //Auto Implemented Property
        //  auto implemented properties can be used when there is NO NEED for additional processing against the incoming data
        //  NO internal private data memeber is required for this property, the system will internally generate a data are for the data
        //  accessing the stored data (get, set) CAN ONLY be done via the property 
        public decimal Width { get; set; }

        //one can still code auto implemented properties as fully implemented properties
        //private decimal _Width;
        //public decimal Width
        //{
        //      get { return _Width; }
        //      set { _Width = value; }
        //}

        //what about nullable Numerics
        //Do we need to test for a null value to be used for missing incoming data
        //NO, you do not need to code a fully implemented property for a nullable numeric
        //numerics have a default of 0.
        //numerics CAN ONLY store a numeric (unless nullable)
        //numerics CAN BE NULL if declared as nullable
        //IF the numeric has additional criteria THEN you can code the property as a Fully Implemented Property
        public int? NumberOfPanes { get; set; }
        //        ^
        // question mark indicates nullable

        //Constructors
        //a contsructor is "a method" that guarantees that the newly created instance of this class will ALWAYS
        // be creates in a "known state"

        //syntax
        //public constructorName([list of parameters]) 
        //{
        //      your code
        //}
        //NOTE: there is NO RETURN DATATYPE

        //constructors are optional
        //If a class DOES NOT have a contructor then the system will generate the class instance using the datatype defaults
        // for your private data memebers and auto implemented properties
        // this situation of no constructor(s) is often referred to as using a "system" constructor

        //IF you code a constructor, you MUST code any and all constructor(s)
        // needed by your class 

        //there are two common types of constructors:
        //  Default Constructor
        //  Greedy Constructor

        //Defualt
        //this version of the constructor takes NO parameters
        //this version of the constructor usually similates the "system" constructor
        //you can, if you wish, assign values to your class data member/properties that are not the system default for the data type.
        //this constructor is called on your behalf when an instance of the class is requested by the outside user.
        //You CANNOT call a constructor directly like a method.

        public Window()
        {
            //technically numerics are set to zero when they are declared
            //logically in this classthe numeric fields should not be zero
            //therefore, we will set the numeric fields to a literal not equal to zero

            //one could assign value directly to private data members within the class
            //a preferred methof is to use the properties instead of the private data members
            //this is because the properties may have validation to ensure acceptable values exist for the data
            //also, auto implemented properties have no direct private data members

            Height = 0.9m;  //the assumed window height is .9 meters
            //          ^
            //this means it is a decimal
            Width = 1.2m;
            NumberOfPanes = 1;
        }

        //Greedy Constructor
        //takes in a value for each data member/property in the class
        //each data member/property is assigned the appropriate incoming parameter value

        public Window(decimal width, decimal height, int? numberofpanes, string manufacturer)
        {
            Width = width;
            Height = height;
            NumberOfPanes = numberofpanes;
            Manufacturer = manufacturer;
        }

        //Behaviors
        //are also known as methods
        //optional

        //Area of a Window
        public decimal WindowArea()
        {
            return Height * Width;
        }

        //Perimeter of a Window
        public decimal WindowPerimeter()
        {
            return 2 * (Height + Width);
        }
    }
}


