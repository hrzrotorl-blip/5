using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlaneImage : MonoBehaviour
{
    public Renderer targetRenderer; // Plane�� MeshRenderer
    public Texture newTexture; // ��ü�� �̹���(Texture)

    void Start()
    {
        if (targetRenderer != null && newTexture != null)
        {
            targetRenderer.material.mainTexture = newTexture;
        }
    }
}
