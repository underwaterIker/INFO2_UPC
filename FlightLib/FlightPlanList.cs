using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FlightLib
{
    public class FlightPlanList
    {
        // Atributos
        List<FlightPlan> miLista = new List<FlightPlan>();
        OperationsBBDD myOperations = new OperationsBBDD();

        // Constructores
        public FlightPlanList()
        {

        }

        // Métodos
        public List<FlightPlan> GetLista()
        // Returns the list of FlighPlans
        {
            return this.miLista;
        }

        public void Mover(double tiempo)
        // Moves all the aircrafts inside the list a specific time, given as a parameter
        {
            for(int i = 0; i<this.miLista.Count; i++)
            {
                this.miLista[i].Mover(tiempo);
            }
        }

        public void EscribeConsola()
        // Writes in console all the FlightPlan data of all the Flightplans inside the list
        {
            for (int i = 0; i < this.miLista.Count; i++)
            {
                this.miLista[i].EscribeConsola();
            }
        }

        public void Restart()
        // Moves all the aircrafts inside the list to its initial position
        {
            for (int i = 0; i < this.miLista.Count; i++)
            {
                this.miLista[i].Restart();
            }
        }

        public void CopyList(FlightPlanList lista)
        // Copies the list of FlightPlans given as a parameter to another FlightPlanList
        {
            this.GetLista().Clear();
            for (int i = 0; i < lista.GetLista().Count; i++)
            {
                FlightPlan fp = new FlightPlan();
                fp.SetId(lista.GetLista()[i].DameId());
                fp.SetCompany(lista.GetLista()[i].DameCompany());
                fp.DameCurrentPosition().SetX(lista.GetLista()[i].DameCurrentPosition().GetX());
                fp.DameCurrentPosition().SetY(lista.GetLista()[i].DameCurrentPosition().GetY());
                fp.DameInitialPosition().SetX(lista.GetLista()[i].DameInitialPosition().GetX());
                fp.DameInitialPosition().SetY(lista.GetLista()[i].DameInitialPosition().GetY());
                fp.DameFinalPosition().SetX(lista.GetLista()[i].DameFinalPosition().GetX());
                fp.DameFinalPosition().SetY(lista.GetLista()[i].DameFinalPosition().GetY());
                fp.SetVelocidad(lista.GetLista()[i].DameVelocidad());
                this.GetLista().Add(fp);
            }
        }

        public bool WillBeInConflict(double secDist, double cycleTime)
        // Returns true if the aircrafts inside the list will be closer than the security distance at any time during their flights. Returns false otherwise
        {
            for (int i = 0; i < this.miLista.Count; i++)
            {
                for (int j = 0; j < this.miLista.Count; j++)
                {
                    if(j != i)
                    {
                        bool conflict = this.miLista[i].WillBeInConflict(this.miLista[j], secDist, cycleTime);
                        if (conflict is true)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool ImmediateConflict(double secDist, double cycleTime)
        // Returns true if the next position of, at least, one aircraft is going to be in conflict with another aircraft. Returns false otherwise
        {
            this.Mover(cycleTime);
            for (int i = 0; i < this.miLista.Count; i++)
            {
                for (int j = 0; j < this.miLista.Count; j++)
                {
                    if (j != i)
                    {
                        bool conflict = this.miLista[i].Conflicto(this.miLista[j], secDist);
                        if (conflict is true)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Position[] GetCurrentPositions()
        // Returns a vector with the 'Current Positions' of all the aircrafts in the list
        {
            Position[] pos = new Position[this.miLista.Count];
            for(int i = 0; i < this.miLista.Count; i++)
            {
                pos[i] = this.miLista[i].DameCurrentPosition();
            }
            return pos;
        }

        public bool EstanDestino()
        // Returns true if all the aircrafts inside the list have arrived at their final position, returns false otherwise
        {
            for(int i = 0; i < this.miLista.Count; i++)
            {
                if(this.miLista[i].EstaDestino() is false)
                {
                    return false;
                }
            }
            return true;
        }

        // Métodos FILE (that before were in the class File.cs, but have been relocated here for further optimization)
        public void ReadFile(string name)
        // Reads a file, containing data of different FlightPlans, selected by the user and returns a FlightPlanList with all the FlightPlans mentioned before
        {
            StreamReader r = new StreamReader(name);
            string line = r.ReadLine();

            while (line != null)
            {
                string[] trozos = line.Split('|');
                string id = trozos[0];
                string comp = trozos[1];


                string[] current = trozos[2].Split(' ');
                double cpX = Convert.ToDouble(current[0]);
                double cpY = Convert.ToDouble(current[1]);
                string[] initial = trozos[3].Split(' ');
                double ipX = Convert.ToDouble(initial[0]);
                double ipY = Convert.ToDouble(initial[1]);
                string[] final = trozos[4].Split(' ');
                double fpX = Convert.ToDouble(final[0]);
                double fpY = Convert.ToDouble(final[1]);
                double vel = Convert.ToDouble(trozos[5]);

                FlightPlan fp = new FlightPlan(id, comp, cpX, cpY, ipX, ipY, fpX, fpY, vel);
                this.GetLista().Add(fp);

                line = r.ReadLine();
            }
            r.Close();
        }

        public void WriteFile(string name)
        // Writes a file (.txt) with all the current data of the FlightPlanList exposed at that moment, so that the user can load it later and simulation can be restarted from the last position simulated in the previous simulation session
        {
            StreamWriter w = new StreamWriter(name);
            for (int i = 0; i < this.GetLista().Count; i++)
            {
                FlightPlan fp = this.GetLista()[i];
                w.WriteLine(fp.DameId() + "|" + fp.DameCompany() + "|" + fp.DameCurrentPosition().GetX() + " " + fp.DameCurrentPosition().GetY() + "|" + fp.DameInitialPosition().GetX() + " " + fp.DameInitialPosition().GetY() + "|" + fp.DameFinalPosition().GetX() + " " + fp.DameFinalPosition().GetY() + "|" + fp.DameVelocidad());
            }
            w.Close();
        }

        public void WriteFileSpeedChanges(List<FlightPlan> oldList, List<FlightPlan> newList, string name)
        // Writes a file (.txt) describing each change and including telephone and email of the companies involved so that these companies can be adequately informed
        {
            myOperations.Iniciar();

            StreamWriter w = new StreamWriter(name);

            for (int i = 0; i < oldList.Count; i++)
            {
                w.WriteLine("The aircraft with ID: '" + oldList[i].DameId() + "' has changed its velocity from '" + oldList[i].DameVelocidad() + "' to '" + newList[i].DameVelocidad() + "'. Company: " + newList[i].DameCompany() + ", Telephone: " + myOperations.ObtainTelephoneWithCompNameInt_COMPANY(newList[i].DameCompany()) + ", Email: " + myOperations.ObtainEmailWithCompNameDT_COMPANY(newList[i].DameCompany()) + ".");
            }
            w.Close();
            myOperations.Close();
        }
    }
}
