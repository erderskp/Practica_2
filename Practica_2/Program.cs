using System;
using System.Collections.Generic;

namespace GenericosDelegadosExcepciones
{
    // Delegado para operaciones matemáticas
    public delegate T Operacion<T>(T a, T b);

    // Excepción personalizada
    public class ListaInsuficienteException : InvalidOperationException
    {
        public ListaInsuficienteException(string mensaje)
            : base(mensaje)
        {
        }
    }

    // Clase genérica
    public class CalculadoraGenerica<T>
    {
        private List<T> numeros = new List<T>();

        // Agregar números a la lista
        public void AgregarNumero(T numero)
        {
            numeros.Add(numero);
        }

        // Mostrar números
        public void MostrarNumeros()
        {
            Console.WriteLine("\nNúmeros en la lista:");

            foreach (var num in numeros)
            {
                Console.WriteLine(num);
            }
        }

        // Ejecutar operación usando delegado
        public T EjecutarOperacion(Operacion<T> operacion)
        {
            if (numeros.Count < 2)
            {
                throw new ListaInsuficienteException(
                    "La lista debe contener al menos dos números."
                );
            }

            dynamic resultado = numeros[0];

            for (int i = 1; i < numeros.Count; i++)
            {
                resultado = operacion(resultado, numeros[i]);
            }

            return resultado;
        }
    }

    class Program
    {
        // Operaciones matemáticas
        static T Sumar<T>(T a, T b)
        {
            return (dynamic)a + (dynamic)b;
        }

        static T Restar<T>(T a, T b)
        {
            return (dynamic)a - (dynamic)b;
        }

        static T Multiplicar<T>(T a, T b)
        {
            return (dynamic)a * (dynamic)b;
        }

        static T Dividir<T>(T a, T b)
        {
            if ((dynamic)b == 0)
            {
                throw new DivideByZeroException(
                    "No se puede dividir entre cero."
                );
            }

            return (dynamic)a / (dynamic)b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== CALCULADORA GENÉRICA ===");

            Console.WriteLine("\nSeleccione el tipo de dato:");
            Console.WriteLine("1. int");
            Console.WriteLine("2. double");
            Console.WriteLine("3. float");
            Console.WriteLine("4. decimal");

            string opcionTipo = Console.ReadLine();

            switch (opcionTipo)
            {
                case "1":
                    EjecutarPrograma<int>();
                    break;

                case "2":
                    EjecutarPrograma<double>();
                    break;

                case "3":
                    EjecutarPrograma<float>();
                    break;

                case "4":
                    EjecutarPrograma<decimal>();
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        static void EjecutarPrograma<T>()
        {
            CalculadoraGenerica<T> calculadora =
                new CalculadoraGenerica<T>();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n===== MENÚ =====");
                Console.WriteLine("1. Agregar número");
                Console.WriteLine("2. Mostrar números");
                Console.WriteLine("3. Sumar");
                Console.WriteLine("4. Restar");
                Console.WriteLine("5. Multiplicar");
                Console.WriteLine("6. Dividir");
                Console.WriteLine("7. Salir");

                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Write("Ingrese un número: ");

                            string entrada = Console.ReadLine();

                            T numero = (T)Convert.ChangeType(
                                entrada,
                                typeof(T)
                            );

                            calculadora.AgregarNumero(numero);

                            Console.WriteLine("Número agregado.");
                            break;

                        case "2":
                            calculadora.MostrarNumeros();
                            break;

                        case "3":
                            Console.WriteLine(
                                $"Resultado: {calculadora.EjecutarOperacion(Sumar)}"
                            );
                            break;

                        case "4":
                            Console.WriteLine(
                                $"Resultado: {calculadora.EjecutarOperacion(Restar)}"
                            );
                            break;

                        case "5":
                            Console.WriteLine(
                                $"Resultado: {calculadora.EjecutarOperacion(Multiplicar)}"
                            );
                            break;

                        case "6":
                            Console.WriteLine(
                                $"Resultado: {calculadora.EjecutarOperacion(Dividir)}"
                            );
                            break;

                        case "7":
                            continuar = false;
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Error: Debe ingresar un valor numérico válido."
                    );
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (ListaInsuficienteException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }
            }
        }
    }
}