using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casa : MonoBehaviour
{

    public GameObject pessoa;
    public int numberOfPessoas;
    public GameObject crianca;
    public int numberOfCriancas;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 endereco = this.transform.position;
        int pnc = (int) Random.Range(1, numberOfPessoas+1);
 //       Debug.Log("pessoas na casa: " + pnc);
//        Debug.Log("endereco: " + endereco);

        for (int i = 0; i < pnc; i++)
        {
            pessoa.transform.position = new Vector3(endereco.x, pessoa.transform.position.y, endereco.z);
//            pessoa.transform.position.y = endereco.y;

            Instantiate(pessoa);
            //            Debug.Log("repos pessoa"+ i + " "+ pessoa.transform.position);
           // pessoa.transform.parent = this.transform;
        }

        if (pnc == 2) 
        {
            pnc = (int)Random.Range(0, numberOfCriancas+1);

            for (int i = 0; i < pnc; i++)
            {
                crianca.transform.position = new Vector3(endereco.x, crianca.transform.position.y, endereco.z);
                Instantiate(crianca);
            }

        }
//        crianca.transform.position = endereco;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
