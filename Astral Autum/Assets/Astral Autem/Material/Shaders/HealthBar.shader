Shader "Custom/HealthBar"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _MaxColor("Max Color", Color) = (1,1,1,1)
        _MinColor("Min Color", Color) = (1,1,1,1)
        _EmptyBar("Empty Color", Color) = (1,1,1,1)
        _HealthAmount("Health", Range(0,1)) = 0
        _FlashReduction("Flash Reduction", Range(0.1,0.9)) = 0.1
        _FlashSpeed("Flash Speed", Range(0.1,5)) = 1
        _Transparency("Transparency", Range(0,1)) = 0  
        _BorderSize("Border Size", Range(0,1)) = 0  
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType" = "Transparency"}
        LOD 100

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
          
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MaxColor;
            float4 _MinColor;
            float4 _EmptyBar;
            float _HealthAmount;
            float _Transparency;
            float _FlashReduction;
            float _FlashSpeed;
            float _BorderSize;
            
            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (MeshData v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float InverseLerp(float a, float b, float v)
            {
                return (v-a)/(b-a);
            }
            
            float4 frag (v2f i) : SV_Target
            {
                float2 coords = i.uv;
                coords.x *= 8;
                
                float2 pointOnLineSeg = float2(clamp(coords.x, 0.5, 7.5),0.5);
                float sdf = distance(coords, pointOnLineSeg) *2-1;

                clip(-sdf);

                float borderSdf = sdf + _BorderSize;
                float pd = fwidth(borderSdf); // Screen space partial derivative
                float borderMask = 1-saturate(borderSdf/pd); //inverting a color by doing 1-
                
                //Above is for rounding and clipping

                float healthbarMask = _HealthAmount > i.uv.x;
                float xPos = i.uv.x;
                float2 texturePos = float2(_HealthAmount, i.uv.y);
                float3 col;
                float4 healthColor;
                float t = InverseLerp(0.2, 0.8, _HealthAmount);
                healthColor = lerp(_MinColor, _MaxColor, t);
                                
                
                col = tex2D(_MainTex, texturePos);
                if(_HealthAmount < 0.2)
                {
                    col = col + abs(cos(_FlashSpeed * _Time.y) * _FlashReduction);
                }

                return float4(col * healthbarMask * borderMask, 1);
            }
            ENDCG
        }
    }
}
