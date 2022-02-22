using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool activatePressed;
    private bool switchCollision;
  private Switch SwitchFunc;

    public static event Action DamageAdded;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && switchCollision)
        {
            SwitchFunc.SwichingOn();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        switchCollision = (collision.gameObject.tag == "Switch");
        SwitchFunc = collision.gameObject.GetComponent<Switch>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Damage") return;

        DamageAdded();
    }
}
