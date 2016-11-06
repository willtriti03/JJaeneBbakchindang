using UnityEngine;
using System.Collections;

public class AI_Police : HostileParent {

	public Ray m_ray;

	// Use this for initialization
	void Start () {
		Nav = GetComponent<NavMeshAgent>(); //네비게이션 컴포넌트 접근/연결
		Nav.speed = m_Speed; //스피드 값 설정
	}
	
	// Update is called once per frame
	void Update () {
		//랜덤 이동
		randomMove(Nav, Distance);

		//이벤트 발생
		if (Input.GetKey(KeyCode.R))
		{
			attackMode = true;
			m_DeltaTime = 0.0f;
			StartingPoint = transform.position;
		}
	}
}
