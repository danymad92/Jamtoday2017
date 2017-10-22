Shader "LabCave/AdditiveColored" {
Properties {
	_MainTex ("Particle Texture", 2D) = "white" {}
	_Color ("Main Color", Color) = (1,1,1,1)
}

Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
	Blend SrcAlpha One
	Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
	
	SubShader {
		Pass {
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
            sampler2D _MainTex;
			fixed4 _Color;
			
			struct v2f {
			    float4 pos : SV_POSITION;
			    float2 uv : TEXCOORD0;
			    fixed4 color : COLOR;
			};

			v2f vert(appdata_full v)
			{
			   v2f o;
			   float4 vPos = mul(UNITY_MATRIX_MV, v.vertex);
			   o.pos = mul(UNITY_MATRIX_P, vPos);
			   o.uv = v.texcoord;
			   o.color = v.color;
			   return o;
			}

			half4 frag(v2f i) : COLOR0
			{
			  	half4 col = tex2D(_MainTex, i.uv) * _Color;
				return col * i.color;
			}
			ENDCG
		}
	}
}
}