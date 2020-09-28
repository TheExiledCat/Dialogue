using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    List<string> dialogues = new List<string>();
    List<Sprite> portrets = new List<Sprite>();
    public static DialogueSystem DS;
    bool started = false;
    bool clicked = false;
    public event Action<string,Sprite> DialogueChanged;
    public event Action DialoguesCompleted;

    private void Awake()
    {
        if (DS == null)
        {
            DS = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddToQueue(string _dialogue,Sprite portret)
    {
        dialogues.Add(_dialogue);
        portrets.Add(portret);
    }
    private void Update()
    {
        print(started);
        if (started&&Input.GetMouseButtonDown(0))
        {
            if (!clicked)
            {
                clicked = true;
            }
            else
            {
                NextDialogue();
            }
            
            
        }
    }



    public void NextDialogue()
    {
        if (dialogues.Count == 0&&started)
        {
            started = false;
            clicked = false;
            DialoguesCompleted?.Invoke();
            return;
        }
        started = true;
        string currentDialogue = dialogues[0];
        Sprite currentPortret = portrets[0];
        dialogues.RemoveAt(0);
        portrets.RemoveAt(0);
        DialogueChanged?.Invoke(currentDialogue,currentPortret);

       
    }
}