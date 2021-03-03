using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    Vector3 targetPosition;
    public LayerMask ObjectToSelectLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            CastRay();
        }

    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // shoots out a ray form the mouse position
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, ObjectToSelectLayer); // performs a raycast hit form the mouse position in the z direction
        if (hit)
        {
            // Debug.Log(hit.collider.gameObject.name);
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // gets the mouse position in world space - converts it from pixel space to world space
            targetPosition.z = hit.collider.transform.position.z; // retains the hit object' s original z position

            hit.collider.transform.position = targetPosition; // updates the hit object's position to match the target positions
        }
    }
}
