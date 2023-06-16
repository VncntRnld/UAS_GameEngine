using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public bool isGrounded = false; // untuk mengecek karakter berada di ground
    public bool isFacingRight = false;
    public Transform batas1; //digunakan untuk batas gerak ke kiri
    public Transform batas2; // digunakan untuk batas gerak ke kanan

    public float speed = 2; // kecepatan enemy bergerak
    //Rigidbody2D rigid;
    Animator anim;
    public static int healthenemy = 100;
    public static bool isDead = false;
    public FloatingTextSpawner floatingTextSpawner;
    public Slider slide;
    public Text nyawa;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isDead = false;
        healthenemy = 100;
    }

    // Update is called once per frame
    void Update()
    {
        floatingTextSpawner.transform.position = transform.position;
        if (isGrounded)
        {
            if (isFacingRight)
                MoveRight();
            else
                MoveLeft();

            if (transform.position.x >= batas2.position.x && isFacingRight)
                Flip();
            else if (transform.position.x <= batas1.position.x && !isFacingRight)
                Flip();
        }
        if (healthenemy <= 100)
        {
            if (healthenemy <= 0)
            {
                nyawa.text = "0";
                slide.value = 0;
            }
            else
            {
                nyawa.text = healthenemy.ToString();
                slide.value = healthenemy;
            }
            
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.SendMessage("TakeDamage", 10*speed);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void MoveRight()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (!isFacingRight)
        {
            Flip();
        }
    }
    void MoveLeft()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
        if (isFacingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFacingRight = !isFacingRight;
    }
    void TakeDamage(int damage)
    {
        healthenemy = healthenemy - damage;
        Debug.Log(healthenemy);
        if (healthenemy <= 0)
        {
            anim.SetBool("dead", true);
            isDead = true;
            Destroy(this.gameObject, 2);
            
        }
        else
        {
            floatingTextSpawner.SpawnFloatingText(damage);
        }
    }

    

}
