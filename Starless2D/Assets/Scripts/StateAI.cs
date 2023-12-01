using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAI : MonoBehaviour
{



    public Movement movement;
    public Transform targetTransform;
    public float viewRadius;
    AIState currentState;


    //states=============================================
    //better to set up a dictionary to make this more flexible
    public AIStateWait waitState;
    public AIStatePatrol patrolState;
    public AIStateChase chaseState;

    void Start(){
        movement = GetComponent<Movement>();

        //create the states
        waitState = new AIStateWait(this);
        patrolState = new AIStatePatrol(this);
        chaseState = new AIStateChase(this);

        ChangeState(waitState);
    }

    public void ChangeState(AIState newState){
        currentState = newState;
        newState.BeginState();
    }

    void FixedUpdate(){
        if(currentState != null){
            currentState.UpdateStateBase();
        }

    }

    public bool CanSeeTarget(){
        if(Vector3.Distance(transform.position,targetTransform.position) <= viewRadius){
            return true;
        }
        return false;
    }

    public void ChangeColor(Color c){
        movement.body.GetComponent<SpriteRenderer>().color = c;
    }
}
