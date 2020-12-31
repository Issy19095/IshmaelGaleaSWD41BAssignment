using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.5f;

    //the material from the texture
    Material myMaterial;

    //the movement
    Vector2 offSet;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        //scroll in the y axis at that speed
        offSet = new Vector2(0f, backgroundScrollSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
