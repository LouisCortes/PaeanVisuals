Shader "Unlit/alembic"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_fres("_fres",Range(0,1)) = 1
			_fresIntensity("_fresIntensity",Range(0,1)) = 1
			_spec("_spec",Range(0,1)) = 1
			_specIntensity("_specIntensity",Range(0,1)) = 1
			_Color("Main Color", COLOR) = (1,1,1,1)
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
				float3 normal :NORMAL;
				
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float3 normal : COLOR0;
				float4 worldPos : TEXCOORD2;
				float3 viewDir : TEXCOORD3;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float _fres;
			float _fresIntensity;
			float _spec;
			float _specIntensity;
			float4 _Color;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.viewDir = normalize(UnityWorldSpaceViewDir(o.worldPos));
				o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
			float3 n = i.normal;
			float ld = dot(n, i.viewDir);
			float spec = pow(ld, 500.*_spec)*_specIntensity;
			float fres = pow(1. - ld, 10.*_fres)*_fresIntensity;
			float3 reflectedDir =reflect(i.viewDir, normalize(n));
			float4 c = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, reflectedDir);
			return float4(_Color.xyz*(fres+spec)+c.xyz, 1.);
            }
            ENDCG
        }
    }
}
