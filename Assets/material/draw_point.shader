// Upgrade NOTE: commented out 'float4x4 _CameraToWorld', a built-in variable
// Upgrade NOTE: commented out 'float4x4 _WorldToCamera', a built-in variable
// Upgrade NOTE: replaced '_WorldToCamera' with 'unity_WorldToCamera'

Shader "Custom/BallWithCameraRelativePointShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PointColor ("Point Color", Color) = (1,0,0,1)
        _PointSize ("Point Size", Float) = 10.0
        _PointPosition ("Point Position", Vector) = (0,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            fixed4 _PointColor;
            float _PointSize;
            float3 _PointPosition;
            // float4x4 _CameraToWorld;
            // float4x4 _WorldToCamera;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float3 cameraPointPos = mul(unity_WorldToCamera, float4(_PointPosition, 1)).xyz;
                float3 cameraSpherePos = mul(unity_WorldToCamera, float4(i.worldPos, 1)).xyz;
                cameraPointPos.z = 0; // Project the point onto the camera plane
                cameraSpherePos.z = 0; // Project the sphere surface point onto the camera plane
                float dist = length(cameraPointPos - cameraSpherePos);
                if (dist < (_PointSize / _ScreenParams.y))
                {
                    col = _PointColor;
                }
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}