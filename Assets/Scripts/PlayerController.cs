using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool activatePressed;
    private bool switchCollision;
  private Switch SwitchFunc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
