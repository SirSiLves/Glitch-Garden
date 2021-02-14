using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] float maxSpwanDelay = 1f;
    [SerializeField] float minSpawnDelay = 5f;
    [SerializeField] Attacker attackerPrefab;

    bool spawn = true;


    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpwanDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }


}
