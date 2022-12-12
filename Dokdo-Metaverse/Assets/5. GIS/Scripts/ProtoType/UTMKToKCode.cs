using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UTMK 코드를 국가지점번호로 변환하는 로직
/// </summary>
public class UTMKToKCode : MonoBehaviour
{
    private Dictionary<int, string> widthDictionary = new Dictionary<int, string>();
    private Dictionary<int, string> heightDictionary = new Dictionary<int, string>();

    private void Start()
    {
        widthDictionary = new Dictionary<int, string>()
        {
            {7, "가"},
            {8, "나"},
            {9, "다"},
            {10, "라"},
            {11, "마"},
            {12, "바"},
            {13, "사"},
        };

        heightDictionary = new Dictionary<int, string>()
        {
            {13, "가"},
            {14, "나"},
            {15, "다"},
            {16, "라"},
            {17, "마"},
            {18, "바"},
            {19, "사"},
            {20, "아"},
        };
        // 100km = 100000m
    }
}
