using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TitleButton_UI : MonoBehaviour
{

    public Animator squirrelAnim;
    public AudioSource buttonSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        squirrelAnim.enabled = false;
    }

    // Update is called once per frame
    public void Press()
    {
        squirrelAnim.enabled = true;
        StartCoroutine(SceneChange());
        
        
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
