using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeccionDelegados
{
    class Program
    {
        delegate void DelegadosSinRetorno(int x, int y);
        delegate int DelegadosConRetornoEntero(int x);
        delegate List<int> DelegadosConRetornoListaEntero(int x);
        static void Main(string[] args)
        {
            // DelegadosSinRetorno d1 = ImpresionTablaMultiplicar;
            //EjemploDelegado();
            //EjemploDelegadosLamda();
            //EjemploAcccion();
            //EjemploFunc();
            Predicate();
            Console.Read();
        }

        static void Predicate() 
        {
            Predicate<int> d1 = (valor) =>
            {
                return valor > 10;
            };
            Console.WriteLine($"Predicate Entero");
            Console.WriteLine($"50:{ d1(50)}");
            Console.WriteLine($"5: {d1(5)}");

            Predicate<string> d2 = (valor) =>
            {
                return valor.StartsWith("A");
            };
            Console.WriteLine($"Predicate Entero");
            Console.WriteLine($"ALEX:{ d2("ALEX")}");
            Console.WriteLine($"JORGE: {d2("JORGE")}");
            Console.WriteLine();

            Func<int, bool> f1 = new Func<int, bool>(d1);
            Console.WriteLine($"50:{ f1(50)}");

            Func<string, bool> f2 = new Func<string, bool>(d2);
            Console.WriteLine($"ALEX:{ f2("ALEX")}");

            var lista = new List<int>();
            //lista.ex

            Console.WriteLine();
        }
        static void EjemploFunc()
        {
            Func<int, int> d1 = (numero) => numero * numero;
            Console.WriteLine(d1(13));

            Func<int, List<int>> d2 = (numero) => Enumerable.Range(1, 10).Select(x => x * numero).ToList();
            var lista = d2(20);
            Console.WriteLine(string.Join("-", lista));

            lista.Select(x => x);
            lista.Select((x,y) => x);
            lista.Where(x => x > 0);
            lista.Where((x, y) => x > 0);
            lista.FirstOrDefault(x => x > 0);
            //lista.Aggregate()
        }
        static void EjemploAcccion()
        {
            Action<int, int> d1 = (numero, hasta) =>
            {
                Console.WriteLine($"La tabla de multiplicar del {numero}");
                for(int i = 1; i<= hasta; i++)
                {
                    Console.WriteLine($"{numero} x {i} = {numero * i}");
                }
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
            };
            
            d1(3, 10);

            d1 = (numero1, numero2) =>
            {
                Console.WriteLine("Multiplicacion");
                Console.WriteLine($"{numero1} x {numero2} = {numero1 * numero2 }");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
            };
            d1(3, 10);

            d1 = ImpresionTablaMultiplicar;
            d1(10, 10);
            d1 = ImpresionMultiplicaicon;
            d1(15, 15);

                DelegadosSinRetorno delegandoLamda = (numero, hasta) =>
                {
                    Console.WriteLine($"La tabla de multiplicar {numero}");
                    for (int i = 1; i <= hasta; i++)
                    {
                        Console.WriteLine($"{numero} x {i} = {numero * i}");
                    }
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("");
                };

                d1 = new Action<int, int>(delegandoLamda);
                d1(17, 5);
            
        }
        static void EjemploDelegado() 
        {
            DelegadosSinRetorno d1 = ImpresionTablaMultiplicar;
            d1(3, 10);
            d1 = ImpresionMultiplicaicon;
            d1(3, 10);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Delegados con retorno");
            DelegadosConRetornoEntero d2 = CuadradoNumero;
            var cuadrado = d2(5);
            //Console.WriteLine($"El cuadrado de 5 es : {cuadrado}");
            Console.WriteLine($"El cuadrado de 5 es : {d2(5)}");
            Console.WriteLine("");

            DelegadosConRetornoListaEntero d3 = TablaMultiplicar;
            var lista = d3(5);
            Console.WriteLine("Tabla multiplicar 5");
            //Console.WriteLine(string.Join("-", lista));
            Console.WriteLine(string.Join("-", d3(10)));


        }

        static void EjemploDelegadosLamda()
        {
            DelegadosSinRetorno d1 = (numero, hasta) =>
            {
                for (int i = 0; i <= hasta; i++)
                {
                    Console.WriteLine($"{numero} x {i} = {numero * i}");
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"La Tabla de Multiplicar del {numero}");
            };

            d1(3, 10);
            d1 = (numero1, numero2) =>
            {
                Console.WriteLine("Multiplicacion");
                Console.WriteLine($"{numero1} x {numero2} = {numero1 * numero2}");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("");
            };
            d1(3, 10);

            DelegadosConRetornoEntero d2 = (numero) => numero * numero;
            Console.WriteLine($"Cuadrado numero 5 es {d2(5)}");
            Console.WriteLine($"Cuadrado numero 5 es {d2(25)}");

            DelegadosConRetornoListaEntero d3 = (numero) => Enumerable.Range(1, 10).Select(x => x * numero).ToList();
            Console.WriteLine("Tabla de Multiplicar 10");
            Console.WriteLine(string.Join("-", d3(10)));
        }

        static void ImpresionTablaMultiplicar(int numero, int hasta)
        {
            Console.WriteLine($"La Tabla de Multiplicar del {numero}");
            for(int i=0; i <= hasta; i++)
            {
                Console.WriteLine($"{numero} x {i} = {numero * i}");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"La Tabla de Multiplicar del {numero}");
        }

        static void  ImpresionMultiplicaicon(int numero1, int numero2)
        {
            Console.WriteLine("Multiplicacion");
            Console.WriteLine($"{numero1} x {numero2} = {numero1 * numero2}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Multiplicacion");
        }

        static int CuadradoNumero(int numero)
        {
            return numero * numero; 
        }

        static List<int> TablaMultiplicar(int numero)
        {
            //var lista = new List<int>();
            //for(int i = 1; i <= 10; i++)
            //{
            //    lista.Add(i * numero);
            //}
            //return lista;

            return Enumerable.Range(1, 10).Select(x => x * numero).ToList();
        }

    }
}
