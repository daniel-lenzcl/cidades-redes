using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mapas : MonoBehaviour
{

    public string tipoMapa;
    public string tipoDist;
    public GameObject geral;

    // Start is called before the first frame update
    void Start()
    {
//        Debug.Log("MAPAS - START: comeco");
        geral = GameObject.Find("Terrain");
        

        ///////////////////////////////////////////////////INICIALIZAR DROPDOWN DE TIPOS DE MAPA/////////////////////////////
        List<string> tiposMapas = new List<string>() 
        {
            "aleatorio", 
            "matriz",
            "cruz",
            "linha",
            "circulo"
        };
        var drpMapa = GameObject.Find("DdMAPA").GetComponent<Dropdown>();
        drpMapa.options.Clear();
        foreach (var tipo in tiposMapas)
        {
            drpMapa.options.Add(new Dropdown.OptionData() { text = tipo });
//            Debug.Log("MAPAS - START: opcoes dos tipos");
        }
        tipoMapa = tiposMapas[0];
        ///////////////////////////////////////////////////FIM INICIALIZAR DROPDOWN DE TIPOS DE MAPA/////////////////////////////

        ///////////////////////////////////////////////////INICIALIZAR DROPDOWN DE TIPOS DE DISTRIBUICAO/////////////////////////////
        List<string> tiposDistribuicoes = new List<string>()
        {
            "continuo",
            "setorizado",
            "aleatorio",
        };
        var drpDistribuicao = GameObject.Find("DdDISTRIBUICAO").GetComponent<Dropdown>();
        drpDistribuicao.options.Clear();
        foreach (var tipo in tiposDistribuicoes)
        {
            drpDistribuicao.options.Add(new Dropdown.OptionData() { text = tipo });
//            Debug.Log("MAPAS - START: opcoes das distribuicoes");
        }
        geral.GetComponent<levelgenerator>().tipoDistribuicao = tiposDistribuicoes[0];

        ///////////////////////////////////////////////////FIM INICIALIZAR DROPDOWN DE TIPOS DE DISTRIBUICAO/////////////////////////////

//        Debug.Log("MAPAS - START: final");
    }

    public void selecionaMapa(Dropdown dropMapa)
    {
//        GameObject.Find("Terrain").GetComponent<levelgenerator>().iniciaMapa();
        tipoMapa = dropMapa.options[dropMapa.value].text;
        Debug.Log("MAPAS-TIPO MAPA: o tipo eh:" + tipoMapa);
    }

    public void selecionaDistribuicao(Dropdown dropDistribuicao)
    {
        geral.GetComponent<levelgenerator>().tipoDistribuicao = dropDistribuicao.options[dropDistribuicao.value].text;
        //string td
        Debug.Log("LEVEL-DISTRIBUICAO ATIVIDADES: distribuicao eh:" +geral.GetComponent<levelgenerator>().tipoDistribuicao);
    }

    public void botaoMapa()
    {
        Debug.Log("MAPAS - BOTAO MAPA ->comeco: contagem de predios: " + geral.GetComponent<levelgenerator>().predios.Count);
//        GameObject.Find("Terrain").GetComponent<levelgenerator>().iniciaMapa();
        //        GameObject.Find("Terrain").GetComponent<levelgenerator>().mapaCruz();
        //        GameObject.Find("Terrain").GetComponent<levelgenerator>().atribuiPessoas();
//        "aleatorio", 
//            "matriz",
//            "cruz",
//            "linha",
//            "circulo"

        switch (tipoMapa)
        {
            case "aleatorio":
                Debug.Log("MAPAS - BOTAOMAPA: aleatorio");
                geral.GetComponent<levelgenerator>().mapaAleatorio();
//                geral.levelgenerator.mapaAleatorio();
//                mapaAleatorio();
                break;
            case "matriz":
                Debug.Log("MAPAS - BOTAOMAPA: matriz");
                geral.GetComponent<levelgenerator>().mapaMatriz();
                //                mapaMatriz();
                break;
            case "cruz":
                Debug.Log("MAPAS - BOTAOMAPA: cruz");
                geral.GetComponent<levelgenerator>().mapaCruz();

                //              mapaCruz();
                break;
            case "linha":
                Debug.Log("MAPAS - BOTAOMAPA: linha");
                geral.GetComponent<levelgenerator>().mapaLinha();

                //            mapaLinha();
                break;
            case "circulo":
                Debug.Log("MAPAS - BOTAOMAPA: circulo");
                geral.GetComponent<levelgenerator>().mapaCirculo();
                //          mapaCirculo();
                break;
        }
        Debug.Log("MAPAS - BOTAO MAPA ->final: contagem de predios: " + geral.GetComponent<levelgenerator>().predios.Count);
        geral.GetComponent<levelgenerator>().colocaPessoas();

    }



}
