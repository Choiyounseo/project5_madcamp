using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Curlingstart : MonoBehaviour {

    // Use this for initialization
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
