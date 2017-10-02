using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;
    public Transform startPoint;
    public Transform endPoint;
    private float startTime;
    private float journey;
    public int minDist = 5;
    private bool onChase = false;
    

    void Start()
    {
        startTime = Time.time;
        journey = Vector3.Distance(startPoint.position, endPoint.position);
        NotificationCenter.DefaultCenter().AddObserver(this, "AttackNow");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (onChase == false)
        {
            float distCOvered = (Time.time - startTime) * speed;
            float flacJourney = distCOvered / journey;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, Mathf.PingPong(flacJourney, 1.0f));
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
