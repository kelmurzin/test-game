using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject enemy;

    public void Start()
    {
       Instantiate(enemy, spawnpoint.transform);
    }
}
