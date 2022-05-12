using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{name} i am hit by  {other.gameObject.name }");
        Destroy(gameObject);
    }
}
