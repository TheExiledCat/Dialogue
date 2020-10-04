using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue
{
    [SerializeField]
    protected string text;
    
    public string GetText()
    {
        return text;
    }
    public void SetText(string _text)
    {
        text = _text;
    }
}
