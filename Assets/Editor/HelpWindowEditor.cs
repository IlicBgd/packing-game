using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(HelpWindow))]
public class HelpWindowEditor : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();
        VisualElement buttonParent = new VisualElement();
        Button showButton = new Button(OnShow);
        buttonParent.Add(showButton);
        Button hideButton = new Button(OnHide);
        buttonParent.Add(hideButton);
        showButton.text = "Show Window";
        hideButton.text = "Hide Window";
        showButton.style.backgroundColor = Color.red;
        hideButton.style.backgroundColor = Color.blue;
        buttonParent.style.flexDirection = FlexDirection.Row;
        Editor editor = Editor.CreateEditor(target);
        IMGUIContainer container = new IMGUIContainer(()=> editor.OnInspectorGUI());
        root.Add(buttonParent);
        root.Add(container);
        return root;
    }
    private void OnHide()
    {
        ((HelpWindow)target).ForceFade(false);
        //Tells Unity that something has changed. >>(Makes sure that change is saved.)<<
        EditorUtility.SetDirty(target);
    }
    private void OnShow()
    {
        ((HelpWindow)target).ForceFade(true);
        EditorUtility.SetDirty(target);
    }
}
