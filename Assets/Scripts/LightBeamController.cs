using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamController : MonoBehaviour
{
    [SerializeField] private int speed = 15;
    [SerializeField] private float border = 11.0f;
    private GameObject player;
    private float initPositionX;
    private void Awake()
    {
        initPositionX = transform.position.x;
        player = GameObject.Find("player");
    }


    void FixedUpdate()
    {
        if(!player.GetComponent<SpriteRenderer>().flipX)
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        else
            transform.Translate(-Vector3.right * Time.deltaTime * speed);

        if (transform.position.x > initPositionX+ border || transform.position.x < initPositionX -border)
        {
            Destroy(gameObject);

        }

    }

    private void Update()
    {
        if (Time.timeScale == 0) Destroy(gameObject);
    }

    private void OnColisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }

  
}
