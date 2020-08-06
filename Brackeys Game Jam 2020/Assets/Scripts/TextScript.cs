﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text introText;
    public string contentText;
    private float letterPause = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        string writeThis = contentText;
        StartCoroutine(TypeSentence(writeThis));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        string[] array = sentence.Split(' ');
        introText.text = array[0];
        for (int i = 1; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause);
            introText.text += " " + array[i];
        }
    }
}
