using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public float dampSpeed = 3f;

    public Transform player;
    public Transform room;
    public Transform activeRoom;

    [Range(-5, 5)]
    public float minModX, maxModX, minModY, maxModY;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        player = PlayerContoller.instance.gameObject.transform;
        activeRoom = player;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
            var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
            var minPosx = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
            var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;

            Vector3 clampedPos = new Vector3(Mathf.Clamp(player.position.x, minPosx, maxPosX), Mathf.Clamp(player.position.y, minPosY, maxPosY), Mathf.Clamp(player.position.z, -10, -10));

            Vector3 smoothPos = Vector3.Lerp(transform.position, clampedPos, dampSpeed * Time.deltaTime);

            transform.position = smoothPos;
        }
        catch 
        {

            
        }

    }
}
