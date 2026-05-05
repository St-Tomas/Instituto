namespace SistemaBanco;
using System.Numerics;

public abstract class Cuenta
{
    public string Titular {get; init;}
    public decimal Saldo {get; set;}
    public int CBU {get; init;}
    public TipoCuenta TipoCuenta;
    public string NumeroCuenta;
    public decimal MargenDeuda;

    public Cuenta (string titular, int cbu)
    {
        Titular = titular;
        Saldo = 0;
        CBU = cbu;
    }
    public abstract void Depositar (decimal monto);
    public abstract void Transferir(Cuenta cuentaDestino, decimal monto);
    public abstract Boolean ValidarDeposito(decimal monto);
    public abstract Boolean ValidarRetiro(decimal monto);
    public abstract Boolean ValidarTransferencia(decimal monto);
}