using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AI;

public class pessoa : MonoBehaviour
{
    //public GameObject linha;
    private Vector3 casa;
    private Vector3 trabalho;
    private Vector3 escola;
    private NavMeshAgent jogador;
    public int velocidade;
    private Vector3 destino;
    private string dest;
    public List<GameObject> contatos = new List<GameObject>();
    private float tempo;
//    public List<LineRenderer> linhaContato = new List<LineRenderer>();



    // Start is called before the first frame update
    void Start()
    {
     //   contatos = new List<GameObject>();

        jogador = this.GetComponent<NavMeshAgent>();
        GameObject[] trabalhos = GameObject.FindGameObjectsWithTag("trabalho");

        casa = this.transform.position;
        int num_trab = Random.Range(0, trabalhos.Length);
        trabalho = trabalhos[num_trab].transform.position;

        destino = casa;
        jogador.SetDestination(destino);
        jogador.stoppingDistance = 2f;

        //        Debug.Log("casa: " + casa + "    trabalho (" + num_trab + "): " + trabalho);


    }


    // Update is called once per frame
    void Update()
    {

        tempo = GameObject.Find("Terrain").GetComponent<horas>().hora;
     //   Debug.Log("horas: " + tempo);

//        if (jogador.remainingDistance <= .5f)
//        {
            if (tempo == 2f) {
            destino = trabalho;
            jogador.stoppingDistance = 3f;
        }
        else if (tempo == 10f) { 
            destino = casa;
            jogador.stoppingDistance = 2f;
        }
        else if (tempo == 14f) { 
            destino = trabalho;
            jogador.stoppingDistance = 3f;
        }
        else if (tempo == 20f) { 
            destino = casa;
            jogador.stoppingDistance = 2f;
        }
        //       }
        jogador.SetDestination(destino);   //DESCOBRIR PQ O TERRENO E A NAVMESH TA SE MEXENDO JUNTO COM O JOGADOR -  terreno estava com funcao de agente tb (o q significa funcao de agente tb?)


        GameObject[] populacao = GameObject.FindGameObjectsWithTag("pessoas");
        foreach (GameObject p in populacao)
        {
            //  Debug.Log("contatos: " + contatos.Count);

            //       if (Vector3.Distance(p.transform.position, this.transform.position) < 2) 
            //      {
            //         contatos.Add(p);

            //            };
            //Debug.Log("pessoa qq" + contatos.Count);

            if (contatos.Count > 0)
            {

                for (int i =0; i >contatos.Count; i++)
                {
          //          linhaContato[i].SetPosition(0, this.transform.position);
          //          linhaContato[i].SetPosition(1, contatos[i].transform.position);
                    Debug.Log("contato # " + i);
                }
//                foreach (GameObject c in contatos)
 //               {

                    //TODA LINHA EH UM GAMEOBJECTO
                    //ELA PRECISA SER CRIADA JUNTO COM CADA CONTATO NO Q EH FEITO
                    //PROVAVELMENTE TEM UM SCRIPT PROPRIO DE ATUALIZACAO E MARCA AS 2 PONTAS
                    //ALGO TIPO INSTANTIATE DENTRO DO CONECTADOS

                    //fazer line renderer com cada C. verificar como atualizar, ele deve criar as novas linhas e elas ficam para sempre. 
                    //                    new Vector3[2] ponto(this.transform.position, c.transform.position);
                    //Vector3 [] ponto = new Vector3 (this.transform.position, c.transform.position);
                    //this.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
                    //this.GetComponent<LineRenderer>().SetPosition(1, other.transform.position);
                    //  linhaContato.SetPosition(0, this.transform.position);
                    // linhaContato.SetPosition(1, c.transform.position);
                   // Instantiate(linha);

                    // set the position
                                       // linhaContato[c].SetPosition(0, this.transform.position);
                                       //linhaContato[c].SetPosition(1, c.transform.position);


                    // Debug.DrawRay(this.transform.position, c.transform.position, Color.white);

                    //  Debug.Log("contatos: " + contatos.Count);

   //             }
                //            Debug.DrawRay(contact.point, contact.normal, Color.white);

            }
        }
  //      Debug.Log("contatos: " + contatos);


    }
}
