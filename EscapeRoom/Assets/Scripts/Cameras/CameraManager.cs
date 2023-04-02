using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraManager : MonoBehaviour
{
    Camera mainCamera;

    [SerializeField] GameObject movePanel;
    [SerializeField] GameObject backButton;
    //[SerializeField] GameObject upButton;

    // 全体を回転するカメラのポジションを作成
    [SerializeField] Transform[] mainCameraTransforms = default;
    int currentMainPosition = default;

    PhysicsRaycaster raycaster;
    LayerMask eventMask;
    LayerMask zoomEventMask;

    //どのファイルからでも関数が実行できるようにする
    public static CameraManager instance;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        mainCamera = Camera.main;
        currentMainPosition = 0;
        CamPosChange();

        backButton.SetActive(false);
        
        //最初はブレーカーだけに集中させるため移動ボタンは消す
        HideMoveButton();
        

        //Raycasaterの取得
        if (TryGetComponent<PhysicsRaycaster>(out this.raycaster))
        {
            this.eventMask = this.raycaster.eventMask;
        }    
        zoomEventMask = Camera.main.GetComponent<PhysicsRaycaster>().eventMask;
    }

    public void TurnLeft()
    {
        currentMainPosition--;
        if(currentMainPosition < 0)
        {
            currentMainPosition = mainCameraTransforms.Length-1;
        }
        CamPosChange();

    }

    public void TurnRight()
    {
        currentMainPosition++;
        if(currentMainPosition >= mainCameraTransforms.Length)
        {
            currentMainPosition = 0;
        }
        CamPosChange();
    }

    public void SetZoomCamera(Transform transform)
    {
        mainCamera.transform.position = transform.position;
        mainCamera.transform.rotation = transform.rotation;

        HideMoveButton();
        backButton.SetActive(true);

        Camera.main.GetComponent<PhysicsRaycaster>().eventMask = this.eventMask;
    }

    public void OnBackButton()
    {
        CamPosChange();

        ShowMoveButton();
        backButton.SetActive(false);
        Camera.main.GetComponent<PhysicsRaycaster>().eventMask = zoomEventMask;
    }

    void CamPosChange()
    {
        mainCamera.transform.position = mainCameraTransforms[currentMainPosition].position;
        mainCamera.transform.rotation = mainCameraTransforms[currentMainPosition].rotation;
    }

    public void HideMoveButton()
    {
        //全ての移動ボタンを非表示にする
        movePanel.SetActive(false);
        backButton.SetActive(false);
    }

    public void ShowMoveButton()
    {
        //全ての移動ボタンを表示する
        movePanel.SetActive(true);
        backButton.SetActive(true);
    }
}