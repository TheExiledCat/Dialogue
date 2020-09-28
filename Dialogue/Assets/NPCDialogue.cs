using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField]
    List<string> dialogues = new List<string>();
    [SerializeField] Sprite myDialoguePortret;
    private void OnMouseDown()
    {
        if (dialogues.Count > 0)
        {
            foreach (string d in dialogues)
            {
                DialogueSystem.DS.AddToQueue(d, myDialoguePortret);
            }
            DialogueSystem.DS.NextDialogue();
            dialogues.Clear();
        }
        
    }
    public Sprite GetPortret()
    {
        return myDialoguePortret;
    }
}
