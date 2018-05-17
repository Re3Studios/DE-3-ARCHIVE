using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemList : MonoBehaviour {

    public static newItem[] item;
    public Text itemAmoutDisplay;
    public int itemSelect = 0;

    void Start()
    {
        item = Resources.LoadAll<newItem>("Items");
    }

    void Update()
    {

        itemAmoutDisplay.text = item[itemSelect].itemName + " : " + item[itemSelect].itemAmount;

    }

}
