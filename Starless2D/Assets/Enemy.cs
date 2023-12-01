using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Movement movement;
    public int maxHealth = 100;
    int currentHealth;
    public float attackRate = .5f;
    float nextAttackTime = 0f;

    [SerializeField] PlayerCombat playerCombat;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //StartCoroutine(waiter());
    }

    IEnumerator waiter(){ //wait after getting hit (removed)
        yield return new WaitForSeconds(4);
    }

    public void OnCollisionStay2D(Collision2D other) {
        if(Time.time >= nextAttackTime) {
            Debug.Log(other.transform.name + " Damaged Player.");
            playerCombat.PlayerTakeDamage(5);
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    public void TakeDamage(int damage) {
        
        GetComponent<AudioSource>().pitch = Random.Range(.9f,1.1f);
        GetComponent<AudioSource>().Play();
        currentHealth -= damage;
        animator.SetTrigger("Hit");

        if(currentHealth <= 0) {
            Die();
        }


    }
    
    void Die() {
        Debug.Log("Enemey Died.");
        animator.SetBool("isDead", true);

        movement.Stop();
        GetComponent<Movement>().enabled = false;
        GetComponent<StateAI>().enabled = false;
        GetComponent<AudioSource>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
