/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              WeaponRifle.cs 
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
	public class WeaponRifle : IWeapon
    {
        protected override void PlayBulletEffect(Vector3 targetPosition)
        {
            DoPlayBulletEffect(0.03f, targetPosition);
        }

        protected override void PlaySound()
        {
            DoPlaySound("RifleShot");
        }

        protected override void SetEffectDisplayTime()
        {
            mEffectDisplayTime = 0.3f;
        }
    }
}