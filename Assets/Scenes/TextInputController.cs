using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInputController : MonoBehaviour
{

    public TMP_InputField inputField;
    public TextMeshProUGUI displayText;

    public bool clearOnEnter = true;

    // Start is called before the first frame update
    void Start()
    {
        if (inputField == null)
        {
            inputField = FindObjectOfType<TMP_InputField>();
        }
        inputField.onValueChanged.AddListener(OnInputChanged);
        inputField.onSubmit.AddListener(OnInputSubmit);
        inputField.ActivateInputField();


    }

    void OnInputChanged(string text)
    {
        displayText.text = text;
        Debug.Log("입력 중: " + text);
    }
    void OnInputSubmit(string text)
    {
        displayText.text = "입력 완료: " + text;
        Debug.Log("입력 완료: " + text);

        if (clearOnEnter)
        {
            inputField.text = "";
            displayText.text = "";
        }
        inputField.ActivateInputField();
    }
    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            inputField.text = "";
            displayText.text = "";
            inputField.ActivateInputField();   
        }

    }
}
