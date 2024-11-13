using System;

//Bibliotecas (namespaces) necessários para a manipulação de arquivos.
using System.IO;
using System.Text;


class GerenciadorOnibus
{
    Onibus meu_onibus;

    public bool CarregarDadosPassageiros(string nome_arquivo)
    {
        // Leitura de dados do arquivo, linha por linha.  
        string[] linhas = File.ReadAllLines(nome_arquivo);

        foreach (string linha in linhas)
        {
            string[] dados = linha.Split(";");
            string nome = dados[0];
            float peso = float.Parse(dados[1]);
            float altura = float.Parse(dados[2]);
            meu_onibus.EmbarcarPassageiro(new Pessoa(nome, peso, altura));
        }

        return true;
    }

    public bool GravarDadosPassageiros(string nome_arquivo)
    {
        using (StreamWriter writer = new StreamWriter(nome_arquivo))
        {
            foreach (Pessoa p in meu_onibus.getListaPassageiros())
            {
                string linha = string.Format("{0};{1};{2}", p.getNome(), p.getPeso(), p.getAltura());
                writer.WriteLine(linha);
            }

        }

        return true;
    }



    public GerenciadorOnibus()
    {
        meu_onibus = new Onibus("Mercedes", 10, 4.20f);
    }

    public void MenuInicial()
    {
        string opcao = "";

        while (opcao != "0")
        {
            Console.Clear();
            Console.WriteLine("===============================1======================");
            Console.WriteLine("===                Opcões do Sistema              ===");
            Console.WriteLine("=====================================================");
            Console.WriteLine("0 - Sair.");
            Console.WriteLine("1 - Adicionar Passageiro ao Ônibus.");
            Console.WriteLine("2 - Apresentar Relatório de Passageiros.");
            Console.WriteLine("3 - Carregar dados.");
            Console.WriteLine("4 - Gravar dados.");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    return;
                case "1":
                    Console.WriteLine("Informe o nome do passageiro:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Informe o peso do passageiro:");
                    float peso = float.Parse(Console.ReadLine());
                    Console.WriteLine("Informe a altura do passageiro:");
                    float altura = float.Parse(Console.ReadLine());

                    meu_onibus.EmbarcarPassageiro(new Pessoa(nome, peso, altura));

                    Console.WriteLine("\nPassageiro Embarcado! Pressione qualquer teclar continuar.");
                    Console.ReadKey();
                    break;
                case "2":
                    meu_onibus.ImprimeRelatorioPassageiros();
                    Console.WriteLine("\nRelatório Apresentado! Deseja Salvar em HTML? (S/N).");
                    string resp_html = Console.ReadLine();
                    if (resp_html.ToUpper() == "S")
                    {
                        meu_onibus.ImprimeRelatorioHTML("relatorios/modelo_relatorio.html");
                        Console.WriteLine("\nRelatório impresso em HTML com sucesso! Pressione qualquer teclar continuar.");
                        Console.ReadKey();
                    }
                    break;
                case "3":
                    bool realizar_acao = true;
                    if (meu_onibus.QuantidadePassageiros() > 0)
                    {
                        Console.WriteLine("Os dados atuais serão substituídos, deseja continuar? (S/N)");
                        string resp = Console.ReadLine();
                        if (resp.ToUpper() == "S")
                        {
                            meu_onibus.DesembarcarTodos();
                            realizar_acao = true;
                        }
                        else
                        {
                            realizar_acao = false;
                        }
                    }
                    if (realizar_acao)
                    {
                        CarregarDadosPassageiros("banco_de_dados/dados.txt");
                        Console.WriteLine("\nDados carregados com sucesso! Pressione qualquer teclar continuar.");
                    }
                    else
                    {
                        Console.WriteLine("\nDados NÃO carregados! Pressione qualquer teclar continuar.");
                    }
                    Console.ReadKey();
                    break;
                case "4":
                    GravarDadosPassageiros("banco_de_dados/dados.txt");
                    Console.WriteLine("\nDados gravados com sucesso! Pressione qualquer teclar continuar.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção Inválida! Pressione qualquer teclar para tentar novamente:");
                    Console.ReadKey();
                    break;
            }
            opcao = "";
        }
    }


    public static void Main(string[] args)
    {

        //Cria um objeto do tipo GerenciadorOnibus, que substitui a classe padrao Program.
        GerenciadorOnibus meu_gerenciador = new GerenciadorOnibus();

        //Apresenta o menu de opções do sistema para o usuário:    
        meu_gerenciador.MenuInicial();

    }
}