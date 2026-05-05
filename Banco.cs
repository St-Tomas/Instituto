using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBanco;

public static class Banco
{
    // Mantenemos la propiedad de solo lectura
    public static List<Cuenta> ListaCuentas { get; } = new List<Cuenta>();
    
    public static int NumCuentaId = 0;

    public static void CrearCuenta(string titular, int cbu, TipoCuenta tipoCuenta){
        if (tipoCuenta == TipoCuenta.CajaDeAhorro)
        {
            ListaCuentas.Add(new CajaAhorro(titular, cbu, NumCuentaId));
        }
        else if (tipoCuenta == TipoCuenta.CuentaCorriente)
        {
            ListaCuentas.Add(new CuentaCorriente(titular, cbu, NumCuentaId));
        }
        
        NumCuentaId++;
    }

    public static void EliminarCuenta(int numCuenta){
        var cuenta = ListaCuentas.FirstOrDefault(c => c.NumeroCuentaId == numCuenta);
        
        if (cuenta != null)
        {
            ListaCuentas.Remove(cuenta);
        }
    }

    // --- MÉTODOS DE BÚSQUEDA CON LINQ ---

    public static List<Cuenta> BusquedaPorTitular(string titular){
        return ListaCuentas
            .Where(c => c.Titular.Contains(titular, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public static List<Cuenta> BusquedaPorCBU(int cbu){
        return ListaCuentas
            .Where(c => c.Cbu == cbu)
            .ToList();
    }
    public static List<Cuenta> BusquedaPorAlias(string alias){
        // ignora mayúsculas/minúsculas
        return ListaCuentas
            .Where(c => c.Alias.Equals(alias, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}