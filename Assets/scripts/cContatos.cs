using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cContatos
{
    public GameObject contato;
    public float horacont;


    public cContatos()
    {
    }

    public cContatos(GameObject quem, float time)
    {
        this.contato = quem;
        this.horacont = time;
    }
}


