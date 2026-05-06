using System.ComponentModel;
using SistemaBanco;

while (ConsoleInterface.ProgramAlive)
{
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(23),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedee",Banco.GenerarCBU(123),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(1),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(223),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(2),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(0),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrr",Banco.GenerarCBU(4),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(6),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(7),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(8),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(97),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("ferrr",Banco.GenerarCBU(90),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(91),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(21),TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",Banco.GenerarCBU(63),TipoCuenta.CuentaCorriente);
    Banco.ListaCuentas[5].Depositar(100000000);

    ConsoleInterface.ImprimirMenuInicio();
    //ConsoleInterface.EleccionMenu(ConsoleInterface.Leerint());

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
            //PEDIMOS UNA CUENTA

            switch (ConsoleInterface.Leerint())
            {
                case 1:
                    //Aca ponemos el metodo de Deposito de ConsoleInterface
                    break;
                case 2:
                    //Aca ponemos el metodo de Retiro de ConsoleInterface
                    break;
                case 3:
                    //Aca ponemos el metodo de Transferir de ConsoleInterface
                    break;
                case 4:
                    continue;
            }
            break;
        case 4:
            ConsoleInterface.ConsoleSalir();
            break;
    }
}