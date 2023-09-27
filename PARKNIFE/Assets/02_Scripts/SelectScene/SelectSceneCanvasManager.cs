using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectSceneCanvasManager : MonoBehaviour
{
    public GameObject StageIcon;
    public GameObject StageName;
    public GameObject StageNameBack;
    public GameObject TutorialStageName;
    public GameObject TutorialStageNameBack;
    public GameObject Stage1Name;
    public GameObject Stage1NameBack;
    public GameObject Stage2Name;
    public GameObject Stage2NameBack;
    public GameObject SelectTutorial;
    public GameObject Select1;
    public GameObject Select2;


    public bool canvas_state = false;
    int state = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas_state == true)
        {
            StageIcon.SetActive(false);
            StageName.SetActive(false);
            StageNameBack.SetActive(false);
            TutorialStageName.SetActive(true);
            TutorialStageNameBack.SetActive(true);
            Stage1Name.SetActive(true);
            Stage1NameBack.SetActive(true);
            Stage2Name.SetActive(true);
            Stage2NameBack.SetActive(true);

            if (state == 1)
            {
                SelectTutorial.SetActive(true);
                Select1.SetActive(false);
                Select2.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("Tutorial");
                }
            }
            else if(state == 2)
            {
                SelectTutorial.SetActive(false);
                Select1.SetActive(true);
                Select2.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Space))
                {

                }
            }
            else if(state == 3)
            {
                SelectTutorial.SetActive(false);
                Select1.SetActive(false);
                Select2.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {

                }
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                state = state + 1;

                if (state >= 4)
                {
                    state = 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.W))
            {
                state = state - 1;

                if(state <= 0)
                {
                    state = 3;
                }
            }

        }
    }
}
