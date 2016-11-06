using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AI_Couple : HostileParent {
	public float child_speed;
	public GameObject m_particle;
	public GameObject child_male;
	public NavMeshAgent child_nav;
    public bool catcatch=false;
    GameObject pc;

	void Start () {
	    Nav = GetComponent<NavMeshAgent>(); //네비게이션 컴포넌트 접근/연결
		Nav.speed = m_Speed; //스피드 값 설정
		child_nav = child_male.GetComponent<NavMeshAgent>(); //자식 네비게이션 컴포넌트 접근/연결
		child_nav.speed = child_speed; //자식 네비게이션 컴포넌트 속도값 설정
        setPlayer();
	}

	void OnTriggerExit(Collider col)
	{
        pc = col.gameObject;
        UpSprite.NowScore += 69;
		if (col.tag == "Player")
		{
			if (!attackMode)
			{
				//이벤트 발생, 공격 전환
				m_DeltaTime = 0.0f;
				attackMode = true;
				Nav.enabled = false;
				child_nav.enabled = true;
				StartingPoint = child_male.transform.position;
                col.GetComponent<PlayerControl>().kill=true;
			}
		}
	}
    void OnCollisionEnter(Collision col)
    {
 

    }
    void Update()
	{
		//시간차 합산
		m_DeltaTime += Time.deltaTime;
		if (!attackMode)
		{
			//랜덤이동 AI
			if (m_DeltaTime >= randomMoveDelay && Nav.enabled)
			{
                try
                {
                    randomMove(Nav, Distance);
                    m_DeltaTime -= randomMoveDelay;
                }
                catch (System.IndexOutOfRangeException e) {
                    Destroy(this);

                }
			}
		}
		//남자친구 방향설정
		if (attackMode )
		{
			//플레이어 포기
            if (m_DeltaTime >= followTime)
            {
                attackMode = false;
                 pc.GetComponent<PlayerControl>().kill = false;
                catcatch = false;
                child_nav.SetDestination(StartingPoint);

            }
            //플레이어 목표
            else
            {
                setPlayer();
                child_nav.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
                Invoke("CanCatch", 1);
            }
		}

		//원점으로 돌아왔을경우 오브젝트 제거
		Vector3 d = child_male.transform.position - StartingPoint;
		if (d.x * d.x + d.z * d.z < 20.0f && !attackMode)
		{
            Instantiate(m_particle, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}

		if (transform.position.x == Nav.destination.x && transform.position.z == Nav.destination.z)
		{
			m_animation.CrossFade("Male_Idle");
			m_animation2.CrossFade("Female_Idle");
		}
		else
		{
			m_animation.CrossFade("Male_Walk");
			m_animation2.CrossFade("Female_Walk");
		}
	}

    void OnDestroy()
    {
        UpSprite.NowScore += 176;
        switch(gameObject.layer)
        {
            case 8: //kid
                SpawnManager.CountData[2]--;
                break;
            case 9: //sand      
                SpawnManager.CountData[3]--;
                break;
            case 10: //walk
                SpawnManager.CountData[0]--;
                break;
            case 11: //water
                SpawnManager.CountData[1]--;
                break;
        }
        
    }

    void CanCatch() {
        catcatch = true;
    }
}
