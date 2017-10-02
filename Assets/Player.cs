using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int speed;
    int destroyerCount;
    public bool canDestroy = false;
    public Text destroyCount;

	// Use this for initialization
	void Start ()
    {
        destroyerCount = 0;
        SetCountText();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void SetCountText()
    {
        destroyCount.text = "Destroyer Remaining = " + destroyerCount.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
      
        if (other.gameObject.tag == "Enemy")
        {
            if (canDestroy == true)
            {
                other.gameObject.SetActive(false);
                destroyerCount -= 1;
                SetCountText();
                if(destroyerCount == 0)
                {
                    canDestroy = false;
                }
            }
            else
            {
                SceneManager.LoadScene("Main");
            }  
        }
        if(other.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("Main");
        }
        if(other.gameObject.tag == "PP")
        {
            other.gameObject.SetActive(false);
            destroyerCount += 1;
            canDestroy = true;
            SetCountText();
        }
    }
}
