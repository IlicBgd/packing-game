using System.Collections;
using System.Collections.Generic;
using Tools.DragAndDrop;
using UnityEngine;

public class SupplySlot : Slot
{
    [SerializeField]
    SupplyItem[] items;

    public Field[] itemPositions;
    public int counter = 0;
    private void Start()
    {
        items = new SupplyItem[itemPositions.Length];
    }
    protected override void OnItemDropped(Item item)
    {
        SuitcasePositionSet(item);
    }

    protected override void OnItemPicked(Item item)
    {
        SuitcasePositionReset(item);
    }
    void SuitcasePositionSet(Item item)
    {
        if (counter < itemPositions.Length)
        {
            for (int i = 0; i < itemPositions.Length; i++)
            {
                if (!itemPositions[i].isTaken)
                {
                    item.SetPosition(itemPositions[i].transform.position);
                    itemPositions[i].isTaken = true;
                    items[i] = (SupplyItem)item;
                    ((SupplyItem)item).ItemCheck();
                    counter++;
                    return;
                }
            }
        }
        else
        {
            ((SupplyItem)item).ResetPosition();
        }
    }
    void SuitcasePositionReset(Item item)
    {
        for (int i = 0; i < itemPositions.Length; i++)
        {
            if (items[i] != null && item == items[i])
            {
                items[i] = null;
                ((SupplyItem)item).ItemUncheck();
                itemPositions[i].isTaken = false;
                counter--;
            }
        }
    }
}
