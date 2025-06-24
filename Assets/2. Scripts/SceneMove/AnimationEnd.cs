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
		video.loopPointReached += EndAnimation;
	}
    private void EndAnimation(VideoPlayer v)
	{
		SceneManager.LoadScene("6. StartLastScene");
	}
}
