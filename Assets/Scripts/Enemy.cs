using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 15;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // using this method so that we dont have to attach scoreborad script to the enemy,
                                                     // instead it will fetch that automatically
        
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }
     void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); //using this Instantiate method so that we can call the deathvfx at runtime
        vfx.transform.parent = parent;                                                              //rater than making it a part of enemy prefab
        Destroy(gameObject);
    }

    
}
