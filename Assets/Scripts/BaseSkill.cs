using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour {
    public string Name;
    public int ID;
    public string origin;
    public string target;
    public string type;

    public void CastSkill()
    {
        preCast();
        Casting();
        postCast();
    }
    public abstract void preCast(); //施法前动作：获取施法目标，做施法前摇
    public abstract void Casting();//施法动作：做出施法动作，对目标造成效果 
    public abstract void postCast();//施法后动作：施法后效果处理，做施法后摇
}
