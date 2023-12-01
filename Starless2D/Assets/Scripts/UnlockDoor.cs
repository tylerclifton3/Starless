using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] PlayerCombat playerCombat;

    void OnTriggerEnter2D(Collider2D other) {
        if (playerCombat.weapon) {
            Unlock();
        }
    }

    public void Unlock() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
