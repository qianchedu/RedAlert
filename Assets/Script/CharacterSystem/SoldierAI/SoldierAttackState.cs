/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              SoldierAttackState.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-06 
    *Description:           AedAlter
    *History:               自定义，可以不写内容，可以删除该行
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Red
{
    /// <summary>
    /// 角色攻击状态
    /// </summary>
	public class SoldierAttackState : ISoldierState
    {

        public SoldierAttackState(SoldierFSMSystem fsm, ICharacter character) : base(fsm,character)
        {
            mStateID = SoldierStateID.Attack;
            mAttackTimer = mAttackTime;
        }


        /// <summary>
        /// 攻击周期
        /// </summary>
        private float mAttackTime = 1;

        /// <summary>
        /// 计时器
        /// </summary>
        private float mAttackTimer = 1;


        public override void Act(List<ICharacter> targets)
        {
            if(targets == null || targets.Count == 0)
            {
                Debug.Log("No Enemys");
                return;
            }

            mAttackTimer += Time.deltaTime;

            if(mAttackTimer >= mAttackTime)
            {
                mCharacter.Attack(targets[0]);
                mAttackTimer = 0;
            }


        }

        public override void Reason(List<ICharacter> targets)
        {
            if(targets == null || targets.Count == 0)
            {
                mFSM.PerformTransition(SoldierTransition.NoEnemy);return;
            }

            float distance = Vector3.Distance(mCharacter.position, targets[0].position);

            if(distance > mCharacter.atkRange)
            {
                mFSM.PerformTransition(SoldierTransition.SeeEnemy);
            }
        }
    }
}