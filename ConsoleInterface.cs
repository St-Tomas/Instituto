using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;

namespace SistemaBanco;

public static class ConsoleInterface{
    public static bool ProgramAlive = true;
    public static Menus PosicionMenu = Menus.Inicio;

    // --- MÉTODO PARA LEER DATOS ---
    public static void ConsoleImpresionMenus(Menus menu){
        switch(menu){
        case Menus.Inicio:
            ImprimirMenuInicio();
            break;
        case Menus.AdministracionCuentas:
            ConsoleAdministrarCuentas();
            break;
        case Menus.Operaciones:
            ConsoleRealizarOperaciones();
            break;
        default:
            Console.WriteLine("Menú inexistente.");
        break;
}
}
    public static int LeerInt(int max){
        while(true){
            var ingreso= Console.ReadLine();
            if (int.TryParse(ingreso, out int m) && m <=max && m>=0){
                return m;
            } 
                Console.WriteLine("Opcion ingresada Invalida.");
                Console.ReadKey();
        }
    }
    public static decimal LeerDecimal(){
    while(true){
        var ingreso = Console.ReadLine();
        if (decimal.TryParse(ingreso, out decimal m) && m > 0){
            return m;
        }
        Console.WriteLine("Monto inválido.");
        Console.ReadKey();
        Console.Clear();
        ConsoleImpresionMenus(PosicionMenu);
    }
}
    public static void ImprimirMenuInicio()
    {
        Console.Clear();
        Console.WriteLine("--- SISTEMA BANCARIO ---");
        Console.WriteLine("1: Administrar Cuentas."); //De aca a un switch para crear, eliminar y dar de baja
        Console.WriteLine("2: Mostrar Cuentas.");
        Console.WriteLine("3: Realizar Operaciones.");
        Console.WriteLine("4: Mostrar reportes de Cuentas.");
        Console.WriteLine("5: Salir.");
        Console.Write("Seleccione una opción: ");
    }
    public static void ConsoleAdministrarCuentas()
    {
        Console.Clear();
        Console.WriteLine("--- Administración de Cuentas ---");
        Console.WriteLine("1: Crear una Cuenta.");
        Console.WriteLine("2: Dar de Baja una Cuenta.");
        Console.WriteLine("3: Eliminar una Cuenta.");
        Console.WriteLine("4: Abortar.");
        Console.Write("Seleccione una opción: ");
    }
    public static void ConsoleRealizarOperaciones()
    {
        Console.Clear();
        Console.WriteLine("--- Realizar Operaciones ---");
        Console.WriteLine("1: Depositar.");
        Console.WriteLine("2: Retirar.");
        Console.WriteLine("3: Transferir.");
        Console.WriteLine("4. Abortar.");
        Console.Write("Seleccione una opción: ");
    }
    public static void ConsoleCrearUsuario(){
        TipoCuenta tipoDeCuenta = TipoCuenta.CajaDeAhorro;
        Console.Clear();
        Console.WriteLine("Crear una nueva Cuenta:");
        Console.WriteLine("1: Caja de Ahorro | 2: Cuenta Corriente");
        int opcionTipo = LeerInt(2);
        switch (opcionTipo){
            case 1:
                tipoDeCuenta = TipoCuenta.CajaDeAhorro;
            break;
            case 2:
                tipoDeCuenta = TipoCuenta.CuentaCorriente;
            break;
        }
        Console.Write("Nombre del Titular: ");
        string titular = Console.ReadLine() ?? "Sin Nombre";
 //ya no pide cbu
        Banco.CrearCuenta(titular, Banco.GenerarCBU(Banco.NumCuentaId), tipoDeCuenta);
        Console.WriteLine("Petición de creación enviada.");
        Console.ReadKey();
    }
    public static void ConsoleDarDeBaja(){
    //cambiar el status de la cuenta a inactiva, no eliminarla de la lista
        Console.Clear();
        Console.WriteLine("\nIngrese el número de cuenta a dar de baja:");
        int numeroCuenta = LeerInt(int.MaxValue);
        try
        {
            Banco.DarDeBaja(numeroCuenta);   
            // La cuenta se dió de baja
            Console.WriteLine("Cuenta dada de baja exitosamente.");
        }
        catch (Exception ex)
        {
            // Mensaje de excepción si la cuenta no existe
            Console.WriteLine(ex.Message); 
        }
        Console.WriteLine("\nPresione un boton para continuar");
        Console.ReadKey();
    }

