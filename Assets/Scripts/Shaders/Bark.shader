Shader "Custom/Bark"
{
    Properties
    {
        _Color("Main Color", Color) = (1,1,1,1)

        [HideInInspector] _TreeInstanceColor("TreeInstanceColor", Vector) = (1,1,1,1)
        [HideInInspector] _TreeInstanceScale("TreeInstanceScale", Vector) = (1,1,1,1)
    }

        SubShader
    {
        Tags
        {
            "RenderType" = "TreeBark"
        }
        LOD 200

        CGPROGRAM
        #pragma surface surf NoLighting vertex:TreeVertBark
        #include "UnityBuiltin3xTreeLibrary.cginc"

        struct Input
        {
            float2 uv_MainTex;
            fixed4 color : COLOR;
        };

        fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
        {
            fixed4 c;
            c.rgb = s.Albedo;
            c.a = s.Alpha;
            return c;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = IN.color.rgb;
        }

        ENDCG
    }
}