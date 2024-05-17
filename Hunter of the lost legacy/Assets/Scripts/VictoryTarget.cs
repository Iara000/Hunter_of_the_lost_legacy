using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryTarget : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene("Victory Scene");
    }
}
