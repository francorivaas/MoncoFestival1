using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public GameObject target;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > target.transform.position.x)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;

    }
}
