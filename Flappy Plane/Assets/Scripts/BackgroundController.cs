using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Renderer myBackgroundMaterial;

    private float xOffset = 0f;

    private Vector2 textureOffset;

    private float speedBackground = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        myBackgroundMaterial = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xOffset += speedBackground * Time.deltaTime;
        textureOffset.x = xOffset;
        myBackgroundMaterial.material.mainTextureOffset = textureOffset;
    }
}
