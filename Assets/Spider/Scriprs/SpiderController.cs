using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public GameObject spider;
    public float speed;
    public float jumpSpeed;
    Vector3 direction;
    private Animator animator;
    Quaternion rotation;
    private Rigidbody spiderRb;
    public bool isGround;
    public float toGround;
    public bool isDead;
    private bool isMaxDeathSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        spiderRb = spider.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (!isDead)
        {
            float forward = Input.GetAxis("Vertical");
            float right = Input.GetAxis("Horizontal");
            direction = new Vector3(transform.forward.x * speed * -forward, 0, transform.forward.z * speed * -forward) * Time.deltaTime;
            rotation = Quaternion.Euler(new Vector3(0, right, 0));
            if (isGround)
            {
                animator.SetFloat("Forward", forward);
                animator.SetFloat("Right", right);
            }
            if (!isGround)
            {
                animator.SetFloat("Forward", 0);
                animator.SetFloat("Right", 0);
            }
            transform.position += direction;
            transform.Rotate(rotation.eulerAngles);



            animator.SetFloat("vSpeed", spiderRb.velocity.y);



            Jump();
            if (Input.GetMouseButtonDown(0) && isGround)
                animator.SetTrigger("Attack");
            if (Input.GetMouseButtonDown(2) && isGround)
            {
                animator.SetTrigger("WebAttack");
                spiderRb.AddForce(0, jumpSpeed * Time.deltaTime, 0, ForceMode.Impulse);
                spiderRb.velocity = Vector3.zero;
            }
            if (spiderRb.velocity.y < -12)
            {
                isMaxDeathSpeed = true;
            }
        }
        if (isMaxDeathSpeed && isGround)
        {
            isDead = true;
            animator.enabled = false;
            animator.SetFloat("vSpeed", 0);
            animator.SetBool("isGround", false);
            animator.SetTrigger("isDead");
            animator.enabled = true;
            
        }
    }


    private void Jump()
    {
        Ray ray = new Ray(spider.transform.position, transform.TransformDirection(Vector3.down));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, toGround))
        {
            isGround = true;
            animator.SetBool("isGround", true);
        }
        else
        {
            isGround = false;
            animator.SetBool("isGround", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            spiderRb.velocity = new Vector3(0, 0, 0);
            spiderRb.AddForce(0, jumpSpeed * Time.deltaTime, 0, ForceMode.Impulse);
        }
    }
}
