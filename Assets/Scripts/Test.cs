using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose);
        transform.DOMove(new Vector3(48, 12, -9), 5).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOMove(new Vector3(-48, 12, -9), 5).SetEase(Ease.InCubic);
        });
    }
}
