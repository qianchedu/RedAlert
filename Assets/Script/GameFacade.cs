/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              GameFacade.cs 
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
    //外观模式  也是  中介者模式
	public class GameFacade 
	{

        private static GameFacade instance;
        private GameFacade() { }

        public static GameFacade Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new GameFacade();
                }

                return instance;
            }
        }

        //游戏是否结束
        private bool mIsGameOver = false;


        public bool isGameOver
        {
            get
            {
                return mIsGameOver;
            }
        }


        private ArchievementSystem mArchievementSystem;

        //兵营系统
        private CampSystem mCampSystem;
        //角色系统
        private CharacterSystem mCharacterSystem;
        //能量系统
        private EnergySystem mEnergySystem;
        //角色事件系统
        private GameEventSystem mGameEventSystem;
        //关卡系统
        private StageSystem mStateSystem;
        //兵营信息UI
        private CampInfoUI mCampInfoUI;
        //游戏暂停UI
        private GamePauseUI mGamePauseUI;
        //游戏状态UI
        private GameStateInfoUI mGameStateInfoUI;
        //战士信息UI
        private SoldierInfoUI mSoldierInfoUI;


		public void Init()
        {
            mArchievementSystem = new ArchievementSystem();
            mCampSystem = new CampSystem();
            mCharacterSystem = new CharacterSystem();
            mEnergySystem = new EnergySystem();
            mGameEventSystem = new GameEventSystem();
            mStateSystem = new StageSystem();

            mCampSystem = new CampSystem();
            mGamePauseUI = new GamePauseUI();
            mGameStateInfoUI = new GameStateInfoUI();
            mSoldierInfoUI = new SoldierInfoUI();


            mArchievementSystem.Init();
            mCampSystem.Init();
            mCharacterSystem.Init();
            mEnergySystem.Init();
            mGameEventSystem.Init();
            mStateSystem.Init();

            mCampSystem.Init();
            mGamePauseUI.Init();
            mGameStateInfoUI.Init();
            mSoldierInfoUI.Init();
        }


        public void Update()
        {
            mArchievementSystem.Update();
            mCampSystem.Update();
            mCharacterSystem.Update();
            mEnergySystem.Update();
            mGameEventSystem.Update();
            mStateSystem.Update();

            mCampSystem.Update();
            mGamePauseUI.Update();
            mGameStateInfoUI.Update();
            mSoldierInfoUI.Update();
        }


        public void Release()
        {
            mArchievementSystem.Release();
            mCampSystem.Release();
            mCharacterSystem.Release();
            mEnergySystem.Release();
            mGameEventSystem.Release();
            mStateSystem.Release();

            mCampSystem.Release();
            mGamePauseUI.Release();
            mGameStateInfoUI.Release();
            mSoldierInfoUI.Release();
        }
	}
}