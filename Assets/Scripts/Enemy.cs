using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    
    GameObject parentGameObject;
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // using this method so that we dont have to attach scoreborad script to the enemy,
                                                     // instead it will fetch that automatically
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");// using this , so that we can add all the hitvfx clone inside this automatically
        AddRigidBody();
    }

    void AddRigidBody() //  using this method so that we dont have to attach rigidbody to the enemy,
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();                                             
        rb.useGravity = false; // using this so everytime when we add rigidbody we make sure that gravity is turned off
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints<1)
        {
            KillEnemy();
        }
     
    }
     void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity); //using this Instantiate method so that we can call the deathvfx at runtime
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); //using this Instantiate method so that we can call the deathvfx at runtime
        vfx.transform.parent = parentGameObject.transform;                                                              //rater than making it a part of enemy prefab
        
            Destroy(gameObject);
        
    }

    
}
