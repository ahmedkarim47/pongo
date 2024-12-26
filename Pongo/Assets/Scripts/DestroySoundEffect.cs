using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoundEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameobject gets destroyed after 1 second
        Destroy(gameObject, 1);
    }
}
