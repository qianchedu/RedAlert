/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              StartState.cs 
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
using UnityEngine.UI;

namespace Red
{
    public class StartState : ISceneState
    {
        public StartState(SceneStateController controller)
            : base("01StartScene", controller)
        {
        }


        private Image mLogo;
        private float mSmoothingTime = 1f;
        private float mWaitTime = 2;

        public override void StateStart()
        {
            mLogo = GameObject.Find("Logo").GetComponent<Image>();

            mLogo.color = Color.black;
        }


        public override void StateUpdate()
        {
            //Color.Lerp颜色a和颜色b之间的线性差值T
            mLogo.color = Color.Lerp(mLogo.color, Color.white, mSmoothingTime*Time.deltaTime);

            mWaitTime -= Time.deltaTime;

            if(mWaitTime <= 0)
            {
                mController.SetState(new MainMenuState(mController));
            }

        }

        public override void StateEnd()
        {
            base.StateEnd();
        }
    }
}