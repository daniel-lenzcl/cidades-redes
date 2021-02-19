using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class conectados : MonoBehaviour
{

    //The list of colliders currently inside the trigger
    List<GameObject> encontro;
    List<LineRenderer> linhasRede;

    void Start()
    {
        encontro = this.GetComponent<pessoa>().contatos;
//        linhasRede = this.GetComponent<pessoa>().linhaContato;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("trigger: " + encontro.Count);

        //if the object is not already in the list
        if (!encontro.Contains(other.gameObject))

        {
            //add the object to the list
            encontro.Add(other.gameObject);
            //         linhasRede.Add(new LineRenderer());
            Instantiate(this.GetComponent<pessoa>().linha);
        }






    }
}