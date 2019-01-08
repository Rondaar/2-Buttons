Shader "Unlit/BackgroundLines"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_SecTex ("Secondary Texture", 2D) = "white" {}
		_BackgroundColor ("Background Color", Color) = (0,0,0,1)
		_DotColor("Dot Color", Color) = (1,1,1,1)
		_DotColor2("Dot Color[2]", Color) = (1,1,1,1)
		_ScrollSpeedX ("Scroll horizontal speed", Float) = 1
		_ScrollSpeedY ("Scroll vertical speed", Float) = 0
		_ScrollSpeedX2 ("Scroll horizontal speed [2]", Float) = 1
		_ScrollSpeedY2 ("Scroll vertical speed [2]", Float) = 0
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
				float2 uv2 : TEXCOORD2;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _SecTex;
			float4 _SecTex_ST;
			fixed _ScrollSpeedX;
			fixed _ScrollSpeedY;
			fixed _ScrollSpeedX2;
			fixed _ScrollSpeedY2;
			fixed _BlinkSpeed;
			fixed _BlinkOffsetX;
			fixed _BlinkOffsetY;
			fixed4 _BackgroundColor;
			fixed4 _DotColor;
			fixed4 _DotColor2;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.uv,_SecTex);
				o.uv.x += _ScrollSpeedX*_Time;
				o.uv.y += _ScrollSpeedY*_Time;
				o.uv2.x += _ScrollSpeedX2*_Time;
				o.uv2.y += _ScrollSpeedY2*_Time;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 textureCol= tex2D(_MainTex, i.uv);
				fixed4 col = _DotColor;
				if (textureCol.r == 0)
				{
					textureCol = tex2D(_SecTex,i.uv2);
					col = _DotColor2;
				}
				
				return lerp(_BackgroundColor,col,textureCol.r);
			}
			ENDCG
		}
	}
}
