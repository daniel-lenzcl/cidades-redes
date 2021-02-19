using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Predios 
{
    public GameObject tipoPredio;
    public Vector3 enderecoXYZ;
    public int capacidadeGente;

    public Predios (GameObject tipo, Vector3 end, int totalGente)
    {
        this.tipoPredio = tipo;
        this.enderecoXYZ = end;
        capacidadeGente = totalGente;
    }
}
