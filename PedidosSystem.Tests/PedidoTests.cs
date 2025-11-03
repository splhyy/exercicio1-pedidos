using Xunit;
using PedidosSystem.Models;
using PedidosSystem.Services;

namespace PedidosSystem.Tests
{
    public class PedidoTests
    {
        [Fact]
        public void TesteLSP_ProcessamentoFuncionaComTodosTiposSemDowncast()
        {
            // Arrange
            Pedido[] pedidos = {
                new PedidoNacional(),
                new PedidoInternacional(5.0m)
            };
            
            // Act & Assert - Não deve lançar exceção nem requerer downcast
            foreach (var pedido in pedidos)
            {
                var exception = Record.Exception(() => pedido.Processar());
                Assert.Null(exception);
            }
        }
        
        [Fact]
        public void TesteComposição_TrocarFreteAlteraTotalSemNovasSubclasses()
        {
            // Arrange
            var pedido = new PedidoNacional();
            var totalSemFrete = pedido.CalcularTotal();
            
            // Act
            pedido.AdicionarPolitica(PoliticasService.FreteFixo);
            var totalComFrete = pedido.CalcularTotal();
            
            // Assert
            Assert.True(totalComFrete > totalSemFrete);
            Assert.IsType<PedidoNacional>(pedido); // Ainda é a mesma classe
        }
        
        [Fact] 
        public void TesteComposição_MultiplasPoliticasCombinadas()
        {
            // Arrange
            var pedido = new PedidoInternacional(5.0m);
            
            // Act - Adiciona múltiplas políticas
            pedido.AdicionarPolitica(PoliticasService.FretePercentual);
            pedido.AdicionarPolitica(PoliticasService.Cupom10Porcento);
            var totalFinal = pedido.CalcularTotal();
            
            // Assert - Deve calcular corretamente
            Assert.True(totalFinal > 0);
        }
    }
}