Shader "Nicky Prefab Team/Vertex Color" {

Properties{
	_Light("Light",Vector) = (0,0,0,0)
	_LightIntensity("Light Intensity", Float) = 0.4
	_LightMap ("Light Map", 2D) = "white" {}
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
				float2 LMUV : TEXCOORD1;
			 };

			 struct vertexOutput {
				float4 pos : SV_POSITION;
				float3 normal: TEXCOORD0; 
				float4 col : TEXCOORD1;
				float2 LMUV : TEXCOORD2;
			 };

			 float4 _Light;
			 float _LightIntensity;

			 sampler2D _LightMap;
			 float4 _LightMap_ST;

			 vertexOutput vert(vertexInput input) 
			 {
				vertexOutput output;
 
				float4x4 modelMatrix = unity_ObjectToWorld;
				float4x4 modelMatrixInverse = unity_WorldToObject;
 
				output.normal = normalize(
				   mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);

				float4 vPos = mul(UNITY_MATRIX_MV, input.vertex);

				output.pos = mul(UNITY_MATRIX_P, vPos);
				output.col = input.col;
				output.LMUV = input.LMUV;
				return output;
			 }

			 float4 RBGlerp(float4 a, float4 b, float t)
			 {
				 return float4(a.x + (b.x - a.x)*t, a.y + (b.y - a.y)*t, a.z + (b.z - a.z)*t, 1);
			 }
 
			 float4 frag(vertexOutput input) : COLOR
			 {
				// Calculamos la cantidad de luz que llega a ese punto
         		float3 light = normalize(_Light);
         		float f = dot(light,input.normal);
         		f = 0.5 + 0.5*f;

				// Le añadimos esa luz al color de la textura, además podemos variar la intensidad global de la luz
         		float4 col = float4(_LightIntensity + f * input.col.xyz,1.0);

				// Aplicamos el lightmap
         		col *= tex2D(_LightMap,input.LMUV);

         		return col;
			 }
 
			 ENDCG
	   }
   }
   Fallback "Diffuse"
}