# MandelBrot-Set

### What is MandelBrot Set?
The Mandelbrot set is the set of complex numbers 'c' for which the sequence (c, c² + c, (c²+c)² + c, ((c²+c)²+c)² + c, (((c²+c)²+c)²+c)² + c, ...) does not approach infinity. You can read more about it
from this [wikipedia page](https://en.wikipedia.org/wiki/Mandelbrot_set).

### What does this program do?
This program implements a visual display of MandelBrot Set. In addition, I have added
4 different colouring methods: Iterations, Modulus, Trigonometric and Logistic
Growth to the visual implementation of this fractal.

### How is it implemented?
The recursive equation behind this fractal is z<sub>n+1</sub> = z<sub>n</sub> + c, where both variables are complex
numbers. The picture box can be thought of as a cartesian plane and each point is converted to its relative complex number
using a linear transformation. Each complex number becomes 'c' and goes through the recursive equation for max of 1000 times
or until the |z| exceeds 2. Values of c which do not exceed the max modulus are then plotted.

### What are the colouring methods?
The colouring methods are for the set of complex numbers which **do** approach infinity or exceed the max modulus. The colouring methods depend on the repetitions (max 100) and the complex number itself. In addition, RBG colouring is used in this program. Each colouring method makes sure that the produced RGB values are positive and less than 256.

1. Iterations: This is a simple colouring method which depends on number of iterations or repetitions.

    ```
    red = |255*(sin(repetitions/30))|
    
    green = |255*(sin(repetitions/2))|
    
    blue = |255*(cos(repetitions/30))|
    
    ```
2. Modulus: This colouring method depends on the modulus of given complex number 'z'.

    ```
    red = (-23.3*modulus) + 277.0d
    
    green = 10.0*modulus^2) - 136.0*modulus + 489.0
    
    blue = (25.3*modulus) - 50.0;
    
    ```
3. Trigonometric: This method purely relies on trigonometric functions and complexity of complex numbers.
    ```
    red = 255 - (255* Complex.Abs(sin(z.Real)))
    
    blue = 255 - (255* Complex.Abs(cos(z.Imaginery)))
    
    green = smaller of red and blue.
    
    ```
4. Logistic Growth: This method is my favourite one. It  uses the logistic growth model of population. The original model is 
                    P(t) = M / (1 + Ae<sup>-kt</sup>) , where A = (M - P<sub>0</sub>)/P<sub>0</sub>, M is the carrying cap,
                    P<sub>0</sub> is the initial population and k is the growth constant. I use this model but play a little
                    with the variables.
    ```
    A = (255 - repetitions) / repetitions;
    
    red = 255 / (1 + A * e^(-modulus*z.Real))
    
    blue = 255 / (1 + A * e^(-repetitions*z.Imaginery))
    
    green = 255 / (1 + A * e^(-repetitions*blue))
    
    ```
### Want to contribute?
Fork this repository, make changes/improve and create a pull request.

