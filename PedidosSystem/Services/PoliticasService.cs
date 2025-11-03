namespace PedidosSystem.Services
{
    public static class PoliticasService
    {
        // Delegates para Frete
        public static decimal FreteFixo(decimal valor) => valor + 15.0m;
        public static decimal FretePercentual(decimal valor) => valor * 1.10m;
        
        // Delegates para Promoção
        public static decimal SemPromocao(decimal valor) => valor;
        public static decimal Cupom10Porcento(decimal valor) => valor * 0.90m;
    }
}