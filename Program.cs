using System;
using System.Text;
using System.Collections.Generic;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 10); // Alterado para 10 dias para testar o desconto
try
{
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);

    // Exibe informações da reserva
    Console.WriteLine("=== Detalhes da Reserva ===");
    Console.WriteLine($"Tipo de Suíte: {reserva.Suite.TipoSuite}");
    Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade} hóspedes");
    Console.WriteLine($"Valor da Diária: R$ {reserva.Suite.ValorDiaria}");
    Console.WriteLine($"Dias Reservados: {reserva.DiasReservados}");
    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    
    Console.WriteLine("\nLista de Hóspedes:");
    foreach (var hospede in reserva.Hospedes)
    {
        Console.WriteLine($"- {hospede.NomeCompleto}");
    }
    
    Console.WriteLine($"\nValor total da estadia: R$ {reserva.CalcularValorDiaria()}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}