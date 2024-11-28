using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName; // Имя предмета
    public Sprite icon; // Иконка предмета
    public int maximumAmount; // Максимальное кол-во предмета
    public GameObject itemPrefab;
}
