using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Projectile; // object peluru
    public Vector2 projectileVelocity; // kecepatan peluru
    public Vector2 projectileOffset; // jarak posisi peluru dari posisi player
    //public float cooldown = 0.5f; // jeda waktu untuk menembak
    bool isCanShoot = true; // memastikan untuk kapan dapat menembak
    public static bool isDiee = false;
    Animator anim;
    public static int healthplayer = 300;
    public FloatingTextSpawner floatingTextSpawner;
    public Slider slide;
    public Text nyawa;
    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
        healthplayer = 300;
        isDiee = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimerDMG.countdown = 1;
        }
        
        if (TimerDMG.countdown == 0)
        {
            Fire();
        }
        if(healthplayer <= 300)
        {
            if (healthplayer <= 0)
            {
                nyawa.text = "0";
                slide.value = 0;
            }
            else
            {
                nyawa.text = healthplayer.ToString();
                slide.value = healthplayer;
            }
        }
        
    }


    //private void Dead()
    //{
         //if (!isDead)
        // {
             //if (transform.position.y < -10f)
            // {
             // kondisi ketika jatuh
        //    isDead = true;
          // }
      //  }
    //}
    void Fire()
    {
        // jika karakter dapat menembak
        if (isCanShoot)
        {
        //Membuat projectile baru
            GameObject bullet = Instantiate(Projectile, (Vector2)transform.position - projectileOffset* transform.localScale.x, Quaternion.identity);
        // mengatur kecepatan dari projectile
            Vector2 velocity = new Vector2(projectileVelocity.x * transform.localScale.x, projectileVelocity.y);bullet.GetComponent<Rigidbody2D>().velocity = velocity* -1;
    
    
         //Menyesuaikan scale dari projectile dengan scale karakter
           Vector3 scale = transform.localScale;
            bullet.transform.localScale = scale* -1;
    
            StartCoroutine(CanShoot());
            anim.SetTrigger("shoot");
        }
    }
    
    IEnumerator CanShoot()
    {
    anim.SetTrigger("shoot");
    isCanShoot = false;
    yield return new WaitForSeconds(2);
    isCanShoot = true;
    anim.SetTrigger("idle");
    }

    void TakeDamage(int damage)
    {
        healthplayer = healthplayer - damage;
        Debug.Log(healthplayer);

        if (healthplayer <= 0)
        {
            isDiee = true;
            Destroy(this.gameObject, 2);
        }
        else
        {
            // Memanggil SpawnFloatingText() pada FloatingTextSpawner
            floatingTextSpawner.SpawnFloatingText(damage);
        }
    }


}
