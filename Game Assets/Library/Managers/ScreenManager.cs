using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ScreenManager : PersistentSingletonManager<ScreenManager>
{
    private CancellationTokenSource cts = new CancellationTokenSource();
    void Start()
    {
        SetOrientation().Forget();
    }
    private async UniTaskVoid SetOrientation()
    {
        while (!cts.IsCancellationRequested)
        {
            await UniTask.WaitUntil(() => Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown);
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}
