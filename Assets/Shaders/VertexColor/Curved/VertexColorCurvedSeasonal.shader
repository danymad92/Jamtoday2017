Shader "Nicky Prefab Team/Curved/Vertex Color Curved Seasonal" {

Properties{
	_Light("Light",Vector) = (0,0,0,0)
	_LightIntensity("Light Intensity", Float) = 0.4
	_LightMap ("Light Map", 2D) = "white" {}
	_SeasonColor("Season Color", Color) = (1, 1, 1, 1)
	_WinterFactor("WinterFactor", Range (0.0, 1.0)) = 0.0

	_Force("Force",Vector) = (1,0,1)
	_Period("Period",Vector) = (1,0,1)
	_Delay("Delay",Vector) = (1,0,1)

	_QOffset ("Offset", Vector) = (0,0,0,0)
	_Dist ("Distance", Float) = 100.0
}

   SubShader {
	   Pass {	
 
			 CGPROGRAM
 
			 #pragma vertex vert  
			 #pragma fragment frag 
 
			 #include "UnityCG.cginc"
 

			 struct vertexInput {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 col: COLOR;
				float4 secondcol: TEXCOORD3;
				float2 LMUV : TEXCOORD1;
				float4 height : TEXCOORD2;
			 };

			 struct vertexOutput {
				float4 pos : SV_POSITION;
				float3 normal: TEXCOORD0; 
				float4 col : TEXCOORD1;
				float2 LMUV : TEXCOORD2;
				float4 secondcol : TEXCOORD3;
			 };

			 float4 _Light;
			 float _LightIntensity;

			 sampler2D _LightMap;
			 float4 _LightMap_ST;

			 float4 _SeasonColor;
			 float _WinterFactor;

			 float3 _Force;
			 float3 _Period;
			 float3 _Delay;

			 float4 _QOffset;
			 float _Dist;

			 vertexOutput vert(vertexInput input) 
			 {
				vertexOutput output;
 
				float4x4 modelMatrix = unity_ObjectToWorld;
				float4x4 modelMatrixInverse = unity_WorldToObject;
 
				output.normal = normalize(
				   mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);


				float4 posWorld = mul(unity_ObjectToWorld,input.vertex);

				//Chicha del movimiento
				//float f = 2.0*(0.5+0.5*sin(0.1*posWorld.x+8.0*_Time.y))+2.0*(0.5+0.5*sin(0.1*posWorld.y+2.0*_Time.y));
				float fx = _Force.x*(0.5+0.5*sin(0.1*posWorld.x+_Period.x*_Time.y));
				float fy = 0.0;
				float fz = _Force.z*(0.5+0.5*sin(0.1*posWorld.x+_Period.z*_Time.y));

				//Restringimos a solo los arboles (lo coloreado por height)
				posWorld.x += fx*(1.0-clamp(0.0,1.0,input.height.x));
				posWorld.z += fz*(1.0-clamp(0.0,1.0,input.height.x));

				float4 vPos = mul(UNITY_MATRIX_V, posWorld);

				float zOff = vPos.z / _Dist;
			   	vPos += _QOffset * zOff * zOff;

				output.pos = mul(UNITY_MATRIX_P, vPos);
				output.col = input.col;
				output.secondcol = input.secondcol;
				output.LMUV = TRANSFORM_TEX(input.LMUV, _LightMap);

				return output;
			 }

			 float4 RBGlerp(float4 a, float4 b, float t)
			 {
				 return float4(a.x + (b.x - a.x)*t, a.y + (b.y - a.y)*t, a.z + (b.z - a.z)*t, 1);
			 }
 
			 float4 frag(vertexOutput input) : COLOR
			 {
			 	// Color Base
			 	float4 col = _SeasonColor;

				// Calculamos la cantidad de luz que llega a ese punto
         		float3 light = normalize(_Light);
         		float f = dot(light,input.normal);
         		f = 0.5 + 0.5*f;

				// Le añadimos esa luz al color de la textura, además podemos variar la intensidad global de la luz
         		col *= float4(_LightIntensity + f * input.col.xyz,1.0);

         		// Aplicamos la nieve
         		f = clamp(0.0, 1.0, 1 - input.secondcol.x);
         		col = lerp(col, 0.8*float4(1, 1, 1, 1), _WinterFactor*f);

				// Aplicamos el lightmap
         		col *= tex2D(_LightMap,input.LMUV);

         		return col;

			 }
 
			 ENDCG
	   }
   }
   Fallback "Diffuse"
}