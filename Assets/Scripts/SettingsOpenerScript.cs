using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsOpenerScript : MonoBehaviour
{
    // Call this from the button
    public void OpenSettingsMenu()
    {
        Debug.Log("Settings button clicked");
        // Loads the settings scene additively (on top of the current scene)
        SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Additive);

        // Optional: pause the game while settings are open
        Time.timeScale = 0f;
    }

    // Call this from a close button in the settings menu
    public void CloseSettingsMenu()
    {
        // Unload the settings scene
        SceneManager.UnloadSceneAsync("SettingsMenu");

        // Resume the game
        Time.timeScale = 1f;
    }
}
