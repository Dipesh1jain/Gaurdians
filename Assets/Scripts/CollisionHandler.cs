using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + " --collided with--" + other.gameObject.name);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} **Triggered by {other.name}"); // string interpolation method to print a messeage if concatination is need ,
                                                               // methodname within '{}' start with dollar sign
    }
}
