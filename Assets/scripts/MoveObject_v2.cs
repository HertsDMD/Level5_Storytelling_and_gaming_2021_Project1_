using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveObject_v2 : MonoBehaviour
{

    Vector3 targetPosition;
    public LayerMask ObjectToSelectLayer;

    bool MouseClick;
    public Action MouseMoveEvent;
    RaycastHit2D hit;
    string selectedItemName;
    bool isDragging;
    public Action<string, bool> ItemSelectedEvent;
    ParticleSystem particles;

    LineRenderAnimation lineAnim;
    bool lineTrigger;
  

    private void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        lineAnim = FindObjectOfType<LineRenderAnimation>();
        lineTrigger = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // right mouse button click registered
        {
            MouseClick = true;          
        }
        else if (Input.GetMouseButton(0)) // right mouse button held down continuously
        {
            CastRayOnMousePress();
        }
        else if (Input.GetMouseButtonUp(0)) // right mouse button release registered
        {
            CastRayOnMouseReslease();
        }       
    }    

    void CastRayOnMousePress()
    {
        float circleCastRadius = 0.6f;
        PerformRaycast(circleCastRadius);   

        if (hit) // if the cursor has collided with an object
        {
            if (lineTrigger) lineAnim.EndLineAnimation(); lineTrigger = false;

            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().rotation = 0;

            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // gets the mouse position in world space - converts it from pixel space to world space
            targetPosition.z = hit.collider.gameObject.transform.position.z; // retains the hit object' s original z position
            hit.collider.gameObject.transform.position = targetPosition; // updates the hit object's position to match the target positions
            particles.gameObject.transform.position = hit.collider.gameObject.transform.position;

            isDragging = true;
            ItemSelectedEvent?.Invoke(selectedItemName = hit.collider.gameObject.transform.name, isDragging);

            if (MouseClick)
            {
                MouseMoveEvent?.Invoke();              
                particles.Play();
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red; // turns the selected object red

                MouseClick = false;
            }
        }
    }
   
    void CastRayOnMouseReslease()
    {
        float circleCastRadius = 5f;
        PerformRaycast(circleCastRadius);

        if (hit) // if the cursor has collided with an object
        {
            isDragging = false;
            ItemSelectedEvent?.Invoke(selectedItemName, isDragging);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    RaycastHit2D PerformRaycast(float circleCastRadius) // performs a CircleCast from the cursor's position and returns an object's Hit point
    {
        //float rayRadius = 0.6f;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // shoots out a ray form the mouse position
        hit = Physics2D.CircleCast(ray.origin, circleCastRadius, ray.direction, Mathf.Infinity, ObjectToSelectLayer);
        return hit;
    }
}
