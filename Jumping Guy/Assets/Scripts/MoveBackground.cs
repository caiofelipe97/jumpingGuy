using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private Renderer backGroundRenderer;
    private Material actualMaterial;
    public float incrementOffSet;
    public int orderRenderer;
    private float offSet;
    public float speed;

        // Start is called before the first frame update
    void Start()
    {
        backGroundRenderer = GetComponent<Renderer>();
        backGroundRenderer.sortingOrder = orderRenderer;
        actualMaterial = backGroundRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        offSet += incrementOffSet;
        actualMaterial.SetTextureOffset("_MainTex", new Vector2(offSet * speed, 0));
    }
}
