using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] Movement movement;
    
    public float attackRate = 5f;
    float nextAttackTime = 0f;

    public void OnTriggerStay2D(Collider2D collider) {
        movement.speed = 1;
        if(Time.time >= nextAttackTime) {
            Debug.Log(collider.name + " posion dmg player");
            playerCombat.PlayerTakeDamage(1);
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    public void OnTriggerExit2D(Collider2D collider) {
        movement.speed = 2;
    }
}
