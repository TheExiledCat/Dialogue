using System;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Question : Dialogue
{
    
    [SerializeField]
    string optionA, optionB;
    [SerializeField]
    string correct,wrong;
    [SerializeField]
    int correctOption;
    public string GetOption(int choice)
    {
        if (choice == 0) return optionA; else return optionB;
    }
    public int GetAnswer()
    {
        return correctOption;
    }
    public void OnCorrect()
    {
        Dialogue d = new Dialogue();
        d.SetText(correct);
        DialogueSystem.DS.AddToQueue(d);
        DialogueSystem.DS.NextDialogue();
            
    }
    public void OnFalse()
    {
        Dialogue d = new Dialogue();
        d.SetText(wrong);
        DialogueSystem.DS.AddToQueue(d);
        DialogueSystem.DS.NextDialogue();
    }
   
}
