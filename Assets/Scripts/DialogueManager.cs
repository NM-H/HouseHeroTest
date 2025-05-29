using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Text narrationText;
    public GameObject narrationPanel;

    public float typingSpeed = 0.03f;
    public float delayBetweenLines = 1.5f;

    private Queue<string> dialogueLines = new Queue<string>();
    private Coroutine typingCoroutine;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartDialogue(List<string> lines)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        dialogueLines.Clear();
        foreach (string line in lines)
        {
            dialogueLines.Enqueue(line);
        }

        narrationPanel.SetActive(true);
        typingCoroutine = StartCoroutine(DisplayNextLine());
    }

    IEnumerator DisplayNextLine()
    {
        while (dialogueLines.Count > 0)
        {
            string line = dialogueLines.Dequeue();
            narrationText.text = "";

            foreach (char letter in line.ToCharArray())
            {
                narrationText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            yield return new WaitForSeconds(delayBetweenLines);
        }

        narrationPanel.SetActive(false);
    }
}
