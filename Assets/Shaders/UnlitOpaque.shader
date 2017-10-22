// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "LabCave/UnlitOpaque"
{
	Properties
	{
		_DiffuseMap ("Diffuse Map", 2D) = "white" {}
		_LightMap ("Light Map", 2D) = "white" {}
		_EmissiveMap ("Emissive Map", 2D) = "black" {}
		_Color ("Day cycle", Color) = (0,0,0,0)
		_TilingOffsetDif("Tiling-Offset Dif", Vector) = (1,1,0,0)
		_TilingMovementSpeed("Tiling Movement Speed", float) = 0
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
				float2 uv1 : TEXCOORD1;

			};

			struct v2f
			{
				float2 uv0 : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _DiffuseMap;
			float4 _DiffuseMap_ST;

			sampler2D _LightMap;
			float4 _LightMap_ST;

			sampler2D _EmissiveMap;
			float4 _EmissiveMap_ST;

			float4 _Color;

			
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				//o.uv0 = v.uv0;
				//o.uv1 = v.uv1;
				o.uv0 = TRANSFORM_TEX(v.uv0, _DiffuseMap);
				o.uv1 = TRANSFORM_TEX(v.uv1, _LightMap);
				return o;
			}
			
			float4 frag (v2f i) : SV_Target
			{
				//Difuso
				float4 dif = tex2D(_DiffuseMap,i.uv0);
				//Emisivo
				float4 emi = tex2D(_EmissiveMap,i.uv1);

				//Mezclamos con emisivo
				//Screen blending
				float4 col;
				//col = float4(saturate((1.0-(1.0-dif.rgb)*(1.0-(emi.rgb*0.7)))),dif.a);
				col = dif + emi;
				//Añadimos sombras con lightmap
				col *= tex2D(_LightMap,i.uv1);

				//Tintamos
				col *= _Color;

				return col;
			}
			ENDCG
		}
	}
}
