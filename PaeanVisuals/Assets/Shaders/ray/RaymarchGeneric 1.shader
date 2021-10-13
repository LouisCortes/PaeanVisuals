
Shader "Hidden/RaymarchGeneric1"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Cull Off ZWrite Off ZTest Always
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile __ DEBUG_PERFORMANCE.
			#pragma target 3.0
			#include "UnityCG.cginc"			
			uniform sampler2D _CameraDepthTexture;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_TexelSize;
			uniform float4x4 _CameraInvViewMatrix;
			uniform float4x4 _FrustumCornersES;
			uniform float4 _CameraWS;
			uniform float3 _LightDir;
			uniform float3 _wp;
			uniform float3 _wr;
			uniform sampler2D _height_Material;
			uniform float _DrawDistance;
			uniform sampler2D _normal;
			uniform sampler2D _ao;
			uniform sampler2D _height;
			uniform sampler2D _rough;
			uniform sampler2D _albedo;
			uniform sampler2D _texture1;
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};
			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 ray : TEXCOORD1;
				float4 projPos : TEXCOORD2;
			};
			v2f vert (appdata v)
			{
				v2f o;
				
				half index = v.vertex.z;
				v.vertex.z = 0.1;
				
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv.xy;
				o.projPos = ComputeScreenPos (o.pos);
				#if UNITY_UV_STARTS_AT_TOP
				if (_MainTex_TexelSize.y < 0)
					o.uv.y = 1 - o.uv.y;
				#endif
				o.ray = _FrustumCornersES[(int)index].xyz;
				o.ray /= abs(o.ray.z);
				o.ray = mul(_CameraInvViewMatrix, o.ray);
				return o;
			}
			float smin(float a, float b, float t) {
				float h = clamp(0.5 + 0.5*(b - a) / t, 0., 1.);
				return lerp(b, a, h) - t * h*(1. - h);
			}
			float3 smin(float3 a, float3 b, float t) {
				float3 h = clamp(0.5 + 0.5*(b - a) / t, 0., 1.);
				return lerp(b, a, h) - t * h*(1. - h);
			}

			float3 ov(float3 a, float3 b) { return lerp(2.*a*b, 1. - 2.*(1. - a)*(1. - b), step(0.5, a)); }
			
			float box(float3 p, float3 r) {
				float3 q = abs(p) - r;
				return length(max(q, float3(0.,0.,0.))) + min(0., max(q.x, max(q.z, q.y)));
			}
			float2x2 rot(float t) { float c = cos(t); float s = sin(t); return float2x2(c, -s, s, c); }
			float ts; float tt; float ta; float2 tn; float tc; float dl;
			float map(float3 p,float2 uv) {
				float3 pfc = p;
				p += _wp;
				p.xz = mul(p.xz,rot(_wr.z));
				float3 pn = p;
				float d1 = 100.; float d4 = 100.;
				p.xz = mul(p.xz,rot(-0.5));
				float3 pl = p;
				for (int k = 0; k < 6; k++) {
					p -= 0.9;
					p.xz = mul(p.xz,rot(0.5));
					p.yz  = mul (p.yz,rot(0.8));
					p = abs(p);
					pl -= 0.9;
					pl.xz = mul(pl.xz, rot(0.5));
					pl.yz = mul(pl.yz, rot(0.8));
					pl = smin(pl, -pl, -0.8);
					d1 = min(d1, box(p, float3(0.8, 0.6, 0.9)));
					d4 = min(d4, box(pl, float3(0.8, 0.6, 0.9)));
				}
				tc = tex2D(_albedo, p.xz*0.5).x*0.35 + tex2D(_albedo, pn.xz*0.3).x*0.65;
				ts = tex2D(_rough, p.xz*0.5).x*0.35 + tex2D(_rough, pn.xz*0.3).x*0.65;
				tt = tex2D(_height, p.xz*0.5).x*0.35 + tex2D(_height, pn.xz*0.3).x*0.65;
				ta = tex2D(_ao, p.xz*0.5).x*tex2D(_ao, pn.xz*0.3).x;
				//tn = (tex2D(_normal, p.xz*0.5).xy + tex2D(_normal, pn.xz*0.3).xy - 1.);
				float d2 = d1 - tex2D(_height, p.xz*0.5).x*0.3 - tex2D(_height, pn.xz*0.3).x*0.6;
				d4 += sin(_Time.y)*0.7+ tex2D(_texture1, frac(pfc.xy*0.1)).x*0.2;
				//float d3 = max(d4 , -(pfc.x + tex2D(_texture1,frac( pfc.yz*0.1)).x*2. + sin(_Time.y)*10.));
				dl = d4;

				return min(d2, d4);
			}
			float3 nor(float3 p,float2 uv) { float2 e = float2(0.0001, 0.); return normalize(map(p,uv) - float3(map(p - e.xyy, uv), map(p - e.yxy, uv), map(p - e.yyx, uv))); }
			float getShadow(float3 pos, float3 at, float k,float2 uv) {
				float3 dir = normalize(at - pos);
				float maxt = length(at - pos);
				float f = 1.;
				float t = .01*10.;
				for (float i = 0.; i <= 1.; i += 1. / 30.) {
					float dist = map(pos + dir * t, uv);
					if (dist < .01) return 0.;
					f = min(f, k * dist / t);
					t += dist;
					if (t >= maxt) break;
				}
				return f;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float3 ray= normalize(i.ray.xyz);
				float3 pos = _CameraWS;
				float2 uv = i.uv;
				float2 duv = i.uv;
				#if UNITY_UV_STARTS_AT_TOP
				if (_MainTex_TexelSize.y < 0)
					duv.y = 1 - duv.y;
				#endif

				float depth = LinearEyeDepth(tex2D(_CameraDepthTexture, duv).r);
				depth *= length(i.ray);

				fixed3 col = tex2D(_MainTex,i.uv);
				
				float t =0.;
				float3 p = float3(0.,0.,0.);
				for (int i = 0; i < 40; ++i) {
				if (t >= depth || t > _DrawDistance) {
						//ret = fixed4(0, 0, 0, 0);
						break;
					}
				
				 p = pos + ray*t;
				float dist = map(p, uv);
				if (dist<0.01){
				break;
				}				 
				 t += dist;
				}
				float ml = step(0.01, dl);
				float s = smoothstep(_DrawDistance, 0., t);
				float3 n = nor(p, uv);
				float ld = clamp(dot(n, -ray), 0., 1.);
				float fres = ((pow(1. - ld, ts) + pow(ld, ts))*(1. - ts) + tc)*ta;
				float3 lp = _LightDir;
				float l1 = dot(n, normalize(lp));
				float sha = lerp(pow(tt, 2.5), 1., getShadow(p, lp, 64., uv));
				float l2 = sha * l1;
				float al = ov(fres, l2);
				float frl = pow(1. - ld, 5.) + pow(ld, 500.);
				float r1 = lerp(frl, al, ml);
				return fixed4 (r1,r1,r1,1.)*s;
				
			}    
			ENDCG
		}
	}
}
