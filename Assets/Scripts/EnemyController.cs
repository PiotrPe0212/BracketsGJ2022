using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Transform> Patrol = new List<Transform>();
    private int PatrolNum = 0;
    private float eventTime;
    private Vector2 dir;
    private Vector2 olddir;
    private bool justWaiting;
    private float oldPos;

    // settings
    public float speed = 5;
    [SerializeField] private int waitingTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        eventTime = float.PositiveInfinity;
        justWaiting = false;
        
        dir = (Patrol[PatrolNum].position - transform.position).normalized;
    }


    private void Update()
    {
        if (Time.time >= eventTime)
        {
            justWaiting = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            transform.gameObject.tag = "Damage";
            eventTime = float.PositiveInfinity;
        }
    }
    void FixedUpdate()
    {
        if (justWaiting) return;

        spriteRenderer.flipX = oldPos < transform.position.x;
        oldPos = transform.position.x;
        olddir = dir;
        dir = (Patrol[PatrolNum].position - transform.position).normalized;
        transform.Translate(dir* Time.deltaTime * speed);
        if(Vector2.Distance(Patrol[PatrolNum].position, transform.position) < 2)
        {
            PatrolNum += 1;
            if(PatrolNum >= Patrol.Count)
            {
                PatrolNum = 0;
            }
            print(dir);
        }

     
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Light") return;
        justWaiting = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(146, 255, 143, 255);
        transform.gameObject.tag = "Untagged";
        StartTimer(waitingTime);
    }

    public void StartTimer(float delay)
    {
        eventTime = Time.time + delay;
    }
}
