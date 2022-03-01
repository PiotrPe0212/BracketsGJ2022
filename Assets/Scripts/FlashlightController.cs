using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{

    [SerializeField] private GameObject LightBeam;
    [SerializeField] private GameObject LightSprite;
    [SerializeField] private int timeForReload = 3;
    private float eventTime;
    private bool reloaded;
    private bool direction;
    private float position;
    private float shift =2;
    // Start is called before the first frame update
    void Start()
    {
        
        reloaded = true;
        eventTime = float.PositiveInfinity;
    }

    // Update is called once per frame
    void Update()
    {
   
        directionChange();

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
        LightSprite.SetActive(true);
        Instantiate(LightBeam, new Vector3(gameObject.transform.position.x +shift , gameObject.transform.position.y-0.7f, gameObject.transform.position.z) , Quaternion.identity);
        reloaded = false;
        StartTimer(timeForReload);
        Invoke(nameof(SetLightSpriteToFalse), 0.5f);
    }

    private void SetLightSpriteToFalse()
    {
        LightSprite.SetActive(false);
    }

    private void directionChange()
    {
       
        LightSprite.GetComponent<SpriteRenderer>().flipX = gameObject.GetComponent<SpriteRenderer>().flipX;
        direction = LightSprite.GetComponent<SpriteRenderer>().flipX;
        if (direction)
        {
            LightSprite.transform.localPosition = new Vector3(14, -0.3f, 0);
            shift = -2;
        }
        else
        {
            LightSprite.transform.localPosition = new Vector3(-14, -0.3f, 0);
            shift = 2;
        }
    }

}
