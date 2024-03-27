using TreinoCSharp.Models;


Conta conta1 = new()
{
    Nome = "carlos",
    Banco = "itau",
    ContaNumero = 155879,
    Agencia = 8596,
    Saldo = 0
};

Conta conta2 = new()
{
    Nome = "Elen",
    Banco ="Itau",
    ContaNumero = 251661,
    Agencia = 5846,
    Saldo = 0

};

conta1.Apresentar();
conta2.Apresentar();
conta1.Depositar(500);
conta2.Depositar(10000);
conta1.Transferir(conta2,100);
conta2.Apresentar();



