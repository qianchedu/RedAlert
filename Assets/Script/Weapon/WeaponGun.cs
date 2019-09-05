/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              WeaponGun.cs 
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
	public class WeaponGun : IWeapon
    {
        ///// <summary>
        ///// 攻击命令
        ///// </summary>
        ///// <param name="targetPosition">攻击目标</param>
        //public override void Fire(Vector3 targetPosition)
        //{
        //    Debug.Log("显示特效");
        //    Debug.Log("播放声音");

        //    //显示枪口特效
        //    mPariticle.Stop();          //将特效停止
        //    mPariticle.Play();          //播放特效
        //    mLight.enabled = true;      //灯光设置开启

        //    //显示子弹的轨迹
        //    mLine.enabled = true;       //轨迹
        //    mLine.startWidth = 0.05f;   //
        //    mLine.endWidth = 0.05f;
        //    mLine.SetPosition(0, mGameObject.transform.position);
        //    mLine.SetPosition(1, targetPosition);

        //    //播放声音
        //    string clipName = "GunShot";
        //    AudioClip clip = null;
        //    mAudio.clip = clip;
        //    mAudio.Play();


        //}


        protected override void PlayBulletEffect(Vector3 targetPosition)
        {
            DoPlayBulletEffect(0.05f, targetPosition);
        }

        protected override void PlaySound()
        {
            DoPlaySound("GunShot");
        }

        protected override void SetEffectDisplayTime()
        {
            mEffectDisplayTime = 0.2f;
        }
    }
}