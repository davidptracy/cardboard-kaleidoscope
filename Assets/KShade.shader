Shader "Custom/KShade" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _Tint ("Tint Color", Color) = (1,1,1,1)
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert vertex:vert
      struct Input {
          float2 uv_MainTex;
      };
      float4 _Tint;
      void vert (inout appdata_full v) {
          v.vertex.xyz += v.normal * sin(10.0*v.vertex.x+_Time);
      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _Tint;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }