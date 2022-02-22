using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    [SerializeField] private Switch FirstSwitch;
    [SerializeField] private Switch SecondSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FirstSwitch.isSwitchOn && SecondSwitch.isSwitchOn)
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
