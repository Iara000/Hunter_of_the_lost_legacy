using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CaminhoMenu : MonoBehaviour
{
    public Button start;
    public Button exit;
    public Animator anim;
    public string nomeDaCena;
    int camada = 0;
    void Start()
    {
        start.onClick.AddListener(OnButtonClick);
        exit.onClick.AddListener(SairJogo);
    }
    void Update()
    {
        if (IsAnimationFinished("Transition"))
        {
            CarregarCena(nomeDaCena);
        }
    }
    void OnButtonClick()
    {
        anim.SetBool("Loading", true);
    }
    void CarregarCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }
    public void SairJogo()
    {
        Application.Quit();
    }
    bool IsAnimationFinished(string nomeDaAnimação)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(camada);
        return stateInfo.IsName(nomeDaAnimação) && stateInfo.normalizedTime >= 1.0f;
    }
}