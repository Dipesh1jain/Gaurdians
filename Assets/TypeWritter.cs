using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWritter : MonoBehaviour
{
    // Start is called before the first frame update
    private Text messageText;
    private void Awake()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        messageText.supportRichText = true;

    }
    private void Start()
    {
        messageText.text = "Hello World";
      
    }
}
