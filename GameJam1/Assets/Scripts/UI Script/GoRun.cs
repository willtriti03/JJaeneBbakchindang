using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoRun : MonoBehaviour {

    public static Slider ShowStamina;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerControl.running == true)
        {
            ShowStamina.value -= 2f * Time.deltaTime;
           
        }
        else
        {
            ShowStamina.value += 0.2f * Time.deltaTime;
        }
    }
}
