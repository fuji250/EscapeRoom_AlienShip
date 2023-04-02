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

    // �S�̂���]����J�����̃|�W�V�������쐬
    [SerializeField] Transform[] mainCameraTransforms = default;
    int currentMainPosition = default;

    PhysicsRaycaster raycaster;
    LayerMask eventMask;
    LayerMask zoomEventMask;

    //�ǂ̃t�@�C������ł��֐������s�ł���悤�ɂ���
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
        
        //�ŏ��̓u���[�J�[�����ɏW�������邽�߈ړ��{�^���͏���
        HideMoveButton();
        

        //Raycasater�̎擾
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
        //�S�Ă̈ړ��{�^�����\���ɂ���
        movePanel.SetActive(false);
        backButton.SetActive(false);
    }

    public void ShowMoveButton()
    {
        //�S�Ă̈ړ��{�^����\������
        movePanel.SetActive(true);
        backButton.SetActive(true);
    }
}