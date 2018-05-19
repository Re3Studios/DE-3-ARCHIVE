using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Item")]
public class newItem : ScriptableObject {

    public string itemName;
    public Sprite itemImage;
    [HideInInspector]
    public int itemAmount;

}
