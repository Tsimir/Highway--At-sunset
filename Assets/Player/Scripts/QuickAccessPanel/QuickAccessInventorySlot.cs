using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickAccessInventorySlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject iconGO;


    private void Start()
    {
        iconGO = transform.GetChild(0).gameObject;
    }
    public void SetIcon(Sprite icon)
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
    }
}
