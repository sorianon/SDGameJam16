﻿using UnityEngine;
using System.Collections;

public class AttackPlayers : WarriorState
{
    EnemyHealth _enemyHealth;
    MachineGun _machine_Gun_Script;
    public AttackPlayers(WarriorFSMOOP data) : base(data)
    {

    }

    public override void Init()
    {
        //data._fatigue = 5f;
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (next != null)
        {
            return;
        }
        data._target = GameObject.FindGameObjectWithTag("Player");
        _enemyHealth = GetComponent<EnemyHealth>();
        if (Vector3.Distance(data._target.transform.position, transform.position) < 1.5f)
        {
            _enemyHealth.Explode();
            //data._health -= data._fatigue * Time.deltaTime * data._fatigueRate;
            //data.arrive = true;
            //next = new Detonate(data);
        }
        
        if(data._target)
        {
            _machine_Gun_Script.Fire();
        }
        UpdateMove(data._player);
    }
    void OnCollisionEnter(Collision other)
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyHealth.Explode();
        Debug.Log("Exploded!");
        Debug.Log("I'm hit");
    }
}
