/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              MainMenuState.cs 
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
	public class MainMenuState : ISceneState
	{
        public MainMenuState(SceneStateController controller) 
            : base("02MainMenu", controller)
        {
        }

        private Button mBtnStartGame;

        public override void StateStart()
        {
            mBtnStartGame = GameObject.Find("BtnStartGame").GetComponent<Button>();

            mBtnStartGame.onClick.AddListener(OnStartButtonClick);
        }



        private void OnStartButtonClick()
        {
            mController.SetState(new BattleState(mController));
        }

    }
}