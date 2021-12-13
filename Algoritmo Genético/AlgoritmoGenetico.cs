using System;

namespace Algoritmo_Genético
{
    class AlgoritmoGenetico
    {
        static string respuesta;
        static int Ncromosomas;
        static int Ngenes;
        static int[,] poblacion;
        static int[,] apto;
        static int incremento = 1;
        static int contador = 0;
        static int suma;
        static double[] evaluacion;
        static double[] evaluacion2;
        double mayor = 0;

        static void Main(string[] args)
        {
            AlgoritmoGenetico algoritmoGenetico = new AlgoritmoGenetico();

            algoritmoGenetico.getCromosomasGenes();
            Console.WriteLine();
            
            Console.WriteLine("La poblacion inicial es:");
            algoritmoGenetico.fill();
            
            Console.WriteLine();
            Console.WriteLine("La población de binario a decimal:");
            algoritmoGenetico.functionAptitud();

            Console.WriteLine();
            Console.WriteLine("La población convertida a decimal:");
            algoritmoGenetico.sumaColumna();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("La población evaluada:");
            algoritmoGenetico.evaluaciones();
        }

        public void getCromosomasGenes()
        {
            //Obtener el valor de n de 2^n en los cromosomas
            Console.WriteLine("Escribe el numero de cromosomas: ");
            respuesta = Console.ReadLine();
            Ncromosomas = Convert.ToInt32(respuesta);

            //Obtener el valor de n de 2^n en los genes
            Console.WriteLine("Escribe el valor de n para generar los genes: ");
            respuesta = Console.ReadLine();
            Ngenes = Convert.ToInt32(respuesta);

            //Calculo de 2^n
            Ncromosomas = (int)Math.Pow(2, Ncromosomas);

            //Tamaño de la poblacion
            poblacion = new int[Ngenes, Ncromosomas];
            apto = new int[Ngenes, Ncromosomas];
        }

        public void fill()
        {
            // Generar numeros random
            Random random = new Random();

            //Rellenar matriz con numeros random
            for (int i = 0; i < Ngenes; i++)
            {
                for (int j = 0; j < Ncromosomas; j++)
                {
                    poblacion[i, j] = random.Next(0, 100);

                    //Cambia los valores a 0 y 1
                    if (poblacion[i, j] < 50)
                    {
                        poblacion[i, j] = 0;
                    }
                    else
                    {
                        poblacion[i, j] = 1;
                    }

                    //Imprime la matriz
                    Console.Write(poblacion[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void functionAptitud()
        {
            for (int i = 0; i < Ngenes; i++)
            {
                for (int j = 0; j < Ncromosomas; j++)
                {
                    if (poblacion[i, j] == 1)
                    {
                        apto[i, j] = incremento;
                    }
                    else
                    {
                        apto[i, j] = 0;
                    }
                    Console.Write(apto[i, j] + " ");
                }

                contador++;
                
                incremento = (int)Math.Pow(2, contador);

                if (incremento == 0)
                    incremento = 2;

                Console.WriteLine();
            }
        }
        public void sumaColumna()
        {
            evaluacion = new double[Ncromosomas];
            
            for (int i = 0; i < Ncromosomas; i++)
            {
                suma = 0;

                for (int j = 0; j < Ngenes; j++)
                {
                    suma += apto[j, i];
                }
                evaluacion[i] = suma;
                Console.Write(suma + " ");

            }
        }

        public void evaluaciones()
        {
            evaluacion2 = new double[Ncromosomas];
            for (int i = 0; i < Ncromosomas; i++)
            {
                evaluacion2[i] = ((-1 * (Math.Pow(evaluacion[i], 2))) + (21 * evaluacion[i]) - 2.25);
                if(evaluacion2[i] > mayor)
                {
                    mayor = evaluacion2[i];
                }
                Console.WriteLine(evaluacion2[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("El individuo más apto es: " + mayor);
        }
    }
}
