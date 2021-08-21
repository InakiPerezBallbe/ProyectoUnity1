using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject nametext;
    public GameObject dialogueText;
    public GameObject dialogueBox;
    Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        nametext.GetComponent<TMPro.TextMeshProUGUI>().text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = sentences.Dequeue();
    }

    public void EndDialogue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        dialogueBox.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<LightsTrigger>().yellow.enabled = true;
    }
}
