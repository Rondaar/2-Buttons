Shader "Unlit/Background"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BackgroundColor ("Background Color", Color) = (0,0,0,1)
		_DotColor("Dot Color", Color) = (1,1,1,1)
		_ScrollSpeedX ("Scroll horizontal speed", Float) = 1
		_ScrollSpeedY ("Scroll vertical speed", Float) = 0
		_BlinkSpeed ("Blinking speed", Float) = 1
		_BlinkOffsetX("Blinking X offset", Float) = .25
		_BlinkOffsetY("Blinking Y offset", Float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }

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
				float3 viewPos : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed _ScrollSpeedX;
			fixed _ScrollSpeedY;
			fixed _BlinkSpeed;
			fixed _BlinkOffsetX;
			fixed _BlinkOffsetY;
			fixed4 _BackgroundColor;
			fixed4 _DotColor;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.viewPos = UnityObjectToViewPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv.x += _ScrollSpeedX*_Time;
				o.uv.y += _ScrollSpeedY*_Time;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 textureCol = tex2D(_MainTex, i.uv);

				return lerp(_BackgroundColor,lerp(_BackgroundColor,_DotColor,((sin(_Time.w*_BlinkSpeed+i.viewPos.x*_BlinkOffsetX+i.viewPos.y*_BlinkOffsetY)+1)/2.0)*(textureCol.r)*.8+.2+textureCol.g),textureCol.r+textureCol.g);
			}
			ENDCG
		}
	}
}
