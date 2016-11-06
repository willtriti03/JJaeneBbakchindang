using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CrashCharater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player"&&col.gameObject.GetComponent<PlayerControl>().kill==true)
        {
            SceneManager.LoadScene(2);
        }

    }
}
