using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Video;


public class OPManager : MonoBehaviour
{
    [SerializeField]
    VideoPlayer videoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += LoopPointReached;
        videoPlayer.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //videoPlayer.Stop();
            Initiate.Fade("Main", Color.black, 1.0f);
        }
    }

    public void LoopPointReached(VideoPlayer vp)
    {
        // 動画再生完了時の処理
        Initiate.Fade("Main", Color.black, 1.0f);
    }
}
