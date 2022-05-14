using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem ExplosionVFX;
    [SerializeField] GameObject[] fighterParts;
   
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} **Triggered by {other.name}"); // string interpolation method to print a messeage if concatination is need ,
                                                               // methodname within '{}' start with dollar sign
       
        StartCrashSequence();
    }

     void StartCrashSequence()
    {
        
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
        ExplosionVFX.Play();
        TurnOffParts();
        
    }
    void TurnOffParts()

    {

        int i = 0;

        for (i = 0; i < fighterParts.Length; ++i)

        {

            fighterParts[i].GetComponent<MeshRenderer>().enabled = false;

        }

    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
