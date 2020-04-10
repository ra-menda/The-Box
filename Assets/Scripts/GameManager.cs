using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;    //前
    public const int WALL_RIGHT = 2;    //右
    public const int WALL_BACK = 3;     //後
    public const int WALL_LEFT = 4;     //左

    //定数定義：ボタンカラー
    public const int COLOR_GREEN = 0;   //緑
    public const int COLOR_RED = 1;     //赤
    public const int COLOR_BLUE = 2;    //青
    public const int COLOR_WHITE = 3;   //白

    public GameObject panelWalls;       //壁全体

    public GameObject buttonHammer;     //ボタントンカチ

    public GameObject imageHammerIcon;  //アイコン：トンカチ

    public GameObject buttonMessage;    //ボタン：メッセージ
    public GameObject buttonMessageText;    //メッセージテキスト

    public GameObject[] buttonLamp = new GameObject[3]; //ボタン：金庫
    public Sprite[] buttonPicture = new Sprite[4];  //ボタンの絵

    public Sprite hammerPicture;                    //トンカチの絵

    private int wallNo;                 //現在の向いている方向
    private bool doesHaveHammer;        //トンカチを持っているか？
    private int[] buttonColor = new int[3]; //金庫のボタン


    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT;            //スタート時点では「前」を向く
        doesHaveHammer = false;  //ハンマー持ってない

        buttonColor [0] = COLOR_GREEN;  //ボタン1は緑
        buttonColor [1] = COLOR_RED;    //ボタン2は赤
        buttonColor [2] = COLOR_BLUE;   //ボタン3は青
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボタン1をタップ
    public void PushBottonLamp1(){
        ChangeButtonColor (0);
    }

     //ボタン2をタップ
    public void PushBottonLamp2(){
        ChangeButtonColor (1);
    }

     //ボタン3をタップ
    public void PushBottonLamp3(){
        ChangeButtonColor (2);
    }

    //金庫のボタンの色変更
    void ChangeButtonColor(int buttonNo){
        buttonColor [buttonNo]++;
        //白のときにボタンを押したら緑に
        if(buttonColor [buttonNo] > COLOR_WHITE){
            buttonColor [buttonNo] = COLOR_GREEN;
        }

        //画像変更
        buttonLamp[buttonNo].GetComponent<Image>().sprite =
            buttonPicture [buttonColor [buttonNo]];
    }

    //メモをタップ
    public void PushButtonMemo(){
        DisplayMessage ("エッフェル塔と書いてある");
    }

    //メッセージタップ
    public void PushButtonMessage() {
        buttonMessage.SetActive (false);    //メッセージを消す
    }

    //右ボタンを押した
    public void PushButtonRight () {
        wallNo++;   //右へ
        
        if (wallNo > WALL_LEFT) {
            wallNo = WALL_FRONT;
        }
        DisplayWall ();//壁表示更新
    }

    //左ボタンを押した
    public void PushButtonLeft () {
        wallNo--;   //左へ
        
        if (wallNo < WALL_FRONT) {
            wallNo = WALL_LEFT;
        }
        DisplayWall ();//壁表示更新
    }

    //メッセージを表示
    void DisplayMessage(string mes){
        buttonMessage.SetActive (true);
        buttonMessageText.GetComponent<Text> ().text = mes;
    }

    //向いている方向の壁を表示
    void DisplayWall() {
        switch (wallNo) {
            case WALL_FRONT:    //前
                panelWalls.transform.localPosition =new Vector3 (0.0f, 0.0f ,0.0f);
                break;  

            case WALL_RIGHT:    //右
                panelWalls.transform.localPosition =new Vector3 (-1000.0f, 0.0f ,0.0f);
                break;
            
            case WALL_BACK:    //後
                panelWalls.transform.localPosition =new Vector3 (-2000.0f, 0.0f ,0.0f);
                break;
            
            case WALL_LEFT:    //左 
                panelWalls.transform.localPosition =new Vector3 (-3000.0f, 0.0f ,0.0f);
                break;
        }
    }
}
