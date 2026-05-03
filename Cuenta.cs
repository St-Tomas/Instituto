namespace SistemaBanco;
using System.Numerics;

public abstract class Cuenta
{
    private string Titular {get; init;}
    private decimal Saldo {get; set;}
    private int CBU {get; init;}
    private TipoCuenta TipoCuenta;
    private string NumeroCuenta;
    private decimal MargenDeuda;

    public Cuenta (string titular, int cbu)
    {
        Titular = titular;
        Saldo = 0;
        CBU = cbu;
    }
    public abstract void Depositar ();
    public abstract void Transferir(Cuenta cuentaInicio, Cuenta cuentaDestino);
    public abstract Boolean ValidarDeposito();
    public abstract Boolean ValidarRetiro();
    public abstract Boolean ValidarTransferencia();
}