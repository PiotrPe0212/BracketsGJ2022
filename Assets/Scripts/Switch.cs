using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isSwitchOn;
    private Color32 color;
    public Sprite turnedOnSprite;
    private void Start()
    {
        isSwitchOn = false;
        
    }

    public void SwichingOn()
    {
        isSwitchOn = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = turnedOnSprite;
       
    }

   }
