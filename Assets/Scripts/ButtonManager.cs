using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

using UnityEditor;

public class ButtonManager : MonoBehaviour
{
    public string inputFiledText;
    private PersistData persistData;
    private Scene1 scene1;

    private void Start()
    {
        persistData = GameObject.Find("Persist Data").GetComponent<PersistData>();
        scene1 = GameObject.Find("Scene1").GetComponent<Scene1>();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        PersistData.Instance.SaveName();
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
    Application.Qiut();
#endif
    }

    public void ReadStringInput(string s)
    {
        persistData.textInputField = s;
        persistData.SaveName();
        scene1.NewInput();
        
    }

    public void RestartScore()
    {
        persistData.ResetScore();
        SceneManager.LoadScene(0);
    }
}
