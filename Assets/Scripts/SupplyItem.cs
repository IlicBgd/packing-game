using System;
using System.Collections;
using System.Collections.Generic;
using Tools.DragAndDrop;
using UnityEngine;

public class SupplyItem : Item
{
    [SerializeField]
    CheckBoardController controller;

    Vector2 startPosition;

    bool insideSuitcase;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        startPosition = transform.position;
        controller = FindObjectOfType<CheckBoardController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void OnItemDropped()
    {
        spriteRenderer.sortingOrder = 0;
        if (!insideSuitcase)
        {
            ResetPosition();
        }
    }

    public override void OnItemPicked()
    {
        spriteRenderer.sortingOrder = 1;
    }

    public void ResetPosition()
    {
        SetPosition(startPosition);
    }
    public void ItemCheck()
    {
        for (int i = 0; i < controller.itemTexts.Length; i++)
        {
            if (this.name == controller.itemTexts[i].text)
            {
                controller.checkMarks[i].SetActive(true);
                controller.endGameCounter++;
                controller.EndGameWindow();
                return;
            }
        }
    }
    public void ItemUncheck()
    {
        for (int i = 0; i < controller.itemTexts.Length; i++)
        {
            if (this.name == controller.itemTexts[i].text)
            {
                controller.checkMarks[i].SetActive(false);
                controller.endGameCounter--;
                return;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Suitcase")
        {
            insideSuitcase = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Suitcase")
        {
            insideSuitcase = false;
        }
    }
}
