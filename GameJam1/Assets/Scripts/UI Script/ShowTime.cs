using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShowTime : MonoBehaviour {

    public Text ShowMinute; // 보여주는 00분
    public Text ShowMinute_; // 보여주는 0분
    public Text ShowSecond; // 보여주는 00초
    public Text ShowSecond_; // 보여주는 0초
    public int HaveTime; // 실제 시간

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HaveTime = FlowTime.TimeData[0];
        ShowMinute.text = HaveTime.ToString();
        HaveTime = FlowTime.TimeData[1];
        ShowMinute_.text = HaveTime.ToString();
        HaveTime = FlowTime.TimeData[2];
        ShowSecond.text = HaveTime.ToString();
        HaveTime = FlowTime.TimeData[3];
        ShowSecond_.text = HaveTime.ToString();

        if(FlowTime.TimeData[0] == 0 && FlowTime.TimeData[1] == 0 && FlowTime.TimeData[2] == 0 && FlowTime.TimeData[3] == 1)
        {
            SceneManager.LoadScene(2);
        }
    }
}
