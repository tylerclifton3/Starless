using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D other) {
        GetComponent<AudioSource>().pitch = Random.Range(.9f,1.1f);
        GetComponent<AudioSource>().Play();
        //Destroy(this.gameObject);
        
    }
}
