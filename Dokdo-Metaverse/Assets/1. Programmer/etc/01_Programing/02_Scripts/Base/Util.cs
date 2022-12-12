using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public static class Util
{
    public static bool isGrab = false;

    public static bool _MirrorViewFinish = false;

    /// <summary>
    /// 미러뷰 시청(애니메이션)이 다 끝나면 True로 바뀜
    /// </summary>
    /// <returns></returns>
    public static bool GetMirrorView()
    {
        return _MirrorViewFinish;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="pivot"></param>
    /// 
    public static void SetPivot(this RectTransform target, Vector2 pivot)
    {
        if (!target) return;
        var offset = pivot - target.pivot;
        offset.Scale(target.rect.size);
        var wordlPos = target.position + target.TransformVector(offset);
        target.pivot = pivot;
        target.position = wordlPos;
    }

    /// <summary>
    /// 트랜스폼 찾기..
    /// </summary>
    /// <param name="target"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Transform Search(Transform target, string name)
    {
        if (target.name == name) return target;

        for (int i = 0; i < target.childCount; ++i)
        {
            var result = Search(target.GetChild(i), name);

            if (result != null) return result;
        }

        return null;
    }
    

    /// <summary>
    /// 빈오브젝트 생성..
    /// </summary>
    public static GameObject CreateEmptyObject(string strName)
    {
        string objectName = strName/*.Replace(Cons.SeahVR, "")*/;
        return new GameObject(objectName);
    }

    /// <summary>
    /// 유틸 : 객체 중복체크
    /// </summary>
    public static T GetDuplication<T>(T pInstance) where T : UnityEngine.Object
    {
        T[] pList = GameObject.FindObjectsOfType<T>();
        if (null == pList)
        {
            return null;
        }

        for (int iLoop = 0; iLoop < pList.Length; ++iLoop)
        {
            if (pInstance.GetInstanceID() != pList[iLoop].GetInstanceID())
            {
                return pList[iLoop];
            }
        }

        return null;
    }
    public static void SetParent(GameObject pChild, GameObject pParent, Vector3 pos, Quaternion rot, Vector3 scale)
    {
        try
        {
            pChild.transform.SetParent(pParent.transform);
            pChild.transform.localPosition = pos;
            pChild.transform.localScale = scale;
            pChild.transform.localRotation = rot;
        }
        catch (Exception)
        {
            Debug.LogError("pChild: " + pChild.name);
            Debug.LogError("pParent: " + pParent.name);
            throw;
        }
    }

    /// <summary>
    /// string 을 vector3로 변환
    /// </summary>
    /// <param name="_str"></param>
    /// <returns></returns>
    public static Vector3 StringToVector3(string _str)
    {
        string[] strs = _str.Split('§');
        float x = float.Parse(strs[0]);
        float y = float.Parse(strs[1]);
        float z = float.Parse(strs[2]);
        return new Vector3(x, y, z);
    }

    /// <summary>
    /// enum원형의 길이 구하기
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static int EnumLength<T>(T t)
    {
        return Enum.GetNames(typeof(T)).Length;
    }
    public static int EnumLength<T>()
    {
        return Enum.GetNames(typeof(T)).Length;
    }

    /// <summary>
    /// 스트링으로 이넘 찾기
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_str"></param>
    /// <returns></returns>
    public static T String2Enum<T>(string _str)
    {
        try { return (T)Enum.Parse(typeof(T), _str); }
        catch { return (T)Enum.Parse(typeof(T), "None"); }
    }

    //public static void SetTransition(Material mat, bool show, float max = 1f, float duration = 0.3f)
    //{
    //    Single.Scene.StartCoroutine(CoSetTransition(mat, show, max, duration));
    //}

    public static string Enum2String<T>(T e_num) where T : Enum
    {
        try { return Enum.GetName(typeof(T), e_num); }
        catch { return String.Empty; }
    }
    private static IEnumerator CoSetTransition(Material mat, bool show, float max = 1f, float duration = 0.3f)
    {
        float curTime;

        if (show == true)
        {
            curTime = 0f;
            while (curTime < 1f)
            {
                curTime += Time.deltaTime / duration;
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, curTime * max);
                yield return null;
            }
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, max);
        }

        else
        {
            curTime = 1f;
            while (curTime > 0f)
            {
                curTime -= Time.deltaTime / duration;
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, curTime * max);
                yield return null;

            }
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0f);

        }

    }

    /// <summary>
    /// 메테리얼에 색상넣기!
    /// </summary>
    /// <param name="_meshRd"></param>
    /// <param name="_color"></param>
    /// <param name="_texture"></param>
    public static void SetColor(MeshRenderer _meshRd, Color _color, Texture[] _texture)
    {
        for (int i = 0; i < _meshRd.materials.Length; i++)
        {
            _meshRd.materials[i].color = _color;
            _meshRd.materials[i].mainTexture = _texture[i];
        }
    }




    public enum BlendMode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent
    }

    public static void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                break;
            case BlendMode.Cutout:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 2450;
                break;
            case BlendMode.Fade:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
            case BlendMode.Transparent:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
        }

    }


    /*
    public static void SetFade(Image _image, Fade _fade, float _duration = 1f, float _delay = 0f)
    {
        Single.Scene.StartCoroutine(CoFade(_image, _fade, _duration));
    }

    private static IEnumerator CoFade(Image _image, Fade _fade, float _duration = 1f, float _delay = 0f)
    {
        if (_fade == Fade.OutActIn)
        {
            WaitForSeconds wait = new WaitForSeconds(_delay);
            while (true)
            {
                yield return CoFade(_image, Fade.In, _duration);
                yield return wait;
                yield return CoFade(_image, Fade.Out, _duration);
                yield return wait;
            }
        }
        else
        {
            float curTime = 0f;
            Color tempColor = _image.color;
            while (curTime < _duration)
            {
                curTime += Time.deltaTime / _duration;
                if (_fade == Fade.In)
                {
                    _image.color = Color.Lerp(tempColor, new Color(tempColor.r, tempColor.g, tempColor.b, 1f), Mathf.Clamp01(curTime / _duration));
                }
                else if (_fade == Fade.Out)
                {
                    _image.color = Color.Lerp(tempColor, new Color(tempColor.r, tempColor.g, tempColor.b, 0f), Mathf.Clamp01(curTime / _duration));
                }
                yield return null;
            }
        }
    }
     */
}
