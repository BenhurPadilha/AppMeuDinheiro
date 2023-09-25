using System;
using System.Collections.Generic;
using System.Linq;
using AppMeuDinheiro.EF.Models;
using Microsoft.EntityFrameworkCore;

internal class AppMeuDinheiroContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<ContaCorrente> ContasCorrentes { get; set; }
    public DbSet<Extrato> Extratos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configuração da conexão com o banco de dados
        string connectionString = "Server=localhost;User Id=sa;Password=blog_6109;Database=MeuDinheiro;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    // Método para inserir um novo cliente
    public void InserirCliente(Cliente cliente)
    {
        Clientes.Add(cliente);
    }

    // Método para remover um cliente
    public void RemoverCliente(int clienteId)
    {
        var cliente = Clientes.Find(clienteId);
        if (cliente != null)
        {
            Clientes.Remove(cliente);
        }
    }

    // Método para listar todos os clientes
    public List<Cliente> ListarClientes()
    {
        return Clientes.ToList();
    }

    // Método para listar todas as contas de um cliente
    public List<ContaCorrente> ListarContasDoCliente(int clienteId)
    {
        return ContasCorrentes.Where(c => c.ClienteId == clienteId).ToList();
    }

    // Método para depositar em uma conta
    public void DepositarEmConta(int contaId, decimal valor)
    {
        var conta = ContasCorrentes.Find(contaId);
        if (conta != null)
        {
            conta.Saldo += valor;

            // Registrar a movimentação no extrato
            var extrato = new Extrato
            {
                DataMovimentacao = DateTime.Now,
                Movimentacao = "Depósito",
                Valor = valor,
                ContaCorrenteId = contaId
            };

            Extratos.Add(extrato);
        }
    }

    // Método para sacar de uma conta
    public void SacarDeConta(int contaId, decimal valor)
    {
        var conta = ContasCorrentes.Find(contaId);
        if (conta != null && conta.Saldo >= valor)
        {
            conta.Saldo -= valor;

            // Registrar a movimentação no extrato
            var extrato = new Extrato
            {
                DataMovimentacao = DateTime.Now,
                Movimentacao = "Saque",
                Valor = -valor,
                ContaCorrenteId = contaId
            };

            Extratos.Add(extrato);
        }
    }

    // Método para visualizar o extrato de uma conta
    public List<Extrato> VisualizarExtrato(int contaId)
    {
        return Extratos.Where(e => e.ContaCorrenteId == contaId).ToList();
    }
}
