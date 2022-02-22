using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    

    [SerializeField] private float timeOffset;
    [SerializeField] private  Vector2 posOffset;

    private GameObject player;
    Vector3 initialPos = new Vector3(-8f, 5f, -1f);
    private bool correctInitPos;

    void LateUpdate()
    {
        player = GameObject.Find("player");
        if (player)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = player.transform.position;
            endPos.x += posOffset.x;
            endPos.y -= posOffset.y;
            endPos.z = -1;

            transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
            correctInitPos = false;
        }
        else
        {
            if (!correctInitPos)
                InitialCamera();
        }
    }

    private void InitialCamera()
    {
        transform.position = Vector3.Lerp(transform.position, initialPos, timeOffset * Time.deltaTime);
        correctInitPos = true;
    }
}
