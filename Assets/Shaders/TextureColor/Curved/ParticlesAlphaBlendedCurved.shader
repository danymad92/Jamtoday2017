

Shader "Nicky Prefab Team/Curved/Particles Alpha Blended Curved" {
Properties {
	_MainTex ("Particle Texture", 2D) = "white" {}
	_QOffset ("Offset", Vector) = (0,0,0,0)
	_Dist ("Distance", Float) = 100.0
	_TexTiling ("TexTiling", Vector) = (0,0,0,0)
	_TexOffset ("TexOffset", Vector) = (0,0,0,0)
	_TintColor ("Tint Color", Color) = (1,1,1,1)

}

Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha OneMinusSrcAlpha
	Cull Off Lighting Off ZWrite Off 
	
	BindChannels {
		Bind "Color", color
		Bind "Vertex", vertex
		Bind "TexCoord", texcoord
	}
	
	SubShader {
		Pass {
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			float4 _QOffset;
			float _Dist;
			float4 _TexTiling;
			float4 _TexOffset;
			fixed4 _TintColor;


			struct v2f {
			    float4 pos : SV_POSITION;
			    float2 uv : TEXCOORD0;
			    fixed4 color : COLOR;
			    UNITY_FOG_COORDS(4)
			};
			
			v2f vert(appdata_full v)
			{
			   v2f o;
			   float4 vPos = mul(UNITY_MATRIX_MV, v.vertex);
			   float zOff = vPos.z / _Dist;
			   vPos += _QOffset * zOff * zOff;
			   o.pos = mul(UNITY_MATRIX_P, vPos);
			   o.uv = (v.texcoord * _TexTiling.xy) + _TexOffset.xy;
			   o.color = v.color;
			   return o;
			}
			
			half4 frag(v2f i) : COLOR0
			{
			  	half4 col = tex2D(_MainTex, i.uv);
			  	col = col * i.color * _TintColor;
				return col;
			}
			ENDCG
		}
	}
}
}
