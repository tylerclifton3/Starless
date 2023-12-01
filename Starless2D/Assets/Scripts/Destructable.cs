using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    
    public void BreakWall() {
        Debug.Log("HIT WALL");
        GetComponent<Collider2D>().enabled = false;
        transform.GetChild(1).gameObject.SetActive(false);
        
    }

}
