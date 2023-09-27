using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playereye : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Robot1" && Input.GetKeyDown(KeyCode.F))
        {
            //Robot1の選択に関するスクリプト
            SelectScenePlayerController SelectScenePlayerController;
            GameObject player = GameObject.Find("Player");
            SelectScenePlayerController = player.GetComponent<SelectScenePlayerController>();
            SelectScenePlayerController.player_state = false;

            
            SelectSceneCameraController SelectSceneCameraController;
            GameObject camera = GameObject.Find("CameraCenterPoint");
            SelectSceneCameraController = camera.GetComponent<SelectSceneCameraController>();
            SelectSceneCameraController.camera_state = false;


            SelectSceneCanvasManager SelectSceneCanvasManager;
            GameObject canvas = GameObject.Find("CanvasManager");
            SelectSceneCanvasManager = canvas.GetComponent<SelectSceneCanvasManager>();
            SelectSceneCanvasManager.canvas_state = true;

        }
    }
}
