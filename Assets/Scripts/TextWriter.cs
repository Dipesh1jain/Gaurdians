using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    // Start is called before the first frame update
    private Text uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    public void addWriter(Text uiText,string textToWrite,float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;

    }
    private void Update()
    {
        if(uiText!= null)
        {
            timer -= Time.deltaTime;
            if(timer <=0f)
            {
                // display next character
                timer += timePerCharacter;
            }
        }
    }
}
