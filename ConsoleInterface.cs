using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SistemaBanco;

public static class ConsoleInterface
{
    public static bool ProgramAlive = true;

    // --- MÉTODO PARA LEER DATOS ---
    private static T ObtenerValorProtegido<T>(object obj, string nombre)
    {
        var tipo = obj.GetType();
        
        // Busca en las Propiedades (ej. Titular, Saldo, CBU)
        var prop = tipo.GetProperty(nombre, BindingFlags.NonPublic | BindingFlags.Instance);
        if (prop != null) return (T)prop.GetValue(obj);

        // Busca en los Campos (ej. NumeroCuenta, TipoCuenta)
        var campo = tipo.GetField(nombre, BindingFlags.NonPublic | BindingFlags.Instance);
        if (campo != null) return (T)campo.GetValue(obj);

        return default;
    }

    public static void ImprimirMenuInicio()
    {
        Console.WriteLine("--- SISTEMA BANCARIO ---");
        Console.WriteLine("1: Crear Cuenta.");
        Console.WriteLine("2: Eliminar Cuenta.");
        Console.WriteLine("3: Mostrar Cuentas.");
        Console.WriteLine("4: Mostrar reportes de Cuentas.");
        Console.WriteLine("5: Salir.");
        Console.Write("Seleccione una opción: ");
    }

    public static void EleccionMenu(int option)
    {
        switch (option)
        {
            case 1:
                ConsoleCrearUsuario();
                break;
            case 2:
                ConsoleEliminarUsuario();
                break;
            case 3:
                Console.WriteLine("\n¿Cómo desea ordenar la lista?");
                Console.WriteLine("1: Nro Cuenta Asc | 2: Nro Cuenta Desc | 3: Alfabético | 4: Saldo");
                if (int.TryParse(Console.ReadLine(), out int orden))
                    ImprimirCuentas(orden);
                else
                    ImprimirCuentas(1); // Por defecto si escribe mal
                break;
            case 4:
                // Sumamos los saldos accediendo a la propiedad protected "Saldo"
                decimal total = Banco.ListaCuentas.Sum(c => ObtenerValorProtegido<decimal>(c, "Saldo"));
                Console.WriteLine($"\nREPORTE GENERAL:");
                Console.WriteLine($"Total de cuentas: {Banco.ListaCuentas.Count}");
                Console.WriteLine($"Capital total en banco: {total:C2}");
                break;
            case 5:
                ProgramAlive = false;
                break;
        }
    }

    public static void ConsoleCrearUsuario()
    {
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

    public static void ConsoleEliminarUsuario()
    {
        Console.Write("Ingrese el Número de Cuenta a eliminar: ");
        string idCuenta = Console.ReadLine();
        
        var cuentaAEliminar = Banco.ListaCuentas.FirstOrDefault(c => 
            ObtenerValorProtegido<string>(c, "NumeroCuenta") == idCuenta);
        
        if (cuentaAEliminar != null)
        {
            Banco.ListaCuentas.Remove(cuentaAEliminar);
            Console.WriteLine("Cuenta eliminada con éxito.");
        }
        else
        {
            Console.WriteLine("No se encontró ninguna cuenta con ese número.");
        }
    }

    public static void ImprimirCuentas(int orden)
    {
        IEnumerable<Cuenta> listadoOrdenado = Banco.ListaCuentas;

        // Ordenamos extrayendo los valores en tiempo real
        switch (orden)
        {
            case 1:
                listadoOrdenado = Banco.ListaCuentas.OrderBy(x => ObtenerValorProtegido<string>(x, "NumeroCuenta"));
                break;
            case 2:
                listadoOrdenado = Banco.ListaCuentas.OrderByDescending(x => ObtenerValorProtegido<string>(x, "NumeroCuenta"));
                break;
            case 3:
                listadoOrdenado = Banco.ListaCuentas.OrderBy(x => ObtenerValorProtegido<string>(x, "Titular"));
                break;
            case 4:
                listadoOrdenado = Banco.ListaCuentas.OrderByDescending(x => ObtenerValorProtegido<decimal>(x, "Saldo"));
                break;
        }

        Console.WriteLine("\n--- LISTADO DE CUENTAS ---");
        foreach (Cuenta cuenta in listadoOrdenado)
        {
            // Obtenemos los datos para armar el string de impresión
            string nro = ObtenerValorProtegido<string>(cuenta, "NumeroCuenta");
            string titular = ObtenerValorProtegido<string>(cuenta, "Titular");
            decimal saldo = ObtenerValorProtegido<decimal>(cuenta, "Saldo");
            
            Console.WriteLine($"Nro: {nro ?? "Sin asignar"} | Titular: {titular} | Saldo: {saldo:C2}"); 
        }
    }
}