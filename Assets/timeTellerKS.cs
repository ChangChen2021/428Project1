using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class timeTellerKS : MonoBehaviour
{
    public GameObject timeTextObject;

    // Start is called before the first frame update
    void Start()
    {
    InvokeRepeating("UpdateTime", 0f, 10f);   
    }

   
    void UpdateTime()
    {
    timeTextObject.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("HH:mm")+" (CST)";
    }
}
