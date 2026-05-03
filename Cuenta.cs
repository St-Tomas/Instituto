public abstract class Cuenta{
    private string Titular {get; init;}
    private decimal Saldo {get; set;}
    private int CBU {get; init;}
    private TipoCuenta TipoCuenta;
    private int NumeroDeCuenta;
    private decimal MargenDeuda;
    public Cuenta(string titular, int cbu){
        Titular = titular;
        Saldo = 0;
        CBU = cbu;
    }
    public void Depositar(decimal deposito){
        Saldo.Set = Saldo.Get + deposito;
    }
    public abstract void Transferir(Cuenta cuentaInicio, Cuenta cuentaDestino);
    public void Retirar(decimal retiro){
        Saldo = Saldo - retiro;
    }
    public bool ValidarDeposito(decimal monto){
        return monto > 0;
    }
    public bool ValidarRetiro(decimal retiro){
        return Saldo - retiro > MargenDeuda;
    }
    public bool ValidarTransferencia(Cuenta cuentaInicio, decimal transferir){
        return ValidarDeposito(transferir) && ValidarRetiro(transferir);
    }
    public abstract bool ValidarRetiro();
}