using System;

class Pessoa{
  
  /*********************************************
  * Atributos da classe Pessoa. Representam as características que queremos guardar na 
  * mememória RAM para uma Pessoa.
  * 
  * Os atributos são normalmente privados (private) para garantir que apenas a própria 
  * classe pessoa tenha acesso direto aos dados.
  ***/
  private string nome;
  private float peso;
  private float altura;

  //É possível utilizar um atributo da própria classe que se está definindo:
  private Pessoa pai;
  
  /*********************************************
  * Construtores da classe Pessoa. 
  * São os métodos (funções dentro da classe) responsáveis pela instanciação (criação do objeto). 
  *
  * Um construtor é executado sempre que um objeto da classe é criado. 
  * Se nenhum construtor for explicitamente criado o C# criará um padrão para a classe.
  *
  * O construtor sempre terá o mesmo nome da classe e não terá tipo de retorno. 
  ***/
  //Construtor simples, sem parâmetros de entrada:
  public Pessoa(){
    nome = "<Nome não Informado>";
    peso = altura = 0f;
  }

  //Construtor que possui apenas 1 parâmetro (o nome da pessoa):  
  public Pessoa(string nome){
    this.nome = nome;
    peso = altura = 0f;
  }
  
  //Construtor parametizado:
  public Pessoa(string nome, float peso, float altura){
    //Atribui o nome informado por parâmetro, após aplicar a transformação para maiúsculas:
    this.nome = nome.ToUpper();
    
    //Atribui o peso apenas se for maior que zero (Regra de Negócio):
    if(peso >= 0){
      this.peso = peso;
    }else{
      Console.WriteLine("Peso informado deve ser maior que zero. Assumindo valor zero.");
      this.peso = 0f;
    }
    
    //Atribui a altura apenas se for maior que zero (Regra de Negócio):
    if(altura >= 0){
      this.altura = altura;
    }else{
      Console.WriteLine("Altura informada deve ser maior que zero. Assumindo valor zero.");
      this.altura = 0f;
    }    
  }

  
  /*********************************************
  * Métodos de Acesso aos Atributos da Classe Pessoa. 
  * São os métodos responsáveis por dar acesso de escrita e leitura aos atribuos definidos como privados.
  *
  * Normalmente usamos o prefixo get (obter) para realizar a leitura do valor de um atributo. 
  * Normalmente usamos o prefixo set (Alterar) para realizar a escrita do valor de um atributo. 
  ***/  
  // Get para o atributo nome. 
  public string getNome(){
    return nome;
  }
  // Set para o atributo nome. 
  public void setNome(string n){
    nome = n.ToUpper();
  }

  // Get para o atributo peso. 
  public float getPeso(){
    return peso;
  }
  
  // Set para o atributo peso. 
  public void setPeso(float p){
    //Atribui o peso apenas se for maior que zero (Regra de Negócio):
    if(p >= 0){
      this.peso = p;
    }else{
      Console.WriteLine("Peso informado deve ser maior que zero. Valor não será alterado.");
    };
  }

  // Get para o atributo altura. 
  public float getAltura(){
    return altura;
  }
  // Set para o atributo altura. 
  public void setAltura(float a){
    //Atribui a altura apenas se for maior que zero (Regra de Negócio):
    if(a >= 0){
      this.altura = a;
    }else{
      Console.WriteLine("Altura informada deve ser maior que zero. Valor não será alterado.");
    };
  }

  //Get para o atributo pai:
  public Pessoa getPai(){
    return pai;
  }

  //Set para o atributo pai:
  public void setPai(Pessoa pes){
    pai = pes;
  }

  
  /*********************************************
  * Métodos Diveros. 
  * São as operações associadas ao tipo de dados (à classe).  
  * Os métodos são responsáveis por determinar comportamento dos objetos de uma classe.
  *
  ***/    
  // Método responsável por cálcular o IMC (Indice de Mássa Corpotal) a partir dos atributos da classe:
  public float IMC(){
      float imc_calc = peso/(altura*altura);
  
      //retorna o valor para o ponto de chamada do método:
      return imc_calc;
  }

  //Método responsável por obter o avo paterno da pessoa:
  public Pessoa AvoPaterno(){
    if(this.pai is not null){
      return pai.pai;
    }
    // Caso não encontre o pai no objeto, retorna null  
    return null;
  }

  //Método que retorna True (verdadeiro) caso a pessoa que chamou o método seja 
  //mais alta que a outra pessoa, informada por parâmetro:
  public bool MaiorQue(Pessoa outraPessoa){
    if(this.altura > outraPessoa.altura){
      return true;
    }

    //Retornará falso caso a pessoa NÃO seja mais alta que a outra informada por parâmetro:  
    return false;
  }

}