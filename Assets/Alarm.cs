using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public Transform player;
    private int minDist = 5;
    public float speed = 1f;

	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(transform.position, player.position) <= minDist)
        {
            transform.LookAt(player);
            transform.position += transform.forward * speed * Time.deltaTime;

            NotificationCenter.DefaultCenter().PostNotification(this, "AttackNow");
        }
    }

    
}
