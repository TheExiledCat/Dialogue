using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField]
    List<Dialogue> dialogues = new List<Dialogue>();
    List<Sprite> portrets = new List<Sprite>();
    public static DialogueSystem DS;
    bool started = false;
    bool clicked = false;
    public event Action<Dialogue,Sprite> DialogueChanged;
    public event Action DialoguesCompleted;
    bool pause = false;
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
    public void AddToQueue(Dialogue _dialogue,Sprite portret=null)
    {
        dialogues.Add(_dialogue);
        portrets.Add(portret);
    }
    private void Update()
    {
        
        if (started&&Input.GetMouseButtonDown(0)&&!pause)
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
        pause = false;
        if (dialogues.Count == 0&&started)
        {
            started = false;
            clicked = false;
            DialoguesCompleted?.Invoke();
            return;
        }
        if (dialogues[0].GetType() == typeof(Question))
        {
            pause = true;
        }
        started = true;
        Dialogue currentDialogue = dialogues[0];
        Sprite currentPortret = portrets[0];
        dialogues.RemoveAt(0);
        portrets.RemoveAt(0);
        DialogueChanged?.Invoke(currentDialogue,currentPortret);

       
    }
}