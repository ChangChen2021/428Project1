using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class timeTeller : MonoBehaviour
{
    public GameObject timeTextObject;

    // Start is called before the first frame update
    void Start()
    {
    InvokeRepeating("UpdateTime", 0f, 10f);   
    }

   
    void UpdateTime()
    {
    DateTime original = System.DateTime.Now;
    DateTime updated = original.Add(new TimeSpan(7,0,0));   
    timeTextObject.GetComponent<TextMeshPro>().text = timeTextObject.GetComponent<TextMeshPro>().text = updated.ToString("h:mm ")+" (CET)";
    }
}
