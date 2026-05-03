public class CajaAhorro : Cuenta {
    public CajaAhorro(string titular, int cbu) : base(titular,cbu){
       
        TipoCuenta = TipoCuenta.CajaDeAhorro;
        MargenDeuda = 0;
    }
    public override void Transferir(Cuenta cuentaInicio, Cuenta cuentaDestino, decimal CantidadTransferida){
            if(ValidarTransferencia(cuentaInicio,CantidadTransferida)){
                cuentaInicio.Retirar(CantidadTransferida);
                cuentaDestino.Depositar(CantidadTransferida);
            }
    }
    public override boolean ValidarTransferencia(Cuenta cuentaInicio, decimal monto){
        return monto > 0 && cuentaInicio.Saldo - monto > 0;
    }
    public override void Retirar(decimal monto){
        if(ValidarRetiro(monto)){
        Saldo-= monto;
        }
    }
    public override boolean ValidarRetiro(decimal monto){
        return Saldo - retiro > 0;
    }
}