    public static void ConsoleImprimirCuentas()
    {
        Console.Clear();
        if(Banco.ListaCuentas.Any()){
            Console.WriteLine("Ingrese un tipo de Ordenamiento");
            Console.WriteLine("1: Nro Cuenta Asc | 2: Tipo | 3: Alfabético | 4: Saldo");
            var orden = LeerInt(4);
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
            int anchoTipoCuenta = listadoOrdenado.Max(c => c.TipoCuenta.ToString().Length);
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
                                    }||{cuenta.TipoCuenta.ToString().PadRight(anchoTipoCuenta)
                                    }||||$ {cuenta.Saldo.
                                    ToString().PadRight(anchoSaldo)}||{(cuenta.
                                    EstadoCuenta ? "Activa" : "Inactiva")}");
            }
            Console.WriteLine("\nPresione un boton para continuar");
            Console.ReadKey();
        } else
        {
            Console.WriteLine("Todavia no se crearon cuentas");
        }
    }
	public static void ConsoleEliminarCuenta(){
        Console.Clear();
        Console.WriteLine("\nIngrese el número de cuenta a eliminar:");
        int numeroCuenta = LeerInt(int.MaxValue);

        try
        {
            Banco.EliminarCuenta(numeroCuenta);   
            // La cuenta se eliminó bien
            Console.WriteLine("Cuenta eliminada exitosamente.");
        }
        catch (Exception ex)
        {
            // Mensaje de excepción si la cuenta no existe
            Console.WriteLine(ex.Message); 
        }
        Console.WriteLine("\nPresione un boton para continuar");
        Console.ReadKey();
    }
    //añadir mostrar consola para reportes y salir int numeroCuenta
    public static void ConsoleMostrarReportes(){
        Console.Clear();
        if(Banco.ListaCuentas.Any()){
        Console.WriteLine("Ingrese el número de cuenta para mostrar movimientos:");
        int m = LeerInt(int.MaxValue);
        var cuenta = Banco.ListaCuentas.FirstOrDefault(c => c.NumeroCuenta == m);
        if (cuenta == null){
            Console.WriteLine("Cuenta inexistente.");
            Console.ReadKey();
            return;
        }
        if (!cuenta.CuentaMovimientos.Any()){
            Console.WriteLine("La cuenta no tiene movimientos.");
            Console.ReadKey();
            return;
        }
        int anchoMonto = cuenta.CuentaMovimientos.Max(c => c.Monto.ToString().Length);
        int anchoHorita = cuenta.CuentaMovimientos.Max(c => c.Horita.ToString().Length);
        int anchoTipo = cuenta.CuentaMovimientos.Max(c => c.Tipo.ToString().Length);
        Console.WriteLine("Reporte de Cuenta:");
        foreach (var c in cuenta.CuentaMovimientos){
        Console.WriteLine(
            $"{c.Horita.ToString().PadLeft(anchoHorita)} || " +
            $"{c.Tipo.ToString().PadLeft(anchoTipo)} || " +
            $"{c.Monto.ToString().PadLeft(anchoMonto)} || " +
            $"{(cuenta.EstadoCuenta ? "Activa" : "Inactiva")}"
        );
    }
        } else { Console.WriteLine("Mal ahi bro, no hay cuentas todavia como para hacer eso");}
    Console.WriteLine("\nPresione un botón para continuar");
    Console.ReadKey();
}
    public static void ConsoleSalir()
    {
        Console.Clear();
        Console.WriteLine("Saliendo del programa...");
        Console.ReadKey();
        ProgramAlive = false;
    }
     public static void ConsoleRetirar(){
        Console.Clear();
        Console.WriteLine("\nIngrese el número de cuenta para retirar:");
        int numeroCuenta = LeerInt(int.MaxValue);
        Console.WriteLine("Ingrese el monto a retirar:");
        decimal monto = LeerDecimal();
        try
        {
            Banco.Retirar(numeroCuenta, monto);
            Console.WriteLine("Retiro exitoso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nPresione un boton para continuar");
        Console.ReadKey();
    }
    public static void ConsoleDepositar(){
        Console.Clear();
        Console.WriteLine("\nIngrese el número de cuenta para depositar:");
        int numeroCuenta = LeerInt(int.MaxValue);
        Console.WriteLine("Ingrese el monto a depositar:");
        decimal monto = LeerDecimal();
        try{
            Banco.Depositar(numeroCuenta, monto);
            Console.WriteLine("Depósito exitoso.");
        }
        catch (Exception ex){
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("\nPresione un boton para continuar");
        Console.ReadKey();
    }
    public static void ConsoleTransferir(){
        Console.Clear();
        Console.WriteLine("\nIngrese el número de cuenta origen para transferir:");
        int numeroCuentaOrigen = LeerInt(int.MaxValue);
        Console.WriteLine("Ingrese el número de cuenta destino para transferir:");
        int numeroCuentaDestino = LeerInt(int.MaxValue);
        Console.WriteLine("Ingrese el monto a transferir:");
        decimal monto = LeerDecimal();
        try
        {
            Banco.Transferir(numeroCuentaOrigen, numeroCuentaDestino, monto);
            Console.WriteLine("Transferencia Exitosa");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("\nPresione un boton para continuar");
        Console.ReadKey();
    }
}
