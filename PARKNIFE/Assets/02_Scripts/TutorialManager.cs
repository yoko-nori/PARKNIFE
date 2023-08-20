using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject TutorialGroup1;
    public GameObject TutorialGroup2;

    public GameObject MoveCheck;
    public GameObject CameraCheck;
    public GameObject AttackCheck;
    public GameObject JumpCheck;

    bool Moveflag   = false;
    bool Cameraflag = false;
    bool Attackflag = false;
    bool Jumpflag   = false;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの取得
        TutorialGroup1 = GameObject.Find("TutorialGroup1");
        TutorialGroup2 = GameObject.Find("TutorialGroup2");

        MoveCheck   = GameObject.Find("MoveCheck");
        CameraCheck = GameObject.Find("CameraCheck");
        AttackCheck = GameObject.Find("AttackCheck");
        JumpCheck   = GameObject.Find("JumpCheck");

        //非表示設定
        TutorialGroup2.SetActive(false);
        MoveCheck.SetActive(false);
        CameraCheck.SetActive(false);
        AttackCheck.SetActive(false);
        JumpCheck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Tutorial1();

        Change();

    }

    void Tutorial1()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            MoveCheck.SetActive(true);
            Moveflag = true;
        }
        else if (Input.GetMouseButton(1))
        {
            CameraCheck.SetActive(true);
            Cameraflag = true;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            AttackCheck.SetActive(true);
            Attackflag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpCheck.SetActive(true);
            Jumpflag = true;
        }
    }

    void Change()
    {
        if (Moveflag == true && Cameraflag == true && Attackflag == true && Jumpflag == true)
        {
            Invoke("Tutorial2", 2.0f);
        }

    }

    void Tutorial2()
    {
        TutorialGroup1.SetActive(false);
        TutorialGroup2.SetActive(true);
    }

    

}
