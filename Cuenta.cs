namespace SistemaBanco;
using System.Numerics;
//cbu ahora es string
public abstract class Cuenta
{
    public bool EstadoCuenta;
    public string Titular {get; init;}
    public decimal Saldo {get; set;}
    public string CBU {get; init;}
    public TipoCuenta TipoCuenta;
    public int NumeroCuenta;
    public decimal MargenDeuda;
    public record Movimiento(decimal Monto, TipoMovimiento Tipo, DateTime Horita);
    public List<Movimiento> CuentaMovimientos = new();

    public Cuenta (string titular, string cbu, int numeroCuenta, bool estadoCuenta = true)
    {
        Titular = titular;
        Saldo = 0;
        CBU = cbu;
        NumeroCuenta = numeroCuenta;
        EstadoCuenta = estadoCuenta;
    }
    public abstract void Depositar (decimal monto);
    public abstract void Retirar (decimal monto);
    public abstract void Transferir(Cuenta cuentaDestino, decimal monto);
    public abstract Boolean ValidarDeposito(decimal monto);
    public abstract Boolean ValidarRetiro(decimal monto);
    public abstract Boolean ValidarTransferencia(decimal monto);
}