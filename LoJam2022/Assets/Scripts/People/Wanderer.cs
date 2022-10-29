using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    // Start is called before the first frame update
    public float leftBound;
    public float rightBound;
    public float minSpeed;
    public float maxSpeed;
    private bool walkingLeft = true;
    Animator m_Animator;

    private float speed;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound)
        {
            m_Animator.SetBool("WalkLeft", true);
            walkingLeft = false;
        }
        else if (transform.position.x > rightBound)
        {
            m_Animator.SetBool("WalkLeft", false);
            walkingLeft = true;
        }
    }
    private void LateUpdate()
    {
        if (walkingLeft)
        {
            transform.Translate(Vector3.right * -speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
