namespace SistemaBanco;

public abstract class Cuenta
{
    protected string Titular { get; init; }
    protected decimal Saldo { get; set; }
    protected int CBU { get; init; }
    protected TipoCuenta TipoCuenta;
    protected string NumeroCuenta;

    public Cuenta(string titular, int cbu){
        Titular = titular;
        Saldo = 0;
        CBU = cbu;
    }
    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);
    public abstract void Transferir(Cuenta cuentaDestino, decimal monto);

    public abstract bool ValidarDeposito(decimal monto);
    public abstract bool ValidarRetiro(decimal monto);
    public abstract bool ValidarTransferencia(decimal monto);
}