using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed = 2f;
    Rigidbody2D rb;
    [SerializeField] AnimationStateChanger animationStateChanger;
    public Transform body;
    
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    /*public void MoveTransform(Vector3 vel) {
        transform.position += vel * speed * Time.deltaTime;
    }*/

    public void MoveRB (Vector3 vel) {
        rb.velocity = vel * speed;

        if(vel.magnitude > 0.01){
            animationStateChanger?.ChangeAnimationState("Walk",speed/5);
            if(vel.x > 0){
                body.localScale = new Vector3(1,1,1);
            }else if(vel.x < 0){
                body.localScale = new Vector3(-1,1,1);
            }

        }else{
            animationStateChanger?.ChangeAnimationState("Idle");
        }
    }

    public void MoveToward(Vector3 targetPosition){
        Vector3 direction = targetPosition - transform.position;
        direction = Vector3.Normalize(direction);
        MoveRB(direction);
    }

    public void Stop(){
        MoveRB(Vector3.zero);
    }

}
