Shader "Hidden/Gameboy"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Step ("Step", Range(0, 0.2)) = 0.02
    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Step;

            fixed4 frag (v2f i) : SV_Target
            {
                float4 originalColor = tex2D(_MainTex, i.uv);
                //if (_Step == 0) return originalColor;

                //float4 color;
                //if (originalColor.x == 1) {
                //    color.x = 1;
                //} else if (originalColor.x == 0) {
                //    color.x = 0;
                //} else {
                //    color.x = _Step * floor(originalColor.x / _Step) + _Step / 2;
                //}

                //if (originalColor.y == 1) {
                //    color.y = 1;
                //} else if (originalColor.y == 0) {
                //    color.y = 0;
                //} else {
                //    color.y = _Step * floor(originalColor.y / _Step) + _Step / 2;
                //}

                //if (originalColor.z == 1) {
                //    color.z = 1;
                //} else if (originalColor.z == 0) {
                //    color.z = 0;
                //} else {
                //    color.z = _Step * floor(originalColor.z / _Step) + _Step / 2;
                //}

                //color.rgb = _Step * floor(originalColor.rgb / _Step);
                //color.a = originalColor.a;
                
                return originalColor;
            }
            ENDCG
        }
    }
}
