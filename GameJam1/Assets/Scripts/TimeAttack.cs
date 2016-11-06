using UnityEngine;
using System.Collections;

public class TimeAttack : MonoBehaviour {
	public float total; //시간(초단위)
	public int[] TimeData; //시간(데이터)
	// Use this for initialization
	void Start () {
		TimeData = new int[4];
	}
	
	// Update is called once per frame
	void Update () {
		TimeUpdate(total);

		if (total >= 0.0f)
			total -= Time.deltaTime;
	}

	void TimeUpdate(float _second)
	{
		int minutes = (int)_second / 60;
		int second = (int)_second % 60;

		TimeData[0] = (int)minutes / 10;
		TimeData[1] = (int)minutes % 10;
		TimeData[2] = (int)second / 10;
		TimeData[3] = (int)second % 10;
	}
}
