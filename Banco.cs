namespace SistemaBanco;
public static class Banco{
    public static List<Cuenta> ListaCuentas = new List<Cuenta>();
    public static int NumCuentaId = 0;
    public static void CrearCuenta(string titular, int cbu, TipoCuenta tipoCuenta){
        if(tipoCuenta == TipoCuenta.CajaDeAhorro){
            ListaCuentas.Add(new CajaAhorro(titular,cbu,NumCuentaId));
        }else if(tipoCuenta == TipoCuenta.CuentaCorriente){
            ListaCuentas.Add(new CuentaCorriente(titular,cbu,NumCuentaId));
        }
        NumCuentaId++;
    }
    public static void EliminarCuenta(int numCuenta){
        var cuenta = ListaCuentas.FirstOrDefault(c => c.NumeroCuentaId == numCuenta); //cambie aca el .get que puso fede
        if(cuenta != null){
            ListaCuentas.Remove(cuenta);
        }
    }

}