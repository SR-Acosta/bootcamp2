using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public float speed;
    public float moveX;
    public float moveY;
    public Transform gx;
    public Transform lifeBarGX;
    public float stayAfterDeath;
    //Slider
    public Slider slider;
    public float lifeCount;
    public Gradient gradient;
    public Image fill;
    
    public AudioSource _AudioSource;
    private playerAudioFX _audioFX;
    private void Start()
    {
        slider.maxValue = lifeCount;
        slider.value = slider.maxValue;
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(false);
        fill.color = gradient.Evaluate(1f);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        _audioFX = GetComponentInChildren<playerAudioFX>();
        _AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        Flip();
        Attack();
        MoveInY(); 
        Slider();
    }
    private void FixedUpdate()
    {
        Vector2 move = new Vector2(moveX, moveY);
        rb.velocity = speed * move;
    }
    private void Slider()
    {
        if (slider.value < slider.maxValue)
        {
            slider.gameObject.SetActive(true);
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    private void Flip()
    {
        if (moveX > 0.001)
        {
            gx.transform.localScale = new Vector3(1f, 1f, 1f);
            lifeBarGX.transform.localScale = new Vector3(1f, 1f, 1f);
            anim.SetFloat("moveX",moveX);
        }
        if (moveX < -0.001)
        {
            gx.transform.localScale = new Vector3(-1f, 1f, 1f);
            lifeBarGX.transform.localScale = new Vector3(-1f, 1f, 1f);

            anim.SetFloat("moveX",moveX);
        }
    }
    private void MoveInY()
    {
        if (moveY > 0.01) 
        {
            anim.SetFloat("moveY",moveY);
        }

        if (moveY < -0.01)
        {
            anim.SetFloat("moveY",moveY);
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown("k"))
        {
            anim.SetBool("isAttacking",true);
            _AudioSource.clip = _audioFX.sowrdAttack;
            _AudioSource.Play();
        }
        else
        {
            anim.SetBool("isAttacking",false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemiesAttack")
        {
            anim.SetBool("isHurt",true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemiesAttack")
        {
            anim.SetBool("isHurt",false);
        }
    }

    public void TakeHeal(float heal)
    {
        slider.value += heal;
    }
    
    public void TakeDamage(float damage)
    {
        slider.value -= damage;
        _AudioSource.clip = _audioFX.damage;
        _AudioSource.Play();
        if (slider.value  == 0)
        {
            Death();
        }
    }
    private void Death()
    {
        anim.SetBool("isDeath",true);
        Destroy(gameObject, stayAfterDeath);
        SceneManager.LoadScene("death");
    }
}