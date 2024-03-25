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
    [SerializeField] Vector2 DireccionRaycast;
    [SerializeField] float distancia;
    [SerializeField] LayerMask layerFondo;
    [SerializeField] LayerMask layerObjetos;
    posiblidades LaPosibilidadObjetos = posiblidades.nada;
    posiblidades LaPosibilidadFondo = posiblidades.nada;
    RaycastHit2D m_Hit_fondo;
    RaycastHit2D m_Hit_objetos;
    public GameObject ObjetoGuardadoFondo;
    public GameObject ObjetoGuardadoObjeto;
    public posiblidades laPosibilidadObjetos
    {
        get { return LaPosibilidadObjetos; }
    }
    public posiblidades laPosibilidadFondo
    {
        get { return LaPosibilidadFondo; }
    }


    private void Update()
    {
        Debug.DrawLine(transform.position, new Vector2(transform.position.x + DireccionRaycast.x, transform.position.y + DireccionRaycast.y), Color.red);
    }

    public void posibilidadDeColicion()
    {
        //(Physics.Raycast(startPos, transform.forward, out RaycastHit hit, raycastDistance))
        m_Hit_objetos = Physics2D.Raycast(transform.position, DireccionRaycast,distancia, layerObjetos);
        m_Hit_fondo = Physics2D.Raycast(transform.position, DireccionRaycast,distancia, layerFondo);
        if (m_Hit_objetos.collider != null)
        {
            ObjetoGuardadoObjeto = m_Hit_objetos.collider.gameObject;
            print("entro Objetos");
            switch (ObjetoGuardadoObjeto.transform.tag)
            {
                case "objeto":
                    {
                        LaPosibilidadObjetos = posiblidades.objeto;
                    }
                    break;
            }
        }
        else
        {
            LaPosibilidadObjetos = posiblidades.nada;
            print("0");
        }


        if (m_Hit_fondo.collider != null)
        {
            ObjetoGuardadoFondo = m_Hit_fondo.collider.gameObject;
            print("entro fondo");
            switch (ObjetoGuardadoFondo.transform.tag)
            {
                case "Crear":
                    {
                        LaPosibilidadFondo = posiblidades.crear;
                        //print("1");
                    }
                    break;
            }
        }
        else
        {
            LaPosibilidadFondo = posiblidades.nada;
            print("0");
        }

    }

    
}
