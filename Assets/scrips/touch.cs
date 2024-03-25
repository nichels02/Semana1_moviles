using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class touch : MonoBehaviour
{
    [SerializeField] GameObject Cubo;
    [SerializeField] Colicionador colision;
    bool OneTap = false;
    [SerializeField] bool DobleTap = false;
    [SerializeField] bool prees = false;
    [SerializeField] bool eliminar = false;
    [SerializeField] bool yaSePresiono = false;
    int objetosCreados = 0;
    [SerializeField] float time;
    [SerializeField] Vector2 posicion;
    List<GameObject> ListObjetosCreados = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if ((eliminar || DobleTap || prees) && time < 0.3f) 
        {
            time += Time.deltaTime;
            print("si");
        }
        else
        {
            print("no");
            DobleTap = false;
            prees = false;
            time = 0;
        }
        if(Input.touchCount > 0)
        {
            Touch ElTouch = Input.GetTouch(0);
            Vector2 vector = Camera.main.ScreenToWorldPoint(ElTouch.position);
            colision.transform.position = vector;
            colision.posibilidadDeColicion();
            if (!OneTap && colision.laPosibilidad == Colicionador.posiblidades.nada && time==0) 
            {
                eliminar = true;
                time = 0;
                posicion = vector;
            }
            else if (eliminar && math.distance(posicion,vector)>3 && time < 0.3f && colision.transform.childCount == 0)
            {
                eliminar= false;
                print("eliminar");
                for(int i = 0; i < ListObjetosCreados.Count; i++)
                {
                    Destroy(ListObjetosCreados[i]);
                }
                ListObjetosCreados.Clear();
            }
            if (!OneTap && DobleTap && time > 0.1f && time < 0.3f)
            {
                OneTap = true;
                DobleTap = false;
                //switch para diferenciar entre objetos
                switch (colision.laPosibilidad)
                {
                    case Colicionador.posiblidades.objeto:
                        {
                            colision.ObjetoGuardado.GetComponent<Formas>().DobleTap();
                        }
                    break;
                }
                
            }
            else if (prees && time > 0.1f && time < 0.3f)
            {
                OneTap = true;
                prees = false;
                yaSePresiono = true;
                //switch para diferenciar entre objetos
                switch (colision.laPosibilidad)
                {
                    case Colicionador.posiblidades.objeto:
                        {
                            colision.ObjetoGuardado.GetComponent<Formas>().Press(colision.gameObject);
                        }
                        break;
                }
            }
            else if (!OneTap && !DobleTap && !prees)
            {
                OneTap = true;
                DobleTap = true;
                prees = true;
                time = 0;
                //switch para diferenciar entre objetos
                switch (colision.laPosibilidad)
                {
                    case Colicionador.posiblidades.nada:
                        {
                            objetosCreados += 1;
                            GameObject gameObject = Instantiate(Cubo, vector, Quaternion.identity);
                            ListObjetosCreados.Add(gameObject);
                            gameObject.name = "objeto" + objetosCreados;
                        }
                        break;
                }
                
            }
        }
        else
        {
            if (yaSePresiono)
            {
                print("se solto");
                yaSePresiono = false;
                if (colision.transform.childCount > 0)
                {
                    Transform hijo = colision.transform.GetChild(0);
                    hijo.GetComponent<Formas>().NoPress();
                }
                
            }
            eliminar = false;
            OneTap = false;
            prees = false;
        }
        */
        /*
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
        */

    }






}
