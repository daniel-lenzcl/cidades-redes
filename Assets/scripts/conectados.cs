using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class conectados : MonoBehaviour
{

    //The list of colliders currently inside the trigger
    List<GameObject> encontro;
    public LineRenderer linhasRede;
    Vector3 pos0;
    Vector3 pos1;
    private List<Vector3> pontosLinha = new List<Vector3>();
    private Vector3 posContato;

    public List<cContatos> quemEncontrei = new List<cContatos>();
    public cContatos testando;
    public string quemVi = " ";
//    public List<string> quemVi = new List<string>();

    void Start()
    {
        encontro = this.GetComponent<pessoa>().contatos;
        encontro.Clear();
        //        linhasRede = this.GetComponent<pessoa>().linhaContato;
        //        pos0 = this.transform.position;
        //        linhasRede = GetComponent<LineRenderer>();
        linhasRede.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        linhasRede.SetColors(Color.blue, Color.blue);
        linhasRede.SetWidth ( 0.3f, 0.3f);


        quemEncontrei.Clear();

    }

    void Update()
    {

        //---------BLOCO DE DEBUG PARA DISCRIMINACAO DOS CONTATOS
        //string result = "rede contatos: ";
        //foreach (var item in encontro)
        //{
        //    result += item.ToString() + ", ";
        //}
        //        Debug.Log(result);
        //------------------------------------------------------

        //--------------------------------------------------
        //incluir rotina para decair o valor dos encontros
        //----------------------------------------------------

        /*
        if (quemEncontrei.Count > 0)
        {
            pontosLinha.Clear();
            string r = "rede: ";

            foreach (cContatos pessoaContato in quemEncontrei)
            {
                posContato = pessoaContato.contato.transform.position;
                //Debug.Log("pt: " + posContato.ToString());
                //if (!pontosLinha.Contains(posContato))
                //      {
                //                        Debug.Log("entrou no pontosLinha: " + posContato);
                pontosLinha.Add(posContato);
                pontosLinha.Add(this.transform.position);
                r += posContato.ToString() + ", ";
                //    }
            }
            //            Debug.Log("total encontros " + encontro.Count + " total pontos linha " + pontosLinha.Count);
            //     Debug.Log(r);
            //    Debug.Log("pontos: " + pontosLinha.ToString());

            linhasRede.SetPositions(pontosLinha.ToArray());
        }
        */


        //----------------------------------------------------------
        /*
        if (encontro.Count > 0)
        {
            pontosLinha.Clear();
            string r = "rede: ";

                foreach (GameObject contato in encontro)
                {
                posContato = contato.transform.position;
                //Debug.Log("pt: " + posContato.ToString());
                //if (!pontosLinha.Contains(posContato))
                //      {
                    //                        Debug.Log("entrou no pontosLinha: " + posContato);
                    pontosLinha.Add(posContato);
                    pontosLinha.Add(this.transform.position);
                    r += posContato.ToString() + ", ";
                //    }
                }
            //            Debug.Log("total encontros " + encontro.Count + " total pontos linha " + pontosLinha.Count);

            //     Debug.Log(r);
            //    Debug.Log("pontos: " + pontosLinha.ToString());


            //   TENTAR FAZER ISSO COM O FOREACH
            /*
             int total_contatos = encontro.Count -1;
            while (total_contatos > 0)
            {
//                Debug.Log("contatos: " + total_contatos);
                //VERIFICAR COMO ASSOCIAR A POSICAO Dos GameObject
                //LINERENDERER SO PODE SER 1 POR OBJETO. ENTAO VERIFICAR ONDE Q FICA CADA UM E COMO ORGANIZAR ISSO. SE DA PRA CRIAR POR VEZ. OU JA DEIXA CRIADO POR CADA PESSOA

                //                pontosLinha.Add(this.GetComponent<GameObject>().transform.position);
                Vector3 posContato = encontro[total_contatos].transform.position;
                pontosLinha.Add(posContato);

                total_contatos--;
            }
            *//*
            linhasRede.SetPositions(pontosLinha.ToArray());

        }
        */
        //----------------------------------------------------------------

    }
    public void dizEncontros()
    {
        if(quemVi == " ")
        {
            Debug.Log("CONECTADOS-DIZ_ENCONTROS: eu, "+this.GetComponent<pessoa>().identidadepessoa + ", nao vi ninguem");
            return;
        }
        Debug.Log("CONECTADOS-DIZ_ENCONTROS: eu, " + this.GetComponent<pessoa>().identidadepessoa + ", vi " + quemVi);
//        Debug.Log("dizEncontros: eu, " + this.GetComponent<pessoa>().identidadepessoa + ", encontrei " + quemEncontrei.Count + "pessoas");
    }


    private void OnTriggerExit(Collider other)
    {

//        if (!other.CompareTag("pessoas"))
//        {
//            Debug.Log("CONECTADOS: esbarrei em uma nao pessoa: " + other.name);
//            return;
//        }
        //--------tava dando erro por COLIDIR com objetos q nao fossem pessoa, resolvido ao checar pela tag se eh pessoa ou nao.
        /////////////////////////////////////////----------PREPARAR A ROTINA DE COMPARACAO E ADICAO A PARTIR DOS cCONTATOS--------------------------------------------

        bool tp = false;
        cContatos tempcont = new cContatos(other.gameObject, Time.time);
        //////////////////////////////////verificar como fazer o registro do tempo. o q se quer eh q os encontros mais frequentes tenham valores mais altos.
        

        //Debug.Log("CONECTADOS: eu, "+ this.GetComponent<pessoa>().identidadepessoa + ", ja encontrei " + quemEncontrei.Count + "pessoas");
 //       Debug.Log("CONECTADOS: esbarrei agora no " + tempcont.contato.GetComponent<pessoa>().identidadepessoa);
        string tempquemVi = tempcont.contato.GetComponent<pessoa>().identidadepessoa.ToString();
        //-----------------checar aki pq ta dando esse nessa linha de cima. as vezes da erro, as vezes nao-> erro pq era crianca, e portanto, nao tinha identidade e etc---------

        if (quemEncontrei.Count == 0)
        {
            quemEncontrei.Add(tempcont);
            quemVi += tempquemVi + " ";
        
            //Debug.Log("CONECTADOS: " + tempquemVi + " foi meu 1o encontro");
            //Debug.Log("CONECTADOS: ja vi os seguinte: " + quemVi);
            return;
        }

        foreach (cContatos c in quemEncontrei)
        {
            bool testepertenca = (c.contato == other.gameObject);

        //    Debug.Log("CONECTADOS: eu, " + this.GetComponent<pessoa>().identidadepessoa + ", procurando se ja encontrei " + tempcont.contato.GetComponent<pessoa>().identidadepessoa);
        //    if (testepertenca)
        //    {Debug.Log("CONECTADOS: eu, " + this.GetComponent<pessoa>().identidadepessoa + ", ja encontrei o " + tempcont.contato.GetComponent<pessoa>().identidadepessoa);}
        //    else{Debug.Log("CONECTADOS: eu, " + this.GetComponent<pessoa>().identidadepessoa + ", NAO tinha encontrado o " + tempcont.contato.GetComponent<pessoa>().identidadepessoa);}

            tp = tp | testepertenca;
        }

        if (!tp)
        {

            quemEncontrei.Add(tempcont);
            quemVi += tempquemVi + " ";
            //        int comprimento = quemEncontrei.Count - 1;
            //        Debug.Log("quem encontrei " + quemEncontrei[comprimento].contato.GetComponent<pessoa>().identidadepessoa);
            //Debug.Log("CONECTADOS: eu, "+ this.GetComponent<pessoa>().identidadepessoa + ", acabei de encontrar o " + tempquemVi);
            //Debug.Log("CONECTADOS: ja vi os seguinte: " + quemVi);

        }

        /////////////////////////////////////////----------PREPARAR A ROTINA DE COMPARACAO E ADICAO A PARTIR DOS cCONTATOS--------------------------------------------

        //if the object is not already in the list
        //------------------TIRANDO A PARTE FEITA NO 'ENCONTRO' PRA JOGAR PRA CLASSE CONTATOS
        /*
        if (!encontro.Contains(other.gameObject))

        {
            //add the object to the list
            encontro.Add(other.gameObject);
            //         linhasRede.Add(new LineRenderer());
            //            Instantiate(this.GetComponent<pessoa>().linha);
        }
        Debug.Log("CONECTADOS: pessoa " + this.GetComponent<pessoa>().identidadepessoa + ",  total encontros " + encontro.Count + " total pontos linha " + pontosLinha.Count);
        */
    }
}