using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SistemaBanco;

public static class ConsoleInterface
{
    public static bool ProgramAlive = true;

    // --- MÉTODO PARA LEER DATOS ---
    public static int Leerint(){
        while(true){
            var ingreso= Console.ReadLine();
            if (int.TryParse(ingreso, out int m)){
                return m;
            } 
                Console.WriteLine("Opcion ingresada Invalida.");
        }
    }
   public static void ConsoleCleanRd()
    {
        Console.Read();
        Console.Clear();
    }

    public static void ImprimirMenuInicio()
    {
        Console.Clear();
        Console.WriteLine("--- SISTEMA BANCARIO ---");
        Console.WriteLine("1: Crear Cuenta.");
        Console.WriteLine("2: Eliminar Cuenta.");
        Console.WriteLine("3: Mostrar Cuentas.");
        Console.WriteLine("4: Mostrar reportes de Cuentas.");
        Console.WriteLine("5: Salir.");
        Console.Write("Seleccione una opción: ");
    }

/*     public static void EleccionMenu(int option)
    {
        Console.Clear();
        switch (option)
        {
            case 1:
                ConsoleCrearUsuario();
                break;
            case 2:
                ConsoleDarDeBaja();
                break;
            case 3:
                ConsoleImprimirCuentas();
                break;
            case 4:
                break;
            case 5:
                ProgramAlive = false;
                break;
        }
    } */

    public static void ConsoleCrearUsuario()
    {
        Console.Clear();
        Console.WriteLine("Crear una nueva Cuenta:");
        Console.WriteLine("1: Caja de Ahorro | 2: Cuenta Corriente");
        int.TryParse(Console.ReadLine(), out int opcionTipo);
        TipoCuenta tipoDeCuenta = opcionTipo == 2 ? TipoCuenta.CuentaCorriente : TipoCuenta.CajaDeAhorro;

        Console.Write("Nombre del Titular: ");
        string titular = Console.ReadLine() ?? "Sin Nombre";

        Console.Write("Ingrese CBU (número): ");
        int.TryParse(Console.ReadLine(), out int cbu);

        Banco.CrearCuenta(titular, cbu, tipoDeCuenta);
        Console.WriteLine("Petición de creación enviada.");
    }

    public static void ConsoleDarDeBaja()
    {
    }

    public static void ConsoleImprimirCuentas()
    {
        Console.WriteLine("Ingrese un tipo de Ordenamiento");
        Console.WriteLine("1: Nro Cuenta Asc | 2: Tipo | 3: Alfabético | 4: Saldo");
        var orden = Leerint();
        // Ordenamos extrayendo los valores en tiempo real
        IEnumerable<Cuenta> listadoOrdenado = Banco.ListaCuentas;
        switch (orden){
            case 1:
                listadoOrdenado = Banco.ListaCuentas.OrderBy(x => x.NumeroCuenta);
                break;
            case 2:
                listadoOrdenado = Banco.ListaCuentas.OrderBy(x => x.TipoCuenta);
                break;
            case 3:
                listadoOrdenado = Banco.ListaCuentas.OrderBy(x => x.Titular);
                break;
            case 4:
                listadoOrdenado = Banco.ListaCuentas.OrderBy(x => x.Saldo);
                break;
        }
        int anchoTitular = listadoOrdenado.Max(c => c.Titular.ToString().Length);
        int anchoNumCuenta = listadoOrdenado.Max(c => c.NumeroCuenta.ToString().Length);
        int anchoSaldo = listadoOrdenado.Max(c => c.Saldo.ToString().Length);
        Console.WriteLine("\n--- LISTADO DE CUENTAS ---");
        foreach (Cuenta cuenta in listadoOrdenado)
        {
            Console.WriteLine($"{cuenta.
                                NumeroCuenta.
                                ToString().
                                PadRight(anchoNumCuenta)
                                }||{cuenta.
                                Titular.
                                PadLeft(anchoTitular)
                                }||{cuenta.CBU
                                }||{cuenta.TipoCuenta
                                }||||{cuenta.Saldo.
                                ToString().PadRight(anchoSaldo)}");
        }
        Console.WriteLine("\nPresione un boton para continuar");
        Console.ReadKey();
    }
}