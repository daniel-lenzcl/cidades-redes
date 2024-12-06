using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class CarregarMapa : MonoBehaviour
{
    List<GameObject> CamadaCasa;
    List<GameObject> CamadaTrabalho;
    public GameObject terrain;

    // Start is called before the first frame update
    void Start()
    {
        terrain = GameObject.Find("Terrain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void captura()
    {
        CamadaCasa = new List<GameObject>();
        CamadaTrabalho = new List<GameObject>();

        GameObject camada = GameObject.Find("novoteste");
        Debug.Log("nome camada: " + camada.name);

        Transform trabalhos = camada.transform.Find("trabalho");
        Transform casas = camada.transform.Find("casa");

        //        GameObject[] cs = GameObject.Find("casa");

        //Debug.Log("total de cs: " + cs.Length);
        //foreach (GameObject c in cs)
        //{
        //    Debug.Log("nome da parada: " + c.name + "; posicao: " + c.transform.position);
        //    //            Instantiate(geral.GetComponent<levelgenerator>().casa, c.transform.position, Quaternion.identity);
        //    //            Debug.Log("LEVEL-COLOCA PREDIOS: nome predio: "+ p.nomePredio + "endereco " + p.enderecoXYZ);
        //}

        GameObject geral = GameObject.Find("Terrain");

        GameObject cs = GameObject.Find("casa");
        //Renderer rendererPai = cs.transform.GetComponent<Renderer>();
        //Vector3 sizePai = rendererPai.bounds.size;
        //float widthPai = sizePai.x;
        //float heightPai = sizePai.y;
        //Debug.Log("Dimensões da layer casa: largura = " + widthPai + ", altura = " + heightPai);

        float scaleFactor = 1;

        Bounds limites_mapa_importado = new Bounds(Vector3.zero, Vector3.zero);
        bool limitesInitialized = false;

        int filhos_c = cs.transform.childCount;
        for (int i = 0; i < filhos_c; i++)
        {
            Transform child = cs.transform.GetChild(i);
            Renderer renderer = child.GetComponent<Renderer>();

            child.name = "casa " + i;
            CamadaCasa.Add(child.GetComponent<GameObject>());
            Debug.Log("nome da parada: " + child.name + "; posicao: " + child.transform.position);

            if (renderer != null)
            {
                //obter a medida x e y do objeto cs 
                Vector3 size = renderer.bounds.size;
                float width = size.x;
                float height = size.y;
                Debug.Log("Dimensões da casa " + i + ": largura = " + width + ", altura = " + height);
                scaleFactor = 2 / width;

                //encapsula os limites do mapa importado
                if (!limitesInitialized)
                {
                    limites_mapa_importado = renderer.bounds;
                    limitesInitialized = true;
                }
                else
                {
                    limites_mapa_importado.Encapsulate(renderer.bounds);
                }
            }
        }

        scaleFactor *= 10f;
        Vector3 centro = terrain.GetComponent<Terrain>().terrainData.bounds.center;

        cs.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

        Debug.Log("posicao central do mapa: " + terrain.GetComponent<Terrain>().terrainData.bounds.center);
        cs.transform.position = centro;

        Debug.Log("posicao do mapa importado: " + cs.transform.position + 
                    "; limites do mapa importado: " + limites_mapa_importado.size + 
                    "; centro do mapa importado: " + limites_mapa_importado.center);
        Debug.Log("posicao do mapa: " + terrain.transform.position);

        for (int i = 0; i < cs.transform.childCount; i++)
        {
            Vector3 offset_altura = new Vector3(0, 0.5f, 0);
            Transform child = cs.transform.GetChild(i);
            Vector3 centro_child = child.GetComponent<Renderer>().bounds.center;
            //            Debug.Log("o q tem em camada casa [" + i + "]: " + CamadaCasa[i].name);
            Debug.Log("o child casa [" + i + "]: " + child.name +"; na posicao: " + centro_child);
            Instantiate(geral.GetComponent<levelgenerator>().casa, centro_child + offset_altura, Quaternion.identity);
//            Instantiate(geral.GetComponent<levelgenerator>().casa, CamadaCasa[i].GetComponent<Renderer>().bounds.center + offset_altura, Quaternion.identity);
        }

        GameObject ts = GameObject.Find("trabalho");
        int filhos_t = ts.transform.childCount;
        for (int i = 0; i < filhos_t; i++)
        {
            ts.transform.GetChild(i).name = "casa " + i;
            CamadaCasa.Add(ts.transform.GetChild(i).GetComponent<GameObject>());
//            Debug.Log("nome da parada: " + ts.transform.GetChild(i).name + "; posicao: " + ts.transform.GetChild(i).transform.position);
            Instantiate(geral.GetComponent<levelgenerator>().trabalho, ts.transform.GetChild(i).transform.position, Quaternion.identity);
        }

        Debug.Log("casas adquiridas: " + cs.transform.childCount + "; trabalhos adquiridos: " + ts.transform.childCount);


        //        maxPessoas = geral.GetComponent<levelgenerator>().maxPessoasI;


        //foreach (GameObject trabalho in CamadaTrabalho)
        //{
        //    Instantiate(geral.GetComponent<levelgenerator>().trabalho, trabalho.transform.position, Quaternion.identity);
        //    //            Debug.Log("LEVEL-COLOCA PREDIOS: nome predio: "+ p.nomePredio + "endereco " + p.enderecoXYZ);
        //}


    }

    public void ReposicionaMapaTerreno()
    {

    }
}
