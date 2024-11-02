Shader "Custom/ZebraShader"
{
    Properties
    {
        _ColorA ("ColorA", Color) = (1,1,1,1)
        _ColorB ("ColorB", Color) = (0,0,0,0)
        _StripeWidth ("Stripe Width", Range(0, 1)) = 10
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
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
            
            float4 _ColorA, _ColorB;
            float _StripeWidth;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                
                float stripe = frac(i.uv.y / _StripeWidth);
                fixed4 col = lerp(_ColorA, _ColorB, step(0.5, stripe));
                return col;
            }
            ENDCG
        }
    }
}
