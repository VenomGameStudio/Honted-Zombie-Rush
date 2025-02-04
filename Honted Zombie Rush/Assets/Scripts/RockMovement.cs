﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : PlatformMovement
{
    [SerializeField] private Vector3 topPosition;
    [SerializeField] private Vector3 bottomPosition;
    [SerializeField] private float movementSpeed;

    void Start()
    {
        StartCoroutine(Move(bottomPosition));
    }

    protected override void Update()
    {
        if(GameManager.instance.PlayerActive)
            base.Update();
    }

    IEnumerator Move(Vector3 target)
    {
        while(Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * movementSpeed * Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(Move(newTarget));
    }

}
