// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Unlit/DepthMask"
{
    SubShader
    {
        Tags {"Queue" = "Transparent-1" }
        Pass
        {
            ZWrite On
            ColorMask 0
        }
    }
}