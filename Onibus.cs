using System;
using System.IO;

//Namespace utilizado para manipular coleções (ex.: List)
using System.Collections.Generic;


/*************************************************
* Classe que representa um ônibus de turismo.
* Esse ônibus possui um valor fixo de passagem para cada viagem que faz.
*****/
class Onibus
{
    private string marca;
    private int capacidade;
    private float valor_passagem;

    //Lista de objetos para representar a relação entre pessoas e ônibus.
    private List<Pessoa> passageiros;

    public Onibus()
    {
        marca = "Marca Não Informada";
        capacidade = 0;
        passageiros = new List<Pessoa>();
    }

    public Onibus(string marca, int capacidade, float vlr_passagem)
    {
        this.marca = marca;
        this.capacidade = capacidade;
        this.valor_passagem = vlr_passagem;

        passageiros = new List<Pessoa>();
    }

    //Recebe uma Pessoa para embarcar no ônibus
    public bool EmbarcarPassageiro(Pessoa p)
    {
        if (passageiros.Count < capacidade)
        {
            passageiros.Add(p);
            return true;
        }

        return false;
    }


    public int QtdPassageirosIMCAlto()
    {
        int qtd = 0;

        for (int i = 0; i < passageiros.Count; i++)
        {
            Pessoa p = passageiros[i];

            //Conta sempre que o IMC for maior que o normal (24.9):
            if (p.IMC() > 24.9f)
            {
                qtd++;
            }

        }

        return qtd;
    }

    public Pessoa BuscaPessoa(string nome)
    {

        for (int i = 0; i < passageiros.Count; i++)
        {
            Pessoa p = passageiros[i];

            if (p.getNome() == nome)
            {
                return p;
            }
        }

        return null;
    }

    public List<Pessoa> getListaPassageiros()
    {
        return passageiros;
    }

    public int QuantidadePassageiros()
    {
        return passageiros.Count;
    }

    public void DesembarcarTodos()
    {
        passageiros.Clear();
    }


    //Imprime um relatório de pessoas dentro do ônibus e a receita total obtida com 
    //a venda de passagens:
    public void ImprimeRelatorioPassageiros()
    {
        Console.WriteLine("=====================================================");
        Console.WriteLine("============ Relatório de Passageiros ===============");
        Console.WriteLine("=====================================================");

        //percorre toda a lista de passageiros para imprimir a informação de cada pessoa:
        for (int i = 0; i < passageiros.Count; i++)
        {
            Pessoa p = passageiros[i];
            Console.WriteLine($"Pessoa {i + 1}: {p.getNome()} ");
        }

        Console.WriteLine("=====================================================");

        //calcula o valor total da passagem com base no valar unitário e na quantidade de pessoas no ônibus:
        float vlr_total = passageiros.Count * valor_passagem;
        Console.WriteLine("Valor da Passagem: R${0:#.00}, Total: R${1:#.00}", this.valor_passagem, vlr_total);

        Console.WriteLine("=====================================================");

        if (QtdPassageirosIMCAlto() > passageiros.Count / 2)
        {
            Console.WriteLine("Mais da metade dos passageiros possui IMC acima do normal!");
            Console.WriteLine("=====================================================");
        }

    }

    //Imprime um relatório de pessoas dentro do ônibus e a receita total obtida com 
    //a venda de passagens:
    public void ImprimeRelatorioHTML(string arquivo_template)
    {

        string texto_arquivo = File.ReadAllText(arquivo_template);

        //percorre toda a lista de passageiros para imprimir a informação de cada pessoa:

        string linha_tabela = "<tr><td>{{nome_passageiro}}</td><td style=\"text-align:center\">{{imc_passageiro}}</td</tr>";
        string linhas_preenchidas = "";

        for (int i = 0; i < passageiros.Count; i++)
        {
            Pessoa p = passageiros[i];
            string linha_aux = linha_tabela.Replace("{{nome_passageiro}}", p.getNome());
            linha_aux = linha_aux.Replace("{{imc_passageiro}}", p.IMC().ToString());

            linhas_preenchidas += linha_aux + Environment.NewLine;
        }

        texto_arquivo = texto_arquivo.Replace("{{linhas_tabela}}", linhas_preenchidas);

        //calcula o valor total da passagem com base no valar unitário e na quantidade de pessoas no ônibus:
        float vlr_total = passageiros.Count * valor_passagem;
        texto_arquivo = texto_arquivo.Replace("{{receita_total}}", vlr_total.ToString());

        if (QtdPassageirosIMCAlto() > passageiros.Count / 2)
        {
            texto_arquivo = texto_arquivo.Replace("{{atencao_imc_alto}}", "visible");
        }
        else
        {
            texto_arquivo = texto_arquivo.Replace("{{atencao_imc_alto}}", "hidden");
        }

        string nome_relatorio = "relatorios/Relatorio-Passageiros.html";
        File.WriteAllText(nome_relatorio, texto_arquivo);
    }
  
}