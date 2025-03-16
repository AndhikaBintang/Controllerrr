using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    private CircleCollider2D[] _colliders;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _colliders = GetComponents<CircleCollider2D>();
    }

    public void Kill()
    {
        ComplexDeath();
    }

    private void ComplexDeath()
    {
        _animator.SetTrigger("Death");

        foreach (var circleCollider2D in _colliders)
        {
            circleCollider2D.enabled = false;
        }

        Wait(() =>
        {
            Destroy(gameObject);
        }, 2f);
    }

    public void Wait(Action action, float delay)
    {
        StartCoroutine(WaitCoroutine(action, delay));
    }

    IEnumerator WaitCoroutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);

        action();
    }
}
