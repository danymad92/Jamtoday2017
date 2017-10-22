// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "LabCave/Slipstream"
{
	Properties
	{
		_DiffuseMap ("Diffuse Map", 2D) = "white" {}
		_Color ("Day cycle", Color) = (0,0,0,0)
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
				float2 uv0 : TEXCOORD0;

			};

			struct v2f
			{
				float2 uv0 : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _DiffuseMap;
			float4 _DiffuseMap_ST;

			float4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv0 = v.uv0;
				return o;
			}
			
			float4 frag (v2f i) : SV_Target
			{
				//Difuso
				float4 col = tex2D(_DiffuseMap,i.uv0);

				//Tintamos
				col *= _Color;

				return col;
			}
			ENDCG
		}
	}
	CustomEditor "SlipstreamMaterialInspector"
}
