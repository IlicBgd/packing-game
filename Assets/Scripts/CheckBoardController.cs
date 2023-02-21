using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckBoardController : MonoBehaviour
{
    [SerializeField]
    SuppliesGenerator suppliesGenerator;
    [SerializeField]
    HelpWindow endGameWindow;

    public int endGameCounter = 0;

    public TextMeshProUGUI[] itemTexts;
    public GameObject[] checkMarks;
    private void Start()
    {
        CheckListCreator();
    }
    void CheckListCreator()
    {
        for (int i = 0; i < itemTexts.Length; i++)
        {
            itemTexts[i].text = suppliesGenerator.itemsToPack[i].name;
        }
    }
    public void EndGameWindow()
    {
        if (endGameCounter == 5)
        {
            endGameWindow.Open();
        }
    }
}
