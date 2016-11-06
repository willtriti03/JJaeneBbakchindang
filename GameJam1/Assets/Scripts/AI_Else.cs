using UnityEngine;
using System.Collections;

public class AI_Else : HostileParent{

	public GameObject m_particle;

	// Use this for initialization
	void Start()
	{
		Nav = GetComponent<NavMeshAgent>(); //네비게이션 컴포넌트 접근/연결
		Nav.speed = m_Speed; //스피드 값 설정
	}

	// Update is called once per frame
	void Update()
	{
		//시간차 합산
		m_DeltaTime += Time.deltaTime;

		//이벤트 발생
		if (Input.GetKey(KeyCode.R))
		{
			attackMode = true;
			m_DeltaTime = 0.0f;
			StartingPoint = transform.position;
		}

		if (attackMode)
		{
			//플레이어 포기
			if (m_DeltaTime >= followTime)
			{
				attackMode = false;
				Nav.SetDestination(StartingPoint);
				dieCheck = true;
			}
			//플레이어 목표
			else
				Nav.SetDestination(Target_Player.position);
		}

		if (!attackMode)
		{
			if (!dieCheck)
			{
				randomMove(Nav, Distance);
				m_DeltaTime -= randomMoveDelay;
			}

			if (transform.position == StartingPoint)
			{
				Instantiate(m_particle, transform.position, transform.rotation);
				Destroy(this.gameObject);
			}
		}

		if (transform.position.x == Nav.destination.x && transform.position.z == Nav.destination.z)
		{
			m_animation.CrossFade("Male_Idle");
			m_animation2.CrossFade("Female_Idle");
		}
	}
}
