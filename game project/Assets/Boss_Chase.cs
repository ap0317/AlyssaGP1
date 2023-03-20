using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Chase : StateMachineBehaviour
{
    public float speed = 4.5f;
    public float attackRange = 2f;
    //creates a place to store the players transform information
    Transform player;
    //creates a place to store the rigidbody
    Rigidbody2D rb;

    //create a place to store our bosses behavior
    BossBehavior bossBehavior;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerIndex)
    {
        //sets the reference for our players location
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //sets the reference for my rigidbody
        rb = animator.GetComponent<Rigidbody2D>();

        //set and fill in the information we are looking for
        bossBehavior = animator.GetComponent<BossBehavior>();

    }

    //OnStateUpdate is called on each update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerIndex)
    {
        //finds the player as target and locks the boss on the y axis
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        //sends the boss to move towards the target
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        //tell our boss to move its position
        rb.MovePosition(newPos);

        float distance = Vector2.Distance(player.position, rb.position);
        if (distance < attackRange)
        {
            Debug.Log("Hit!");
        }
    }
}

   