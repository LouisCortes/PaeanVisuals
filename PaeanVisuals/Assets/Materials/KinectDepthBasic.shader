Shader "Custom/KinectDepthBasic"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_noise("_noise", 2D) = "white" {}
		_Displacement("Displacement", Range(0, 0.1)) = 0.03
		_Color("Particle Color", Color) = (1,1,1,1)
		_audio1("_audio1", Range(0, 1.)) = 0
			_audio2("_audio2", Range(0, 1.)) = 0
		_liquide("_liquide", Range(0, 1.)) = 0
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
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
				float4 col : COLOR;
			};


			sampler2D _MainTex;
			float _Displacement;
			fixed4 _Color;
			sampler2D _noise;
			float4 _MainTex_ST;
			float _audio1;
			float _audio2;
			float _liquide;
			float no(float3 p) {
				float3 f = floor(p); p = smoothstep(0., 1., frac(p));
				float3 se = float3(45., 78., 945.); float4 v1 = dot(se, f) + float4(0., se.y, se.z, se.y + se.z);
				float4 v2 = lerp(frac(sin(v1)*7845.236), frac(sin(v1 + se.x)*7845.236), p.x);
				float2 v3 = lerp(v2.xz, v2.yw, p.y);
				return lerp(v3.x, v3.y, p.z);
			}
			v2f vert(appdata v)
			{
				float4 col = tex2Dlod(_MainTex, float4(v.uv, 0, 0));
				float time = _Time.y;
				float3 b1 = float3(no(v.vertex*1.5 + time) - 0.5, no(v.vertex*1.5 - time) - 0.5, no(v.vertex*1.5 + float3(time, -time, time)) - 0.5);
				float3 b2 = float3(no(v.vertex*5. + time * 3.) - 0.5, no(v.vertex*5. - time * 3.) - 0.5, no(v.vertex*5. + float3(time, -time, time)*3.) - 0.5);

				float d = col.x * 4000 * _Displacement;
				float2 p1 = (float2(v.vertex.y, v.vertex.z)+float2(_Time.y,-_Time.y)*0.75)*0.5;
				float2 p2 = (float2(v.vertex.x, v.vertex.z) + float2(-_Time.y, _Time.y)*0.75)*0.5;
				float2 p3 = (float2(v.vertex.y, v.vertex.x) + float2(-_Time.y, _Time.y)*0.75)*0.5;
				float li =step(0.001,col.x)*20.*max(pow(tex2Dlod(_noise, float4(0.,_Time.y, 0., 0.)).x,2.)*_audio1,_audio2)*length(v.vertex);
				v.vertex.x = v.vertex.x * d / 3.656+(tex2Dlod(_noise,float4(p1,0,0)).x-.5)*li;
				v.vertex.y = v.vertex.y * d / 3.656 + (tex2Dlod(_noise, float4(p2, 0, 0)).x - .5)*li;
				v.vertex.z = d + (tex2Dlod(_noise, float4(p3, 0, 0)).x - .5)*li;
				v.vertex.xyz += (b1*10.+b2 * lerp(3.5, 0.8, pow(_liquide, 0.25)))*_liquide;
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
	

				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = float4(1.,1.,1.,1.);

				return col;
			}
			ENDCG
		}
	}
}