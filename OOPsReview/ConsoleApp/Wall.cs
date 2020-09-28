using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Wall
    {
        //Height, width
        // heigt and width > 0.0
        //height has a default of 2.5, width is 4.25
        //Area and Perimeter
        //throw exceptions for invalid data

        private decimal _Height;
        private decimal _Width;

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
        public Wall()
        {
            Height = 2.5m;
            Width = 4.25m;            
        }
        public Wall(decimal height, decimal width)
        {
            Height = height;
            Width = width;
        }
        public decimal WallArea()
        {
            return Height * Width;
        }

        //Perimeter of a Window
        public decimal WallPerimeter()
        {
            return 2 * (Height + Width);
        }
    }
}
