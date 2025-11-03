using System;
using System.Collections.Generic;

namespace PedidosSystem.Models
{
    public class Pedido
    {
        private readonly List<Func<decimal, decimal>> _politicas = new();
        
        public Pedido(Func<decimal, decimal>? frete = null, Func<decimal, decimal>? promocao = null)
        {
            if (frete != null) _politicas.Add(frete);
            if (promocao != null) _politicas.Add(promocao);
        }

        // RITUAL FIXO - Template Method
        public void Processar()
        {
            Validar();
            var total = CalcularTotal();
            var recibo = EmitirRecibo(total);
            Console.WriteLine(recibo);
        }

        // GANCHOS PROTECTED VIRTUAL
        protected virtual void Validar()
        {
            Console.WriteLine("Validando pedido básico...");
        }

        protected virtual decimal CalcularSubtotal()
        {
            return 100m; // Valor base padrão
        }

        protected virtual string EmitirRecibo(decimal total)
        {
            return $"Recibo Base: {total:C}";
        }

        // COMPOSIÇÃO com delegates
        public decimal CalcularTotal()
        {
            var subtotal = CalcularSubtotal();
            var total = subtotal;
            
            foreach (var politica in _politicas)
            {
                total = politica(total);
            }
            
            return total;
        }

            public void AdicionarPolitica(Func<decimal, decimal>? politica)
        {
            if (politica != null) _politicas.Add(politica);
        }
    }
}