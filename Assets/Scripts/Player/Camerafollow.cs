using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;

    private void Start()=>         
        offset = transform.position - player.position;
    
    private void LateUpdate()
    {
        Vector3 newPos = new Vector3(offset.x + player.position.x,  transform.position.y, offset.z + player.position.z);
        transform.position = newPos;
    }
}
