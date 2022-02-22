using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    [SerializeField] private Switch FirstSwitch;
    [SerializeField] private Switch SecondSwitch;

    void FixedUpdate()
    {
        if (FirstSwitch.isSwitchOn && SecondSwitch.isSwitchOn)
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
