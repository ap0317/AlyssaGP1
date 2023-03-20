using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    // Start is called before the first frame update
    
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Do stuff
            PlayerManager manager = collision.GetComponent<PlayerManager>();

            manager.PickupItem(gameObject);

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
