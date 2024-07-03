using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string[] dialogueLines;
    private int currentLineIndex;
    public GameObject dialogueUI;
    public Text dialogueText;

    private bool isPlayerInRange;

    void Start()
    {
        dialogueUI.SetActive(false);
        currentLineIndex = 0;
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueUI.activeInHierarchy)
            {
                DisplayNextLine();
            }
            else
            {
                StartDialogue();
            }
        }
    }

    void StartDialogue()
    {
        dialogueUI.SetActive(true);
        dialogueText.text = dialogueLines[currentLineIndex];
    }

    void DisplayNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);
        currentLineIndex = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueUI.SetActive(false);
        }
    }
}