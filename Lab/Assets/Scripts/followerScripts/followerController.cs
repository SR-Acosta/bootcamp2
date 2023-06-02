using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class followerController : MonoBehaviour
{
    private Animator _animator;
    public Transform _followerGX;
    private AIPath _aiPath;
    public Transform barraVidaBurro;
    public Slider slider;
    public float lifeCount;
    public Gradient gradient;
    public Image fill;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _aiPath = GetComponent<AIPath>();
        slider.maxValue = lifeCount;
        slider.value = slider.maxValue;
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(false);
        fill.color = gradient.Evaluate(1f);
    }
    private void Update()
    {
        Flip();
        Movement();
        Slider();
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
        Vector2 direction = _aiPath.desiredVelocity;
        if (direction.x > 0.2f)
        {
            _followerGX.transform.localScale = new Vector3(-1f, 1f, 1f);
            barraVidaBurro.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (direction.x < -0.2f)
        {
            _followerGX.transform.localScale = new Vector3(1f, 1f, 1f);
            barraVidaBurro.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void Movement()
    {
        Vector2 direction = _aiPath.desiredVelocity;
        if (direction.x > 0.2f)
        {
            _animator.SetFloat("moveX",direction.x);
        }
        if (direction.x < -0.2f)
        {
            _animator.SetFloat("moveX",direction.x);
        }
        if (direction.y > 0.2f)
        {
            _animator.SetFloat("moveY",direction.y);
        }
        if (direction.y < -0.2f)
        {
            _animator.SetFloat("moveY",direction.y);
        }
    }
    public void TakeDamageFollower(float damage)
    {
        slider.value -= damage;
        if (slider.value <= 0)
        {
            Die();   
        }
    }
    private void Die()
    {
        Destroy(gameObject, 2f);
    }
}