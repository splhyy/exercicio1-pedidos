\# Exercício 1 - Sistema de Pedidos Nacional/Internacional



\## 📋 Sobre o Projeto

Implementação do exercício de Herança e Composição em C#, demonstrando:

\- Herança controlada com ritual fixo (Processar → Validar → Calcular → Emitir)

\- LSP (Princípio de Substituição de Liskov) - cliente agnóstico aos subtipos

\- Composição com delegates para políticas plugáveis (frete, promoção)



\## 🏗️ Arquitetura



\### Herança para Especialização

\- `Pedido` (base) - Orquestra ritual fixo com ganchos protected virtual

\- `PedidoNacional` (sealed) - Especializa cálculo de impostos e NF-e

\- `PedidoInternacional` (sealed) - Especializa taxas de importação e invoice



\### Composição para Políticas

\- `Frete: decimal → decimal` - Estratégias de cálculo de frete

\- `Promocao: decimal → decimal` - Estratégias de desconto

## 🚀 Como Executar

### Compilar e executar o projeto:
```bash
cd PedidosSystem
dotnet run

Executar os testes:

cd PedidosSystem
dotnet test

##🧪 Testes Implementados
Teste LSP: Processamento funciona com todos os tipos sem downcast

Teste Composição: Troca de frete altera total sem novas subclasses

Teste Múltiplas Políticas: Combinação de políticas funciona corretamente

Desenvolvido por: Shara Palharini Lima
(https://github.com/splhyy)