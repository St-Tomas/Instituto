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
        if (tipoCuenta == TipoCuenta.CajaDeAhorro){
            ListaCuentas.Add(new CajaAhorro(titular, cbu, NumCuentaId));
        }
        else if (tipoCuenta == TipoCuenta.CuentaCorriente)
        {
            ListaCuentas.Add(new CuentaCorriente(titular, cbu, NumCuentaId));
        }
        NumCuentaId++;
    }


    public static string GenerarCBU(int numeroCuenta){
    string banco = "285";
    string sucursal = "0041";
    string cuenta = numeroCuenta.ToString().PadLeft(13, '0');
    string cbu = banco + sucursal + cuenta;
    return cbu;
    } //generador de CBUs!!!!!!

    // --- MÉTODOS DE BÚSQUEDA CON LINQ ---
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

    public static void Retirar(int numeroCuenta, decimal monto)
    {
        var cuenta = ListaCuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuenta);
        if (cuenta != null && cuenta.EstadoCuenta == true){
            if (cuenta.ValidarRetiro(monto))
            {
                cuenta.Retirar(monto);
            }
            else
            {
                throw new Exception ("Saldo insuficiente");
            }
        }
        else
        {
            // Lanzar error si la cuenta no existe
            throw new Exception("Número de cuenta no encontrado. / Cuenta Dada de Baja.");
        }
    }
        public static void Depositar(int numeroCuenta, decimal monto)
    {
        var cuenta = ListaCuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuenta);
        if (cuenta != null && cuenta.EstadoCuenta == true)
        {
            if (cuenta.ValidarDeposito(monto))
            {
                cuenta.Depositar(monto);
            }
            else
            {
                throw new Exception ("Depósito inválido");
            }    
        }
        else
        {
            // Lanzar error si la cuenta no existe
            throw new Exception("Número de cuenta no encontrado. / Cuenta Dada de Baja");
        }
    }
    //tenemos que implementar la funcion de transferencia en el banco, porque sino no se puede hacer la transferencia entre cuentas
    public static void Transferir(int numeroCuentaOrigen, int numeroCuentaDestino, decimal monto){
        var cuentaOrigen = ListaCuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuentaOrigen);
        var cuentaDestino = ListaCuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuentaDestino);
        if(cuentaOrigen == cuentaDestino){
            throw new Exception("No tiene sentido transferirse a uno mismo");
        }
        if ((cuentaOrigen != null && cuentaOrigen.EstadoCuenta == true) && (cuentaDestino != null && cuentaDestino.EstadoCuenta == true)){
            if (cuentaOrigen.ValidarTransferencia(monto))
            {
                cuentaOrigen.Transferir(cuentaDestino, monto);
            }
            else
            {
                throw new Exception ("Transferencia inválida");
            }    
        }
        else
        {
            // Lanzar error si alguna de las cuentas no existe
            throw new Exception("Número de cuenta no encontrado. / Dado de baja");
        }
    }
}

/*       ------ Ideas NO IMPLEMENTADAS --------
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
*/ 