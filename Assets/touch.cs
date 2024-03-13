using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    [SerializeField] GameObject Cubo;
    [SerializeField] Colicionador colision;
    bool OneTap = false;
    [SerializeField] bool DobleTap = false;
    [SerializeField] bool prees = false;
    [SerializeField] bool yaSePresiono = false;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0 && DobleTap && time < 0.5)  
        {
            time += Time.deltaTime;
        }
        else if(time > 0.5)
        {
            DobleTap = false;
        }
        if (Input.touchCount > 0)
        {
            Touch ElTouch = Input.GetTouch(0);
            Vector2 vector=Camera.main.ScreenToWorldPoint(ElTouch.position);
            colision.transform.position = vector;
            colision.posibilidadDeColicion();
            switch (colision.laPosibilidad)
            {
                case Colicionador.posiblidades.crear:
                    {
                        if (OneTap == false)
                        {
                            Instantiate(Cubo, vector, Quaternion.identity);
                            OneTap = true;
                        }
                    }
                    break;
                case Colicionador.posiblidades.objeto:
                    {
                        if (!DobleTap && !prees)
                        {
                            OneTap = true;
                            prees = true;
                            time = 0;
                        }
                        else if(DobleTap&& time < 0.5)
                        {
                            colision.ObjetoGuardado.GetComponent<objeto>().DobleTap();
                            DobleTap=false;
                        }
                        else if (OneTap && prees) 
                        {
                            time += Time.deltaTime;
                            if (time < 0.5)
                            {
                                yaSePresiono = true;
                                colision.ObjetoGuardado.GetComponent<objeto>().Press(colision.gameObject);
                                OneTap = false;
                                prees=false;
                            }
                        }
                    }
                    break;
                case Colicionador.posiblidades.nada:
                    {

                    }
                    break;
            }
        }
        else if (Input.touchCount == 0 &&  OneTap == true)
        {
            if (yaSePresiono)
            {
                Transform hijo=colision.transform.GetChild(0);
                hijo.transform.parent = null;
                yaSePresiono = false;
            }
            prees = false;
            DobleTap = true;
            OneTap = false;
        }


    }






}
