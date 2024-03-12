using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colicionador : MonoBehaviour
{
    public enum posiblidades
    {
        crear,
        nada
    }
    posiblidades LaPosibilidad = posiblidades.nada;
    public posiblidades laPosibilidad
    {
        get { return LaPosibilidad; }
    }
    // Start is called before the first frame update
    

    public void posibilidadDeColicion()
    {
        if(Physics.BoxCast(new Vector2(-0.5f+transform.position.x,-0.5f + transform.position.y), transform.localScale, ))
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            switch (collision.transform.tag)
            {
                case "Crear":
                    {
                        LaPosibilidad = posiblidades.crear;
                        print("1");
                    }
                    break;
                default:
                    {
                        LaPosibilidad = posiblidades.nada;
                        print("2");
                    }
                    break;
            }
        }
        else
        {
            LaPosibilidad = posiblidades.nada;
            print ("0");
        }
    }
    
}
