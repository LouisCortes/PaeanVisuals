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
        obj1._audio1 =audio1  + osc.audio1*osc.low;
        obj2._audio1 =audio1  + osc.audio1*osc.low;
        obj3._audio1 =audio1  + osc.audio1*osc.low;
        obj4._audio1 =audio1  + osc.audio1*osc.low;
        obj5._audio1 =audio1  + osc.audio1*osc.low;
        obj6._audio1 =audio1  + osc.audio1*osc.low;
        obj7._audio1 =audio1  + osc.audio1*osc.low;
        obj8._audio1 =audio1  + osc.audio1*osc.low;
        obj9._audio1 =audio1  + osc.audio1*osc.low;
        obj10._audio1 =audio1  + osc.audio1*osc.low;
        obj11._audio1 =audio1  + osc.audio1*osc.low;
        obj12._audio1 =audio1  + osc.audio1*osc.low;
        obj13._audio1 =audio1  + osc.audio1*osc.low;
        obj14._audio1 =audio1  + osc.audio1*osc.low;
        obj15._audio1 =audio1  + osc.audio1*osc.low;
        obj16._audio1 =audio1  + osc.audio1*osc.low;
        obj17._audio1 =audio1  + osc.audio1*osc.low;
        obj1._audio4 = audio1 + osc.audio1*osc.mid;
        obj2._audio4 = audio1 + osc.audio1*osc.mid;
        obj3._audio4 = audio1 + osc.audio1*osc.mid;
        obj4._audio4 = audio1 + osc.audio1*osc.mid;
        obj5._audio4 = audio1 + osc.audio1*osc.mid;
        obj6._audio4 = audio1 + osc.audio1*osc.mid;
        obj7._audio4 = audio1 + osc.audio1*osc.mid;
        obj8._audio4 = audio1 + osc.audio1*osc.mid;
        obj9._audio4 = audio1 + osc.audio1*osc.mid;
        obj10._audio4 = audio1 + osc.audio1*osc.mid;
        obj11._audio4 = audio1 + osc.audio1*osc.mid;
        obj12._audio4 = audio1 + osc.audio1*osc.mid;
        obj13._audio4 = audio1 + osc.audio1*osc.mid;
        obj14._audio4 = audio1 + osc.audio1*osc.mid;
        obj15._audio4 = audio1 + osc.audio1*osc.mid;
        obj16._audio4 = audio1 + osc.audio1*osc.mid;
        obj17._audio4 = audio1 + osc.audio1*osc.mid;
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
        obj1._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj2._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj3._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj4._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj5._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj6._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj7._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj8._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj9._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj10._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj11._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj12._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj13._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj14._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj15._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj16._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj17._audio2 =osc.low2 *osc.address01*osc.audio2 * osc.fac2;
        obj1._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj2._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj3._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj4._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj5._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj6._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj7._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj8._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj9._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj10._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj11._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj12._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj13._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj14._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj15._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj16._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj17._audio3 = osc.mid2 * osc.address02 * osc.audio2 * osc.fac2;
        obj1._sonar = osc.mouv;
        obj2._sonar = osc.mouv;
        obj3._sonar = osc.mouv;
        obj4._sonar = osc.mouv;
        obj5._sonar = osc.mouv;
        obj6._sonar = osc.mouv;
        obj7._sonar = osc.mouv;
        obj8._sonar = osc.mouv;
        obj9._sonar = osc.mouv;
        obj10._sonar = osc.mouv;
        obj11._sonar = osc.mouv;
        obj12._sonar = osc.mouv;
        obj13._sonar = osc.mouv;
        obj14._sonar = osc.mouv;
        obj15._sonar = osc.mouv;
        obj16._sonar = osc.mouv;
        obj17._sonar = osc.mouv;
    }
}
