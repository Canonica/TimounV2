// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:6815,x:33818,y:32591,varname:node_6815,prsc:2|normal-9015-RGB,emission-7031-OUT,clip-2116-R,olwid-3337-OUT,olcol-7044-RGB;n:type:ShaderForge.SFN_Tex2d,id:598,x:32345,y:32345,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_598,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:86b7001bc8c0a004d967e67f7c7203fd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9015,x:33427,y:32520,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_9015,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1c9726fbdf681294cb10bbdec7657503,ntxv:3,isnm:True;n:type:ShaderForge.SFN_LightVector,id:1327,x:31607,y:32160,varname:node_1327,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:928,x:31648,y:32319,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:2582,x:31889,y:32193,varname:node_2582,prsc:2,dt:0|A-1327-OUT,B-928-OUT;n:type:ShaderForge.SFN_LightColor,id:921,x:32120,y:32491,varname:node_921,prsc:2;n:type:ShaderForge.SFN_Multiply,id:100,x:32345,y:32534,varname:node_100,prsc:2|A-921-RGB,B-5984-RGB;n:type:ShaderForge.SFN_Multiply,id:8101,x:32548,y:32522,varname:node_8101,prsc:2|A-598-RGB,B-100-OUT;n:type:ShaderForge.SFN_Multiply,id:1893,x:32569,y:32163,varname:node_1893,prsc:2|A-3756-OUT,B-598-RGB;n:type:ShaderForge.SFN_Add,id:5480,x:33111,y:32354,varname:node_5480,prsc:2|A-5639-OUT,B-8101-OUT;n:type:ShaderForge.SFN_Color,id:5984,x:32120,y:32654,ptovrint:False,ptlb:light_color,ptin:_light_color,varname:node_5984,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8348944,c2:0.7871972,c3:0.9558824,c4:1;n:type:ShaderForge.SFN_Posterize,id:3756,x:32401,y:32146,varname:node_3756,prsc:2|IN-1232-OUT,STPS-6995-OUT;n:type:ShaderForge.SFN_Vector1,id:6995,x:32199,y:32223,varname:node_6995,prsc:2,v1:1;n:type:ShaderForge.SFN_Fresnel,id:774,x:32634,y:33106,varname:node_774,prsc:2|EXP-7464-OUT;n:type:ShaderForge.SFN_Slider,id:3819,x:31956,y:33225,ptovrint:False,ptlb:fresnel_intensity,ptin:_fresnel_intensity,varname:node_3819,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.01,cur:0.5223077,max:10;n:type:ShaderForge.SFN_Posterize,id:608,x:32856,y:33063,varname:node_608,prsc:2|IN-774-OUT,STPS-5066-OUT;n:type:ShaderForge.SFN_Vector1,id:5066,x:32707,y:33343,varname:node_5066,prsc:2,v1:4;n:type:ShaderForge.SFN_Add,id:7031,x:33013,y:32570,varname:node_7031,prsc:2|A-5480-OUT,B-4442-OUT;n:type:ShaderForge.SFN_Multiply,id:4442,x:32823,y:32676,varname:node_4442,prsc:2|A-608-OUT,B-18-RGB;n:type:ShaderForge.SFN_Color,id:18,x:32495,y:32830,ptovrint:False,ptlb:fresnel_color,ptin:_fresnel_color,varname:node_18,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9612785,c2:0.8053633,c3:0.9779412,c4:1;n:type:ShaderForge.SFN_Clamp01,id:1036,x:32724,y:32186,varname:node_1036,prsc:2|IN-1893-OUT;n:type:ShaderForge.SFN_Multiply,id:5639,x:32877,y:32230,varname:node_5639,prsc:2|A-1036-OUT,B-598-RGB;n:type:ShaderForge.SFN_LightColor,id:4535,x:32558,y:32345,varname:node_4535,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:3420,x:33235,y:32729,ptovrint:False,ptlb:node_3420,ptin:_node_3420,varname:node_3420,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-2567-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3337,x:33476,y:32882,varname:node_3337,prsc:2|A-3420-B,B-7931-OUT;n:type:ShaderForge.SFN_Vector1,id:445,x:33141,y:32988,varname:node_445,prsc:2,v1:0.01;n:type:ShaderForge.SFN_TexCoord,id:7520,x:32948,y:32730,varname:node_7520,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:2567,x:33121,y:32730,varname:node_2567,prsc:2,spu:0.5,spv:0.5|UVIN-7520-UVOUT;n:type:ShaderForge.SFN_Power,id:6365,x:33453,y:32729,varname:node_6365,prsc:2|VAL-3420-B,EXP-6778-OUT;n:type:ShaderForge.SFN_Vector1,id:6778,x:33235,y:32916,varname:node_6778,prsc:2,v1:5;n:type:ShaderForge.SFN_Color,id:7044,x:33428,y:33265,ptovrint:False,ptlb:outline color,ptin:_outlinecolor,varname:node_7044,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:2116,x:33476,y:33074,ptovrint:False,ptlb:node_2116,ptin:_node_2116,varname:node_2116,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b00f95e7057884d40956440a4d252b13,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Divide,id:7464,x:32396,y:33091,varname:node_7464,prsc:2|A-7468-OUT,B-3819-OUT;n:type:ShaderForge.SFN_Vector1,id:7468,x:31983,y:33089,varname:node_7468,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:1232,x:32088,y:32118,varname:node_1232,prsc:2|A-2582-OUT,B-8335-OUT;n:type:ShaderForge.SFN_Slider,id:8335,x:31761,y:32507,ptovrint:False,ptlb:node_8335,ptin:_node_8335,varname:node_8335,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5982906,max:1;n:type:ShaderForge.SFN_SwitchProperty,id:7931,x:33341,y:33004,ptovrint:False,ptlb:outline ? ,ptin:_outline,varname:node_7931,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-445-OUT,B-1524-OUT;n:type:ShaderForge.SFN_Vector1,id:1524,x:33141,y:33106,varname:node_1524,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:9973,x:32877,y:32383,varname:node_9973,prsc:2|A-4535-RGB,B-5480-OUT;n:type:ShaderForge.SFN_Vector1,id:3533,x:32703,y:32556,varname:node_3533,prsc:2,v1:2;proporder:9015-598-5984-3819-18-3420-7044-2116-8335-7931;pass:END;sub:END;*/

