using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField]
    protected List<Dialogue> dialogues = new List<Dialogue>();
    [SerializeField]
    protected List<Question> questions = new List<Question>();
    [SerializeField] Sprite myDialoguePortret;
    public void AddDialogues(List<Dialogue> _dialogues)
    {
        dialogues.AddRange(_dialogues);
    }
    private void OnMouseDown()
    {
        Talk();
        
        
    }
    protected void Talk()
    {
        if (dialogues.Count > 0)
        {
            foreach (Dialogue d in dialogues)
            {

                DialogueSystem.DS.AddToQueue(d, myDialoguePortret);
            }
            foreach (Question q in questions)
            {
                DialogueSystem.DS.AddToQueue(q, myDialoguePortret);
            }
            DialogueSystem.DS.NextDialogue();
            dialogues.Clear();
            questions.Clear();
        }
    }
    public Sprite GetPortret()
    {
        return myDialoguePortret;
    }
}
