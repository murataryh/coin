Shader "Unlit/CoinMateria"
{
    SubShader
    {
      Pass
      {
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #include "UnityCG.cginc"

        struct appdata
        {
          float4 vertex : POSITION;
          float3 normal : NORMAL;
        };

        struct v2f
        {
          float4 vertex : SV_POSITION;
          float3 normal : NORMAL;
          float3 worldPosition : TEXCOORD1;
        };

        v2f vert(appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.normal = UnityObjectToWorldNormal(v.normal);
            o.worldPosition = mul(unity_ObjectToWorld, v.vertex);
            return o;
        }

        fixed4 frag(v2f i) : SV_Target
        {
          float3 eyeDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPosition);
          float intensity = saturate(dot(normalize(i.normal), normalize(_WorldSpaceLightPos0 + eyeDir)));
          fixed4 color = fixed4(1,1,0,1);
          return color * pow(intensity,20);
        }

        ENDCG
      }
    }
}
