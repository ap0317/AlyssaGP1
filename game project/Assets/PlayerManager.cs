using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playermovement;
    public int coinCount;
    public int maxHealth;
    public int currentHealth;
    private void Awake()
    {
        playermovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {

    }
    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
                coinCount++;
                return true;
            case "Speed+":
                //function goes here
                return true;
            default:
                return false;
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
    }
}

