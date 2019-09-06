/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              ISoldierState.cs 
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
    /// 状态的转换条件
    /// </summary>
    public enum SoldierTransition
    {
        NullTransition = 0,
        SeeEnemy,
        NoEnemy,
        CanAttack
    }


    /// <summary>
    /// 想要转换的状态
    /// </summary>
    public enum SoldierStateID
    {
        NullState,
        Idle,
        Chase,
        Attack
    }

	public abstract class ISoldierState
	{
        protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();

        protected SoldierStateID mStateID;


        public SoldierStateID stateID
        {
            get
            {
                return mStateID;
            }
        }

        public void AddTransition(SoldierTransition trans,SoldierStateID id)
        {
            if(trans == SoldierTransition.NullTransition)
            {
                Debug.LogError("SoldierState Error: trans没有状态");
                return;
            }

            if(id == SoldierStateID.NullState)
            {
                Debug.LogError("SoldierState Error:ID状态不能为空");
                return;
            }

            if (mMap.ContainsKey(trans))
            {
                Debug.LogError("SoldierState Error:" + trans + "已经添加上了");
                return;
            }

            //将状态添加到字典中
            mMap.Add(trans, id);
        }


        /// <summary>
        /// 删除状态
        /// </summary>
        /// <param name="trans"></param>
        public void DeleteTransition(SoldierTransition trans)
        {
            if(mMap.ContainsKey(trans) == false)
            {
                Debug.LogError("删除转换田间的时候，转换条件:[" + trans + "]不存在");
                return;
            }

            mMap.Remove(trans);
        }

        /// <summary>
        /// 获取转换的状态
        /// </summary>
        /// <param name="trans">转换的条件</param>
        /// <returns></returns>
        public SoldierStateID GetOutPutState(SoldierTransition trans)
        {
            if(mMap.ContainsKey(trans) == false)
            {
                Debug.LogError("想要获取的模式不存在");
                return SoldierStateID.NullState;
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
        public abstract void Reason();

        /// <summary>
        /// 在当前状态下的游戏逻辑--这个状态想要做的一些事情
        /// </summary>
        public abstract void Act();


	}
}