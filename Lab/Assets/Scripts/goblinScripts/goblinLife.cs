using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class goblinLife : MonoBehaviour
{
    private Animator _animator;
    public int lifeAfterDeath;
    private Rigidbody2D _rigidbody;

    private waveManager _waveManager;
    private gameManager _gameManager;

    public Slider slider;
    public float lifeCount;
    public Gradient gradient;
    public Image fill;
    private enemyDropSystem _dropSystem;
    private void Start()
    {
        slider.maxValue = lifeCount;
        slider.value = slider.maxValue;
        slider = GetComponentInChildren<Slider>();
        slider.gameObject.SetActive(false);
        fill.color = gradient.Evaluate(1f);
        
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        
        _waveManager = GameObject.Find("gameManager").GetComponent<waveManager>();
        _gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
    }

    private void Update()
    {
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
    public void TakeDamage(float damage)
    {
        slider.value -= damage;
        if (slider.value == 0)
        {
            Die();
        }
    }
    private void Die()
    {
        _waveManager.enemiesSpawned -= 1;
        _gameManager.totalTreasures += 100;
        _rigidbody.isKinematic = true;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        _animator.SetBool("isDeath",true);
        Destroy(gameObject, lifeAfterDeath);
        _dropSystem.Defeat();
    }
}