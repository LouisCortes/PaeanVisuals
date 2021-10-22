using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllCave : MonoBehaviour
{
    public PointAnimation obj1;
    public PointAnimation obj2;
    public PointAnimation obj3;
    public PointAnimation obj4;
    public PointAnimation obj5;
    public PointAnimation obj6;
    public PointAnimation obj7;
    public PointAnimation obj8;
    public PointAnimation obj9;
    public PointAnimation obj10;
    public PointAnimation obj11;
    public PointAnimation obj12;
    public PointAnimation obj13;
    public PointAnimation obj14;
    public PointAnimation obj15;
    public PointAnimation obj16;
    public PointAnimation obj17;
    public GettingStartedReceiving osc;
    [Range(0, 1)]
    public float audio1;
    [Range(0, 1)]
    public float liquide;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj1._audio1 =audio1  + osc.audio1;
        obj2._audio1 =audio1  + osc.audio1;
        obj3._audio1 =audio1  + osc.audio1;
        obj4._audio1 =audio1  + osc.audio1;
        obj5._audio1 =audio1  + osc.audio1;
        obj6._audio1 =audio1  + osc.audio1;
        obj7._audio1 =audio1  + osc.audio1;
        obj8._audio1 =audio1  + osc.audio1;
        obj9._audio1 =audio1  + osc.audio1;
        obj10._audio1 =audio1  + osc.audio1;
        obj11._audio1 =audio1  + osc.audio1;
        obj12._audio1 =audio1  + osc.audio1;
        obj13._audio1 =audio1  + osc.audio1;
        obj14._audio1 =audio1  + osc.audio1;
        obj15._audio1 =audio1  + osc.audio1;
        obj16._audio1 =audio1  + osc.audio1;
        obj17._audio1 =audio1  + osc.audio1;
        obj1._liquide = liquide + osc.liquide2;
        obj2._liquide = liquide + osc.liquide2;
        obj3._liquide = liquide + osc.liquide2;
        obj4._liquide = liquide + osc.liquide2;
        obj5._liquide = liquide + osc.liquide2;
        obj6._liquide = liquide + osc.liquide2;
        obj7._liquide = liquide + osc.liquide2;
        obj8._liquide = liquide + osc.liquide2;
        obj9._liquide = liquide + osc.liquide2;
        obj10._liquide = liquide + osc.liquide2;
        obj11._liquide = liquide + osc.liquide2;
        obj12._liquide = liquide + osc.liquide2;
        obj13._liquide = liquide + osc.liquide2;
        obj14._liquide = liquide + osc.liquide2;
        obj15._liquide = liquide + osc.liquide2;
        obj16._liquide = liquide + osc.liquide2;
        obj17._liquide = liquide + osc.liquide2;
        obj1._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj2._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj3._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj4._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj5._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj6._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj7._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj8._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj9._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj10._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj11._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj12._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj13._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj14._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj15._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj16._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
        obj17._audio2 =osc.low *osc.address01*osc.audio2 * osc.fac2;
    }
}
