
using System;
using UnityEngine;
using UnityEngine.UI;

public class horas : MonoBehaviour
{
    //    public Transform mexerhoras, mexerminuto, mexersegundo;
    public Text as_hora;
    public float tempoSimulado = .05f;


    public float hora;
    public float min;
    //    float temposim = 0.5f;
    float temporizador = 0f;
    float tpassado = 0f;
    Texture tex;

    public bool rodadia = true;

    void Start()
    {
        hora = 0f;
        min = 0f;
        //        Debug.Log(DateTime.Now);
        //   Debug.Log(" vamo ver");
        //       Debug.Log(DateTime.Now);
        tpassado = Time.deltaTime;
        Debug.Log("HORAS - START: inicializado RODA DIA = " +rodadia);

    }

    void Update()
    {
        //   rodadia = GameObject.Find("Canvas").GetComponent<botoes>().comecaDia;  -----------------> ESSE CONTROLE VEIO PRA UMA VARIAVEL DAKI


        //        temporizador += Time.deltaTime * boolToFloat(rodadia);
//        Debug.Log("HORAS - UPDATE: roda dia: " + rodadia);

        if (rodadia)
              {
                  temporizador += Time.deltaTime;
            //Debug.Log("roda dia: " + rodadia);
            //        Debug.Log("intervalo " + tempoSimulado);
            //        Debug.Log("temporizador " + temporizador);
            //        Debug.Log("tempo passado " + (temporizador - tpassado));

            if (tempoSimulado < temporizador)
            {
                //            float tpassado = Time.deltaTime - temporizador;
                //           Debug.Log("tempo passado " + tpassado);
                //           Debug.Log("tempo andou");
                temporizador = Time.deltaTime;
                min++;
                if (min > 59f)
                {
                    min = 0f;
                    hora++;
                    if (hora > 23f) { hora = 0f; }
                }
            }
            /*
                    mexerhoras.localRotation = Quaternion.Euler(0f, DateTime.Now.Hour * angulohora, 0f);
                    mexerminuto.localRotation = Quaternion.Euler(0f, DateTime.Now.Minute * angulomin, 0f);
                    mexersegundo.localRotation = Quaternion.Euler(0f, DateTime.Now.Second * anguloseg, 0f);
            */
            //        mexerhoras.localRotation = Quaternion.Euler(0f, hora * angulohora, 0f);
            //        mexerminuto.localRotation = Quaternion.Euler(0f, min * angulomin, 0f);
            //        mexersegundo.localRotation = Quaternion.Euler(0f, DateTime.Now.Second * anguloseg, 0f);
            //        as_hora.text = hora.ToString() + "h" + min.ToString();

        }

        as_hora.text = ("  " + hora + "h" + min);


    }

/*
    public void Sair()
    {
        Application.Quit();
    }
*/

    /*
    void OnGUI()
    {
        GUILayout.Label(tex);
        GUILayout.Label(tex);
        GUILayout.Label("  " + hora + "h" + min);
    }
*/
}