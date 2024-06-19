using UnityEngine;
using UnityEngine.SceneManagement;
public class Caminho : MonoBehaviour
{
    public void CarregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
    public void SairJogo()
    {
        Application.Quit();
    }
}