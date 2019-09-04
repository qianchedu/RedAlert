/***********************************************
    *ProjectsName:          RedAlert
    *Copyright(C) 2017 by   笑笑科技公司  
    *All rights reserved. 
    *FileName:              T006Bridge.cs 
    *Author:                Norlan 
    *Version:               0.1 
    *UnityVersion:          2018.3.0f2 
    *Date:                  2019-09-04 
    *Description:           AedAlter
    *History:               自定义，可以不写内容，可以删除该行
/***********************************************/

using Red;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
	public class T006Bridge : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
            //Sphere sphere = new Sphere();
            //sphere.Draw();

            //IRenderEngine mRenderEngine = new RenderX();
            //IShape mSphere = new Cube(mRenderEngine);
            //mSphere.Draw();


            ICharacter character = new SoldierCaptain();
            //WeaponRifle rifle = new WeaponRifle();
            //character.rifle = rifle;
            character.weapon = new WeaponGun();
            character.Attack(Vector3.zero);


		}

		// Update is called once per frame
		void Update()
		{
			
		}
	}


    public class IShape
    {
        public string mName;
        public IRenderEngine mRenderEngine;


        public IShape (IRenderEngine renderEngine)
        {
            mRenderEngine = renderEngine;
        }

        public void Draw()
        {
            mRenderEngine.Draw(mName);
        }
    }


    public abstract class IRenderEngine
    {
        public abstract void Draw(string name);
    }

    public class Sphere:IShape
    {
        //public string name = "Sphere";

        //public OpenGL openGL = new OpenGL();

        //public  void Draw()
        //{
        //    openGL.Render(name);
        //}

        public Sphere(IRenderEngine renderEngine):base(renderEngine)
        {
            mName = "Sphere";
        }
    }


    public class Cube : IShape
    {
        public Cube(IRenderEngine renderEngine) : base(renderEngine)
        {
            mName = "Cube";
        }
        //public string name = "Cube";

        //public OpenGL openGL = new OpenGL();

        //public void Draw()
        //{
        //    openGL.Render(name);
        //}
    }

    public class Capsule : IShape
    {

        public Capsule(IRenderEngine renderEngine) : base(renderEngine)
        {
            mName = "Capsule";
        }
        //public string name = "Capsule";

        //public OpenGL openGL = new OpenGL();

        //public void Draw()
        //{
        //    openGL.Render(name);
        //}
    }

    public class OpenGL : IRenderEngine
    {

        //public void Render(string name)
        //{
        //    Debug.Log("OpenGL:" + name);
        //}
        public override void Draw(string name)
        {
            Debug.Log("OpenGL:" + name);
        }
    }


    public class DirectX : IRenderEngine
    {
        public override void Draw(string name)
        {
            Debug.Log("DirectX:" + name);
        }
    }


    public class RenderX : IRenderEngine
    {
        public override void Draw(string name)
        {
            Debug.Log("RenderX:" + name);
        }
    }
}