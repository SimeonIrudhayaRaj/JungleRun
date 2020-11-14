using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	private Player player;
	private float distance;
	private Vector3 lastPosition;
    void Start()
    {
        player = FindObjectOfType<Player>();
        lastPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.x - lastPosition.x;
        transform.position = new Vector3(
        		transform.position.x + distance,
        		transform.position.y,
        		transform.position.z);
        lastPosition = transform.position;
    }
}
