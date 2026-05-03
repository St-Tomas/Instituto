public interface ITransferible{
    boolean ValidarDeposito();
    boolean ValidarTransferencia();
    boolean ValidarRetiro();
    void Transferir(int monto, ITransferible cuentaInicio, ITransferible cuentaDestino);
    TipoCuenta tipoCuenta;
}