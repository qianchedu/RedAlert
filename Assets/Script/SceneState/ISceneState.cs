/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              ISceneState.cs 
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

namespace Red
{
    /// <summary>
    /// 场景状态
    /// </summary>
	public class ISceneState 
	{
        /// <summary>
        /// 场景的名称
        /// </summary>
        private string mSceneName;

        /// <summary>
        /// 场景控制器
        /// </summary>
        public SceneStateController mController;



        public ISceneState(string sceneName,SceneStateController controller)
        {
            mSceneName = sceneName;
            mController = controller;
        }

        public string SceneName
        {
            get
            {
                return mSceneName;
            }
        }

        /// <summary>
        /// 每次进入状态的时候调用 == 进入场景的时候 需要做的事情
        /// </summary>
        public virtual void StateStart() { }


        /// <summary>
        /// 每次离开状态的时候调用 == 离开场景的时候，需要做的事情
        /// </summary>
        public virtual void StateEnd() { }

        /// <summary>
        /// 更新当前场景的状态行为
        /// </summary>
        public virtual void StateUpdate()
        {

        }
	}
}