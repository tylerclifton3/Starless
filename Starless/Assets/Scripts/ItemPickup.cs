using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Pickup() {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Pickup();
        }
    }
}
