using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinTesting : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneGameManager.Instance.FadeAndLoadScene(SceneName.Kasra.ToString(), transform.position);
        }
    }
}
