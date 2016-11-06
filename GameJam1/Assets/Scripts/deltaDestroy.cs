using UnityEngine;
using System.Collections;

public class deltaDestroy : MonoBehaviour
{
	//시간차 오브젝트 삭제용 스크립트
	public float destroyDelay = 0.0f;
	public float m_delta = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		m_delta += Time.deltaTime;
		if (m_delta > destroyDelay)
			Destroy(this.gameObject);
	}
}
