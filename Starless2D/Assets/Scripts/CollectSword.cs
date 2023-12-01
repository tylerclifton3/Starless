using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSword : MonoBehaviour
{
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] AudioSource coinSound;

    void OnTriggerEnter2D(Collider2D other) {
        collectSword();
        coinSound.Play();
        Destroy(this.gameObject);
    }

    public void collectSword() {
        playerCombat.weapon = true;
    }

}
