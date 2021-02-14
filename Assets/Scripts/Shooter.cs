using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true); // "IsAttacking" string method in Animator
        }
        else
        {
            animator.SetBool("IsAttacking", false); // "IsAttacking" string method in Animator
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner newAttacker in spawners)
        {

            bool isCloseEnough = (Mathf.Abs(newAttacker.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = newAttacker;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
