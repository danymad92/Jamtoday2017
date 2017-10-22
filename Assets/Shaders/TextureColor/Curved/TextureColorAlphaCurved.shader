Shader "Nicky Prefab Team/Curved/Texture Color Alpha Curved" {

Properties{
	_DiffuseMap ("Diffuse Map", 2D) = "white" {}
	_Light ("Light",Vector) = (0,0,0,0)
	_LightIntensity("Light Intensity", Float) = 0.25
	_LightMap ("Light Map", 2D) = "white" {}

	_Alpha("Alpha", Range (0.0, 1.0)) = 0.0

	_QOffset ("Offset", Vector) = (0,0,0,0)
	_Dist ("Distance", Float) = 100.0

}

   SubShader {
   			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjection" = "True" }

           Pass {	

             Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency
             // Este modo nos puede interesar para otros efectos
             // Blend Blend One OneMinusSrcAlpha // Premultiplied transparency
 
	         CGPROGRAM
	 
	         #pragma vertex vert  
	         #pragma fragment frag 
	 
	         #include "UnityCG.cginc"
	 

	         struct vertexInput {
	            float4 vertex : POSITION;
	            float3 normal : NORMAL;
	            float2 uv0: TEXCOORD1;
	            float2 LMUV : TEXCOORD2;
	         };

	         struct vertexOutput {
	            float4 pos : SV_POSITION;
	            float3 normal: TEXCOORD0; 
	            float2 uv0 : TEXCOORD1;
	            float2 LMUV : TEXCOORD2;
	         };

				sampler2D _DiffuseMap;
				float4 _DiffuseMap_ST;

	         float4 _Light;
	         float _LightIntensity;

	         sampler2D _LightMap;
	         float4 _LightMap_ST;

	         float _Alpha;

	         float4 _QOffset;
		 	 float _Dist;


	         vertexOutput vert(vertexInput input) 
	         {
	            vertexOutput output;
	 
	            float4x4 modelMatrix = unity_ObjectToWorld;
	            float4x4 modelMatrixInverse = unity_WorldToObject;
	 
	            output.normal = normalize(
	               mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
	 
            	float4 vPos = mul(UNITY_MATRIX_MV, input.vertex);

				float zOff = vPos.z / _Dist;
			   	vPos += _QOffset * zOff * zOff;

				output.pos = mul(UNITY_MATRIX_P, vPos);
	            output.uv0 = input.uv0;
	            output.LMUV = input.LMUV;
	            return output;
	         }
	 
	         float4 frag(vertexOutput input) : COLOR
	         {
	         	// Calculamos la cantidad de luz que llega a ese punto
	         	float3 light = normalize(_Light);
	         	float f = dot(light,input.normal);
	         	f = 0.5 + 0.5*f;

	         	// Aplicamos la textura
				float4 col = tex2D(_DiffuseMap,input.uv0);

				// Le añadimos esa luz a la textura, además podemos variar la intensidad global de la luz
				float lightFactor = _LightIntensity + f;
	         	col *= float4(lightFactor, lightFactor, lightFactor, 1.0);

	         	// Aplicamos el lightmap
	         	col *= tex2D(_LightMap,input.LMUV);

	         	col.w = _Alpha;

	         	return col;
	         }
	 
	         ENDCG
      }
   }
   Fallback "Diffuse"
}