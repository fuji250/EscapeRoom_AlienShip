using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    // �J�����̐؂�ւ�
    // �ǂ��ɂǂ̃J������L���ɂ���̂�
    // �ǂ���
    // �Emain�̑S�̂���]����J����
    // �E�Y�[�������Ƃ��̃J����

    Camera currentCamera;
    Camera mainCamera;

    [SerializeField] GameObject movePanel;
    [SerializeField] GameObject backButton;
    //[SerializeField] GameObject upButton;

    // �S�̂���]����J�����̃|�W�V�������쐬
    [SerializeField] Transform[] mainCameraTransforms = default;
    int currentMainPosition = default;


    //�ǂ̃t�@�C������ł��֐������s�ł���悤�ɂ���
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

    public void SetZoomCamera(Transform transform)
    {
        currentCamera.transform.position = transform.position;
        currentCamera.transform.rotation = transform.rotation;

        HideMoveButton();
        backButton.SetActive(true);
    }

    public void OnBackButton()
    {
        currentCamera.transform.position = mainCameraTransforms[currentMainPosition].position;
        currentCamera.transform.rotation = mainCameraTransforms[currentMainPosition].rotation;

        ShowMoveButton();
        backButton.SetActive(false);
    }

    

    public void HideMoveButton()
    {
        //�S�Ă̈ړ��{�^�����\���ɂ���
        movePanel.SetActive(false);
        backButton.SetActive(false);
        //upButton.SetActive(false);
    }

    public void ShowMoveButton()
    {
        //�S�Ă̈ړ��{�^����\������
        movePanel.SetActive(true);
        backButton.SetActive(true);
        //upButton.SetActive(true);
    }
}