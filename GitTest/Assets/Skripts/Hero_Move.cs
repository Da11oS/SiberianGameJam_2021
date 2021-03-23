using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Move : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    //[SerializeField] private int leaves = 5;
    [SerializeField] private float jumpForce = 15f;
  

	private Rigidbody2D rb;
	private SpriteRenderer sprite;

	public Transform checkGround;
	public float checkRadius =0.5f;
	public LayerMask Ground;
	public bool onGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
	sprite = GetComponentInChildren<SpriteRenderer>();
    }

	private void Run()
{

	Vector3 dir = transform.right * Input.GetAxis("Horizontal");
	transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
	sprite.flipX = dir.x<0.0f;
}
	private void Jump()
{
	rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
}
	
	private void CheckGround()
	{
	  onGround =Physics2D.OverlapCircle(checkGround.position, checkRadius, Ground);
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal"))
	Run();
        if(onGround &&Input.GetButtonDown("Jump"))
	Jump();
    }

void FixedUpdate()
    {
CheckGround();
    }
}
