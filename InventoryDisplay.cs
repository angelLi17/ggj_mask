using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Text collectibleText;
    public Inventory playerInventory;

    public Text keyText;


    // Update is called once per frame
    void Update()
    {
        collectibleText.text = playerInventory.collectibleCount.ToString();

        keyText.text = playerInventory.keyCount.ToString();
    }
}
