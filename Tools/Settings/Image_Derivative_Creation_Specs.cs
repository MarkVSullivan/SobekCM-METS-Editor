using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLC.Tools.Settings
{
    public class Image_Derivative_Creation_Specs
    {
        private int width_restriction;
        private int height_restriction;

        public Image_Derivative_Creation_Specs(int Width_Restriction, int Height_Restriction)
        {
            this.width_restriction = Width_Restriction;
            this.height_restriction = Height_Restriction;
        }

        public int Width_Restriction
        {
            get
            {
                return width_restriction;
            }
            set
            {
                width_restriction = value;
            }
        }

        public int Height_Restriction
        {
            get
            {
                return height_restriction;
            }
            set
            {
                height_restriction = value;
            }
        }

    }
}
