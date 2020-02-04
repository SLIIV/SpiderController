using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public GameObject spider;
    public float speed;
    Vector3 direction;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        

        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");
        direction = new Vector3(forward * speed, 0, -right * speed) * Time.deltaTime;
        animator.SetFloat("Forward", forward);
        animator.SetFloat("Right", right);
        

        //transform.position += direction;
        
    }
}
