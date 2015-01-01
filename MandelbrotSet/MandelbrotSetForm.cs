using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//To access the "Complex" structure, it is necessary to include the following "using" directive.
//In addition, it is necessary to add a reference to "System.Numerics" through "Project/Add Reference..." (.NET tab)
using System.Numerics;
 

namespace MandelbrotSetApplication
{
    
    /**
     * Definition of the class 'MandelbrotSetForm.' This class inherits all the members of the 'Form' class.
     */
    
    public partial class MandelbrotSetForm : Form
    {
        /**
         * DATA MEMBERS of the class 'MandelbrotSetForm.'
         * 
         * These constants, variables and objects are GLOBAL to the class.
         * 
         * Data members can be declared as 'public,' 'private' or 'protected.' The keywords 'public,' 'private' 
         * and 'protected'are known as "MEMBER ACCESS MODIFIERS" because they define the level of access to the data members.
         * 
         * private   -> The member can only be accessed within the class or structure in which it is declared.
         *              This is the least permissive access level.
         * public    -> The member can be accessed by any class. There are no restrictions on accessing public members.
         *              This is the most permissive access level.
         * protected -> The member is accessible from within the class in which it is declared and and from within any
         *              class derived from the class that declared this member. This level of access is intermediate
         *              between 'public' and 'private.'
         */
        

        private const int NO_COLOURING=0, ITERATIONS = 1, MODULUS = 2, TRIG = 3;

        private static int colouringMethod = NO_COLOURING;
        private static double maxModulus = 2.0d;
        
        private Bitmap mandelbrotSetBitmap = new Bitmap(800, 600); //The size of the bitmap is set initially to 800x600.
                
        
        
        /**
         * Constructor Method for the class 'MandelbrotSetForm.' This method is called as soon as the form object is created.
         * This constructor should include any statements that need to be executed before the user interacts with the program.
         */
        public MandelbrotSetForm()
        {
            InitializeComponent();

            //Add items to the object 'colouringMethodComboBox.'
            colouringMethodComboBox.Text = "None";
            colouringMethodComboBox.Items.Add("None");
            colouringMethodComboBox.Items.Add("Iterations Method");
            colouringMethodComboBox.Items.Add("Modulus Method");
            colouringMethodComboBox.Items.Add("Trigonometric Method");
        }

        
        /*
         * EVENT HANDLER METHODS
         */
                
        private void displayMandelbrotSetButton_Click(object sender, EventArgs e)
        {

            Graphics mandelbrotSetImage = Graphics.FromImage(mandelbrotSetBitmap);
            
            //Instantiations of the 'Complex' class. Create two complex objects, 'c' and 'z.'
            //For both 'Complex' objects, the real and imaginary parts are initially set to 0.
            Complex z = new Complex(0, 0);
            Complex c =new Complex(0,0);

            //For efficiency reasons, copy the 'Width' and 'Height' properties to variables.
            //This is called "caching" the values of properties.
            int width = mandelbrotSetBitmap.Width;
            int height = mandelbrotSetBitmap.Height;

            mandelbrotSetImage.Clear(mandelbrotSetPictureBox.BackColor);
            mandelbrotSetPictureBox.Refresh();

            //Traverse the bitmap one pixel at a time, column by column. Screen co-ordinates are (x,y).
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //The real and imaginary parts of the 'c' are determined by the linear transformations that map
                    //the region of the Cartesian plane in which 0<=x<800, 0<=y<600 to the region of the Complex plane
                    //in which -2.5<=Re(z)<1.5 and -1.5<=Im(z)<1.5
                    c = new Complex(4.0d / width*x - 2.5d, -3.0d / height*y + 1.5d);
                    z = 0;
                    int iterations=0;
                    
                    //For the value of c corresponding to screen co-ordinates (x,y), generate terms of the Mandelbrot sequence. 
                    //The loop terminates as soon as |z| exceeds 'maxModulus' or at the 100th term.
                    do
                    {
                        z = Complex.Add(Complex.Pow(z, 2), c);//z=z^2+c
                        iterations++;
                    }while(Complex.Abs(z)<maxModulus && iterations<=100);

                    mandelbrotSetBitmap.SetPixel(x, y, pixelColour(colouringMethod, iterations-1, z));
                    
                }//end inner for
            }//end outer for

            //Display the Mandelbrot set by firing the 'Paint' event on 'mandelbrotSetPictureBox.'
            mandelbrotSetPictureBox.Refresh();
        }

        private void mandelbrotSetPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(mandelbrotSetBitmap, 0, 0);
        }

        private void colouringMethodComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            colouringMethod = colouringMethodComboBox.SelectedIndex;
            if (colouringMethodComboBox.SelectedIndex == MODULUS)
                maxModulus = 3.0d;
            else
                maxModulus = 2.0d;
        }


        /*
         * OTHER METHODS FOR INTERNAL USE ONLY
         */

        private static Color pixelColour(int colourMethod, int repetitions, Complex c)
        {
            double modulus = Complex.Abs(c);

            if (colourMethod == ITERATIONS)
            {
                if (modulus >= 2.0d)
                {
                    int red=(int)(2.55f * repetitions);
                    int green=red;
                    int blue=(int)(255 - 2.55f * repetitions);
                    return Color.FromArgb(red,green,blue);
                }
                else
                    return Color.Black;
            }
            else if (colourMethod == MODULUS)
            {
                if (modulus >= 2.0d)
                {
                    int red = (int)Math.Round(-23.3d * modulus + 277.0d);
                    int green = (int)Math.Round(10.0d * Math.Pow(modulus, 2) - 136.0d * modulus + 489.0d);
                    int blue = (int)Math.Round(25.3d * modulus - 50.0d);
                    return Color.FromArgb(red,green,blue);
                }
                else
                    return Color.Black;

            }
            else if (colourMethod == TRIG)
            {
                int red = 255 - (int)(255 * Complex.Abs(Math.Sin(c.Real)));
                int blue = 255 - (int)(255 * Complex.Abs(Math.Cos(c.Imaginary)));
                int green = (red < blue) ? red : blue; //Set green to smaller of red and blue
                return Color.FromArgb(red, green, blue);
            }
            else if (modulus < 2.0d) //
                return Color.Black;
            else
                return Color.White;
        }

        private void mandelbrotSetPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            mouseCoordinatesLabel.Text = "(" + e.X + ", " + e.Y + ")";
            complexPlaneCoordinatesLabel.Text = "(" + Math.Round(4.0d / mandelbrotSetBitmap.Width * e.X - 2.5d,2)
                                                    + ", " + Math.Round(-3.0d / mandelbrotSetBitmap.Height * e.Y + 1.5d, 2) + ")";
        }

    }
}
