using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : NPCDialogue
{
    [SerializeField]
    NPCDialogue npc;

    
    public void Complete()
    {
        npc.AddDialogues(dialogues);
    }

}
