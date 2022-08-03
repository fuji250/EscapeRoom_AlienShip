using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    // カメラの切り替え
    // どこにどのカメラを有効にするのか
    // どこに
    // ・mainの全体を回転するカメラ
    // ・ズームしたときのカメラ

    Camera currentCamera;
    Camera mainCamera;

    [SerializeField] GameObject movePanel;
    [SerializeField] GameObject backButton;
    //[SerializeField] GameObject upButton;

    // 全体を回転するカメラのポジションを作成
    [SerializeField] Transform[] mainCameraTransforms = default;
    int currentMainPosition = default;


    //どのファイルからでも関数が実行できるようにする
    public static CameraManager instance;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        mainCamera = Camera.main;
        currentCamera = Camera.main;
        currentMainPosition = 0;
        currentCamera.transform.position = mainCameraTransforms[currentMainPosition].position;
        currentCamera.transform.rotation = mainCameraTransforms[currentMainPosition].rotation;

        backButton.SetActive(false);
    }

    public void TurnLeft()
    {
        currentMainPosition--;
        if(currentMainPosition < 0)
        {
            currentMainPosition = mainCameraTransforms.Length-1;
        }
        currentCamera.transform.position = mainCameraTransforms[currentMainPosition].position;
        currentCamera.transform.rotation = mainCameraTransforms[currentMainPosition].rotation;
    }

    public void TurnRight()
    {
        currentMainPosition++;
        if(currentMainPosition >= mainCameraTransforms.Length)
        {
            currentMainPosition = 0;
        }
        currentCamera.transform.position = mainCameraTransforms[currentMainPosition].position;
        currentCamera.transform.rotation = mainCameraTransforms[currentMainPosition].rotation;
    }


    public void OnUpButton(Camera camera)
    {
        currentCamera.gameObject.SetActive(false);
        camera.gameObject.SetActive(true);
        currentCamera = camera;

        HideMoveButton();
        backButton.SetActive(true);

    }

    public void OnDownButton(Camera camera)
    {
        currentCamera.gameObject.SetActive(false);
        camera.gameObject.SetActive(true);
        currentCamera = camera;

        HideMoveButton();
        backButton.SetActive(true);
    }

    public void SetZoomCamera(Camera camera)
    {
        currentCamera.gameObject.SetActive(false);
        camera.gameObject.SetActive(true);
        currentCamera = camera;

        HideMoveButton();
        backButton.SetActive(true);
    }

    public void OnBackButton()
    {
        mainCamera.gameObject.SetActive(true);
        currentCamera.gameObject.SetActive(false);
        currentCamera = mainCamera;

        ShowMoveButton();
        backButton.SetActive(false);
    }

    

    public void HideMoveButton()
    {
        //全ての移動ボタンを非表示にする
        movePanel.SetActive(false);
        backButton.SetActive(false);
        //upButton.SetActive(false);
    }

    public void ShowMoveButton()
    {
        //全ての移動ボタンを表示する
        movePanel.SetActive(true);
        backButton.SetActive(true);
        //upButton.SetActive(true);
    }
}