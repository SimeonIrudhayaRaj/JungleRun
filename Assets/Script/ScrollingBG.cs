using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public Renderer bg;
    public float bgSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bg.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
}
