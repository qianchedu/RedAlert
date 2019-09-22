/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              SoldierIdleState.cs 
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
    /// 战士Idle(无聊)状态
    /// </summary>
    public class SoldierIdleState : ISoldierState
    {
        public SoldierIdleState(SoldierFSMSystem fsm, ICharacter character) : base(fsm,character)
        {
            mStateID = SoldierStateID.Idle;
        }


        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="targets"></param>
        public override void Act(List<ICharacter> targets)
        {
            mCharacter.PlayAnim("stand");
        }


        /// <summary>
        /// 转换条件
        /// </summary>
        /// <param name="targets"></param>
        public override void Reason(List<ICharacter> targets)
        {
           if(targets != null && targets.Count > 0)
            {
                //
                mFSM.PerformTransition(SoldierTransition.SeeEnemy);
            }
        }
    }
}