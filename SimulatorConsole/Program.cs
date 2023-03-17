using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;

namespace SimulatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tratar excepcion de formato incorrecto
            try
            {
                // FlightPlan A
                Console.WriteLine("Escribe el identificador");
                //   string nombre = Console.ReadLine();
                string identificador = Console.ReadLine();

                Console.WriteLine("Escribe la compañía");
                string compA = Console.ReadLine();

                Console.WriteLine("Escribe la velocidad");
                double velocidad = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
                string linea = Console.ReadLine();
                string[] trozos = linea.Split(' ');
                double ix = Convert.ToDouble(trozos[0]);
                double iy = Convert.ToDouble(trozos[1]);

                Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                double fx = Convert.ToDouble(trozos[0]);
                double fy = Convert.ToDouble(trozos[1]);

                // Instancia un objeto del tipo FlightPlan
                FlightPlan plan_a = new FlightPlan(identificador, compA ,ix, iy, ix, iy, fx, fy, velocidad);


                // FlightPlan B
                Console.WriteLine("Escribe el identificador");
                //   string nombre = Console.ReadLine();
                identificador = Console.ReadLine();

                Console.WriteLine("Escribe la compañía");
                string compB = Console.ReadLine();

                Console.WriteLine("Escribe la velocidad");
                velocidad = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                ix = Convert.ToDouble(trozos[0]);
                iy = Convert.ToDouble(trozos[1]);

                Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                fx = Convert.ToDouble(trozos[0]);
                fy = Convert.ToDouble(trozos[1]);

                // Instancia un objeto del tipo FlightPlan
                FlightPlan plan_b = new FlightPlan(identificador, compB, ix, iy, ix, iy, fx, fy, velocidad);


                // Simulación
                // Bucle de simulación (ciclos + tiempo de ciclos)

                int ciclos = 10;
                int tiempoCiclo = 10;
                double distanciaSeguridad = 10;

                int i = 0;
                while (i < ciclos)
                {
                    plan_a.Mover(tiempoCiclo);
                    plan_b.Mover(tiempoCiclo);
                    plan_a.EscribeConsola();
                    plan_b.EscribeConsola();
                    if (plan_a.Conflicto(plan_b, distanciaSeguridad))
                    {
                        Console.WriteLine("Conflicto!!!");
                        plan_a.Restart();
                        plan_b.Restart();
                        Console.WriteLine("Escribe la nueva velocidad de {0}", plan_a.DameId());
                        double nuevaVelocidad_a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Escribe la nueva velocidad de {0}", plan_b.DameId());
                        double nuevaVelocidad_b = Convert.ToDouble(Console.ReadLine());
                        plan_a.SetVelocidad(nuevaVelocidad_a);
                        plan_b.SetVelocidad(nuevaVelocidad_b);
                    }
                    if (plan_a.EstaDestino() is true && plan_b.EstaDestino() is true)
                        i = ciclos;
                    i = i + 1;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato.");
            }

            Console.ReadLine();

        }
    }
}
