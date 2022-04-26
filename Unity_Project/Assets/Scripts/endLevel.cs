using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel: MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "hero")
            Application.LoadLevel("Scene2");
    }

}
