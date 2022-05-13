using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void OnParticleCollision(GameObject other)
    {

       GameObject vfx= Instantiate(deathVFX, transform.position, Quaternion.identity); //using this Instantiate method so that we can call the deathvfx at runtime
        vfx.transform.parent = parent;                                                              //rater than making it a part of enemy prefab
        Destroy(gameObject);
    }
}
