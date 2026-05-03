public class CuentaCorriente : Cuenta {
    public CuentaCorriente(string titular, int cbu){
        base(titular,cbu);
        TipoCuenta = TipoCuenta.CuentaCorriente;
        MargenDeuda = -10.000;
    }
}