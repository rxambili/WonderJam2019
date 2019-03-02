using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    //public Animator animator;
    public GameObject canvas;
    private Queue<string> sentences;
    public bool isTalking = false;
    public bool hasTalked = false;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
        canvas.SetActive(false);
    }

    public void StartDialogue(Punchline punchline)
    {
        // animator.SetBool("IsOpen", true);
        canvas.SetActive(true);
        isTalking = true;
        hasTalked = false;
        sentences.Clear();

        foreach (string line in punchline.lines)
        {
            sentences.Enqueue(line);
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

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        DisplayNextSentence();
    }

    void EndDialogue()
    {
        canvas.SetActive(false);
        isTalking = false;
        hasTalked = true;
        // animator.SetBool("IsOpen", false);
    }

}
