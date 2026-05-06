using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBanco;

public static class Banco
{
    // Mantenemos la propiedad de solo lectura
    public static List<Cuenta> ListaCuentas { get; } = new List<Cuenta>();
    
    public static int NumCuentaId = 0;

    public static void CrearCuenta(string titular, string cbu, TipoCuenta tipoCuenta){
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
	public static void DarDeBaja(int numeroCuenta){
        var cuenta = ListaCuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuenta);
        if (cuenta != null)
        {
            cuenta.EstadoCuenta = false;
        }
        else {
            // Lanzar error si la cuenta no existe
            throw new Exception("Número de cuenta no encontrado.");
        }
    }
    public static void EliminarCuenta(int numeroCuenta){
        var cuenta = ListaCuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuenta);
        if (cuenta != null)
        {
            ListaCuentas.Remove(cuenta);
        }
        else
        {
            // Lanzar error si la cuenta no existe
            throw new Exception("Número de cuenta no encontrado.");
        }  
    }
    public static string GenerarCBU(int numeroCuenta){
    string banco = "285";
    string sucursal = "0041";
    string cuenta = numeroCuenta.ToString().PadLeft(13, '0');
    string cbu = banco + sucursal + cuenta;
    return cbu;
    } //generador de CBUs!!!!!!

    // --- MÉTODOS DE BÚSQUEDA CON LINQ ---

    public static List<Cuenta> BusquedaPorTitular(string titular){
        return ListaCuentas
            .Where(c => c.Titular.Contains(titular, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    public static List<Cuenta> BusquedaPorCBU(string cbu){
        return ListaCuentas
            .Where(c => c.CBU == cbu)
            .ToList();
    }
}