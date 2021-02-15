using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] float maxSpwanDelay = 1f;
    [SerializeField] float minSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;

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
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }


    public void StopSpawning()
    {
        spawn = false;
    }

}
