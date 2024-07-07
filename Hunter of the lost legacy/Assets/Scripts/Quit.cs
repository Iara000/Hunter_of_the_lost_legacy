using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Quit : MonoBehaviour
{
    public Button exit;
    void Start()
    {
        exit.onClick.AddListener(SairJogo);
    }
    void SairJogo()
    {
        SceneManager.LoadScene("Menu");
    }
}
