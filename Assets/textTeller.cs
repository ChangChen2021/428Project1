﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class textTeller : MonoBehaviour
{
    public GameObject magic8TextObject;
    private AudioSource _audioSource;
    int rd = 0;
    string[] glossary = {"Um zu starten!", "Es ist entschieden, so", "Ohne Zweifel", "Darauf kannst du dich verlassen", "Höchstwahrscheinlich", "Frag später noch einmal", "Erzähl es dir jetzt besser nicht", "Meine Antwort ist nein", "Outlook ist nicht so gut", "Sehr zweifelhaft"};
    
    
    // Start is called before the first frame update
    void Start()
    {
    InvokeRepeating("UpdateText", 0f, 1f);
    }

   
    public void UpdateText()
    {
    _audioSource = GetComponent<AudioSource>();
    magic8TextObject.GetComponent<TextMeshPro>().text = "";
    Transform arCameraTransform = GameObject.Find("ARCamera").transform;
    Transform kickKnackTransform = GameObject.Find("KnickKnack1").transform;   
    bool isUpsideDown = false;  
    //get the z rotation coordinate of the camera
    float zRotation_camera = arCameraTransform.eulerAngles.z;
    //get the z coordinate of the kickknack
    float zRotation_kickknack = kickKnackTransform.eulerAngles.z;
    //the angle between the two vectors is obtuse 
    Debug.Log("camera: "+ zRotation_camera + "kickknack: "+ zRotation_kickknack);
    isUpsideDown = Mathf.Abs(zRotation_kickknack - zRotation_camera) > 150 && Mathf.Abs(zRotation_kickknack - zRotation_camera) < 280;
    if (isUpsideDown == true){
        //make a non-annoying sound when it has randomized a new saying as feedback
        rd = UnityEngine.Random.Range(1,10);
        _audioSource.Play();
        //hide the content
        magic8TextObject.GetComponent<TextMeshPro>().text = "????????";
        //play drum

    }else{
        magic8TextObject.GetComponent<TextMeshPro>().text = glossary[rd];
    }
    }
}
