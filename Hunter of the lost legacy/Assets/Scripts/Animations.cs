using UnityEngine;
using UnityEngine.SceneManagement;
public class Animations : MonoBehaviour
{
    Animator animator;
    int camada = 0;
    public string nomeDaAnimação;
    public string nomeDaCena;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (IsAnimationFinished(nomeDaAnimação))
        {
            CarregarCena(nomeDaCena);
        }
    }
    bool IsAnimationFinished(string nomeDaAnimação)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(camada);
        return stateInfo.IsName(nomeDaAnimação) && stateInfo.normalizedTime >= 1.0f;
    }
    void CarregarCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}