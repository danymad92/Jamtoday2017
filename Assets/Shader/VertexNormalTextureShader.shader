// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Vertex Normal Texure Shader" {

Properties{
	_Light ("Luz",Vector) = (0,0,0,0)
	_MainTexture("Main Texture", 2D) = "white" {}
	_LightMap ("Light Map", 2D) = "white" {}
}

   SubShader {
//   	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
//		Blend SrcAlpha OneMinusSrcAlpha 
           Pass {	
            // make sure that all uniforms are correctly set
 
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         #include "UnityCG.cginc"
 

         struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            //float4 col: COLOR;
			float2 uv0: TEXCOORD0;
            float2 LMUV : TEXCOORD2;
         };

         struct vertexOutput {
            float4 pos : SV_POSITION;
            float3 normal: TEXCOORD1; 
            //float4 col : TEXCOORD1;
			float2 uv0: TEXCOORD0;
            float2 LMUV : TEXCOORD2;
         };

         float4 _Light;
         
		 sampler2D _LightMap;
         float4 _LightMap_ST;

		 sampler2D _MainTexture;
		 float4 _MainTexture_ST;
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            float4x4 modelMatrix = unity_ObjectToWorld;
            float4x4 modelMatrixInverse = unity_WorldToObject;
 
            output.normal = normalize(
               mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
 
            output.pos = UnityObjectToClipPos(input.vertex);
			output.uv0 = TRANSFORM_TEX(input.uv0, _MainTexture);
            output.LMUV = input.LMUV;
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
         	float3 light = normalize(_Light);
         	float f = dot(light,input.normal);
         	f = 0.5 + 0.5*f;

         	//float4 _col = float4(0.25 + f * input.col.xyz,1.0);
			
			float4 _col = tex2D(_MainTexture, input.uv0);

			_col *= (0.0 + f);

         	_col *= tex2D(_LightMap,input.LMUV);

         	return _col;
//            return float4(0.25+f*input.col.xyz,1.0);
         }
 
         ENDCG
      }
   }
   Fallback "Diffuse"
}