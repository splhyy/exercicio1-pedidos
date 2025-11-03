namespace PedidosSystem.Models
{
    public sealed class PedidoNacional : Pedido
    {
        protected override decimal CalcularSubtotal()
        {
            var subtotalBase = base.CalcularSubtotal();
            // Impostos nacionais: ICMS 18% + IPI 5% = 23%
            return subtotalBase * 1.23m;
        }

        protected override string EmitirRecibo(decimal total)
        {
            return $"NF-e Nacional: {total:C} (inclui impostos internos)";
        }

        protected override void Validar()
        {
            base.Validar();
            Console.WriteLine("Validando regras fiscais nacionais...");
        }
    }
}