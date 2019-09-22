/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              SoldierChaseState.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-06 
    *Description:           AedAlter
    *History:               追击敌人
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Red
{
    /// <summary>
    ///  追击敌人
    /// </summary>
	public class SoldierChaseState : ISoldierState
    {
        public SoldierChaseState(SoldierFSMSystem fsm, ICharacter character) : base(fsm,character)
        {
            mStateID = SoldierStateID.Chase;
        }


        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="targets"></param>
        public override void Act(List<ICharacter> targets)
        {
            if(targets != null && targets.Count > 0)
            {
                mCharacter.MoveTo(targets[0].position);
            }
        }

        /// <summary>
        /// 状态的改变
        /// </summary>
        /// <param name="targets"></param>
        public override void Reason(List<ICharacter> targets)
        {

            //判断敌人为空 或 敌人数量等于0
           if(targets == null || targets.Count == 0)
            {
                Debug.LogError("没有敌人了");
                mFSM.PerformTransition(SoldierTransition.NoEnemy);
                return;
            }

           //敌人与角色之间的距离
            float distance = Vector3.Distance(targets[0].position,mCharacter.position);


            if(distance < mCharacter.atkRange)
            {
                mFSM.PerformTransition(SoldierTransition.CanAttack);

            }
        }
    }
}