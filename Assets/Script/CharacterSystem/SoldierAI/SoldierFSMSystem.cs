/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              SoldierFSMSystem.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-06 
    *Description:           AedAlter
    *History:               有限状态机系统
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Red
{

	public class SoldierFSMSystem 
	{
        /// <summary>
        /// 状态的集合
        /// </summary>
        private List<ISoldierState> mStates = new List<ISoldierState>();

        /// <summary>
        /// 当前的状态
        /// </summary>
        private ISoldierState mCurrentState;

        public ISoldierState currentState { get { return mCurrentState; } }


        public void AddState(params ISoldierState[] states)
        {
            foreach (ISoldierState item in states)
            {
                AddState(item);
            }
        }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="state"></param>
        public void AddState(ISoldierState state)
        {
            if(state == null)
            {
                Debug.LogError("要田间的状态为空");return;
            }

            if(mStates.Count == 0)
            {
                
                mStates.Add(state);
                mCurrentState = state;
                return;
            }

            foreach (ISoldierState s in mStates)
            {
                if(s.stateID == state.stateID)
                {
                    Debug.LogError("要添加的状态["+s.stateID+"]已经存在");
                    return;
                }
            }

            mStates.Add(state);

        }


        /// <summary>
        /// 删除状态
        /// </summary>
        /// <param name="stateID"></param>
        public void DeleteState(SoldierStateID stateID)
        {
            if(stateID == SoldierStateID.NullState)
            {
                Debug.LogError("要删除的状态ID为空" +stateID);
                return;
            }

            foreach (ISoldierState s in mStates)
            {
                if(s.stateID == stateID)
                {
                    mStates.Remove(s);
                    return;
                }
            }

            Debug.LogError("要删除的StateID不存在集合中:" + stateID);
        }



        /// <summary>
        /// 转换
        /// </summary>
        public void PerformTransition(SoldierTransition trans)
        {
            if(trans == SoldierTransition.NullTransition)
            {
                Debug.LogError("要执行的转换条件为空:" + trans);
                return;
            }

            SoldierStateID nextStateID = mCurrentState.GetOutPutState(trans);

            if(nextStateID == SoldierStateID.NullState)
            {
                Debug.LogError("在转换条件[" + trans + "]下，没有对应的转换状态");
                return;
            }

            foreach (ISoldierState s in mStates)
            {
                if(s.stateID == nextStateID)
                {
                    mCurrentState.DoBeforeLeaving();
                    mCurrentState = s;
                    mCurrentState.DoBeforeEntering();

                    return;
                }
            }
        }
	}
}