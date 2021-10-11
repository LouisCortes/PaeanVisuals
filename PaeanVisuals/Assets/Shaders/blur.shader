Shader "Unlit/blur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
			{

				float b = sqrt(64.);
			float3 c = float3(0.,0.,0.); float d = pow(length(i.uv.y - 0.5), 2.)*0.02;
			for (float k = -0.5*b; k <= 0.5*b; k += 1.)
				for (float j = -0.5*b; j <= 0.5*b; j += 1.) {
				c += tex2D(_MainTex, i.uv+float2(k,j)*d).xyz;
			}
			c /= 64.;

                return float4(c,1.);
            }
            ENDCG
        }
    }
}
