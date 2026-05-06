namespace SistemaBanco;
public class CuentaCorriente : Cuenta {
//cbu a string
    public CuentaCorriente(string titular, string cbu, int numerocuentaid) : base(titular, cbu, numerocuentaid){
        TipoCuenta = TipoCuenta.CuentaCorriente;
        MargenDeuda = -10000m;
        CuentaMovimientos.Add(new Movimiento(0,TipoMovimiento.CrearCuenta,DateTime.Now));
    }
    public override void Transferir(Cuenta cuentaDestino, decimal monto){
        if(ValidarTransferencia(monto)){
            Retirar(monto);
            CuentaMovimientos.Add(new Movimiento(monto,TipoMovimiento.TransferenciaEnviada,DateTime.Now));
            cuentaDestino.Depositar(monto);
            CuentaMovimientos.Add(new Movimiento(monto,TipoMovimiento.TransferenciaRecibida,DateTime.Now));
        }
    }
    public override bool ValidarTransferencia(decimal monto){
        return ValidarDeposito(monto) && ValidarRetiro(monto);
    }
    public override void Retirar(decimal monto){
        if(ValidarRetiro(monto)){
            Saldo -= monto;
            CuentaMovimientos.Add(new Movimiento(monto,TipoMovimiento.Retiro,DateTime.Now));
        }
    }
    public override bool ValidarRetiro(decimal monto){
        return monto > 0 && (Saldo - monto >= MargenDeuda);
    }
    public override void Depositar(decimal monto){
        if(ValidarDeposito(monto)){
            Saldo += monto;
            CuentaMovimientos.Add(new Movimiento(monto,TipoMovimiento.Deposito,DateTime.Now));
        }

    }
    public override bool ValidarDeposito(decimal monto){
        return monto > 0;
    }
}