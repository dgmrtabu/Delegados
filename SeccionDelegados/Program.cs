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
            EjemploDelegado();
            Console.Read();
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
