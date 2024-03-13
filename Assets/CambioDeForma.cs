using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeForma : MonoBehaviour
{
    [SerializeField] SpriteRenderer ElPrefab;
    [SerializeField] Sprite[] lasFormas = new Sprite[3];

    private void Start()
    {
        ElPrefab.sprite = lasFormas[0];
        ElPrefab.color = Color.white;
    }

    public void Cuadrado()
    {
        ElPrefab.sprite = lasFormas[0];
    }
    public void Circulo()
    {
        ElPrefab.sprite = lasFormas[1];
    }
    public void triangulo()
    {
        ElPrefab.sprite = lasFormas[2];
    }
    public void red()
    {
        ElPrefab.color = Color.red;
    }
    public void green()
    {
        ElPrefab.color = Color.green;
    }
    public void blue()
    {
        ElPrefab.color = Color.blue;
    }
}
