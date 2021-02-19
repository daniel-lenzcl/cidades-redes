using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class levelgenerator : MonoBehaviour
{

//    public GameObject pessoa;
//    public GameObject enemy;
    public GameObject casa;
    public GameObject escola;
    public GameObject trabalho;
    public GameObject terrain;
    public List<Predios> predios;


    private Collider col;

//    public int numberOfEnemies;
//    public int numberOfPessoas;
    public int numberOfCasas;
    public int numberOfEscolas;
    public int numberOfTrabalhos;

    private List<Vector3> usedPoints;

    // Start is called before the first frame update
    void Start()
    {
        //        GameObject tmp = Instantiate(enemy);
        //        tmp.transform.position = new Vector3(0.0f, tmp.transform.position.y, 0.0f);
        usedPoints = new List<Vector3>();
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {

        GameObject[] pessoas = GameObject.FindGameObjectsWithTag("pessoas");
        foreach (GameObject g in pessoas)
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

//        Vector3 endtemp = new Vector3(0, 0, 0);
//        predios.Add(new Predios(casa, endtemp, 4));
        //if predios[0].tipoPredio
//        Instantiate(predios[0].tipoPredio);

        //      GenerateObjects(pessoa, numberOfPessoas);
        GenerateObjects(escola, numberOfEscolas);
        GenerateObjects(trabalho, numberOfTrabalhos);
        GenerateObjects(casa, numberOfCasas);
        //        pessoa();
    }

    void GenerateObjects (GameObject go, int amount)
    {
        if (go == null) return;
        col = terrain.GetComponent<TerrainCollider>();
        //        if (go == "friend")
        //      {
        //         GameObjetc [] locais = GameObject.FindGameObjectsWithTag("te");
        //     }
        for (int i = 0; i < amount; i++)
        {
            Vector3 randPoint = getRandPoint();
            usedPoints.Add(randPoint);
            randPoint.y += go.transform.position.y;
//            GameObject temporario = new GameObject (objt);
 //           objt.transform.position = randPoint;
   //         casa.Add(objt);
            Instantiate(go,randPoint,Quaternion.identity);
//            go.transform.parent = this.transform;
            //   Debug.Log("altura terreno: " + tempY);

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
}
