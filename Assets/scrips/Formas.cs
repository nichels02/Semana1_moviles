using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formas : objeto
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void DobleTap()
    {
        Destroy(gameObject);
    }


    public override void Press(GameObject elPadre)
    {
        transform.parent = elPadre.transform;
    }

    public override void NoPress()
    {
        transform.parent = null;
    }

}
