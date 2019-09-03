/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              SceneStateController.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-03 
    *Description:           AedAlter
    *History:               自定义，可以不写内容，可以删除该行
/***********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Red
{
	public class SceneStateController
	{
        private ISceneState mState;
        private AsyncOperation mAO;

        private bool mIsRunStart = false;

        public void SetState(ISceneState state,bool isLoadScene = true)
        {
            if(mState != null)
            {
                mState.StateEnd();//让上一个场景状态做一下清理工作
                
            }
            mState = state;
            if (isLoadScene)
            {
                mAO = SceneManager.LoadSceneAsync(mState.SceneName);
                mIsRunStart = false;
            }
            else
            {
                mState.StateStart();
                mIsRunStart = true;
            }
            

        }

        /// <summary>
        /// 更新状态
        /// </summary>
        public void StateUpdate()
        {

            //场景正在加载
            if (mAO != null && mAO.isDone == false) return;

            //场景加载完成
            if(mIsRunStart == false && mAO != null && mAO.isDone)
            {
                //切换场景
                mState.StateStart();
                mIsRunStart = true;
            }

            if(mState != null)
            {
                mState.StateUpdate();
            }
        }


	}
}