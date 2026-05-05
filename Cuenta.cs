namespace SistemaBanco;
using System.Numerics;

public abstract class Cuenta
{
    public string Titular {get; init;}
    public decimal Saldo {get; set;}
    public int CBU {get; init;}
    public TipoCuenta TipoCuenta;
    public int NumeroCuenta;
    public decimal MargenDeuda;
    public record Movimiento(decimal Monto, TipoMovimiento tipo);
    public List<Movimiento> CuentaMovimientos = new();

    public Cuenta (string titular, int cbu, int numeroCuenta)
    {
        Titular = titular;
        Saldo = 0;
        CBU = cbu;
        NumeroCuenta = numeroCuenta;
    }
    public abstract void Depositar (decimal monto);
    public abstract void Retirar (decimal monto);
    public abstract void Transferir(Cuenta cuentaDestino, decimal monto);
    public abstract Boolean ValidarDeposito(decimal monto);
    public abstract Boolean ValidarRetiro(decimal monto);
    public abstract Boolean ValidarTransferencia(decimal monto);
}