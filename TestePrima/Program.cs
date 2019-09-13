using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestePrima
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nTESTE PRIMA");
            Console.WriteLine("Digite qual o número do exercício deseja validar (0 para sair):");
            string valorDigitado = Console.ReadLine();

            while (true) {
                if (ValidaNumero(valorDigitado))
                {

                    switch (Convert.ToInt32(valorDigitado))
                    {
                        case 12:
                            Exercicio12();
                            break;
                        case 13:
                            Exercicio13();
                            break;
                        case 14:
                            Exercicio14();
                            break;
                        case 15:
                            Exercicio15();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Exercicio digitado é inválido. Precisa estar entre 12,13,14,15");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um exercício válido (12,13,14,15)");
                }
                Console.WriteLine("\n\nTESTE PRIMA");
                Console.WriteLine("Digite qual o número do exercício deseja validar (0 para sair):");
                valorDigitado = Console.ReadLine();
            }
        }

        public static bool ValidaNumero(string valor)
        {
            int numero = 0;

            try
            {
                numero = Convert.ToInt32(valor);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static void Exercicio12()
        {
            Console.WriteLine("Exercício 12 - Números ímpares entre 100 e 1000");

            const int numeroInicial = 100;
            const int numeroFinal = 1000;
            int numeroAtual = numeroInicial;

            List<int> numerosImpares = new List<int>();

            while (numeroAtual <= numeroFinal)
            {
                if (numeroAtual % 2 != 0)
                    numerosImpares.Add(numeroAtual);

                numeroAtual++;
            }

            Console.WriteLine("Números ímpares: \n");

            foreach (int valor in numerosImpares.OrderByDescending(value => value))
                Console.Write(valor + "\t");
        }

        public static void Exercicio13()
        {
            Console.WriteLine("Exercício 13 - Lista de 100 números");

            int contador = 0;
            List<int> numerosDigitados = new List<int>();

            while (contador < 10)
            {
                Console.WriteLine("\nDigite o número da posição " + contador + ":");
                string valorDigitado = Console.ReadLine();

                try
                {
                    numerosDigitados.Add(Convert.ToInt32(valorDigitado));
                    contador++;
                }
                catch
                {
                    Console.WriteLine("Número inválido. Digite novamente: ");
                }
            }

            Console.WriteLine("\n\n========= Resultado =========7");
            Console.WriteLine("\nMaior número digitado: " + numerosDigitados.OrderByDescending(value => value).FirstOrDefault()); ;
            Console.WriteLine("Menor número digitado: " + numerosDigitados.OrderBy(value => value).FirstOrDefault());
        }

        public static void Exercicio14()
        {
            Console.WriteLine("Exercício 14 - Idade de aposentadoria");

            Console.WriteLine("\nDigite o nome do empregado:");
            string nomeEmpregado = Console.ReadLine();

            DateTime dataNascimentoValida = DateTime.MinValue;
            DateTime dataIngressoValida = DateTime.MinValue;

            while (dataNascimentoValida == DateTime.MinValue)
            {
                Console.WriteLine("\nDigite a data de nascimento do empregado no formato DD/MM/AAAA:");
                string dataNascimento = Console.ReadLine();
                try
                {
                    dataNascimentoValida = Convert.ToDateTime(dataNascimento);
                }
                catch
                {
                    Console.WriteLine("\nÉ necessário digitar uma data válida para prosseguir. Exemplo: 01/12/2018");
                    dataIngressoValida = DateTime.MinValue;
                }
                if (dataNascimentoValida >= DateTime.Now.Date)
                {
                    Console.WriteLine("\nData de nascimento precisa ser menor que a data de hoje.");
                    dataIngressoValida = DateTime.MinValue;
                }
            }

            while (dataIngressoValida == DateTime.MinValue)
            {
                Console.WriteLine("\nDigite a data de ingresso na Empresa do empregado no formato DD/MM/AAAA:");
                string dataIngresso = Console.ReadLine();
                try
                {
                    dataIngressoValida = Convert.ToDateTime(dataIngresso);
                }
                catch
                {
                    Console.WriteLine("\nÉ necessário digitar uma data válida para prosseguir. Exemplo: 01/12/2018");
                    dataIngressoValida = DateTime.MinValue;
                }

                if (dataIngressoValida <= dataNascimentoValida)
                {
                    Console.WriteLine("\nData de ingresso precisa ser maior que a data de nascimento.");
                    dataIngressoValida = DateTime.MinValue;
                }    
            }

            int idadeFuncionario = DateTime.Now.Year - dataNascimentoValida.Year;
            int tempoEmpresa = DateTime.Now.Year - dataIngressoValida.Year;

            Console.WriteLine("\n=========Resultado===========");
            if ((idadeFuncionario >= 65) || (tempoEmpresa >= 30) || (idadeFuncionario >= 60 && tempoEmpresa >= 25))
                Console.WriteLine(nomeEmpregado + " apto para aposentadoria.");
            else
                Console.WriteLine(nomeEmpregado + " inapto para aposentadoria.");

            Console.WriteLine("Idade: " + idadeFuncionario + " anos;");
            Console.WriteLine("Tempo de empresa: " + tempoEmpresa + " anos;");

        }

        public static void Exercicio15()
        {
            Console.WriteLine("Exercício 15 - Total de todas as mercadorias em estoque");

            int contador = 1;

            Console.WriteLine("Digite - (traço) para interromper a contagem e ver o resultado.");
            string qtdeMercadoria = "";
            string valorUnidadeMercadoria = "";
            decimal totalEstoque = 0;
            decimal estoqueProdutoAtual = 0;
            decimal valorTotalMercadorias  = 0;

            while (qtdeMercadoria != "-")
            {

                while (!ValorDecimalValido(qtdeMercadoria) && qtdeMercadoria != "-")
                {
                    Console.WriteLine("\nDigite a quantidade total da mercadoria " + contador + " em estoque");
                    qtdeMercadoria = Console.ReadLine();

                    if (ValorDecimalValido(qtdeMercadoria) && qtdeMercadoria != "-")
                    {
                        totalEstoque += Convert.ToDecimal(qtdeMercadoria);
                        estoqueProdutoAtual = Convert.ToDecimal(qtdeMercadoria);
                    }
                    else
                        Console.WriteLine("Digite uma quantidade válida.");
                }
                if (qtdeMercadoria == "-") break;
                qtdeMercadoria = "";

                while (!ValorDecimalValido(valorUnidadeMercadoria))
                {
                    Console.WriteLine("\nDigite o valor de cada unidade da mercadoria "+ contador +" (em R$):");
                    valorUnidadeMercadoria = Console.ReadLine();

                    if (ValorDecimalValido(valorUnidadeMercadoria))
                    {
                        valorTotalMercadorias += estoqueProdutoAtual * Convert.ToDecimal(valorUnidadeMercadoria);
                        contador++;
                    }
                    else
                        Console.WriteLine("Digite um valor de mercadoria válido, somente números.");
                }
                valorUnidadeMercadoria = "";
            }

            Console.WriteLine("\n=========Resultado===========");

            Console.WriteLine("Valor Total das " + (contador-1) +" mercadorias em estoque: R$ " + Math.Round(valorTotalMercadorias,2));
            Console.WriteLine("Valor médio das mercadorias: R$ " + Math.Round(valorTotalMercadorias / totalEstoque, 2));

        }

        public static bool ValorDecimalValido(string valor)
        {
            try
            {
                Convert.ToDecimal(valor);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
