Shader "Unlit/luid2d"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
	 _noise("_noise", 2D) = "white" {}
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
			sampler2D _noise;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
			float hs(float p) { return frac(sin(dot(p, 45.))*7845.236 ); }
			float ov(float a, float b) { return lerp(2.*a*b, 1. - 2.*(1. - a)*(1. - b), step(0.5, a)); }
            fixed4 frag (v2f i) : SV_Target
            {
					float b = sqrt(64.);
			float c = 0.; float n = 0.;
			float d = pow(length(i.uv.y - 0.5), 1.5)*0.02;
			float2 uu = i.uv * 15. +float2(hs(_Time.y+8.23),hs(_Time.y+125.3));
			for (float k = -0.5*b; k <= 0.5*b; k += 1.)
				for (float j = -0.5*b; j <= 0.5*b; j += 1.) {
					c += tex2D(_MainTex, i.uv + float2(k, j)*d).x;
					n += tex2D(_noise, uu + float2(k, j)*d).x;
			}
			c /= 64.;
			n /= 66.;
			n = clamp(n, 0., 1.);
               float col = pow(1.-c,2.);
			   col = ov(col, n);
                return col*float4(0.,0.,1.,1.);
            }
            ENDCG
        }
    }
}
