using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject slime1;
    [SerializeField] GameObject slime2;
    [SerializeField] GameObject slime3;
    [SerializeField] GameObject slime4;
    [SerializeField] GameObject slime5;

    public void Reload() {
        player.SetActive(false);
        slime1.SetActive(false);
        slime2.SetActive(false);
        slime3.SetActive(false);
        slime4.SetActive(false);
        slime5.SetActive(false);

        player.SetActive(true);
        slime1.SetActive(true);
        slime2.SetActive(true);
        slime3.SetActive(true);
        slime4.SetActive(true);
        slime5.SetActive(true);
    }

}
