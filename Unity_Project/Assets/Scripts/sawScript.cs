using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawScript : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//	int i = GetRandom();
                transform.Rotate (new Vector3(0f,0f,Random.Range(-1f, -2f)));
    }
}
