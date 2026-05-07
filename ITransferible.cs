namespace SistemaBanco;

public interface ITransferible
{
    // Propiedades que toda cuenta debe tener
    decimal Saldo { get; set; }
    int CBU { get; init; }

    // Métodos obligatorios
    void Depositar(decimal monto);
    void Retirar(decimal monto);
    void Transferir(ITransferible cuentaDestino, decimal monto);

    // Validaciones
    bool ValidarDeposito(decimal monto);
    bool ValidarRetiro(decimal monto);
    bool ValidarTransferencia(decimal monto);
}//