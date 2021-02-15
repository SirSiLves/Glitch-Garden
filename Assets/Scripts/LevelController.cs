﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winLabel;
    [SerializeField] float waitingTime = 4f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;


    void Start()
    {
        winLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);

        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitingTime);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpwaners();
    }

    private void StopSpwaners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}