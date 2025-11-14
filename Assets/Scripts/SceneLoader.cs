using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button loadButton;       // Assign your button in the Inspector
    public string sceneName = "Level 1"; // Replace with your scene name

    void Start()
    {
        loadButton.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
