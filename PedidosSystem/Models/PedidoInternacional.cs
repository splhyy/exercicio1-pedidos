namespace PedidosSystem.Models
{
    public sealed class PedidoInternacional : Pedido
    {
        private readonly decimal _taxaCambio;

            public PedidoInternacional(decimal taxaCambio = 5.0m, 
                                 Func<decimal, decimal>? frete = null, 
                                 Func<decimal, decimal>? promocao = null) 
            : base(frete, promocao)
        {
            _taxaCambio = taxaCambio;
        }

        protected override decimal CalcularSubtotal()
        {
            var subtotalBase = base.CalcularSubtotal();
            // Taxas internacionais: importação 15% + conversão cambial
            var subtotalComTaxas = subtotalBase * 1.15m;
            return subtotalComTaxas * _taxaCambio;
        }

        protected override string EmitirRecibo(decimal total)
        {
            return $"Commercial Invoice: {total:C} (câmbio: {_taxaCambio})";
        }

        protected override void Validar()
        {
            base.Validar();
            Console.WriteLine("Validando documentação aduaneira...");
        }
    }
}