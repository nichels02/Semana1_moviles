using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Colicionador : MonoBehaviour
{
    public enum posiblidades
    {
        crear,
        nada,
        objeto
    }
    [SerializeField] Vector2 distanciaRaycast;
    posiblidades LaPosibilidad = posiblidades.nada;
    RaycastHit2D m_Hit;
    public GameObject ObjetoGuardado;
    public posiblidades laPosibilidad
    {
        get { return LaPosibilidad; }
    }



    private void Update()
    {
        Debug.DrawLine(transform.position, new Vector2(transform.position.x + distanciaRaycast.x, transform.position.y + distanciaRaycast.y), Color.red);
    }

    public void posibilidadDeColicion()
    {
        //(Physics.Raycast(startPos, transform.forward, out RaycastHit hit, raycastDistance))
        m_Hit = Physics2D.Raycast(transform.position, new Vector2(transform.position.x + distanciaRaycast.x, transform.position.y + distanciaRaycast.y));
        if (m_Hit.collider != null) 
        {
            ObjetoGuardado = m_Hit.collider.gameObject;
            print("entro");
            switch (m_Hit.transform.tag)
            {
                case "Crear":
                    {
                        LaPosibilidad = posiblidades.crear;
                        print("1");
                    }
                    break;
                case "objeto":
                    {
                        LaPosibilidad = posiblidades.objeto;
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
            print("0");
        }

    }

    
}
