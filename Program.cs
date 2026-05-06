using System.ComponentModel;
using SistemaBanco;

while (ConsoleInterface.ProgramAlive)
{
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedee",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",1246,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("ferrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.CrearCuenta("fedeerrrrrrrrrr",124346576,TipoCuenta.CuentaCorriente);
    Banco.ListaCuentas[5].Depositar(100000000);

    ConsoleInterface.ImprimirMenuInicio();
    //ConsoleInterface.EleccionMenu(ConsoleInterface.Leerint());

    //Menú de seleccion
    switch (ConsoleInterface.Leerint())
    {
        case 1:
            ConsoleInterface.ConsoleCrearUsuario();
            break;
        case 2:
            ConsoleInterface.ConsoleDarDeBaja();
            break;
        case 3:
            ConsoleInterface.ConsoleImprimirCuentas();
            break;
        case 4:
            break;
        case 5:
            ConsoleInterface.ConsoleEliminarCuenta();
            break;
        case 6:
            ConsoleInterface.ProgramAlive = false;
            break;
    }
}