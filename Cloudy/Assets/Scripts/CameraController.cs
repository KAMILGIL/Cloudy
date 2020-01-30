using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 playerDelta; 
    
    private void Start()
    {
        playerDelta = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.position += (player.transform.position + playerDelta - transform.position) * 3f * Time.deltaTime;
    }
}
