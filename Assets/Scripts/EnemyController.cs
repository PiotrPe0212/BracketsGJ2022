using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Transform> Patrol = new List<Transform>();
    private int PatrolNum = 0;

    private Vector2 dir;
    private Vector2 olddir;

    // settings
    public float speed = 5;
    
    
    // Start is called before the first frame update
    void Start()
    {
        dir = (Patrol[PatrolNum].position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
    
        olddir = dir;
        dir = (Patrol[PatrolNum].position - transform.position).normalized;
        transform.Translate(dir* Time.deltaTime * speed);
        if(Vector2.Distance(Patrol[PatrolNum].position, transform.position) < 1)
        {
            PatrolNum += 1;
            if(PatrolNum >= Patrol.Count)
            {
                PatrolNum = 0;
            }
            print(dir);
        }
    }
}
