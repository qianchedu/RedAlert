/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              ICharacter.cs 
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
using UnityEngine.AI;

namespace Red
{
    public abstract class ICharacter
    {

        protected ICharacterAttr mAttr;
        protected GameObject mGameObject;
        protected NavMeshAgent mNavAgent;
        protected AudioClip mAudioClip;
        protected Animation mAnim;
        protected IWeapon mWeapon;

        public IWeapon weapon { set { mWeapon = value; } }

        /// <summary>
        /// 获取对象的位置
        /// </summary>
        public Vector3 position
        {
            get
            {
                if (mGameObject == null)
                {
                    Debug.LogError("mGameObjec为空");
                    return Vector3.zero;
                }

                return mGameObject.transform.position;

            }
           
        }


        /// <summary>
        /// 攻击距离
        /// </summary>
        public float atkRange
        {
            get
            {
                return mWeapon.atkRange;
            }
        }

        /// <summary>
        /// 攻击
        /// </summary>
        /// <param name="target">想要攻击的目标</param>
        public void Attack(ICharacter target)
        {
            mWeapon.Fire(target.position);
        }

		
        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="animName">想要播放的动画</param>
        public void PlayAnim(string animName)
        {
            mAnim.CrossFade(animName);
        }


        /// <summary>
        /// 移动到目标位置
        /// </summary>
        /// <param name="targetPosition">目标位置</param>
        public void MoveTo(Vector3 targetPosition)
        {
            //设置位置 导航组件会根据你设置的位置去移动
            mNavAgent.SetDestination(targetPosition);
        }


       

	}
}