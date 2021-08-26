using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class levelgenerator : MonoBehaviour
{

    //    public GameObject pessoa;
    //    public GameObject enemy;
    public GameObject prefabP;
    public GameObject casa;
    public GameObject escola;
    public GameObject trabalho;
    public GameObject terrain;
    public List<Predios> predios;
    public List<Vector3> enderecos;
    public List<cPessoa> todasAsPessoas;
    public string tipoDistribuicao = "aleatorio";
    public List<cPessoa> tempPessoas;



    private Collider col;

//    public int numberOfEnemies;
//    public int numberOfPessoas;
    public int totalCasas;
    public int totalEscolas;
    public int totalTrabalhos;
    public int maxPessoasI;
    public int totalPessoas;

    private List<Vector3> usedPoints;

    public int numLugares;

    public Lugar lugar;
    public cPessoa[] familias;
    public int contador;
    public int contador2;
    //    public List<cPessoa> familias;

    /*  -------------------------------------------tentando tratar o dropdown com enum de origem                /
    enum distribuicoes { a,b,c};                                                                                /
    public Dropdown dropdown;                                                                                   /
                                                                                                                /
    void preencheDd()                                                                                           /
    {                                                                                                           /
        //        List<string>listaDist = Enum.GetValues(typeof(distribuicoes)).Cast<SomeEnum>().ToList();      /
        string [] lista = distribuicoes.GetNames(typeof(distribuicoes));                                        /
        List<string> listaDist = new List<string>(lista);                                                       /
                                                                                                                /
        dropdown.AddOptions(listaDist);                                                                         /
    }-------------------------------------------tentando tratar o dropdown com enum de origem
    */

    // Start is called before the first frame update
    void Start()
    {

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //       List<string> teste = new List<string> { "casa1", "casa2", "escola", "casa3", "escola1", "escola2" };
        //      int testeindex = teste.IndexOf("casa2");
        //        Debug.Log("LEVEL-START: index de casa2: " + testeindex);
        //        List<string> testecasa = new List<string>();
        /*    foreach (string t in teste)
            {
                if (t.Contains("e")) { testecasa.Add(t); }
            }
        */

        //        testecasa.AddRange( teste.FindAll((x) => x.Contains("es")));                   // tentando fazer sublist de list. .ADDRANGE resolveu a questao
        //        string temp = "";
        //        foreach (string z in testecasa)
        //        {
        //            temp += " " + z;
        //        }
        //      Debug.Log("lista de casas: " + temp);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//                totalCasas = 5;
        //        totalEscolas = 5;
  //              totalTrabalhos = 5;
        //        maxPessoasI = 5;
    //            totalPessoas = 10;
        Debug.Log("levelgenerator - START: total pessoas: " + totalPessoas +
                  "\n                total casas: " + totalCasas +
                  "\n                total trabalhos: " + totalTrabalhos);


        /*        int tpop = GetComponent<populacao>().populacaoTotal;
                int criancas = tpop * GetComponent<populacao>().p100crianca/100;
                int adultos = tpop - criancas;
                Debug.Log("populacao total: " + tpop + " criancas: " + criancas);
        */
        usedPoints = new List<Vector3>();
//        iniciaMapa();
        //        lugar = new List<Lugar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setaListas(string lista)
    {
        if (predios == null) { return; }

        switch (lista)
        {
            case "predios":
                predios.Clear();
                break;
            case "enderecos":
                enderecos.Clear();
                break;
            case "pessoas":
//                if (todasAsPessoas == null) { return; }
                todasAsPessoas.Clear();
                break;
        }
    }


    public void iniciaMapa()
    {

        setaListas("predios");
        setaListas("enderecos");
//        setaListas("pessoas");


        GameObject[] pessoas = GameObject.FindGameObjectsWithTag("pessoas");
        foreach (GameObject g in pessoas)
        {
            contador = 0;
            Destroy(g);
        }
        GameObject[] criancas = GameObject.FindGameObjectsWithTag("criancas");
        foreach (GameObject g in criancas)
        {
            Destroy(g);
        }
        GameObject[] lugares = GameObject.FindGameObjectsWithTag("lugares");
        foreach (GameObject g in lugares)
        {
            Destroy(g);
        }
        GameObject[] escolas = GameObject.FindGameObjectsWithTag("escolas");
        foreach (GameObject g in escolas)
        {
            Destroy(g);
        }
        GameObject[] trabalhos = GameObject.FindGameObjectsWithTag("trabalho");
        foreach (GameObject g in trabalhos)
        {
            Destroy(g);
        }

        ///////////////////////////////////////////////////////////////////////////// testes para uso da classe lugar. a versao generateObjects(lugar.tipo) eh a mais interessante
        /*if (lugar.tipoLugar == escola) {
            GenerateObjects(escola, totalEscolas);
            Debug.Log("tipo escola");
        }*/

        //        GenerateObjects(lugar.tipoLugar, totalEscolas);

        /////////////////////////////////////////////////////////////////////////////
        ///PROVAVELMENTE, MELHOR REGISTRAR TODOS OS LUGARES AQUI. PERMITIRIA UM COUNT TOTAL DE LUGARES, BEM COMO DE CADA TIPO.
        ///NESSE CASO, COMO CONTROLAR A ATRIBUICAO DISTRIBUIDA, ALEATORIA OU SETORIZADA? 
        ///         FAZER UMA ROTINA DE ESCOLHA DISSO, ONDE SE FACA A LISTA DE LUGARES A PARTIR DA UNIAO DAS DEMAIS. ESSA UNIAO VAI SER ALEATORIA, SEQUENCIAL, OU INTERCALADA. 
        ///         ESSA LISTA FINAL SERIA ENVIADA PARA A LOCACAO. ENTRETANTO, ISSO PODE TER CASOS ESPECIAIS QUANDO TRATAR DE MATRIZES POR EXEMPLO


        //      GenerateObjects(pessoa, numberOfPessoas);
        //        GenerateObjects(escola, totalEscolas);

        //        GenerateObjects(trabalho, totalTrabalhos);
        //        GenerateObjects(casa, totalCasas);

        //        pessoa();

        /*
        for (int i = 0; i < totalCasas; i++)
        {
            predios.Add(new Predios(casa, "casa" + i));
        }
        for (int i = 0; i < totalEscolas; i++)
        {
            predios.Add(new Predios(escola, "escola" + i));
        }
        for (int i = 0; i < totalTrabalhos; i++)
        {
            predios.Add(new Predios(trabalho, "trabalho" + i));
        }

        Debug.Log("LEVEL-INICIA MAPA: contagem todasaspessoas: " + todasAsPessoas.Count);
        for (int i = 0; i < totalPessoas; i++)
        {
            todasAsPessoas.Add(new cPessoa(prefabP, "pessoa" + i));
        }
        Debug.Log("LEVEL-INICIA MAPA: contagem todasaspessoas: " + todasAsPessoas.Count);
        */


        //atribuiPessoas();
    }


    public void colocaPredios()
    {
        //        iniciaMapa();

        switch (tipoDistribuicao)
        {
            case "aleatorio":
                List<Vector3> endtemp = enderecos;
                for (int i = 0; i < predios.Count; i++)
                {
                    //                    Debug.Log("LEVEL\COLOCA PREDIOS: total de enderecos rand:" + enderecos.Count);
                    int tend = Random.Range(0, enderecos.Count);
                    predios[i].enderecoXYZ = endtemp[tend];
                    //                    Instantiate(predios[i].predioPreFab, endtemp[tend], Quaternion.identity);
                    endtemp.RemoveAt(tend);

                }
                break;
            case "setorizado":
                break;
            case "continuo":
                for (int i = 0; i < predios.Count; i++)
                {
                    predios[i].enderecoXYZ = enderecos[i];
                    //                    Instantiate(predios[i].predioPreFab, enderecos[i], Quaternion.identity);

                }
                break;
        }
        foreach (Predios p in predios)
        {
            Instantiate(p.predioPreFab, p.enderecoXYZ, Quaternion.identity);
            //            Debug.Log("LEVEL-COLOCA PREDIOS: end instanciado " + p.enderecoXYZ);
        }

    }

    /*
    public void distribuicaoAtividades(Dropdown dropDistribuicao)
    {
        tipoDistribuicao = dropDistribuicao.options[dropDistribuicao.value].text;
        Debug.Log("LEVEL-DISTRIBUICAO ATIVIDADES: distribuicao eh:" + tipoDistribuicao);

        //        Debug.Log("distribuicao eh:" + dropDistribuicao.options[dropDistribuicao.value].text);
    }*/

    public void mapaAleatorio()
    {
        //        Generate();   -----> substituido por iniciaMapa
        GenerateObjects(escola, totalEscolas);
        GenerateObjects(trabalho, totalTrabalhos);
        GenerateObjects(casa, totalCasas);

    }

    public void mapaMatriz()
    {
        //        enderecos = new Vector3[totalCasas + totalEscolas + totalTrabalhos];

        Debug.Log("LEVEL-MAPA MATRIZ: total de enderecos: " + predios.Count);

        int ladoX = (int)Mathf.Sqrt(predios.Count);
        int ladoZ = (int)(predios.Count / ladoX);
        float sobra = predios.Count - (ladoX * ladoZ);
        //        Debug.Log("LEVEL\MAPA MATRIZ: lado 1: " + lado1 + "; lado 2: " + lado2 + "; sobra: " + sobra);
        //        Debug.Log("LEVEL\MAPA MATRIZ: colunas: " + (lado1 + Mathf.Ceil(sobra/lado1)));

        float colunaExtra = Mathf.Ceil(sobra / ladoX);
        //        Debug.Log("LEVEL\MAPA MATRIZ: sobra/lado: " + colunaExtra);
        //        Debug.Log("LEVEL\MAPA MATRIZ: pontos x: " + (ladoX + colunaExtra));
        //        Debug.Log("LEVEL\MAPA MATRIZ: pontos z: " + (ladoZ));

        Collider terreno = terrain.GetComponent<TerrainCollider>();
        float lateralX = terreno.bounds.max.x - terreno.bounds.min.x;
        float lateralZ = terreno.bounds.max.z - terreno.bounds.min.z;
        float passoX = lateralX / (ladoX + colunaExtra + 1);
        float passoZ = lateralZ / (ladoZ + 1);
        //        Debug.Log("LEVEL\MAPA MATRIZ: lado x: "+ lateralX+"passo x: " + passoX);
        //        Debug.Log("LEVEL\MAPA MATRIZ: lado z: " +lateralZ+"passo z: " + passoZ);

        float posX = passoX;
        float posZ = passoZ;
        int indexX = 1;
        int indexZ = 1;

        Vector3 tvector = new Vector3((indexX * passoX), 0f, (indexZ * passoZ));
        float tempY = Terrain.activeTerrain.SampleHeight(tvector);

        //        Vector3 novapos = new Vector3(x, tempY, z);

        //        GameObject predio = casa;
        for (int i = 0; i < predios.Count; i++)
        {
            //            Debug.Log("LEVEL-MAPA MATRIZ: index x: " + indexX + "; index z: " + indexZ);
            Vector3 posicao = new Vector3((indexX * passoX), tempY, (indexZ * passoZ));
            enderecos.Add(posicao);
            //            Debug.Log("LEVEL-MAPA MATRIZ: coordendas: " + posicao);
            //            Debug.Log("LEVEL-MAPA MATRIZ: coordendas\n x: " + (indexX * passoX) + ", z: " + (indexZ * passoZ) + ", y: " + tempY);

            ////////////////////////// colocar a instanciacao pra outro lugar, baseada na associacao de list.predios com list.enderecos/////////////////
            //            Instantiate(predios[i].tipoPredio, posicao, Quaternion.identity);

            indexX += 1;
            if (indexX > ladoX + colunaExtra)
            {
                indexX = 1;
                indexZ += 1;
                if (indexZ > ladoZ)
                {
                    indexZ = 1;
                }
            }
        }

        ////////////////////////// colocar a instanciacao pra outro lugar, baseada na associacao de list.predios com list.enderecos/////////////////
        colocaPredios();
        /*
         * registro do total de posicoes necessarias
         * registro da posicao inicial
         * gerar as varias posicoes na forma (forma definida pela expressao que a define)
         * 
         * decidir se gera todas as posicoes e devolve pra rotina anterior para atribuicao, ou se mantem registro interno e vai atribuindo a medida q recebe
        */
    }

    public void mapaLinha()
    {
        //        enderecos = new Vector3[totalCasas + totalEscolas + totalTrabalhos];

        Debug.Log("LEVEL-MAPA LINHA: total de enderecos: " + predios.Count);

        int ladoX = predios.Count;
        int ladoZ = 1;
        float sobra = predios.Count - (ladoX * ladoZ);

        //        Debug.Log("lado 1: " + lado1 + "; lado 2: " + lado2 + "; sobra: " + sobra);
        //      Debug.Log("colunas: " + (lado1 + Mathf.Ceil(sobra/lado1)));
        float colunaExtra = Mathf.Ceil(sobra / ladoX);
        //        colunaExtra = colunaExtra / lado1;
        Debug.Log("LEVEL-MAPA LINHA: sobra/lado: " + colunaExtra);
        Debug.Log("LEVEL-MAPA LINHA: pontos x: " + (ladoX + colunaExtra));
        Debug.Log("LEVEL-MAPA LINHA: pontos z: " + (ladoZ));

        Collider terreno = terrain.GetComponent<TerrainCollider>();
        float lateralX = terreno.bounds.max.x - terreno.bounds.min.x;
        float lateralZ = terreno.bounds.max.z - terreno.bounds.min.z;
        float passoX = lateralX / (ladoX + colunaExtra + 1);
        float passoZ = lateralZ / (ladoZ + 1);

        Debug.Log("LEVEL-MAPA LINHA: lado x: " + lateralX + "passo x: " + passoX);
        Debug.Log("LEVEL-MAPA LINHA: lado z: " + lateralZ + "passo z: " + passoZ);

        float posX = passoX;
        float posZ = passoZ;
        int indexX = 1;
        int indexZ = 1;

        Vector3 tvector = new Vector3((indexX * passoX), 0f, (indexZ * passoZ));
        float tempY = Terrain.activeTerrain.SampleHeight(tvector);

        //        Vector3 novapos = new Vector3(x, tempY, z);

        //        GameObject predio = casa;
        for (int i = 0; i < predios.Count; i++)
        {
            Debug.Log("LEVEL-MAPA LINHA: index x: " + indexX + "; index z: " + indexZ);
            Vector3 posicao = new Vector3((indexX * passoX), tempY, (indexZ * passoZ));
            Debug.Log("LEVEL-MAPA LINHA: coordendas: " + posicao);
            //            Debug.Log("coordendas\n x: " + (indexX * passoX) + ", z: " + (indexZ * passoZ) + ", y: " + tempY);

            enderecos.Add(posicao);


            //            Instantiate(predios[i].tipoPredio, posicao, Quaternion.identity);

            indexX += 1;
            if (indexX > ladoX + colunaExtra)
            {
                indexX = 1;
                indexZ += 1;
                if (indexZ > ladoZ)
                {
                    indexZ = 1;
                }
            }

        }
        colocaPredios();


    }

    public void mapaCirculo()
    {
        //        enderecos = new Vector3[totalCasas + totalEscolas + totalTrabalhos];

        Debug.Log("LEVEL-MAPA CIRCULO: total de enderecos: " + predios.Count);

        int pontos = predios.Count;
        Debug.Log("LEVEL-MAPA CIRCULO: pontos: " + pontos);

        Collider terreno = terrain.GetComponent<TerrainCollider>();
        float lateralX = terreno.bounds.max.x - terreno.bounds.min.x;
        float lateralZ = terreno.bounds.max.z - terreno.bounds.min.z;

        float raio = lateralZ;
        if (lateralX < lateralZ)
        {
            raio = lateralX;
        }
        raio = (raio * .85f) / 2;

        float passoRad = 2 * Mathf.PI / pontos;

        Debug.Log("LEVEL-MAPA CIRCULO: passo(rad): " + passoRad);

        int index = 1;

        Vector3 tvector = new Vector3(0f, 0f, 0f);
        float tempY = Terrain.activeTerrain.SampleHeight(tvector);

        for (int i = 0; i < predios.Count; i++)
        {
            Debug.Log("LEVEL-MAPA CIRCULO: index x: " + index);
            float x = Mathf.Cos(passoRad * index) * raio + lateralX / 2;
            float z = Mathf.Sin(passoRad * index) * raio + lateralZ / 2;
            Vector3 posicao = new Vector3(x, tempY, z);
            Debug.Log("LEVEL-MAPA CIRCULO: coordendas: " + posicao);
            //            Debug.Log("LEVEL\MAPA CIRCULO: coordendas\n x: " + (indexX * passoX) + ", z: " + (indexZ * passoZ) + ", y: " + tempY);


            enderecos.Add(posicao);
            //            Instantiate(predios[i].tipoPredio, posicao, Quaternion.identity);

            index += 1;

        }
        colocaPredios();
    }

    public void mapaCruz()
    {
        //        enderecos = new Vector3[totalCasas + totalEscolas + totalTrabalhos];

        Debug.Log("LEVEL-MAPA CRUZ: total de enderecos: " + predios.Count);

        int ladoX = (int)Mathf.Ceil(predios.Count / 2);
        int ladoZ = predios.Count - ladoX;
        float sobra = 0;
        //        float sobra = predios.Count - (ladoX * ladoZ);

        //        Debug.Log("lado 1: " + lado1 + "; lado 2: " + lado2 + "; sobra: " + sobra);
        //      Debug.Log("colunas: " + (lado1 + Mathf.Ceil(sobra/lado1)));
        float colunaExtra = Mathf.Ceil(sobra / ladoX);
        //        colunaExtra = colunaExtra / lado1;
        Debug.Log("LEVEL-MAPA CRUZ: sobra/lado: " + colunaExtra);
        Debug.Log("LEVEL-MAPA CRUZ: pontos x: " + (ladoX + colunaExtra));
        Debug.Log("LEVEL-MAPA CRUZ: pontos z: " + (ladoZ));

        Collider terreno = terrain.GetComponent<TerrainCollider>();
        float lateralX = terreno.bounds.max.x - terreno.bounds.min.x;
        float lateralZ = terreno.bounds.max.z - terreno.bounds.min.z;
        float passoX = lateralX / (ladoX + colunaExtra + 1);
        float passoZ = lateralZ / (ladoZ + 1);

        Debug.Log("LEVEL-MAPA CRUZ: lado x: " + lateralX + "passo x: " + passoX);
        Debug.Log("LEVEL-MAPA CRUZ: lado z: " + lateralZ + "passo z: " + passoZ);

        //        float posX = passoX;
        //        float posZ = passoZ;
        float posX = passoX;
        float posZ = lateralZ / 2;
        int indexX = 1;
        int indexZ = 1;

        Vector3 tvector = new Vector3((indexX * passoX), 0f, (indexZ * passoZ));
        float tempY = Terrain.activeTerrain.SampleHeight(tvector);

        //        Vector3 novapos = new Vector3(x, tempY, z);

        //        GameObject predio = casa;


        for (int i = 0; i < predios.Count; i++)
        {
            //            Debug.Log("index x: " + indexX + "; index z: " + indexZ);
            //            Vector3 posicao = new Vector3((indexX * posX), tempY, (indexZ * posZ));
            //            Debug.Log("coordendas: " + posicao);
            //            Debug.Log("coordendas\n x: " + (indexX * passoX) + ", z: " + (indexZ * passoZ) + ", y: " + tempY);


            //           Instantiate(predios[i].tipoPredio, posicao, Quaternion.identity);

            if (i < ladoX)
            {
                Debug.Log("LEVEL-MAPA CRUZ: index x: " + indexX + "; index z: " + indexZ);
                Vector3 posicao = new Vector3((indexX * posX), tempY, (indexZ * posZ));
                enderecos.Add(posicao);
                //                Instantiate(predios[i].tipoPredio, posicao, Quaternion.identity);
                indexX += 1;
            }
            else
            {
                indexX = 1;
                posX = lateralX / 2;
                posZ = passoZ;

                Debug.Log("LEVEL-MAPA CRUZ: index x: " + indexX + "; index z: " + indexZ);
                Vector3 posicao = new Vector3((indexX * posX), tempY, (indexZ * posZ));
                enderecos.Add(posicao);
                //                Instantiate(predios[i].tipoPredio, posicao, Quaternion.identity);
                indexZ += 1;
            }

        }
        colocaPredios();
    }


    void GenerateObjects (GameObject go, int amount)
    {


        if (go == null) return;
        col = terrain.GetComponent<TerrainCollider>();
     
        for (int i = 0; i < amount; i++)
        {
            Vector3 randPoint = getRandPoint();
            usedPoints.Add(randPoint);
            randPoint.y += go.transform.position.y;
            Instantiate(go,randPoint,Quaternion.identity);

        }
    }
    
    Vector3 getRandPoint()
    {
        //aki a nao sobreposicao ta precisa, o q permite q um obj entre dentro do outro. refazer de modo a nao criar mais obj dentro de outro

        float maiorpredio = 5f;
        float x = Random.Range(col.bounds.min.x + maiorpredio, col.bounds.max.x - maiorpredio);
        float z = Random.Range(col.bounds.min.z + maiorpredio, col.bounds.max.z - maiorpredio);

        Vector3 tvector = new Vector3(x, 0f, z);
        float tempY = Terrain.activeTerrain.SampleHeight(tvector);

        Vector3 novapos = new Vector3(x, tempY, z);

        //CHECAR COMO SELECIONAR PONTO NAO REPETIDO FORA DE AREA JA OCUPADA POR OUTRO OBJETO. TVZ BOUNDS SEJA UMA ESTRATEGIA
        if (usedPoints.Contains(novapos)) getRandPoint();
//      foreach (GameObject limites in trabalhos)
//       {
//           if (limites.Collider.Contains(novapos)) getRandPoint();
//                Destroy(limites);
//       }

        return tvector;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////verificar a sequencia de geracao das coisas. ex: lista de predios, lista de pessoas, atribuir enderecos, instanciar
    /////////////////////////////////////////////// e a relacao disso com os botoes
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////mudar os processos de ir de um lado pra outro na classe PESSSOA pra ficar compativel com o nome sistema de enderecos



    public void colocaPessoas()
    {
        /*
        List<Predios> asCasas = new List<Predios>();
        asCasas.AddRange(predios.FindAll((x) => x.nomePredio.Contains("casa")));                   // tentando fazer sublist de list. .ADDRANGE resolveu a questao
        string tempcasa = "";
        foreach (Predios z in asCasas)
        {
            tempcasa += " " + z.nomePredio;
        }*/
        //        Debug.Log("LEVEL-ATRIBUI PESSOAS:nome das casas: " + tempcasa);

        /*
        List<Predios> osTrabalhos = new List<Predios>();
        osTrabalhos.AddRange(predios.FindAll((x) => x.nomePredio.Contains("trabalho")));                   // tentando fazer sublist de list. .ADDRANGE resolveu a questao
        string temptrab = "";
        foreach (Predios z in osTrabalhos)
        {
            temptrab += " " + z.nomePredio;
        }*/

        //        Debug.Log("LEVEL-ATRIBUI PESSOAS:nome dos trampos: " + temptrab);

        //        for (int i = 0; i < todasAsPessoas.Count; i++)
        //        {
        //            todasAsPessoas[i].minhaCasa = asCasas[(int)Mathf.PingPong(i, asCasas.Count-1)];
        //            todasAsPessoas[i].meuTrabalho = osTrabalhos[(int)Mathf.PingPong(i, osTrabalhos.Count-1)];
        //          Debug.Log("LEVEL-ATRIBUI PESSOAS: pessoa " + todasAsPessoas[i].identidade + " mora na casa " +todasAsPessoas[i].minhaCasa.nomePredio + "e trabalha no "+ todasAsPessoas[i].meuTrabalho.nomePredio);
        //            Debug.Log("endereco casa " + todasAsPessoas[i].minhaCasa.);
        //        }

        Debug.Log("LEVEL-ATRIBUI PESSOAS: so perguntando total de gente: " + todasAsPessoas.Count);

//        Debug.Log("LEVEL-ATRIBUI PESSOAS: so perguntando casa" + todasAsPessoas[1].identidade + " endereco" + todasAsPessoas[1].minhaCasa.enderecoXYZ);
//        Debug.Log("LEVEL-ATRIBUI PESSOAS: so perguntando nome " + todasAsPessoas[1].identidade + " endereco" + todasAsPessoas[1].minhaCasa.predioPreFab.transform.position);

        foreach(cPessoa tp in todasAsPessoas)
        {
            Debug.Log("LEVEL-ATRIBUI PESSOAS: so perguntando nome " + tp.identidade + " endereco"+tp.minhaCasa.nomePredio+ " " +tp.minhaCasa.enderecoXYZ + "trabalho: "+ tp.meuTrabalho.enderecoXYZ);
      
            Instantiate(tp.tipoPessoa, tp.minhaCasa.enderecoXYZ, Quaternion.identity);
        }
    }
}