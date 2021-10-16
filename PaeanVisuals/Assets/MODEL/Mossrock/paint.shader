Shader "Custom/paint" {
	Properties {
		[Header(standard)]
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Smoothstess ", 2D) = "white" {}
		_Normal("Normal ", 2D) = "bump" {}
		_Normal2("Normal2 ", 2D) = "bump" {}
		_Tex ("Metalic ", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_iridescent("_iridescent", Range(0,1)) = 0.0
		_zoneIridescent("_zoneIridescent", Range(0,1)) = 0.5
[Space]
		[Space]
		[Header(ondulation)]
		_v1("tailleOndulation",Range(0,1)) = 0.0
		_v2("intensiteOndulation",Range(0,1)) = 0.0
		_v3("variationOndulation",Float) = 0
		_v4("mouvement",Range(0,1)) = 0.0
[Space]
		[Space]
		[Header(twist)]
		_tailleTwist("_tailleTwist", Float) = 0
		_mvtTwist("_mvtTwist", Float) = 0
[Space]
		[Space]
		[Header(mouvement aleatiore)]
		_RandomMotion("_RandomMotion",Range(0,1)) = 0
		_SpeedRandomMotion("_SpeedRandomMotion",Range(0,1)) = 0.5
[Space]
		[Space]
		[Header(rotation)]
		_rotationYAxis("_rotationYAxis",Float) = 0
		_rotationZAxis("_rotationZAxis",Float) = 0

[Space]
		[Space]
[Header(Utilities)]

		_Ramp("ramp ", 2D) = "white" {}
		_v5("tnPastoucher", Float) = 0.1
		_v6("pnPastoucher", Float) = 3

	  _audio1("audio1",Range(0,1)) = 0
			_liquide("_liquide",Range(0,1)) = 0
			_fluid("_fluid ", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		//Cull Off
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _Tex;
		float4 _Tex_ST;
		sampler2D _Ramp;
		sampler2D _Normal;
		sampler2D _Normal2;
		sampler2D _fluid;
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float facing : VFACE;
			float3 viewDir;
			float3 worldNormal; INTERNAL_DATA
			
		};

		half _Glossiness;
		half _Metallic;

		half _v1;
		half _v2;
		float _v3;
		float _v4;
		float _v5;
		float _v6;
		float _liquide;
		float _tailleTwist;
		float _mvtTwist;
		float _RandomMotion;
		float _SpeedRandomMotion;
		float _rotationYAxis;
		float _rotationZAxis;
		float _intentisityRotation;
		float _iridescent;
		float _zoneIridescent;
		float _audio1;
		fixed4 _Color;
		struct VertexInput {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
			float4 texcoord  : TEXCOORD0;
			
		};
		struct VertexOutput {
			float4 pos : SV_POSITION;
			float2 uv : TEXCOORD0;

		};
		
		UNITY_INSTANCING_BUFFER_START(Props)
			UNITY_INSTANCING_BUFFER_END(Props)

			float hs(float2 p) { return frac(sin(dot(p, float2(45., 98.)))*7845.236); }
		
		float2x2 rot(float t) { float c = cos(t); float s = sin(t); return float2x2(c, -s, s, c); }
		float4x4 rx(float t) {
			return  float4x4(1.0, 0.0, 0.0, 0.0,
				0.0, cos(t), sin(t), 0.0,
				0.0, -sin(t), cos(t), 0.0,
				0.0, 0.0, 0.0, 1.0);
		}
		float4x4 ry(float t) {
			return  float4x4(cos(t), 0.0, -sin(t), 0.0,
				0.0, 1.0, 0.0, 0.0,
				sin(t), 0.0, cos(t), 0.0,
				0.0, 0.0, 0.0, 1.0);
		}
		float4x4 rz(float t) {
			return  float4x4(cos(t), sin(t), 0.0, 0.0,
				-sin(t), cos(t), 0.0, 0.0,
				0.0, 0.0, 1.0, 0.0,
				0.0, 0.0, 0.0, 1.0);
		}
			void vert(inout appdata_full v)
		{
				float3 p = mul(unity_ObjectToWorld, v.vertex);
			//float to = tex2Dlod(_Ramp, float4(float2(0.5,_Time.x*10.* _SpeedRandomMotion), 0., 0)).r * _RandomMotion;
			//float to2 = tex2Dlod(_Ramp, float4(float2(0.5, _Time.x * 20.* _SpeedRandomMotion), 0., 0)).r * _RandomMotion;
			float to3 =( tex2Dlod(_Ramp, float4(float2(0.5, _Time.x * 50.* _SpeedRandomMotion), 0., 0)).r - 0.5) * _RandomMotion*3.;
			float to4 =( tex2Dlod(_Ramp, float4(float2(0.5, _Time.x * 30.* _SpeedRandomMotion), 0., 0)).r - 0.5) * _RandomMotion*3.;
			/*
			float3 vn = p * _v1 * 10. + _v3*2.5 + _Time * _v4;
			float2 e = float2(_v5, 0.);
			float v1 = no(vn + e.xyy);
			float v2 = no(vn - e.xyy);
			float v3 = no(vn + e.yxy);
			float v4 = no(vn - e.yxy);
			float v5 = no(vn + e.yyx);
			float v6 = no(vn - e.yyx);
			float3 rn =(float3(v1 - v2, v3 - v4,v5-v6));
			float vr = (p.x * _tailleTwist + _mvtTwist)+to*10. ;
			v.vertex.y += (no(vn) - 0.5) * _v2*10.;
			v.vertex = mul(v.vertex, rx(vr));*/
			/*v.normal = v.normal - rn * _v6*_v2*10.;
			v.normal = mul(v.normal, rx(vr));*/
			float t2 = pow(tex2Dlod(_Ramp, float4(float2(0.25, _Time.y), 0., 0)).r, 2.)*_audio1*10.;
			v.vertex = mul(v.vertex, rz((to3)*t2 ));
			v.vertex = mul(v.vertex, ry((to4)*t2));
			v.normal = mul(v.normal, rz((to3 )*t2));
			v.normal = mul(v.normal, ry((to4 )*t2));
				float time = _Time.y;
				float ta = pow(tex2Dlod(_Ramp, float4(float2(0.5, _Time.y), 0., 0)).r,2.)*_v4*5.*_audio1*10.;
			v.vertex.x += v.normal.x*(tex2Dlod(_Ramp, float4((p.zy+float2(-time,time)*2.)*0.25, 0., 0)).r-0.5)*ta;
			v.vertex.y += v.normal.y*(tex2Dlod(_Ramp, float4((p.zx + float2(time, time)*2.)*0.25, 0., 0)).r - 0.5)*ta;
			v.vertex.z += v.normal.z*(tex2Dlod(_Ramp, float4((p.xy + float2(-time, -time)*2.)*0.25, 0., 0)).r - 0.5)*ta;
			//v.vertex.xyz +=v.normal*smoothstep(0.4,1., tex2Dlod(_fluid, float4(v.texcoord.xy,0.,0.)).x)*0.1;
		}
		void surf (Input IN, inout SurfaceOutputStandard o) {
			
			o.Normal *= IN.facing;
			//float2 uf = 
			float fl = tex2D(_fluid, IN.uv_MainTex).x;
			float l2 = _liquide * 1.5;
			float mf = smoothstep(1.3-l2, 1.5-l2, fl);
			float2 e = float2(0.001, 0.);
			float t1 = smoothstep(1.4 - l2, 1.7 - l2, tex2D(_fluid, IN.uv_MainTex+e.xy).x);
			float t2 = smoothstep(1.4 - l2, 1.7 - l2, tex2D(_fluid, IN.uv_MainTex-e.xy).x);
			float t3 = smoothstep(1.4 - l2, 1.7 - l2, tex2D(_fluid, IN.uv_MainTex+e.yx).x);
			float t4 = smoothstep(1.4 - l2, 1.7 - l2, tex2D(_fluid, IN.uv_MainTex-e.yx).x);
			float3 n = normalize(float3(t1 - t2, t3- t4, 0.5));
			float2 e2 = float2(0.02, 0.);
			float t5 = tex2D(_fluid, IN.uv_MainTex + e2.xy).x;
			float t6 = tex2D(_fluid, IN.uv_MainTex - e2.xy).x;
			float t7 = tex2D(_fluid, IN.uv_MainTex + e2.yx).x;
			float t8 = tex2D(_fluid, IN.uv_MainTex - e2.yx).x;
			float3 n2 = normalize(float3(t5 - t6, t7 - t8, 0.05));
			n += n2;
			float h = hs(IN.uv_MainTex);
			float fres =dot(normalize(o.Normal), normalize(IN.viewDir))*h;
			float3 col = tex2D(_Tex, IN.uv_MainTex*5.).xyz;
			float fres2 = pow(1.-clamp(fres,0.,1.), _zoneIridescent*10.);
			fixed4 c =  lerp(_Color,float4(col,1.),fres2* _iridescent)*tex2D(_Tex, IN.uv_MainTex).y;
			o.Albedo =lerp(pow( c ,float4(0.5,0.5,0.5,1.)),float4(fl,fl,fl,1.),mf);
			o.Metallic = max(tex2D(_MainTex, IN.uv_MainTex*5.).x* _Metallic, mf);
			o.Smoothness = max(smoothstep(0.5,0.6,tex2D(_MainTex, IN.uv_MainTex).x*pow(h, 0.2))* _Glossiness,mf);
			o.Normal = lerp(UnpackNormal(tex2D(_Normal, IN.uv_MainTex)) + UnpackNormal(tex2D(_Normal2, IN.uv_MainTex*5.))*2. + (h - 0.5)*2.,n,mf);
			o.Emission = pow(mf*tex2D(_Tex, n).x, lerp(4., 2.25, fl));
			//o.Emission = fres;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
