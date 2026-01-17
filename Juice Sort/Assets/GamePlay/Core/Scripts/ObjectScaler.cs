using System;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField]
    private float mainAspect;

    private float currentAspect;

    public Action<float> onSetCurrentAspect;

    void Start()
    {
        SpriteRenderer renderer =  GetComponent<SpriteRenderer>();

        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        currentAspect = Camera.main.aspect;

        currentAspect = currentAspect / mainAspect;

        transform.localScale = transform.localScale * currentAspect;
        transform.localPosition= transform.position * currentAspect;

        onSetCurrentAspect?.Invoke(currentAspect);
    }
}
