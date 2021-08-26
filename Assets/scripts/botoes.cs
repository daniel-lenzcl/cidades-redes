using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botoes : MonoBehaviour
{
    public Text BotaoDia;
    public bool comecaDia = false;

    // Start is called before the first frame update
    void Start()
    {
//        comecaDia = GameObject.Find("Terrain").GetComponent<horas>().rodadia;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void botaDia()
    {
        //    comecaDia = !comecaDia;
        //    GameObject.Find("Terrain").GetComponent<horas>().rodadia = comecaDia;
        //    if (comecaDia)
        GameObject.Find("Terrain").GetComponent<horas>().rodadia = !GameObject.Find("Terrain").GetComponent<horas>().rodadia;
        if (GameObject.Find("Terrain").GetComponent<horas>().rodadia)
        {
            BotaoDia.text = "dia rolando";
        } else
        {
            BotaoDia.text = "começar dia";
        }
    }

    public void botaoSair()
    {
        Application.Quit();
    }

    public void botaoMapaAleatorio()
    {
        GameObject.Find("Terrain").GetComponent<levelgenerator>().iniciaMapa();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().mapaAleatorio();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().colocaPessoas();
    }

    public void botaoMapaMatriz()
    {
        GameObject.Find("Terrain").GetComponent<levelgenerator>().iniciaMapa();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().mapaMatriz();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().colocaPessoas();

    }

    public void botaoMapaLinha()
    {
        GameObject.Find("Terrain").GetComponent<levelgenerator>().iniciaMapa();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().mapaLinha();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().colocaPessoas();
    }

    public void botaoMapaCirculo()
    {
        GameObject.Find("Terrain").GetComponent<levelgenerator>().iniciaMapa();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().mapaCirculo();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().colocaPessoas();
    }

    public void botaoMapaCruz()
    {
        GameObject.Find("Terrain").GetComponent<levelgenerator>().iniciaMapa();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().mapaCruz();
        GameObject.Find("Terrain").GetComponent<levelgenerator>().colocaPessoas();
    }

    public void botaoListaRede()
    {
        //------------COMO PEGAR OS CONTATOS TODOS? ONDE Q FICA ISSO? COMO LISTA NA CLASSE "CONECTATOS, CONTATOS"? OU PEGO PELOS PREFABS?
        GameObject[] individuos = GameObject.FindGameObjectsWithTag("pessoas");
        Debug.Log("BOTOES-BOTAO LISTA REDE: total de pessoas: " + individuos.Length);

        if (individuos == null)
        {
            Debug.Log("BOTOES-BOTAO LISTA REDE: nenhuma pessoa");
            return;
        }

        foreach (GameObject i in individuos)
        {
            i.GetComponent<conectados>().dizEncontros();
        }


        GameObject.Find("Terrain").GetComponent<populacao>().matrizEncontros();
        GameObject.Find("Terrain").GetComponent<populacao>().salvaMatriz();


    }
}
