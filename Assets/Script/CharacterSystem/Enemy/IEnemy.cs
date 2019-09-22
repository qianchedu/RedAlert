/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              IEnemy.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-04 
    *Description:           AedAlter
    *History:               自定义，可以不写内容，可以删除该行
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Red
{
	public class IEnemy : ICharacter
	{
        protected EnemyFSMSystem mFSMSystem;

        public IEnemy()
        {
            MakeFSM();
        }

        public void UpdateFSMAI(List<ICharacter> targets)
        {
            mFSMSystem.currentState.Reason(targets);
            mFSMSystem.currentState.Act(targets);
        }

        private void MakeFSM()
        {
            mFSMSystem = new EnemyFSMSystem();

            EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem, this);
            chaseState.AddTrainsition(EnemyTransition.CanAttack, EnemyStateID.Attack);

            EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
            attackState.AddTrainsition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

            mFSMSystem.AddState(chaseState, attackState);
        }
	}

}