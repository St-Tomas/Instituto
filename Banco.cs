namespace SistemaBanco;
public static class Banco{
    public static List<Cuenta> ListaCuentas {get;} = new List<Cuenta>();
    public static int NumCuentaId = 0;
    public static void CrearCuenta(string titular, int cbu, TipoCuenta tipoCuenta){
        if(tipoCuenta == TipoCuenta.CajaDeAhorro){
            ListaCuentas.Add(new CajaAhorro(titular,cbu,NumCuentaId));
        }else if(tipoCuenta == TipoCuenta.CuentaCorriente){
            ListaCuentas.Add(new CuentaCorriente(titular,cbu));
        }
        NumCuentaId++;
    }
    public static void EliminarCuenta(int numCuenta){
        var cuenta = ListaCuentas.FirstOrDefault(c => c.NumeroCuenta.get == numCuenta);
        if(cuenta != null){
            ListaCuentas.Remove(cuenta);
        }
    }
    public static List<Cuenta> BusquedaPorTitular(string titular)
    {
        return null;
    }
    public static List<Cuenta> BusquedaPorCBU(int cbu)
    {
        return null;
    }
   // public static List<Cuenta> BusquedaPorAlias()
    //{
      //  return null;
    //} //todavia a punto de implementarse

}