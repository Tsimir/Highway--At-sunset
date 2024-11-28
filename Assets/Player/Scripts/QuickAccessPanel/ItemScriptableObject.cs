using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName; // ��� ��������
    public Sprite icon; // ������ ��������
    public int maximumAmount; // ������������ ���-�� ��������
    public GameObject itemPrefab;
}
