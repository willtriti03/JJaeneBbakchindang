using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    static public int[] CountData = new int[4];
    static public bool[] WaterCoupleDat = new bool[5];
    public int[] MaxCountData = new int[4];
    public Vector3[] WaterCouplePos = new Vector3[5];
    public GameObject[] CoupleData = new GameObject[4];
    public bool spawnCheck = false;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 4; i++)
            CountData[i] = 0;
        for (int i = 0; i < 5; i++)
            WaterCoupleDat[i] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCheck == true)
        {
            for (int i = 0; i < 4; i++)
            {
                if (CountData[i] < MaxCountData[i])
                {
                    int Count = MaxCountData[i] - CountData[i];
                    for (int j = 0; j < Count; j++)
                        spawnCouple(i);
                }
            }
        }

    }

    public void spawnCouple(int key)
    {
        Vector3 position = randPos(0.0f, 600.0f, 0.0f, 1000.0f, key);
        switch (key)
        {
            case 1:
                int randNum;
                for (;;)
                {
                    randNum = Random.Range(0, 4);
                    WaterCoupleDat[randNum] = true;
                    Instantiate(CoupleData[1], new Vector3(position.x, position.y, position.z), Quaternion.identity);
                }
                break;

            default:
                Instantiate(CoupleData[key], new Vector3(position.x, position.y, position.z), Quaternion.identity);
                break;
        }
        CountData[key]++;
    }

    public Vector3 randPos(float min_x, float max_x, float min_z, float max_z, int key)
    {
        Vector3 _position;
        _position.x = Random.Range(min_x, max_x);
        _position.y = Terrain.activeTerrain.SampleHeight(transform.position);
        _position.z = Random.Range(min_z, max_z);
        Debug.Log(_position);
        return _position;
    }
}

