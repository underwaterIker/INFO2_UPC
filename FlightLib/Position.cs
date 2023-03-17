using System;

namespace FlightLib
{
    public class Position
    {
        // Atributos
        double x; // coordenada X (2D)
        double y; // coordenada Y (2D)

        // Constructores
        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Métodos
        public double GetX()
        // Returns x
        { return x;  }

        public double GetY()
        // Returns y
        { return y; }

        public void SetX(double x)
        // Sets the 'x'
        {
            this.x = x;
        }

        public void SetY(double y)
        // Sets the 'y'
        {
            this.y = y;
        }

        public double Distancia(Position b)
        // Returns the distance between the two positions
        {
            double resultado = Math.Sqrt((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y));
            return resultado;
        }
    }
}
