using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    //[SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Animator animator;
    [SerializeField] Animator deathAnimator;
    [SerializeField] DeathHandler deathHandler;
    [SerializeField] Slider healthSlider;
    Movement movement;
    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;

    //Destructable destructable;
    public int attackDamage = 40;
    public int playerHealth;
    public bool weapon;

    public float attackRate = .5f;
    float nextAttackTime = 0f;

    

    void Awake() {
        weapon = false;
        playerHealth = 100;
        movement = GetComponent<Movement>();
    }

    void Update() {
        healthSlider.value = playerHealth;
    }

    public void Attack() {
        //int attackDamage = 5;

        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies) {
            Debug.Log("hit: " + enemy.name);
            if (enemy.CompareTag("Wall") && weapon) { //if layer is wall and have weapon
                enemy.GetComponent<Destructable>().BreakWall();
            } else {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            
        }
    }

    public void PlayerTakeDamage(int damage) {
        if(Time.time >= nextAttackTime) {
            GetComponent<AudioSource>().pitch = Random.Range(.9f,1.1f);
            GetComponent<AudioSource>().Play();
            playerHealth -= damage;
            animator.SetTrigger("Hit");
            nextAttackTime = Time.time + 1f / attackRate;
        }

        if(playerHealth <= 0) {
            Death();
        }
    }

    IEnumerator deathWait(float delay){ 
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Death() {
        Debug.Log("I died.");
        movement.Stop();
        animator.SetTrigger("isDead");
        deathAnimator.SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;

        StartCoroutine(deathWait(3f));
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
