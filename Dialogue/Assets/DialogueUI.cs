
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueUI : MonoBehaviour
{
    TMP_Text text;
    Image image;
    DialogueSystem dialogue;
    private void Awake()
    {
        Disable();
        text = transform.GetChild(0).GetComponent<TMP_Text>();
        image = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        dialogue = GetComponent<DialogueSystem>();
        dialogue.DialogueChanged += OnDialogueChange;
        dialogue.DialoguesCompleted += OnDialogueCompleted;
    }
    void OnDialogueChange(string newDia,Sprite newSprite)
    {
        text.text = newDia;
        image.sprite = newSprite;
        Enable();
    }

    // Update is called once per frame
    void OnDialogueCompleted()
    {
        text.text = "";
        image.sprite = null;
        Disable();
    }
    public void Enable()
    {
        transform.localScale = Vector3.one;
    }
    public void Disable()
    {
        transform.localScale = Vector3.zero;
    }
}
