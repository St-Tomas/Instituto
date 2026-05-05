using System.ComponentModel;

namespace SistemaBanco;
public static class ConsoleInterface{
    public static bool ProgramAlive = true;
    public static void ImprimirMenuInicio(){
        Console.WriteLine("Menu inicio");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1: Crear Cuenta.");
        Console.WriteLine("2: Eliminar Cuenta.");
        Console.WriteLine("3: Mostrar Cuentas.");
        Console.WriteLine("4: Mostrar reportes de Cuentas.");
        Console.WriteLine("5: Salir.");
    }
    public static void EleccionMenu(int option){
        switch (option){
            case 1:
                Console.WriteLine("Crear Cuenta:");
                ConsoleCrearUsuario();
                break;
            case 2:
                Console.WriteLine("Eliminar Cuenta:");
                ConsoleEliminarUsuario();
                break;
            case 3:
                Console.WriteLine("Mostrar Cuentas:");
                ImprimirCuentas();
                break;
            case 4:
                Console.WriteLine("Mostrar Reportes de Cuenta:");
                break;
            case 5:
                Console.WriteLine("Salir:");
                ProgramAlive = false;
                break;
            default:
        }
    }
    public static void ConsoleCrearUsuario(){
        var titular="fede";
        var cbu=0;
        TipoCuenta tipoDeCuenta = tipoDeCuenta.CajaDeAhorro;
        Console.WriteLine("Que tipo de Cuenta desea crear?");
        Console.WriteLine("1: Caja de Ahorro");
        Console.WriteLine("2: Cuenta Corriente");
        //readline
        Console.WriteLine("Nombre del Titular:");
        //readline;
        Banco.CrearCuenta(titular,cbu,tipoDeCuenta);
    }
    public static void ConsoleEliminarUsuario(){
        Console.WriteLine("Que Cuenta desea dar de baja?");
        //hay q usar un LINQ
    }
    public static void ImprimirCuentas(int orden)
    {
        var listadoOrdenado;
        switch (orden){
            case 1: //ordenar por id ascendente
                listadoOrdenado = Banco.ListaCuentas.OrderByAscending(x => x.NumeroCuenta);
                break;
            case 2: //ordenar por id descendente
                listadoOrdenado = Banco.ListaCuentas.OrderByDescending(x => x.NumeroCuenta);
                break;
            case 3: //ordenar por orden alfabetico 

                break;
            case 4: //ordenar por saldo
                break;
            default:

        }
        foreach(List<Cuenta> cuenta in Banco.ListaCuentas){
            Console.WriteLine(cuenta);
        }
    }
}
