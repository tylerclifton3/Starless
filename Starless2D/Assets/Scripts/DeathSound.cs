using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    public void playSound() {
        GetComponent<AudioSource>().Play();
    }
}
