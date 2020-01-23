using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenEnable : MonoBehaviour
{
    public int index;

    private void Start()
    {
        StartCoroutine(scenepls());
    }

    IEnumerator scenepls() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(index);
    }
}
