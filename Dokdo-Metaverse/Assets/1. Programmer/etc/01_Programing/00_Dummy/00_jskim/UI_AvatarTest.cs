using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_AvatarTest : MonoBehaviour
{
    public TMP_Text main;
    public GameObject mainObj;
    public TMP_Text gender;
    public TMP_Text hair;
    public TMP_Text face;
    public TMP_Text body;
    //public TMP_Text hat;
    public TMP_Text glasses;
    private string[] hairStr;
    private string[] faceStr;
    private string[] bodyStr;
    //private string[] hatStr;
    private string[] glassesStr;
    public GameObject[] maleHair;
    public GameObject[] maleFace;
    public GameObject[] maleBody;
    //public GameObject[] maleHat;
    public GameObject[] maleGlasses;
    public GameObject[] femaleHair;
    public GameObject[] femaleFace;
    public GameObject[] femaleBody;
    //public GameObject[] femaleHat;
    public GameObject[] femaleGlasses;
    [Space(10)]
    public Animator animator;
    public Avatar[] avatar;
    public RuntimeAnimatorController[] animatorControllers;
    private void Start()
    {
        hairStr = new string[] { "0", "0" };
        faceStr = new string[] { "0", "0" };
        bodyStr = new string[] { "0", "0" };
        //hatStr = new string[] { "0", "0" };
        glassesStr = new string[] { "0", "0" };

        curHairObj = maleHair[0];
        curFaceObj = maleFace[0];
        curBodyObj = maleBody[0];
        curGlassesObj = maleGlasses[0];
        Click_Main();
        Click_Gender(0);
    }

    public enum eShow
    {
        hide,
        show,
    }
    public eShow showState = eShow.hide;
    //public string
    public void Click_Main()
    {
        if (showState == eShow.hide)
        {
            showState = eShow.show;
            main.text = ">";
            mainObj.SetActive(true);
        }
        else
        {
            showState = eShow.hide;
            main.text = "<";
            mainObj.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Click_Main();
        }
    }

    int genderIdx = 0;
    public void Click_Gender(int gender)
    {
        genderIdx = gender;

        Click_Hair(hairStr[gender]);

        Click_Face(faceStr[gender]);

        Click_Body(bodyStr[gender]);

        //hat.text = hatStr[gender];

        Click_Glasses(glassesStr[gender]);

        animator.avatar = avatar[gender];
        animator.runtimeAnimatorController = animatorControllers[gender];

        this.gender.text = gender.ToString();
      
    }

    GameObject curHairObj;
    GameObject curFaceObj;
    GameObject curBodyObj;
    GameObject curGlassesObj;

    public void Click_Hair(string hair)
    {
        this.hair.text = hairStr[genderIdx] = hair;
        curHairObj.SetActive(false);
        curHairObj = genderIdx == 0 ? maleHair[int.Parse(hair)] : femaleHair[int.Parse(hair)];
        curHairObj.SetActive(true);
    }
    public void Click_Face(string face)
    {
        this.face.text = faceStr[genderIdx] = face;
        curFaceObj.SetActive(false);
        curFaceObj = genderIdx == 0 ? maleFace[int.Parse(face)] : femaleFace[int.Parse(face)];
        curFaceObj.SetActive(true);
    }
    public void Click_Body(string body)
    {
        this.body.text = bodyStr[genderIdx] = body;
        curBodyObj.SetActive(false);
        curBodyObj = genderIdx == 0 ? maleBody[int.Parse(body)] : femaleBody[int.Parse(body)];
        curBodyObj.SetActive(true);
    }
    //public void Click_Hat(string hat)
    //{
    //    this.hat.text = hatStr[genderIdx] = hat;
    //}
    public void Click_Glasses(string glasses)
    {
        this.glasses.text = glassesStr[genderIdx] = glasses;
        curGlassesObj.SetActive(false);
        curGlassesObj = genderIdx == 0 ? maleGlasses[int.Parse(glasses)] : femaleGlasses[int.Parse(glasses)];
        curGlassesObj.SetActive(true);
    }


}
