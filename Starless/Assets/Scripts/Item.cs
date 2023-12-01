using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create")]
public class Item : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite icon;
}
