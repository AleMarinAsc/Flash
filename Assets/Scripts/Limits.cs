using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    private Transform theThransform;
    public Vector2 Hrange = Vector2.zero;
    public Vector2 Vrange = Vector2.zero;

    // Start is called before the first frame update
    void LateUpdate()
    {
        theThransform.position = new Vector3( 
            Mathf.Clamp(transform.position.x, Hrange.x, Hrange.y),
            Mathf.Clamp(transform.position.y, Vrange.x, Vrange.y),
            transform.position.z
        );
    }

    void Start()
    {
        theThransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
