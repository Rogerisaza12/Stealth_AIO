using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GuardEnemy : MonoBehaviour
{
    public Transform startPoint;
    public Transform player;
    public float speed = 1f;
    public int minDist = 5;
    public bool onChase = false;
    
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "AttackNow");
    }

    void Update()
    {
        if(onChase == false)
        {
            transform.LookAt(startPoint);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, player.position) <= minDist)
        {
            onChase = true;
            transform.LookAt(player);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, player.position) > minDist)
        {
            onChase = false;
        }
    }


    void AttackNow()
    {
        onChase = true;
        transform.LookAt(player);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
