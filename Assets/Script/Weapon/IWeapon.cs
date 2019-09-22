/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              IWeapon.cs 
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
    public abstract class IWeapon
    {
        protected int mAtk;
        protected float mAtkRange;
        protected float mAtkPlusValue;

        protected GameObject mGameObject;
        protected ICharacter mOwner;
        protected ParticleSystem mPariticle;
        protected LineRenderer mLine;
        protected Light mLight;
        protected AudioSource mAudio;

        protected float mEffectDisplayTime = 0;                 //特效显示的时间

        public float atkRange
        {
            get
            {
                return mAtkRange;
            }
        }

        /// <summary>
        /// 每帧更新
        /// </summary>
        public void Update()
        {
            if(mEffectDisplayTime > 0)
            {
                mEffectDisplayTime -= Time.deltaTime;
                if(mEffectDisplayTime <= 0)
                {
                    //关闭特效
                    DisableEffect();
                }
            }
        }

        public void Fire(Vector3 targetPosition)
        {

            //显示枪口特效
            PlayMuzzleEffect();

            //显示子弹的轨迹
            PlayBulletEffect(targetPosition);


            //设置特效显示的时间
            SetEffectDisplayTime();

            //播放声音
            PlaySound();

        }


        protected abstract void SetEffectDisplayTime();

        /// <summary>
        /// //显示枪口特效
        /// </summary>
        protected virtual void PlayMuzzleEffect()
        {
            //显示枪口特效
            mPariticle.Stop();          //将特效停止
            mPariticle.Play();          //播放特效
            mLight.enabled = true;      //灯光设置开启
        }


        /// <summary>
        /// //显示子弹的轨迹
        /// </summary>
        /// <param name="tragetPosition"></param>
        protected abstract void PlayBulletEffect(Vector3 targetPosition);

        protected void DoPlayBulletEffect(float width,Vector3 targetPosition)
        {
            mLine.enabled = true;       //轨迹
            mLine.startWidth = width;   //
            mLine.endWidth = width;
            mLine.SetPosition(0, mGameObject.transform.position);
            mLine.SetPosition(1, targetPosition);
        }


        /// <summary>
        ///  //播放声音
        /// </summary>
        protected abstract void PlaySound();


        protected void DoPlaySound(string clipName)
        {
            AudioClip clip = null;
            mAudio.clip = clip;
            mAudio.Play();
        }


        /// <summary>
        /// 关闭特效
        /// </summary>
        private void DisableEffect()
        {
            mLine.enabled = false;
            mLight.enabled = false;
        }
    }
}