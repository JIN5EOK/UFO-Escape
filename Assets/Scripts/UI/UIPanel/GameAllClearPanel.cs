using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAllClearPanel : UIBase
{
    private void Start()
    {
        StartCoroutine(GameEnd());
    }
    IEnumerator GameEnd()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        ScenesManager.Instance.LoadScene("MainMenu");
    }
}
