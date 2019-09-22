/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              IEnemyState.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-22 
    *Description:           AedAlter
    *History:               自定义，可以不写内容，可以删除该行
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Red
{


    public enum EnemyTransition
    {
        NullTansition = 0,
        CanAttack,
        LostSoldier
    }


    public enum EnemyStateID
    {
        NullState,
        Idle,
        Chase,
        Attack
    }
	public abstract class IEnemyState 
	{
        protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();

        protected EnemyStateID mStateID;

        protected ICharacter mCharacter;

        protected EnemyFSMSystem mFSM;

        public IEnemyState(EnemyFSMSystem fsm,ICharacter character)
        {
            mFSM = fsm;
            mCharacter = character;
        }


        public EnemyStateID stateID
        {
            get { return mStateID; }
        }

        public  void AddTrainsition(EnemyTransition trans,EnemyStateID id)
        {
            if(trans == EnemyTransition.NullTansition)
            {
                Debug.Log("EnemyState Error:trans不能为空");
                return;
            }

            if(id == EnemyStateID.NullState)
            {
                Debug.LogError("EnemyState Error:id状态ID不能为空");
                return;
            }

            if (mMap.ContainsKey(trans))
            {
                Debug.LogError("EnemyState Error:" + trans + "已经添加上了");
                return;
            }
            mMap.Add(trans, id);
        }


        public void DeleteTrainsition(EnemyTransition trans)
        {
            if(mMap.ContainsKey(trans) == false)
            {
                Debug.LogError("删除转换条件的时候,转换条件:["+trans+"]不存在");
                return;
            }
            mMap.Remove(trans);
        }


        public EnemyStateID GetOutPutState(EnemyTransition trans)
        {
            if(mMap.ContainsKey(trans) == false)
            {
                return EnemyStateID.NullState;
            }
            else
            {
                return mMap[trans];
            }
        }

        /// <summary>
        /// 进入状态的时候进行一些初始化的操作
        /// </summary>
        public virtual void DoBeforeEntering() { }

        /// <summary>
        /// 
        /// </summary>
        public virtual void DoBeforeLeaving() { }

        /// <summary>
        /// 判断在当前状态下是否需要转换到其他状态的
        /// </summary>
        public abstract void Reason(List<ICharacter> targets);

        /// <summary>
        /// 在当前状态下的游戏逻辑--这个状态想要做的一些事情
        /// </summary>
        public abstract void Act(List<ICharacter> targets);
    }
}