using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{

    [SerializeField] private GameObject LightBeam;
    [SerializeField] private int timeForReload = 3;
    private float eventTime;
    private bool reloaded;
    // Start is called before the first frame update
    void Start()
    {
        reloaded = true;
        eventTime = float.PositiveInfinity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= eventTime)
        {
           
            reloaded = true;
            eventTime = float.PositiveInfinity;
        }

        if (!Input.GetKeyDown(KeyCode.L)) return;
        if (!reloaded) return;
        LightUp();


    }

    public void StartTimer(float delay)
    {
        eventTime = Time.time + delay;
    }

    public void LightUp()
    {
        Instantiate(LightBeam, new Vector3(gameObject.transform.position.x +2 , gameObject.transform.position.y, gameObject.transform.position.z) , Quaternion.identity);
        reloaded = false;
        StartTimer(timeForReload);
    }
}
