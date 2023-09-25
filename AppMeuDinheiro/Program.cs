using AppMeuDinheiro.EF.Models;
using System;

class Program
{
    static void Main()
    {
        using (var dbContext = new AppMeuDinheiroContext())
        {

            // Inserindo clientes
            var novoCliente = new Cliente { Nome = "Cliente_Teste_1" };
            dbContext.InserirCliente(novoCliente);
            Console.WriteLine("Novo cliente inserido com ID: " + novoCliente.Id);

            var novoCliente2 = new Cliente { Nome = "Cliente_Teste_2" };
            dbContext.InserirCliente(novoCliente);
            Console.WriteLine("Novo cliente inserido com ID: " + novoCliente.Id);

            // Listando todos os clientes
            var clientes = dbContext.ListarClientes();
            Console.WriteLine("\nLista de Clientes:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}");
            }

            // Realizando uma transação de depósito em uma conta
            int contaId = 1;
            decimal valorDeposito = 100.00m;
            dbContext.DepositarEmConta(contaId, valorDeposito);
            Console.WriteLine($"\nDepósito de {valorDeposito:C} realizado na conta {contaId}.");

            // Realizando uma transação de saque em uma conta
            int contaIdSaque = 2;
            decimal valorSaque = 50.00m;
            dbContext.SacarDeConta(contaIdSaque, valorSaque);
            Console.WriteLine($"\nSaque de {valorSaque:C} realizado na conta {contaIdSaque}.");

            // Visualizando o extrato de uma conta
            int contaIdExtrato = 1;
            var extrato = dbContext.VisualizarExtrato(contaIdExtrato);
            Console.WriteLine($"\nExtrato da Conta {contaIdExtrato}:");
            foreach (var movimentacao in extrato)
            {
                Console.WriteLine($"Data: {movimentacao.DataMovimentacao}, Movimentação: {movimentacao.Movimentacao}, Valor: {movimentacao.Valor:C}");
            }
        }
    }
}

