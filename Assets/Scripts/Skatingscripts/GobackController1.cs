using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GobackController1 : MonoBehaviour {

    private Button button;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Start_scenes");
    }
}
