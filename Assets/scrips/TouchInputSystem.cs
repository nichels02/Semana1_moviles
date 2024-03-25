using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputSystem : MonoBehaviour
{
    [SerializeField] Colicionador ElColicionador;
    [SerializeField] GameObject ElObjeto;

    float time;
    bool prees;
    [SerializeField] bool dobleTap;
    bool tap;
    bool tap2;
    bool swipe;
    bool yaEntro;
    Vector2 posicion;
    List<GameObject> listaDeObjetos = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((prees || dobleTap || swipe) && time < 0.5f) 
        {
            time += Time.deltaTime;
        }
        else if ((prees || dobleTap || swipe) && time > 0.5f)
        {
            prees = false;
            dobleTap = false;
            swipe = false;
            time = 0;
            tap2 = false;
        }

        if(Input.touchCount == 0)
        {
            if (yaEntro)
            {
                yaEntro = false;
                Transform hijo = ElColicionador.transform.GetChild(0);
                hijo.GetComponent<Formas>().NoPress();
            }
            dobleTap=tap2? true:false;
            tap = false;
            prees = false;
            swipe = false;
        }
    }



    public void tapTouch(InputAction.CallbackContext value)
    {
        Vector2 ElTouch = value.ReadValue<Vector2>();
        //UnityEngine.Touch elTouch= value.ReadValue<UnityEngine.Touch>();
        ElColicionador.transform.position = Camera.main.ScreenToWorldPoint(ElTouch);
        ElColicionador.transform.position = new Vector3(ElColicionador.transform.position.x, ElColicionador.transform.position.y, 0);
        ElColicionador.posibilidadDeColicion();
        if (ElColicionador.laPosibilidadObjetos != Colicionador.posiblidades.nada)
        {
            switch (ElColicionador.laPosibilidadObjetos)
            {
                case Colicionador.posiblidades.objeto:
                    {
                        if (dobleTap && time < 0.5f)
                        {
                            print("doble Tap");
                            dobleTap = false;
                            tap2 = false;
                            ElColicionador.ObjetoGuardadoObjeto.GetComponent<Formas>().DobleTap();
                        }
                        else if(prees && time > 0.1f && time < 0.3f && !yaEntro)
                        {
                            prees = false;
                            yaEntro = true;
                            tap2 = false;
                            ElColicionador.ObjetoGuardadoObjeto.GetComponent<Formas>().Press(ElColicionador.gameObject);
                        }
                        else if (!tap2)
                        {
                            print("Antes del doble tap");
                            tap2 = true;
                            prees=true;
                        }

                    }
                    break;
            }
        }
        else if(ElColicionador.laPosibilidadFondo != Colicionador.posiblidades.nada)
        {
            switch (ElColicionador.laPosibilidadFondo)
            {
                case Colicionador.posiblidades.crear:
                    {
                        if (!swipe)
                        {
                            swipe = true;
                            time = 0;
                            posicion = ElColicionador.transform.position;
                            print("inicio Destruccion");
                        }
                        else if(Vector2.Distance(posicion, ElColicionador.transform.position) > 3
                            && swipe && time < 0.5f && !yaEntro) 
                        {
                            swipe = false;
                            time = 0;
                            for (int i = 0; i < listaDeObjetos.Count; i++)
                            {
                                Destroy(listaDeObjetos[i]);
                            }
                            listaDeObjetos.Clear();
                            print("destrucion");
                        }
                        if (!tap && !yaEntro)
                        {
                            tap = true;
                            GameObject ObjetoCreado = Instantiate(ElObjeto, 
                            ElColicionador.transform.position, Quaternion.identity);
                            listaDeObjetos.Add(ObjetoCreado);
                        }
                    }
                    break;
            }
        }

    }

}
