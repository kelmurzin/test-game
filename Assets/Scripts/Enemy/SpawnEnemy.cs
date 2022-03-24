using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private float spawnTime = 4f;

    private void Start()=>
          StartCoroutine(Spawn());


    IEnumerator Spawn()
    {
        while(true)
        {
            Transform randomspawn = _spawnPoint[Random.Range(0, _spawnPoint.Length)];
            GameObject  enemy =  ObjectPooler.SharedInstance.GetPooledObject("Enemy");
            if (enemy != null)
            {
                enemy.transform.position = randomspawn.position;
                enemy.transform.rotation = randomspawn.rotation;
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
