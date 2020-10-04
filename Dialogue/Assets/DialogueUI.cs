using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueUI : MonoBehaviour
{
    TMP_Text text;
    Image image;
    DialogueSystem dialogue;
    [SerializeField]
    GameObject questionPrefab;
    GameObject buttonOrigin;
    Question currentQuestion;
    GameObject boxA;
    GameObject boxB;
    public event Action OnCorrect;
    public event Action OnFalse;
    private void Awake()
    {
        Disable();
        text = transform.GetChild(0).GetComponent<TMP_Text>();
        image = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        dialogue = GetComponent<DialogueSystem>();
        buttonOrigin = transform.GetChild(2).gameObject;
        dialogue.DialogueChanged += OnDialogueChange;
        dialogue.DialoguesCompleted += OnDialogueCompleted;

    }
    void OnDialogueChange(Dialogue newDia,Sprite newSprite)
    {
        text.text = newDia.GetText();
        image.sprite = newSprite;
        if (newDia.GetType() == typeof(Question))
        {
            currentQuestion= newDia as Question;
            Vector3 pos = buttonOrigin.transform.position;
            boxA = Instantiate(questionPrefab, buttonOrigin.transform);
            boxB = Instantiate(questionPrefab, buttonOrigin.transform);
            boxA.transform.position = pos;
            boxB.transform.position = boxA.transform.position +Vector3.right * (boxA.transform.position.x-boxB.GetComponent<RectTransform>().sizeDelta.x/2);
            Button a = boxA.GetComponent<Button>();
            Button b = boxB.GetComponent<Button>();
            a.onClick.AddListener(AnswerA);
            b.onClick.AddListener(AnswerB);
            boxA.transform.GetChild(0).GetComponent<TMP_Text>().text=currentQuestion.GetOption(0);
            boxB.transform.GetChild(0).GetComponent<TMP_Text>().text = currentQuestion.GetOption(1);
        }
        Enable();
    }

    // Update is called once per frame
    void OnDialogueCompleted()
    {
        text.text = "";
        image.sprite = null;
        Disable();
    }
    public void AnswerA()
    {
        if (currentQuestion != null && 0 == currentQuestion.GetAnswer())
        {
            print("correct");
            OnCorrect += currentQuestion.OnCorrect;
            DialogueSystem.DS.NextDialogue();
            OnCorrect?.Invoke();
            Destroy(boxA);
            Destroy(boxB);
        }
        else
        {
            print("false");
            OnFalse += currentQuestion.OnFalse;
            
            DialogueSystem.DS.NextDialogue();
            OnFalse?.Invoke();
            Destroy(boxA);
            Destroy(boxB);
        }
    }
    public void AnswerB()
    {
        if (currentQuestion != null && 1 == currentQuestion.GetAnswer())
        {
            print("correct");
            OnCorrect += currentQuestion.OnCorrect;
            
            DialogueSystem.DS.NextDialogue();
            OnCorrect?.Invoke();
            Destroy(boxA);
            Destroy(boxB);
        }
        else
        {
            print("false");
            OnFalse += currentQuestion.OnFalse;
            DialogueSystem.DS.NextDialogue();
            OnFalse?.Invoke();
            Destroy(boxA);
            Destroy(boxB);
        }
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
