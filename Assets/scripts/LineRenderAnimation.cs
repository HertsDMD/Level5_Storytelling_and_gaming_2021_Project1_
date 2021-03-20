using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderAnimation : MonoBehaviour
{
    LineRenderer lineRenderer;
   
   
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.enabled = false;

        anim = GetComponent<Animator>();
    }  

    public void StartLineAnimation() 
    {
        lineRenderer.enabled = true;
        anim.SetBool("LineAnimation", true);
    }
    public void EndLineAnimation()
    {
        lineRenderer.enabled = false;
        anim.SetBool("LineAnimation", false);
    }   


}

