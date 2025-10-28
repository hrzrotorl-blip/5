using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlaneImage : MonoBehaviour
{
    public Renderer targetRenderer; // Plane의 MeshRenderer
    public Texture newTexture; // 교체할 이미지(Texture)

    void Start()
    {
        if (targetRenderer != null && newTexture != null)
        {
            targetRenderer.material.mainTexture = newTexture;
        }
    }
}
