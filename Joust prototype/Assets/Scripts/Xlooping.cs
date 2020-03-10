using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xlooping : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x <= -10)
        {
            transform.Translate(20, 0, 0);
        }
        if (this.gameObject.transform.position.x >= 10)
        {
            transform.Translate(-20, 0, 0);
        }
    }
}
