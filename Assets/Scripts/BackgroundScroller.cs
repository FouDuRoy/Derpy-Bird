using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    public float offSet;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offSet += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
    }
}
