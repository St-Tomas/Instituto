public class CajaAhorro : Cuenta {
    
    public CuentaCorriente(string titular, int cbu){
        base(titular,cbu);
        TipoCuenta = TipoCuenta.CajaDeAhorro;
        MargenDeuda = 0;
    }
    public override void Transferir(Cuenta cuentaInicio, Cuenta cuentaDestino, decimal CantidadTransferida){
        if(cuentaInicio.ValidarRetiro(CantidadTransferida)){
            cuentaInicio.Saldo -= CantidadTransferida;
            cuentaDestino.Saldo += CantidadTransferida;
        }
    }
}