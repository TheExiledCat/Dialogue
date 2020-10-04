using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSetup : MonoBehaviour
{
    [SerializeField]
    List<string> texts = new List<string>();
    List<string> GetTexts()
    {
        return texts;
    }
}
