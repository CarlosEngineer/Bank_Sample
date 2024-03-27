using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace TreinoCSharp.Models
{
    public class Conta
    {

        //encapsulamento: 
        private string _Nome;
        private string _Banco;
        private int _ContaNumero;
        private decimal _Saldo;

        public Conta()
        {
        }

        public Conta(string Nome, string Banco, int ContaNumero, int Agencia, decimal Saldo)
        {
            this.Nome = Nome;
            this.Banco = Banco;
            this.ContaNumero = ContaNumero;
            this.Agencia = Agencia;
            this.Saldo = Saldo;
        }

        //propriedades
         public string Nome { 
            get => _Nome.ToUpper();
            
            set =>_Nome = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Este nome não é válido", nameof(Nome)) : value;
           
         } 
         public string Banco { 
            get => _Banco.ToUpper();
            set => _Banco = string.IsNullOrEmpty(value) ? throw new ArgumentException("Digite Um Banco valido.", nameof(Banco)) : value;
        }
         public int ContaNumero { 
            get => _ContaNumero;
            set => _ContaNumero = int.IsEvenInteger(value) ? throw new Exception("Digite um valor valido"): value;   
        }
         public int Agencia { get; set; }

         public decimal Saldo { 
            get => _Saldo;
            set => _Saldo = decimal.IsNegative(value) ? throw new Exception("Seu saldo nao pode ficar negativo"): value;
        }

         public void Apresentar() //metodo 
         {
                Console.WriteLine($"Seguem os dados cadastrados \nNome:{Nome},\nBanco: {Banco},\nConta: {ContaNumero},\nAgencia: {Agencia},\nSaldo: {Saldo}.");
         }

         public void Depositar(decimal valor)
         {
            if(valor<0)
            {
                throw new ArgumentException("Nao pode depositar um valor negativo");
            }
            else{
                Saldo += valor;
                CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("pt-BR");
                Console.WriteLine($"Voce depositou o valor de {valor.ToString("C",cultureInfo)}\nEsse é seu saldo atual {Saldo.ToString("C",cultureInfo)}");
            }
         }
         
         public void Transferir(Conta contaDestino,decimal valor )
         {
            if(contaDestino == null || valor <= 0  )
            {
                throw new ArgumentException($"Conta destino inválida ou valor de transferência inválido{nameof(contaDestino)}." );
            }
            if(valor <= 0 )
            {
                throw new ArgumentException("Valor incorreto ");
            }

            Saldo -=valor;
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("pt-BR");
            contaDestino.Depositar(valor);
            Console.WriteLine($"Voce Transferiu a quantia de {valor.ToString("C",cultureInfo)}\nEsse é seu saldo atual {Saldo.ToString("C",cultureInfo)}");
            
         }
         public void Sacar(decimal valor)
         {
            if(valor<0)
            {
                throw new ArgumentException("Nao pode depositar um valor negativo");
            }
            else if(valor>Saldo)
            {
                throw new Exception ("Seu valor a sacar e maior do que o saldo.");
            }
            else{
                Saldo -= valor;
                CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("pt-BR");
                Console.WriteLine($"Voce sacou a quantia de {valor.ToString("C",cultureInfo)}\nEsse é seu saldo atual {Saldo.ToString("C",cultureInfo)}");
            }
         }
    }
}