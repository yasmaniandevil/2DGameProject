using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueText : MonoBehaviour
{

    public TextMeshProUGUI dialogueTexty;
    private int dialogueStep = 0;
    // Start is called before the first frame update
    void Start()
    {
        ShowDialogueLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            NextDialogue();
        }
    }

    public void ShowDialogueLine()
    {
        switch(dialogueStep)
        {
            case 0:
                dialogueTexty.text = "hello";
                break;
            case 1:
                dialogueTexty.text = "how are you?";
                break;
            default:
                dialogueTexty.text = "Goodbye";
                break;
        }
    }

    public void NextDialogue()
    {
        dialogueStep++;
        ShowDialogueLine();
    }
}
