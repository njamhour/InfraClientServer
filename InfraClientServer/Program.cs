using InfraClientServer.DAL;
using InfraClientServer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string CaminhoNumeroUm = @"c:\users\nicholas.jamhour\desktop\InfraClientServer\first.txt";
            string CaminhoNumeroDois = @"c:\users\nicholas.jamhour\desktop\InfraClientServer\second.txt";
            string CaminhoOperador = @"c:\users\nicholas.jamhour\desktop\InfraClientServer\operador.txt";
            string UmCripto = @"c:\users\nicholas.jamhour\desktop\InfraClientServer\firstcrypt.txt";
            string DoisCripto = @"c:\users\nicholas.jamhour\desktop\InfraClientServer\secondcrypt.txt";
            string OperadorCripto = @"c:\users\nicholas.jamhour\desktop\InfraClientServer\operadorcrypt.txt";
            //string Text = "Teste";

            int opcao;
            Atributos Atrr;

            do
            {
                
                Console.Clear();
                Console.WriteLine(" -- CLIENT -- ");
                Console.WriteLine("1 - Inserir dados");
                Console.WriteLine("2 - Visualizar dados registrados");
                Console.WriteLine("3 - Salvar em arquivo");
                Console.WriteLine("4 - Visualizar dados criptografados");
                Console.WriteLine("0 - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Atrr = new Atributos();
                        bool NumeroUm;
                        bool Operador;
                        bool NumeroDois;

                        do
                        {
                            Console.WriteLine("Digite o primeiro numero");
                            string PrimeiroNumero = Console.ReadLine();
                            int ParsePrimeiroNumero;
                            if (int.TryParse(PrimeiroNumero, out ParsePrimeiroNumero))
                            {
                                Console.WriteLine("Primeiro numero registrado");
                                int First = Convert.ToInt32(PrimeiroNumero);
                                Atrr.PrimeiroDigito = First;
                                NumeroUm = true;
                            }
                            else
                            {
                                Console.WriteLine("Erro... numero não registrado");
                                NumeroUm = false;
                            }
                        } while (NumeroUm != true);

                        do
                        {
                            Console.WriteLine("Digite o segundo numero");
                            string SegundoNumero = Console.ReadLine();
                            int ParseSegundoNumero;
                            if (int.TryParse(SegundoNumero, out ParseSegundoNumero))
                            {
                                Console.WriteLine("Segundo numero registrado");
                                int Second = Convert.ToInt32(SegundoNumero);
                                Atrr.SegundoDigito = Second;
                                NumeroDois = true;
                            }
                            else
                            {
                                Console.WriteLine("Erro... numero não registrado");
                                NumeroDois = false;
                            }
                        } while (NumeroDois != true);
                        do
                        {
                            Console.WriteLine("Digite o operador");
                            string Op = Console.ReadLine();
                            if (Op.Contains("+"))
                            {
                                Console.WriteLine("Operador registrado");
                                Atrr.Operador = Op;
                                Operador = true;
                            }
                            else
                            {
                                Console.WriteLine("Erro... operador não registrado");
                                Operador = false;
                            }
                            
                            
                        } while (Operador != true);

                        AtributosDAO.CadastrarAtributos(Atrr);
                        break;     
                    case 2:
                        Console.WriteLine("Visualizar dados....");
                        //Console.WriteLine(Atrr.PrimeiroDigito + " " + Atrr.SegundoDigito + " " + Atrr.Operador);
                        //Console.WriteLine(AtributosDAO.RetornarAtributos.NumeroUm);
                        foreach (Atributos att in AtributosDAO.RetornarAtributos())
                        {
                            Console.WriteLine(att.PrimeiroDigito);
                            Console.WriteLine(att.SegundoDigito);
                            Console.WriteLine(att.Operador);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        foreach (Atributos att in AtributosDAO.RetornarAtributos())
                        {
                            File.WriteAllText(CaminhoNumeroUm, Convert.ToString(att.PrimeiroDigito));
                            File.WriteAllText(CaminhoNumeroDois, Convert.ToString(att.SegundoDigito));
                            File.WriteAllText(CaminhoOperador, Convert.ToString(att.Operador));
                        }
                        Console.WriteLine("Salvos com sucesso...");
                        Console.ReadKey();
                        break;
                    case 4:
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                
                }

            } while (opcao != 0);

            //File.WriteAllText(Caminho, Text);
            //Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
