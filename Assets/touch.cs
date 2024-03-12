using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    [SerializeField] GameObject Cubo;
    [SerializeField] Colicionador colision;
    bool OneTap = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && OneTap == false)
        {
            OneTap = true;
            Touch ElTouch = Input.GetTouch(0);
            Vector2 vector=Camera.main.ScreenToWorldPoint(ElTouch.position);
            colision.transform.position = vector;
            switch (colision.laPosibilidad)
            {
                case Colicionador.posiblidades.crear:
                    {
                        Instantiate(Cubo, vector, Quaternion.identity);
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
            OneTap = false;
        }


    }






}
