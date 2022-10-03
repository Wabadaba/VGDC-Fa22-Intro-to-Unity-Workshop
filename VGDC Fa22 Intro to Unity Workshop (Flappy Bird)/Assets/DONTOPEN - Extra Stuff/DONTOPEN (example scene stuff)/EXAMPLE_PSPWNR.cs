using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXAMPLE_PSPWNR : MonoBehaviour
{
    private float totalTime;
    public float SPAWNERINTERVAL;

    private const float TIMETODESTROY = 7f;

    public GameObject PipePrefab;

    public float heightVariation = 5f;

    private void FixedUpdate()
    {
        if(totalTime > SPAWNERINTERVAL)
        {
            Vector3 SpawnPos = new Vector3(transform.position.x,
                Random.Range(-heightVariation, heightVariation)
                , 0);
            GameObject spawnedPipe = Instantiate(PipePrefab, SpawnPos, Quaternion.identity);

            Destroy(spawnedPipe, TIMETODESTROY);
            Debug.Log("SPAWN PIPE!");
            totalTime = 0;
        }
        totalTime += Time.deltaTime;
    }

    
}
