using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class AnimationEnd : MonoBehaviour
{
	private VideoPlayer video;
    // Start is called before the first frame update
    private void Start()
    {
		video = GetComponent<VideoPlayer>();
        // 영상의 (루프 포인트) 끝에 도달했다면
		// video.loopPointReached += EndAnimation; // 이 스크립트가 두 개의 씬에서 쓰이므로 이 방법은 사용하지 않음
		
	}

    private void Update()
    {
        if(video.isPaused)
        {
            if (SceneManager.GetActiveScene().name == "5. AnimationScene")
            {
                SceneManager.LoadScene("6. StartLastScene");
            }
            else if(SceneManager.GetActiveScene().name == "8. EndingScene")
            {
                SceneManager.LoadScene("0. IntroScene");
            }
        }
    }
    /*
    private void EndAnimation(VideoPlayer v)
	{
		SceneManager.LoadScene("6. StartLastScene");
	}
    */

}
