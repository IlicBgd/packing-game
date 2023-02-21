using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewGameButton : HelpWindowButton
{
    [SerializeField]
    SuppliesGenerator suppliesGenerator;
    public override void OnPointerClick(PointerEventData eventData)
    {
        helpWindow.Close();
        suppliesGenerator.OnNewGame();
    }
}
