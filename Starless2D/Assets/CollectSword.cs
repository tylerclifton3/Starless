using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSword : MonoBehaviour
{
    [SerializeField] PlayerCombat playerCombat;

    void OnTriggerEnter2D(Collider2D other) {
        collectSword();
        Destroy(this.gameObject);
    }

    public void collectSword() {
        playerCombat.weapon = true;
    }

}
