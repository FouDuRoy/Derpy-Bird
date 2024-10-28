using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawnerScript : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnInterval = 3.0f;
    public float lifeTime = 10f;
    public float heighOffSet = 5f;


    void Start()
    {
        float lowestPoint = transform.position.y - heighOffSet;
        float highestPoint = transform.position.y + heighOffSet;
        StartCoroutine(SpawnObject(lowestPoint, highestPoint));
    }

    IEnumerator SpawnObject(float lowestPoint, float highestPoint)
    {
        while (true)
        {


            Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint), 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
