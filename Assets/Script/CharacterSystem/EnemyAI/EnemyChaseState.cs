/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              EnemyChaseState.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-22 
    *Description:           AedAlter
    *History:               
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Red
{
    /// <summary>
    /// 
    /// </summary>
    public class EnemyChaseState : IEnemyState
    {
        public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
        {
            mStateID = EnemyStateID.Chase;
        }

        private Vector3 mTargetPosition;
        public override void DoBeforeEntering()
        {
            mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
        }



        public override void Act(List<ICharacter> targets)
        {
            if(targets != null && targets.Count > 0)
            {
                mCharacter.MoveTo(targets[0].position);
            }
            else
            {
                mCharacter.MoveTo(mTargetPosition);
            }
        }

        public override void Reason(List<ICharacter> targets)
        {
            if(targets != null && targets.Count > 0)
            {
                float distance = Vector3.Distance(mCharacter.position, targets[0].position);
                if(distance <= mCharacter.atkRange)
                {
                    mFSM.PerformTrainsition(EnemyTransition.CanAttack);
                }
                
            }
        }
    }
}