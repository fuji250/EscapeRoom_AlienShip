using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineGimmick : MonoBehaviour
{
    //�M�~�b�N����������A�C�e�����O�Őݒ�ł���悤�ɂ���
    [SerializeField] Item.Type clearItem = default;

    private bool isOpen = false;

    private BoxCollider code1;

    public List<Collider> codesColiderList;
    public List<GameObject> onCodesList;
    public List<GameObject> offCodesList;

    private Collider clickColider;
    
    private Camera  mainCamera= default;

    private void Start()
    {
        mainCamera= Camera.main;

        foreach (var onCode in onCodesList)
        {
            onCode.SetActive(false);
        }

        foreach (var offCode in offCodesList)
        {
            offCode.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickCode();
        }
    }

    public void OnClickObj()
    {
        //TODO �R���C�_�[����������������
        if (isOpen)
        {
            Debug.Log("s");
            // �A�C�e��Cube�������Ă��邩�ǂ���
            bool Clear = ItemBox.instance.TryUseItem(clearItem);
            if(Clear == true) // �N���A�A�C�e���������Ă���ꍇ
            {
                Debug.Log("�M�~�b�N����");
                gameObject.SetActive(false);    // TODO:�W���J���A�j���[�V������ǉ� 
            }
            else
            {
                Debug.Log("�J���Ȃ��݂�����");
            }
        }
    }
    
    public void OnClickCode()
    {
        clickColider = null;
 
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
 
        if (Physics.Raycast(ray, out hit)) {
            clickColider = hit.collider;
        }

        for (int i = 0; i < codesColiderList.Count; i++)
        {
            if (clickColider == codesColiderList[i])
            {
                SwitchOnOff(i);
            }
        }
    }

    void SwitchOnOff(int position)
    {
        if (offCodesList[position].activeSelf == true)
        {
            onCodesList[position].SetActive(true);
            offCodesList[position].SetActive(false);
        }
        else
        {
            onCodesList[position].SetActive(false);
            offCodesList[position].SetActive(true);
        }
    }
    
}
