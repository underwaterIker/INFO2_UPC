using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos
        string id; // identificador
        string company; // company name
        Position currentPosition = new Position(0, 0); // posicion actual
        Position initialPosition = new Position(0, 0); // posicion inicial
        Position finalPosition = new Position(0, 0); // posicion final
        double velocidad; // velocidad

        // Constructures
        public FlightPlan()
        {

        }

        public FlightPlan(string id, string comp, double cpx, double cpy, double ipx, double ipy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.company = comp;
            this.currentPosition = new Position(cpx, cpy);
            this.initialPosition = new Position(ipx, ipy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }
        
        // Métodos
        public void SetId(string id)
        // Sets the Id, given as a parameter, of a FlightPlan
        {
            this.id = id;
        }

        public void SetCompany(string company)
        // Sets the Company, given as a parameter, of a FlightPlan
        {
            this.company = company;
        }

        public void SetCurrentPosition(Position pos)
        // Sets the Current Position, given as a parameter, of a FlightPlan
        {
            this.currentPosition = pos;
        }

        public void SetInitialPosition(Position pos)
        // Sets the Initial Position, given as a parameter, of a FlightPlan
        {
            this.initialPosition = pos;
        }

        public void SetFinalPosition(Position pos)
        // Sets the Final Position, given as a parameter, of a FlightPlan
        {
            this.finalPosition = pos;
        }

        public void SetVelocidad(double vel)
        // Sets the Velocity, given as a parameter, of a FlightPlan
        {
            this.velocidad = vel;
        }

        public string DameId()
        // Returns the Id of a FlightPlan
        {
            return this.id;
        }

        public string DameCompany()
        // Returns the Company of a FlightPlan
        {
            return this.company;
        }

        public Position DameCurrentPosition()
        // Returns the Current Position of a FlightPlan
        {
            return this.currentPosition;
        }

        public Position DameInitialPosition()
        // Returns the Initial Position of a FlightPlan
        {
            return this.initialPosition;
        }

        public Position DameFinalPosition()
        // Returns the Final Position of a FlightPlan
        {
            return this.finalPosition;
        }

        public double DameVelocidad()
        // Returns the Velocity of a FlightPlan
        {
            return this.velocidad;
        }

        public void CopiarFlightPlan(FlightPlan fp)
        // Copies the FlightPlan given as a paremeter to another FlightPlan
        {
            this.id = fp.DameId();
            this.company = fp.DameCompany();
            this.currentPosition.SetX(fp.DameCurrentPosition().GetX());
            this.currentPosition.SetY(fp.DameCurrentPosition().GetY());
            this.initialPosition.SetX(fp.DameInitialPosition().GetX());
            this.initialPosition.SetY(fp.DameInitialPosition().GetY());
            this.finalPosition.SetX(fp.DameFinalPosition().GetX());
            this.finalPosition.SetY(fp.DameFinalPosition().GetY());
            this.velocidad = fp.DameVelocidad();
        }

        public bool EstaDestino()
        // Returns true if the aircraft has arriven at his destination, and false if it hasn't
        {
            bool resultado = false;
            if (currentPosition == finalPosition)
                resultado = true;

            return resultado;
        }

        public double DistanciaRecorrida(double tiempo)
        // Returns the distance traveled by an aircraft during a specific time, which is given as a parameter
        {
            double distancia = tiempo * this.velocidad / 60;
            return distancia;
        }

        public double Hipotenusa()
        // Returns the hypotenuse
        {
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            return hipotenusa;
        }

        public double Coseno()
        // Returns the cosine
        {
            double hipotenusa = this.Hipotenusa();
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            return coseno;
        }

        public double Seno()
        // Returns the sinus
        {
            double hipotenusa = this.Hipotenusa();
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;
            return seno;
        }

        public Position NextPosition(double tiempo)
        // Returns the Next Position of an aircraft using the following methods: DistanciaRecorrida(tiempo), Hipotenusa(), Coseno() & Seno()
        {
            double distancia = this.DistanciaRecorrida(tiempo);
            double coseno = this.Coseno();
            double seno = this.Seno();
            double x = this.currentPosition.GetX() + distancia * coseno;
            double y = this.currentPosition.GetY() + distancia * seno;
            Position position = new Position(x, y);
            return position;
        }

        public void Mover(double tiempo)
        // Moves the aircraft to the corresponding position to travel during the time given as a parameter
        {
            double hipotenusa = this.Hipotenusa();

            // Calculates the new position of the aircraft
            Position nextPosition = this.NextPosition(tiempo);

            // Assigns the new position as the current position of the aircraft only if it hasn't arrived to the final position, if this happens, assigns the current position as the final position
            if (this.currentPosition.Distancia(nextPosition) < hipotenusa)
                this.currentPosition = nextPosition;
            else
                this.currentPosition = this.finalPosition;
        }

        public void Restart()
        // Moves the aircraft to its initial position
        {
            this.currentPosition = this.initialPosition;
        }

        public double Distance(FlightPlan plan)
        // Returns the distance with the FlightPlan received as argument
        {
            double resultado =  this.currentPosition.Distancia(plan.currentPosition);
            return resultado;
        }

        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        // Reads data form two FlightPlans and a security distance, and returns true if the two aircraft are closer than that distance
        {
            bool conclicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < 2*distanciaSeguridad)
            {
                conclicto = true;
            }
            return conclicto;
        }

        public string MostrarDatos()
        // returns a string with all the data of a FlightPlan
        {
            string str = "Id: " + this.id +
                "\nCompany: " + this.company +
                "\nCurrent Position: {X=" + Convert.ToString(this.currentPosition.GetX()) + ",Y=" + Convert.ToString(this.currentPosition.GetY()) + "}" +
                "\nInitial Position: {X=" + Convert.ToString(this.initialPosition.GetX()) + ",Y=" + Convert.ToString(this.initialPosition.GetY()) + "}" +
                "\nFinal Position: {X=" + Convert.ToString(this.finalPosition.GetX()) + ",Y=" + Convert.ToString(this.finalPosition.GetY()) + "}" +
                "\nVelocity: " + Convert.ToString(this.velocidad);
            return str;
        }

        public bool WillBeInConflict(FlightPlan f, double secDist, double cycleTime)
        // Reads data form two FlightPlans, a security distance and a cycle time. Returns true if the two aircraft will be closer than the security distance at any time during their flight
        {
            Position oldPosition1 = this.DameCurrentPosition();
            Position oldPosition2 = f.DameCurrentPosition();

            // Aircraft1
            Position nextPosition1 = this.NextPosition(cycleTime);
            double hipotenusa1 = this.Hipotenusa();

            // Aircraft2
            Position nextPosition2 = f.NextPosition(cycleTime);
            double hipotenusa2 = f.Hipotenusa();

            bool conflict = false;
            while(this.currentPosition.Distancia(nextPosition1)<hipotenusa1 || f.currentPosition.Distancia(nextPosition2)<hipotenusa2)
            {
                this.Mover(cycleTime);
                f.Mover(cycleTime);
                if(this.Conflicto(f, secDist) is true)
                {
                    conflict = true;
                }

                // Aircraft1
                hipotenusa1 = this.Hipotenusa();
                nextPosition1 = this.NextPosition(cycleTime);

                // Aircraft2
                hipotenusa2 = f.Hipotenusa();
                nextPosition2 = f.NextPosition(cycleTime);
            }
            this.SetCurrentPosition(oldPosition1);
            f.SetCurrentPosition(oldPosition2);
            return conflict;
        }

        public void EscribeConsola()
        // Writes in console the FlightPlan data
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", this.id);
            Console.WriteLine("Compañía: {0}", this.company);
            Console.WriteLine("Velocidad: {0:F2}", this.velocidad);
            Console.WriteLine("Posición actual: ({0:F2}, {1:F2})", this.currentPosition.GetX(), this.currentPosition.GetY());
            if (this.EstaDestino())
                Console.WriteLine("Ha llegado al destino");
            Console.WriteLine("******************************");
        }
    }
}
