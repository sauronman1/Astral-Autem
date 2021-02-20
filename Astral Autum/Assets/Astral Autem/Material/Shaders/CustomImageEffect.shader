Shader "Custom/CustomImage"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _DisplaceTex("Displacement Texture", 2D) = "white" {}
        _Magnitude("Magnitude", Range(0,0.5)) = 1
        _WaveSpeed("Wave Speed", Range(1,0.01)) = 1
        _Transparency("Transparency", Range(0,1)) = 1
    }    
    SubShader
    {
        Tags
        {
            "Queu" = "Transparent"
        }
        Pass
        {
            Blend srcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _DisplaceTex;
            float _Magnitude;
            float _WaveSpeed;
            float _Transparency;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            
            
            float4 frag(v2f i) : SV_Target
            {
                float2 distuv = float2(i.uv.x + _WaveSpeed * _Time.x * 2, i.uv.y + _WaveSpeed * _Time.x * 2);
                
                float2 disp = tex2D(_DisplaceTex, distuv).xy;
                disp = ((disp * 2) - 1) * _Magnitude;
                float4 color = tex2D(_MainTex, i.uv + disp);
                color = color * float4(1,1,1,_Transparency);
                return color;
            }
            ENDCG
        }
    }
}
