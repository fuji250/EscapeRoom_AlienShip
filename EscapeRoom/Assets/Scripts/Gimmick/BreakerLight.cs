using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class BreakerLight : MonoBehaviour
{
    [SerializeField] MeshRenderer mainLightMesh;
    [SerializeField] private Material[] lightMat;
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private int num = 0;
    [SerializeField] private MeshRenderer[] miniLightMesh;
    
    private float seconds = 0;
    
    int[] currentNum = { 1, 1, 1, 1 };//図形の数は1,1,1
    int[] correctAnserNum = { 2, 1, 2, 3 };//図形の数は3,3,2
    
    public UnityEvent ClearEvent;

    //[SerializeField] private GameObject emergencyLight;
    [SerializeField] private GameObject emergencyLight;
    
    // Start is called before the first frame update
    void Start()
    {
        //MainLight.GetComponent<MeshRenderer>().material;
        //emergencyLight.intensity = 0;
        emergencyLight.GetComponent<Light>().intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= duration && seconds <= duration*2)
        {
            if (mainLightMesh.material != lightMat[2])
            {
                mainLightMesh.material = lightMat[2];
            }
        }
        else if(seconds >= duration*2 && seconds <= duration*3)
        {
            if (mainLightMesh.material != lightMat[1])
            {
                mainLightMesh.material = lightMat[1];
            }
        }
        else if(seconds >= duration*3 && seconds <= duration*4)
        {
            if (mainLightMesh.material != lightMat[2])
            {
                mainLightMesh.material = lightMat[2];
            }
        }
        else if(seconds >= duration*4 && seconds <= duration*5)
        {
            if (mainLightMesh.material != lightMat[3])
            {
                mainLightMesh.material = lightMat[3];
            }
        }
        else if(seconds >= duration*5 && seconds <= duration*6)
        {
            if (mainLightMesh.material != lightMat[0])
            {
                mainLightMesh.material = lightMat[0];
            }
        }
        else if(seconds >= duration*6 && seconds <= duration*7)
        {
            seconds = 0;
        }
    }

    public void UpLight(int number)
    {
        if (currentNum[number] < 3)
        {
            currentNum[number]++;
            miniLightMesh[number].material = lightMat[currentNum[number]];
        }
        if (IsClear() == true)
        {
            Clear();
        }
    }
    public void DownLight(int number)
    {
        if (currentNum[number] > 1)
        {
            currentNum[number]--;
            miniLightMesh[number].material = lightMat[currentNum[number]];
        }
        if (IsClear() == true)
        {
            Clear();
        }
    }

    public void OnEmergencyLight()
    {
        //GetComponent<Animation>().Play();
        emergencyLight.GetComponent<Animation>().Play();
    }

    public void Clear()
    {
        Debug.Log("クリア");
        ClearEvent.Invoke();

        Destroy(this);
    }
    
    //クリアしているか判定する関数
    bool IsClear()
    {
        // 正解しているかどうか
        // =>１つでも一致しなければfalse
        // =>全てのチェックをクリアすればtrue
        for (int i = 0; i < correctAnserNum.Length; i++)
        {
            if (currentNum[i] != correctAnserNum[i])
            {
                return false;
            }
        }
        return true;
    }
}
