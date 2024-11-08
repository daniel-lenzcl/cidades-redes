using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class CarregarMapa : MonoBehaviour
{
    List<GameObject> CamadaCasa;
    List<GameObject> CamadaTrabalho;

    // Start is called before the first frame update
    void Start()
    {
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

        if (casas != null)
        {
            foreach (Transform t in casas)
            {
                t.name = "casa " + CamadaCasa.Count.ToString();
                t.gameObject.AddComponent<casa>();
                CamadaCasa.Add(t.GetComponent<GameObject>());
                Debug.Log(t.name + " transform - casa ");
            }
        }
        if (trabalhos != null)
        {
            foreach (Transform t in trabalhos)
            {
                t.transform.gameObject.name = "trabalho " + CamadaTrabalho.Count.ToString();
                CamadaTrabalho.Add(t.transform.gameObject);
                Debug.Log(t.transform.name + " transform - trabalho" );
            }
        }
        Debug.Log("casas adquiridas: " + CamadaCasa.Count + "; trabalhos adquiridos: " + CamadaTrabalho.Count);
    }
}
