namespace SistemaBanco;
public class CajaAhorro : Cuenta {

    public CajaAhorro(string titular, int cbu) : base(titular, cbu){
        TipoCuenta = TipoCuenta.CajaDeAhorro;
    }
    public override void Transferir(Cuenta cuentaDestino, decimal monto){
        if(ValidarTransferencia(monto)){
            Retirar(monto);
            cuentaDestino.Depositar(monto);
        }
    }
    public override bool ValidarTransferencia(decimal monto){
        return ValidarDeposito(monto) && ValidarRetiro(monto);
    }
    public override void Retirar(decimal monto){
        if(ValidarRetiro(monto)){
            Saldo -= monto;
        }
    }
    public override bool ValidarRetiro(decimal monto){
        return monto > 0 && Saldo >= monto;
    }
    public override void Depositar(decimal monto){
        if(ValidarDeposito(monto)){
            Saldo += monto;
        }
    }
    public override bool ValidarDeposito(decimal monto){
        return monto > 0;
    }
}