﻿using UnityEngine;
using System.Collections;

public abstract class EffectBehaviour : MonoBehaviour
{

    public float Duration = 5.0f;

    protected float timer;

    protected virtual void Start()
    {
        timer = Duration;
        if (GetComponent<Weapon>() == null)
            this.ApplyEffect();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && GetComponent<Weapon>() == null)
        {
            Debug.Log(gameObject);
            Destroy(this);
        }
    }

    #region Effect
    abstract public void ApplyEffect();

    abstract public void RemoveEffect();

    abstract public override string ToString();
    #endregion
}
