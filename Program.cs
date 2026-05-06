using System.ComponentModel;
using SistemaBanco;

    //Creación de cuentas para testeo
    Banco.CrearCuenta("Fede Alcaraz",Banco.GenerarCBU(23),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Tomas St",Banco.GenerarCBU(123),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Agustin Pistiner",Banco.GenerarCBU(1),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Nita Ortiglia",Banco.GenerarCBU(223),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Armando Banquitos",Banco.GenerarCBU(2),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Don Barredora",Banco.GenerarCBU(0),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Ostin Istiner",Banco.GenerarCBU(4),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Norberto Smith",Banco.GenerarCBU(6),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Lucas Wizconsin",Banco.GenerarCBU(7),TipoCuenta.CajaDeAhorro);
    Banco.CrearCuenta("Noelia Fernandez",Banco.GenerarCBU(8),TipoCuenta.CajaDeAhorro);
    Banco.CrearCuenta("Pepe Grillo",Banco.GenerarCBU(97),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Julieta Cardoso",Banco.GenerarCBU(90),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Maria Garcia",Banco.GenerarCBU(91),TipoCuenta.CajaDeAhorro);
    Banco.CrearCuenta("Federico Bonaterre",Banco.GenerarCBU(21),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("Zulma Santos",Banco.GenerarCBU(63),TipoCuenta.CajaDeAhorro);
    //Elegir 3 cuentas y depositarles 1.000.000 cada una
    Banco.ListaCuentas[5].Depositar(1000000);
    Banco.ListaCuentas[3].Depositar(1000000);
    Banco.ListaCuentas[8].Depositar(1000000);


while (ConsoleInterface.ProgramAlive)
{
    ConsoleInterface.ImprimirMenuInicio();
    //Menú de seleccion
    switch (ConsoleInterface.Leerint())
    {
        case 1:
            ConsoleInterface.ConsoleAdministrarCuentas();
            switch (ConsoleInterface.Leerint()){
                case 1:
                    ConsoleInterface.ConsoleCrearUsuario();
                    break;
                case 2:
                    ConsoleInterface.ConsoleDarDeBaja();
                    break;
                case 3:
                    ConsoleInterface.ConsoleEliminarCuenta();
                    break;
                case 4:
                    continue;
            }
            break;
        case 2:
            ConsoleInterface.ConsoleImprimirCuentas();
            break;
        case 3:
            ConsoleInterface.ConsoleRealizarOperaciones();
            //PEDIMOS UNA CUENTA
            switch (ConsoleInterface.Leerint())
            {
                case 1:
                    ConsoleInterface.ConsoleDepositar();
                    break;
                case 2:
                    ConsoleInterface.ConsoleRetirar();
                    break;
                case 3:
                    ConsoleInterface.ConsoleTransferir();
                    break;
                case 4:
                    continue;
            }
            break;
        case 4:
            ConsoleInterface.ConsoleMostrarReportes();
            break;  
        case 5:
            ConsoleInterface.ConsoleSalir();
            break;
    }
}