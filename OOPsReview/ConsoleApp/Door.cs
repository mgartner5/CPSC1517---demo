using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Door
    {
        //height, width, material (nullable), right or left swing door
        //height and width > 0.0
        //height has a default of 1.75, width is 1.2
        //right or left are indicated with an R or L
        //Area and Perimeter
        //throw exceptions for invalid data
        private decimal _Height;
        private decimal _Width;
        private string _Material;
        private string _SwingDirection;

        public decimal Height
        {
            get
            {
                return _Height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Height cannot be 0 or less than 0.");
                }
                else
                {
                    _Height = value;
                }
            }
        }
        public decimal Width
        {
            get
            {
                return _Width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Width cannot be 0 or less than 0.");
                }
                else
                {
                    _Width = value;
                }
            }
        }
        public string Material
        {
            get
            {
                return _Material;
            }
            set
            {
                _Material = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        public string SwingDirection
        {
            get
            {
                return _SwingDirection;
            }
            set
            {
                if (value.ToUpper().Equals("R") || value.ToUpper().Equals("L"))
                {
                    _SwingDirection = value.ToUpper();
                }
                else
                {
                    throw new Exception("Swing Direction must be 'R' or 'L'.");
                }
            }
        }
        public Door()
        {
            Height = 1.75m;
            Width = 1.2m;
            SwingDirection = "R";
        }
        public Door(decimal height, decimal width, string material, string swingdirection)
        {
            Height = height;
            Width = width;
            Material = material;
            SwingDirection = swingdirection;
        }
        public decimal DoorArea()
        {
            return Height * Width;
        }

        //Perimeter of a Window
        public decimal DoorPerimeter()
        {
            return 2 * (Height + Width);
        }
    }
}
