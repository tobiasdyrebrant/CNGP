﻿using UnityEngine;
using System.Collections;
using Engine;

public class CylinderSpell : MonoBehaviour {
	
	public ActiveSkill CylinderActiveSkill = new ActiveSkill();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (CylinderActiveSkill.Name.CompareTo("Ice floor") == 0) 
		{
			//Debug.Log("local scale = " + transform.localScale);
			//transform.localScale = new Vector3(transform.localScale.x * (float)Scale,  transform.localScale.y, transform.localScale.z * (float)Scale);

			transform.localScale = Vector3.one * (float)CylinderActiveSkill.Radius;
			
			CylinderActiveSkill.Radius +=  (1 * Time.deltaTime);
			

		}
	}
	
	public void Init(ActiveSkill AS)
	{
		CylinderActiveSkill.Name = AS.Name;
		CylinderActiveSkill.Info = AS.Info;
		CylinderActiveSkill.DamageHealingPower = AS.DamageHealingPower;
		CylinderActiveSkill.ChiCost = AS.ChiCost;
		CylinderActiveSkill.Radius = AS.Radius;
		CylinderActiveSkill.SingleTarget = AS.SingleTarget;
		CylinderActiveSkill.SelfTarget = AS.SelfTarget;
		CylinderActiveSkill.AllyTarget = AS.AllyTarget;
		CylinderActiveSkill.DoCollide = AS.DoCollide;
		CylinderActiveSkill.Cooldown = AS.Cooldown;
		CylinderActiveSkill.Range = AS.Range;
		CylinderActiveSkill.ChannelingTime = AS.ChannelingTime;
		CylinderActiveSkill.CastSpeed = AS.CastSpeed;
		CylinderActiveSkill.BuffEffectList = AS.BuffEffectList;
	}
	
	public ActiveSkill AdjustActiveSkillValues(ActiveSkill AS, PlayerStats PS)
	{
		ActiveSkill AdjustedActiveSkill = new ActiveSkill ();
		
		AdjustedActiveSkill.Name = AS.Name;
		AdjustedActiveSkill.Info = AS.Info;
		AdjustedActiveSkill.DamageHealingPower = AS.DamageHealingPower * (PS.stats.Damage / 100);
		AdjustedActiveSkill.ChiCost = AS.ChiCost;
		AdjustedActiveSkill.Radius = AS.Radius * (PS.stats.Skillradius / 100);
		AdjustedActiveSkill.SingleTarget = AS.SingleTarget;
		AdjustedActiveSkill.SelfTarget = AS.SelfTarget;
		AdjustedActiveSkill.AllyTarget = AS.AllyTarget;
		AdjustedActiveSkill.DoCollide = AS.DoCollide;
		AdjustedActiveSkill.Cooldown = AS.Cooldown / (PS.stats.Cooldownduration / 100);
		AdjustedActiveSkill.Range = AS.Range * (PS.stats.Skillrange / 100);
		AdjustedActiveSkill.ChannelingTime = AS.ChannelingTime;
		AdjustedActiveSkill.CastSpeed = AS.CastSpeed;
		AdjustedActiveSkill.BuffEffectList = AS.BuffEffectList;

		if(AdjustedActiveSkill.BuffEffectList.Count != 0)
		{
			for(int i = 0; i < AdjustedActiveSkill.BuffEffectList.Count; i++)
			{
				if(AdjustedActiveSkill.BuffEffectList[i].Effect.Stun > 0)
				{
					AdjustedActiveSkill.BuffEffectList[i].Effect.Stun = AdjustedActiveSkill.BuffEffectList[i].Effect.Stun * (PS.stats.Debuffeffectduration / 100);
				}

				if(AdjustedActiveSkill.BuffEffectList[i].Effect.Root > 0)
				{
					AdjustedActiveSkill.BuffEffectList[i].Effect.Root = AdjustedActiveSkill.BuffEffectList[i].Effect.Root * (PS.stats.Debuffeffectduration / 100);
				}

				if(AdjustedActiveSkill.BuffEffectList[i].Effect.Silence > 0)
				{
					AdjustedActiveSkill.BuffEffectList[i].Effect.Silence = AdjustedActiveSkill.BuffEffectList[i].Effect.Silence * (PS.stats.Debuffeffectduration / 100);
				}

				if(AdjustedActiveSkill.BuffEffectList[i].Effect.Dot > 0)
				{
					AdjustedActiveSkill.BuffEffectList[i].Effect.Dot = AdjustedActiveSkill.BuffEffectList[i].Effect.Dot * (PS.stats.Debuffeffectduration / 100);
				}

				if(AdjustedActiveSkill.BuffEffectList[i].Effect.Hot > 0)
				{
					AdjustedActiveSkill.BuffEffectList[i].Effect.Hot = AdjustedActiveSkill.BuffEffectList[i].Effect.Hot * (PS.stats.Buffeffectduration / 100);
				}

				if(AdjustedActiveSkill.BuffEffectList[i].Effect.Slow > 0)
				{
					AdjustedActiveSkill.BuffEffectList[i].Effect.Slow = AdjustedActiveSkill.BuffEffectList[i].Effect.Slow * (PS.stats.Debuffeffectduration / 100);
				}
			}
		}
		
		return AdjustedActiveSkill;
	}
}