Shader "Custom/monstre" {
    Properties {
        _Normal ("Normal", 2D) = "bump" {}
        _Diffuse ("Diffuse", 2D) = "white" {}
        _light_color ("light_color", Color) = (0.8348944,0.7871972,0.9558824,1)
        _fresnel_intensity ("fresnel_intensity", Range(0.01, 10)) = 0.5223077
        _fresnel_color ("fresnel_color", Color) = (0.9612785,0.8053633,0.9779412,1)
        _node_3420 ("node_3420", 2D) = "white" {}
        _outlinecolor ("outline color", Color) = (1,1,1,1)
        _node_2116 ("node_2116", 2D) = "white" {}
        _node_8335 ("node_8335", Range(0, 1)) = 0.5982906
        [MaterialToggle] _outline ("outline ? ", Float ) = 0.01
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _node_3420; uniform float4 _node_3420_ST;
            uniform float4 _outlinecolor;
            uniform sampler2D _node_2116; uniform float4 _node_2116_ST;
            uniform fixed _outline;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_8683 = _Time + _TimeEditor;
                float2 node_2567 = (o.uv0+node_8683.g*float2(0.5,0.5));
                float4 _node_3420_var = tex2Dlod(_node_3420,float4(TRANSFORM_TEX(node_2567, _node_3420),0.0,0));
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*(_node_3420_var.b*lerp( 0.01, 0.0, _outline )),1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_2116_var = tex2D(_node_2116,TRANSFORM_TEX(i.uv0, _node_2116));
                clip(_node_2116_var.r - 0.5);
                return fixed4(_outlinecolor.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _light_color;
            uniform float _fresnel_intensity;
            uniform float4 _fresnel_color;
            uniform sampler2D _node_2116; uniform float4 _node_2116_ST;
            uniform float _node_8335;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _node_2116_var = tex2D(_node_2116,TRANSFORM_TEX(i.uv0, _node_2116));
                clip(_node_2116_var.r - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
////// Emissive:
                float node_6995 = 1.0;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 node_5480 = ((saturate((floor((dot(lightDirection,i.normalDir)+_node_8335) * node_6995) / (node_6995 - 1)*_Diffuse_var.rgb))*_Diffuse_var.rgb)+(_Diffuse_var.rgb*(_LightColor0.rgb*_light_color.rgb)));
                float node_5066 = 4.0;
                float3 emissive = (node_5480+(floor(pow(1.0-max(0,dot(normalDirection, viewDirection)),(1.0/_fresnel_intensity)) * node_5066) / (node_5066 - 1)*_fresnel_color.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _light_color;
            uniform float _fresnel_intensity;
            uniform float4 _fresnel_color;
            uniform sampler2D _node_2116; uniform float4 _node_2116_ST;
            uniform float _node_8335;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _node_2116_var = tex2D(_node_2116,TRANSFORM_TEX(i.uv0, _node_2116));
                clip(_node_2116_var.r - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform sampler2D _node_2116; uniform float4 _node_2116_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_2116_var = tex2D(_node_2116,TRANSFORM_TEX(i.uv0, _node_2116));
                clip(_node_2116_var.r - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
