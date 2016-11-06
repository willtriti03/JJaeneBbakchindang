using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class BestManager
{
    public static int BestScore = 0;
}

public class UpSprite : MonoBehaviour
{
    public static int NowScore = 0; // 현재 점수를 가져왔다고 가정(여기에 실제 점수를 저장)
    
    //int temp; // 임시 변수
    //public int change; // 자릿수를 나눠줌

    public Sprite[] Score = new Sprite[10]; // 0~9까지의 숫자스프라이트
    public Image[] ScoreImage1 = new Image[5]; // 이미지 다섯자리 이미지들1
    public Image[] ScoreImage2 = new Image[5]; // 이미지 다섯자리 이미지들2
    //public int[] cipher = new int[5]; // 자릿수 배열

    // Use this for initialization
    void Start()
    {
        Debug.Log(NowScore);
        if (NowScore > BestManager.BestScore)
        {
            BestManager.BestScore = NowScore;
        }

        ShowScore(NowScore, ScoreImage1);
        ShowScore(BestManager.BestScore, ScoreImage2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShowScore(int score, Image []ScoreImage)
    {
        for (int i = 4; i >= 0; --i)
        {
            ScoreImage[i].GetComponent<Image>().sprite = Score[score % 10];
            score /= 10;
        }
        /*
        change = 10000; // 초기 나누기값
        temp = score;

        for (int i = 0; i < 5; i++)
        {
            cipher[i] = temp / change; // 자릿수 나누기
            if (i == 4)
            {
                break;
            }
            temp %= change; // 아랫자릿수로 변경
            change /= 10; // 나누는 값도 변경
        }

        for (int i = 0; i < 10; i++)
        {
            if (cipher[0] == 0)
            {

            }
            else if (cipher[0] == i)
            {
                ScoreImage[0].GetComponent<Image>().sprite = Score[i];
            }

            if (cipher[0] == 0 && cipher[1] == 0)
            {

            }
            else if (cipher[1] == i)
            {
                ScoreImage[1].GetComponent<Image>().sprite = Score[i];
            }

            if (cipher[0] == 0 && cipher[1] == 0 && cipher[2] == 0)
            {

            }
            else if (cipher[2] == i)
            {
                ScoreImage[2].GetComponent<Image>().sprite = Score[i];
            }

            if (cipher[0] == 0 && cipher[1] == 0 && cipher[2] == 0 && cipher[3] == 0)
            {

            }
            else if (cipher[3] == i)
            {
                ScoreImage[3].GetComponent<Image>().sprite = Score[i];
            }

            if (cipher[4] == i)
            {
                ScoreImage[4].GetComponent<Image>().sprite = Score[i];
            }
        }*/
    }
}
