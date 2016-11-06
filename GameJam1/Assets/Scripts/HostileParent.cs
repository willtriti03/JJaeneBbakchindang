using UnityEngine;
using System.Collections;

public class HostileParent : MonoBehaviour
{
    public NavMeshAgent Nav;
    public Vector3 StartingPoint;
    public Transform Target_Player;
    public Animation m_animation, m_animation2;
    public GameObject go;
    public PlayerControl plcon;

    public int Distance; //이동 반경
    public bool dieCheck = false;
    public bool attackMode; //공격유무
    public float m_Speed;
    public float randomMoveDelay; //랜덤이동 딜레이
    public float m_DeltaTime; //시간차 계산용 변수
    public float followTime; //플레이어를 쫓는시간

    // Use this for initialization
    void Start()
    {
        //Target_Player = GameObject.FindGameObjectWithTag("Player").transform;
        plcon = GetComponent<PlayerControl>();

        Target_Player = plcon.tr.transform;

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void setPlayer()
    {
        Target_Player = go.transform;

    }
    public void randomMove(NavMeshAgent _nav, float distance)
    {

        _nav.destination = new Vector3(Random.Range(transform.position.x - distance, transform.position.x + distance),
            transform.position.y, Random.Range(transform.position.z - distance, transform.position.z + distance));


    }
}
