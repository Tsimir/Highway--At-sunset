using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickAccessInventory : MonoBehaviour
{
    public Transform quickAccessPanel;
    public List<QuickAccessInventorySlot> slots = new List<QuickAccessInventorySlot>();
    public float reachDistance = 3f;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
        for (int i = 0; i < quickAccessPanel.childCount; i++) // childCount показывает сколько слотов, работает как Count
        {
            if (quickAccessPanel.GetChild(i).GetComponent<QuickAccessInventorySlot>() != null) // Проверка на пустой (имеет он компонент 'QuickAccessInventorySlot' или нет) объект на всякий случай
            {
                slots.Add(quickAccessPanel.GetChild(i).GetComponent<QuickAccessInventorySlot>());
            }
        }
    }
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (QuickAccessInventorySlot slot in slots)
        {
            if (slot.item == _item && slot.amount < _item.maximumAmount)
            {
                slot.amount += _amount;
                return;
            }
        }
        foreach (QuickAccessInventorySlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                break;
            }
        }
    }
}
