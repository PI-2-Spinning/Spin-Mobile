#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Void EdgeER::.ctor(PointER,PointER)
extern void EdgeER__ctor_m753D9685F7271D76741069624AC9ADBB824123BE (void);
// 0x00000002 System.Int32 EdgeER::GetHashCode()
extern void EdgeER_GetHashCode_m1DE8CB004E15C351CA55B8AF9C02C7F70A9AC3CB (void);
// 0x00000003 System.Boolean EdgeER::Equals(System.Object)
extern void EdgeER_Equals_m6087FCB7F8C04144C1156190D773BF03510E06D9 (void);
// 0x00000004 System.Boolean EdgeER::op_Equality(EdgeER,EdgeER)
extern void EdgeER_op_Equality_m900EAF22F4354C74EFA45243BB5BA3C8ED8FEAB0 (void);
// 0x00000005 System.Boolean EdgeER::op_Inequality(EdgeER,EdgeER)
extern void EdgeER_op_Inequality_m660E858CFB54C2D57845112556AE0F63A92C7629 (void);
// 0x00000006 System.Void PointER::.ctor(System.Single,System.Single,System.Single)
extern void PointER__ctor_m6F30D9262BE15A721D76D8D9A6D6D6E37CE81F22 (void);
// 0x00000007 System.Int32 PointER::GetHashCode()
extern void PointER_GetHashCode_m37954111B3F90BB550270B85E610E1E4EAFF2CF8 (void);
// 0x00000008 System.Boolean PointER::Equals(System.Object)
extern void PointER_Equals_m5A1F1D06D9205948D96EC598BE56A5C858503415 (void);
// 0x00000009 System.Boolean PointER::op_Equality(PointER,PointER)
extern void PointER_op_Equality_mFDA86C22281FEA53A3F8D4BBFDD312A64CDF0B3E (void);
// 0x0000000A System.Boolean PointER::op_Inequality(PointER,PointER)
extern void PointER_op_Inequality_mC1745211CE085027A1900D69453453CF647CC3F9 (void);
// 0x0000000B System.Void delaunayER::Start()
extern void delaunayER_Start_m7CDB5A78DC336743985FC7CAD0A22FD2E0317206 (void);
// 0x0000000C System.Void delaunayER::Update()
extern void delaunayER_Update_m5394B8D56DB3F5B820D1C05B9100F073636D0DA9 (void);
// 0x0000000D System.Int32 delaunayER::FindVertice(UnityEngine.Vector3,System.Collections.Generic.List`1<UnityEngine.Vector3>)
extern void delaunayER_FindVertice_mAFE82294E39CE6C4CB07794487A4EF42CD4546FA (void);
// 0x0000000E System.Collections.Generic.List`1<TriangleER> delaunayER::Triangulate(System.Collections.Generic.List`1<PointER>)
extern void delaunayER_Triangulate_mB805EFB366877D68041C0F0753B78146A5DDD161 (void);
// 0x0000000F TriangleER delaunayER::SuperTriangle(System.Collections.Generic.List`1<PointER>)
extern void delaunayER_SuperTriangle_m1F1C343B4EA61FA481F31F31B882F5E62700CC1B (void);
// 0x00000010 System.Void delaunayER::.ctor()
extern void delaunayER__ctor_m8404485B0155C6CA3E60A95966CEC91D9603028E (void);
// 0x00000011 System.Void TriangleER::.ctor(PointER,PointER,PointER)
extern void TriangleER__ctor_m075906522D6291F6C1B2A6700C6EA970BA37456C (void);
// 0x00000012 System.Double TriangleER::ContainsInCircumcircle(PointER)
extern void TriangleER_ContainsInCircumcircle_mF0455E43FB3026A8296894A2E6540946A94EAE31 (void);
// 0x00000013 System.Boolean TriangleER::SharesVertexWith(TriangleER)
extern void TriangleER_SharesVertexWith_mEBC6689F0BB05532C89853EB4E4AB976B8EC09AF (void);
static Il2CppMethodPointer s_methodPointers[19] = 
{
	EdgeER__ctor_m753D9685F7271D76741069624AC9ADBB824123BE,
	EdgeER_GetHashCode_m1DE8CB004E15C351CA55B8AF9C02C7F70A9AC3CB,
	EdgeER_Equals_m6087FCB7F8C04144C1156190D773BF03510E06D9,
	EdgeER_op_Equality_m900EAF22F4354C74EFA45243BB5BA3C8ED8FEAB0,
	EdgeER_op_Inequality_m660E858CFB54C2D57845112556AE0F63A92C7629,
	PointER__ctor_m6F30D9262BE15A721D76D8D9A6D6D6E37CE81F22,
	PointER_GetHashCode_m37954111B3F90BB550270B85E610E1E4EAFF2CF8,
	PointER_Equals_m5A1F1D06D9205948D96EC598BE56A5C858503415,
	PointER_op_Equality_mFDA86C22281FEA53A3F8D4BBFDD312A64CDF0B3E,
	PointER_op_Inequality_mC1745211CE085027A1900D69453453CF647CC3F9,
	delaunayER_Start_m7CDB5A78DC336743985FC7CAD0A22FD2E0317206,
	delaunayER_Update_m5394B8D56DB3F5B820D1C05B9100F073636D0DA9,
	delaunayER_FindVertice_mAFE82294E39CE6C4CB07794487A4EF42CD4546FA,
	delaunayER_Triangulate_mB805EFB366877D68041C0F0753B78146A5DDD161,
	delaunayER_SuperTriangle_m1F1C343B4EA61FA481F31F31B882F5E62700CC1B,
	delaunayER__ctor_m8404485B0155C6CA3E60A95966CEC91D9603028E,
	TriangleER__ctor_m075906522D6291F6C1B2A6700C6EA970BA37456C,
	TriangleER_ContainsInCircumcircle_mF0455E43FB3026A8296894A2E6540946A94EAE31,
	TriangleER_SharesVertexWith_mEBC6689F0BB05532C89853EB4E4AB976B8EC09AF,
};
static const int32_t s_InvokerIndices[19] = 
{
	2880,
	6333,
	3710,
	9100,
	9100,
	1549,
	6333,
	3710,
	9100,
	9100,
	6487,
	6487,
	9285,
	10726,
	10726,
	6487,
	1503,
	4046,
	3710,
};
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_DelaunayER_CodeGenModule;
const Il2CppCodeGenModule g_DelaunayER_CodeGenModule = 
{
	"DelaunayER.dll",
	19,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
