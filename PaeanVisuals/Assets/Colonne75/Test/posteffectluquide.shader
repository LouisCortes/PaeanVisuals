Shader "Unlit/posteffectluquide$"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_noise("_noise", 2D) = "white" {}
	    _ref("ref", Cube) = "defaulttexture" {}
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
				float4 worldPos : TEXCOORD2;
				float3 viewDir : TEXCOORD3;
            };

            sampler2D _MainTex;
			sampler2D _noise;
            float4 _MainTex_ST;
			samplerCUBE _ref;
            v2f vert (appdata v)
            {
                v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.viewDir = normalize(UnityWorldSpaceViewDir(o.worldPos));
                return o;
            }
			float li(float3 r) {
				float time = _Time.y;
				r.xz = mul(r.xz, float2x2(cos(time), sin(time), -sin(time), cos(time)));
				float3 sp = normalize(r* float3(1., 0., 1.));
				return step(0.45,distance(0.5, frac(sp.x*1.5+sp.z)));
			}
            fixed4 frag (v2f i) : SV_Target
            {
				float2 uv = i.uv;
				float b = sqrt(64.);
				float3 c = float3(0., 0., 0.);
				fixed4 col = tex2D(_MainTex, uv);
				for(float i = -0.5*b ; i<=0.5*b; i +=1.)
					for (float j = -0.5*b; j <= 0.5*b; j += 1.) {
						c += tex2D(_MainTex, uv+float2(i,j)*0.003).xyz;
					}
				c /= 64.;
				float m = smoothstep(0., 0.01, max(col.x,col.y));
				float3 n = (c - 0.5)*2.;
				float3 refl= reflect(n, float3(uv,1.));
				//float4 val = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, n);
				float fres = dot(n, float3(0., 0., -1.));
                
				float4 ref = pow(smoothstep(0.,0.7,texCUBE(_ref, refl)),float4(1.6,1.6,1.6,1.));
				ref += float4(li(refl)*float3(0., 0., 1.),1.)*0.3;
				//float4 fond = lerp(col, float4(0., 0., 1., 1.), li(refl));
				return float4(lerp(col+smoothstep(0.7,0.75,tex2D(_noise,float2(0.5,_Time.y*0.5)).x)*float4(0.,0.,1.,1.), ref, m));
            }
            ENDCG
        }
    }
}
