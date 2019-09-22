/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              EnemyFSMSystem.cs 
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
	public class EnemyFSMSystem 
	{
        private List<IEnemyState> mStates = new List<IEnemyState>();

        private IEnemyState mCurrrentState;
        public IEnemyState currentState { get { return mCurrrentState; } }
        public void AddState(params IEnemyState[] states)
        {
            foreach(IEnemyState s  in states)
            {
                AddState(s);
            }
        }

        public void AddState(IEnemyState state)
        {
            if(state == null)
            {
                Debug.LogError("要添加的状态为空");
                return;
            }
            if(mStates.Count == 0)
            {
                mStates.Add(state);
                mCurrrentState = state;
                mCurrrentState.DoBeforeEntering();
                return;
            }

            foreach (IEnemyState item in mStates) 
            {
                if(item.stateID == state.stateID)
                {
                    Debug.LogError("要添加的状态ID[" + item.stateID + "]已经添加");
                    return;
                }
            }
            mStates.Add(state);
        }

        public  void DeleteState(EnemyStateID stateID)
        {
            if(stateID == EnemyStateID.NullState)
            {
                Debug.LogError("要删除的状态ID为空" + stateID);
                return;
            }

            foreach (IEnemyState item in mStates)
            {
                if(item.stateID == stateID)
                {
                    mStates.Remove(item);
                    return;
                }
            }
            Debug.LogError("要删除的StateID不存在集合中:" + stateID);
        }

        public  void PerformTrainsition(EnemyTransition trans)
        {
            if(trans == EnemyTransition.NullTansition)
            {
                Debug.LogError("要执行的转换条件为空:" + trans);
                return;
            }

            EnemyStateID nextStateID = mCurrrentState.GetOutPutState(trans);
            if(nextStateID == EnemyStateID.NullState)
            {
                Debug.LogError("在转换条件[" + trans + "]下，没有对应的转换状态");
                return;
            }

            foreach(IEnemyState item in mStates)
            {
                if(item.stateID == nextStateID)
                {
                    mCurrrentState.DoBeforeLeaving();
                    mCurrrentState = item;
                    mCurrrentState.DoBeforeEntering();
                    return;

                }
            }
        }
	}
}