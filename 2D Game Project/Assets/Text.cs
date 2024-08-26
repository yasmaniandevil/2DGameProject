using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    //public TextMeshProUGUI myText;
    private TextMeshProUGUI m_TextMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        //myText.text = "Hello World";
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        m_TextMeshProUGUI.text = "Hello World";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
