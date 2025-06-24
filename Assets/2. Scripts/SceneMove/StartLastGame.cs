using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLastGame : MonoBehaviour
{
    public void StartMiniGame()
    {
        SceneManager.LoadScene("7. LastGameScene");
    }
}
