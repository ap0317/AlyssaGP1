using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    //create a set a health variable for our boss 
    public int bossHealth = 10;
    public float attackRange = 2f;
    //create a series of bool to track the bosses phases
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;
    public Transform player;
    public bool isFlipped = false;
    PlayerManager playerManager;

    //create a shot locatioh as a referenceoknfksjvdnx
    public Transform shotLocation;
    public GameObject projectile; //drag our created prefab into this reference
    public GameObject projectile2;//mewoemwoemowemwoem

    //create a timer systrem to shoot this projectile every 5 seconds with the ability 
    //change this number
    public float timer;
    public int waitingTime;


    
    private void Start()
    {
        //Found and got our reference and set the information we are looking for
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        //(position, rotation, scale)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    private void Update()
    {
        //creates a series of if else statements that will check to see
        //if the boss is below 7 and above 3, below 3 and above 1,
        //and is less than or equal to 6

        if (bossHealth < 7 && bossHealth > 3)
        {
            phase2 = true;
            Debug.Log("Phase 2");
        }
        else if (bossHealth < 3 && bossHealth >= 1)
        {
            phase2 = false;
            Debug.Log("Phase 2");
            phase3 = true;
        }
        else if (bossHealth <= 0)
        {
            phase3 = false;
            Debug.Log("isDead");
            isDead = true;
        }
    }

    public void ProjectileShoot()
    {
        if (timer > waitingTime)
        {
            if (phase2)
            {
                //creates a new gameobject based off our prefab
                GameObject close = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
            if (phase3)
            {
                //creates a new gameobject based off our prefab
                GameObject close = Instantiate(projectile2, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
        }
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 100, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped) { 
        }
    }
}
