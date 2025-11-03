using PedidosSystem.Models;
using PedidosSystem.Services;

namespace PedidosSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EXERCÍCIO 1 - SISTEMA DE PEDIDOS ===\n");
            
            // DEMONSTRAÇÃO LSP - Cliente agnóstico
            Console.WriteLine("1. TESTE LSP (Substituição):");
            ProcessarQualquerPedido(new PedidoNacional());
            ProcessarQualquerPedido(new PedidoInternacional(5.2m));
            
            // DEMONSTRAÇÃO COMPOSIÇÃO
            Console.WriteLine("\n2. TESTE COMPOSIÇÃO (Troca de Peças):");
            
            // Composição 1: Nacional com frete fixo + cupom
            var pedidoComposto1 = new PedidoNacional();
            pedidoComposto1.AdicionarPolitica(PoliticasService.FreteFixo);
            pedidoComposto1.AdicionarPolitica(PoliticasService.Cupom10Porcento);
            ProcessarQualquerPedido(pedidoComposto1);
            
            // Composição 2: Internacional com frete percentual
            var pedidoComposto2 = new PedidoInternacional(5.0m, PoliticasService.FretePercentual);
            ProcessarQualquerPedido(pedidoComposto2);
            
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
        
        // MÉTODO QUE DEMONSTRA LSP - funciona com qualquer Pedido
        static void ProcessarQualquerPedido(Pedido pedido)
        {
            Console.WriteLine($"\nProcessando {pedido.GetType().Name}:");
            pedido.Processar();
        }
    }
}