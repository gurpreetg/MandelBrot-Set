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
  
    public partial class MandelbrotSetForm : Form
    {
       
        private const int NO_COLOURING=0, ITERATIONS = 1, MODULUS = 2, TRIG = 3, LOGISTIC = 4;

        private static int colouringMethod = NO_COLOURING;
        private static double maxModulus = 2.0d;

        private Bitmap mandelbrotSetBitmap;
 
        public MandelbrotSetForm()
        {
            InitializeComponent();
            mandelbrotSetBitmap = new Bitmap(mandelbrotSetPictureBox.Width, mandelbrotSetPictureBox.Height);
            //Add items to the object 'colouringMethodComboBox.'
            colouringMethodComboBox.Text = "None";
            colouringMethodComboBox.Items.Add("None");
            colouringMethodComboBox.Items.Add("Iterations Method");
            colouringMethodComboBox.Items.Add("Modulus Method");
            colouringMethodComboBox.Items.Add("Trigonometric Method");
            colouringMethodComboBox.Items.Add("Logistic Growth Method");
        }
  
        private void displayMandelbrotSetButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Graphics mandelbrotSetImage = Graphics.FromImage(mandelbrotSetBitmap);
            
            //Instantiations of the 'Complex' class. Create two complex objects, 'c' and 'z.'
            //For both 'Complex' objects, the real and imaginary parts are initially set to 0.
            Complex z = new Complex(0, 0);
            Complex c =new Complex(0,0);

            //For efficiency reasons, copy the 'Width' and 'Height' properties to variables.
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
                    //the region of the Cartesian plane to the region of the Complex plane
                    c = new Complex((4.0d / width)*x - 2.5d, -3.0d / height*y + 1.5d);
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

            mandelbrotSetPictureBox.Refresh();
            this.Cursor = Cursors.Default;
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

        private static Color pixelColour(int colourMethod, int repetitions, Complex z)
        {
            double modulus = Complex.Abs(z);

            if (colourMethod == ITERATIONS)
            {
                if (modulus >= 2.0d)
                {
                    int red = (int)Math.Abs(255 * Math.Sin(repetitions / 30));
                    int green = (int)Math.Abs(255 * Math.Sin(repetitions / 2));
                    int blue = (int)Math.Abs(255 * Math.Cos(repetitions / 30));
                    return Color.FromArgb(red, green, blue);
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
                int red = 255 - (int)(255 * Complex.Abs(Math.Sin(z.Real)));
                int blue = 255 - (int)(255 * Complex.Abs(Math.Cos(z.Imaginary)));
                int green = (red < blue) ? red : blue; //Set green to smaller of red and blue
                return Color.FromArgb(red, green, blue);
            }
            else if (colourMethod == LOGISTIC)
            {
                if (modulus >= 2.0d)
                {
                    double A = (255d - repetitions) / repetitions;

                    int red = (int)(255d / (1 + A * Math.Pow(Math.E, -1d * modulus * z.Real)));
                    int blue = (int)(255d / (1 + A * Math.Pow(Math.E, -1d * repetitions * z.Imaginary)));
                    int green = (int)(255d / (1 + A * Math.Pow(Math.E, -1d * repetitions * blue)));
                    return Color.FromArgb(red, green, blue);
                }
                else
                    return Color.Black;
            }
            else if (modulus < 2.0d)
                return Color.Black;
            else
                return Color.White;
        }

        private void mandelbrotSetPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            mouseCoordinatesLabel.Text = "(" + e.X + ", " + e.Y + ")";
            complexPlaneCoordinatesLabel.Text = "(" + Math.Round(4.0d / mandelbrotSetBitmap.Width * e.X - 2.5d, 2)
                                                    + ", " + Math.Round(-3.0d / mandelbrotSetBitmap.Height * e.Y + 1.5d, 2) + ")";
        }

    }
}   
