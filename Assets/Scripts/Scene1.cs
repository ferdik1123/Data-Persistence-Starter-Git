using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class Scene1 : MonoBehaviour
{
    [SerializeField] TMP_InputField textInputField;
    [SerializeField] TextMeshProUGUI bestScoreText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        textInputField.text = PersistData.Instance.textInputField;
        bestScoreText.text = PersistData.Instance.bestScoreText;               
    }

    public void NewInput()
    {
        textInputField.text = PersistData.Instance.textInputField;
    }
}
