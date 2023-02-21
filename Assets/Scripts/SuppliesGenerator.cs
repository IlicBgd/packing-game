using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuppliesGenerator : MonoBehaviour
{
    [SerializeField]
    SupplyItem supplyPrefab;
    [SerializeField]
    Sprite[] sprites;

    List<int> positionsUsed = new List<int>();
    List<SupplyItem> supplyItems = new List<SupplyItem>();

    public List<SupplyItem> itemsToPack = new List<SupplyItem>();

    Vector2 supplyPosition;
    Vector2 supplyScale;

    int itemsToBeChecked = 5;
    private void Awake()
    {
        supplyPosition = transform.position;
        supplyScale = new Vector2(supplyPrefab.transform.localScale.x, supplyPrefab.transform.localScale.y);
        PositionRandomizer();
        OnStartup();
    }
    void OnStartup()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            CreateSupplies(supplyPosition, i);
            supplyPosition.x += 1.5f;
        }
        SuppliesRandomizer();
    }
    void CreateSupplies(Vector2 position, int z)
    {
        SupplyItem supply;
        supply = Instantiate(supplyPrefab, position, Quaternion.identity, transform);
        supply.GetComponent<SpriteRenderer>().sprite = sprites[positionsUsed[z]];
        supply.transform.localScale = supplyScale;
        supply.name = sprites[positionsUsed[z]].name;
        supplyItems.Add(supply);
    }
    void SuppliesRandomizer()
    {
        for (int i = 0; i < itemsToBeChecked; i++)
        {
            int randomNumber = Random.Range(1, supplyItems.Count);
            itemsToPack.Add(supplyItems[randomNumber]);
            supplyItems.Remove(supplyItems[randomNumber]);
        }
    }
    void PositionRandomizer()
    {
        List<int> numberOfPositions = new List<int>();
        for (int i = 0; i < sprites.Length; i++)
        {
            numberOfPositions.Add(i);
        }
        for (int i = 0; i < sprites.Length; i++)
        {
            int randomNumber = Random.Range(0, numberOfPositions.Count);
            positionsUsed.Add(numberOfPositions[randomNumber]);
            numberOfPositions.Remove(numberOfPositions[randomNumber]);
        }
    }
    public void OnNewGame()
    {
        //for (int i = 0; i < supplyItems.Count; i++)
        //{
        //    Destroy(supplyItems[i].gameObject);
        //    supplyItems.Remove(supplyItems[i]);
        //    Destroy(itemsToPack[i].gameObject);
        //    itemsToPack.Remove(itemsToPack[i]);
        //    slot.itemPositions[i].isTaken = false;
        //}
        //supplyPosition = transform.position;
        //slot.counter = 0;
        //OnStartup();
        //checkBoardController.CheckboardNewGame();
        SceneManager.LoadScene(0);
    }
}
