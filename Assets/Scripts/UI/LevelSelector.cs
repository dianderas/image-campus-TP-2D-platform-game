using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string level;
    public void LevelSelect()
    {
        SceneManager.LoadScene(level);
    }
}
