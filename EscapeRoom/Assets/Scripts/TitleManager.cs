using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleManager : MonoBehaviour
{
    [SerializeField] private string loadScene;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeSpeedMultiplier = 1.0f;

    
    [SerializeField]
    private Button button = null;
    
    // Start is called before the first frame update
    void Start()
    {
        //SceneName.LoadSceneEx(SceneName.SceneID.Title);
    }

    public void StartNewGame()
    {
        Initiate.Fade("OP", fadeColor, fadeSpeedMultiplier);
        //SceneManager.LoadScene("Main");
        //音
    }

    public void StartLoadGame()
    {
    }
    
    
 
    /*
    public void ChangeScene(SceneName.SceneType sceneType)
    {
        
        SceneManager.LoadScene(sceneType.ToJpnName());
    }
    */
    


}
