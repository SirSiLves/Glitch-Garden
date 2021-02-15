using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILES_PARENT_NAME = "Projectiles";


    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjetctileParent();
    }

    private void CreateProjetctileParent()
    {
        projectileParent = GameObject.Find(PROJECTILES_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILES_PARENT_NAME);
        }
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
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;


    }
}
