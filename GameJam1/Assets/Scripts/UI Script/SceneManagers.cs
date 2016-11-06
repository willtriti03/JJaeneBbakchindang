using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagers : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
