/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              ISoldier.cs 
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
	public class ISoldier : ICharacter
	{
        /// <summary>
        /// 战士的有限状态机模式
        /// </summary>
        protected SoldierFSMSystem mFSMSystem;


        public ISoldier():base()
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
            mFSMSystem = new SoldierFSMSystem();

            //参数1:角色的有限状态机
            //参数2:控制的对象(为当前角色的对象)
            SoldierIdleState idleState = new SoldierIdleState(mFSMSystem,this);
            idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

            SoldierChaseState chaseState = new SoldierChaseState(mFSMSystem, this);
            chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
            chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);


            SoldierAttackState attackState = new SoldierAttackState(mFSMSystem, this);
            attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
            attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

            mFSMSystem.AddState(idleState,chaseState,attackState);
           

        }
	}
}