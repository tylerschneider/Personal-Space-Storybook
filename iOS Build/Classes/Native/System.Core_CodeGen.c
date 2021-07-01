#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Exception System.Linq.Error::ArgumentNull(System.String)
extern void Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E (void);
// 0x00000002 System.Exception System.Linq.Error::ArgumentOutOfRange(System.String)
extern void Error_ArgumentOutOfRange_m2EFB999454161A6B48F8DAC3753FDC190538F0F2 (void);
// 0x00000003 System.Exception System.Linq.Error::MoreThanOneMatch()
extern void Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8 (void);
// 0x00000004 System.Exception System.Linq.Error::NoElements()
extern void Error_NoElements_mB89E91246572F009281D79730950808F17C3F353 (void);
// 0x00000005 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Where(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000006 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
// 0x00000007 System.Func`2<TSource,System.Boolean> System.Linq.Enumerable::CombinePredicates(System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,System.Boolean>)
// 0x00000008 System.Func`2<TSource,TResult> System.Linq.Enumerable::CombineSelectors(System.Func`2<TSource,TMiddle>,System.Func`2<TMiddle,TResult>)
// 0x00000009 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::SelectMany(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Collections.Generic.IEnumerable`1<TResult>>)
// 0x0000000A System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::SelectManyIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Collections.Generic.IEnumerable`1<TResult>>)
// 0x0000000B System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderBy(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000C System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderByDescending(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000D System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::ThenBy(System.Linq.IOrderedEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000E System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Distinct(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000F System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::DistinctIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000010 TSource[] System.Linq.Enumerable::ToArray(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000011 System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000012 TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000013 TSource System.Linq.Enumerable::FirstOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000014 TSource System.Linq.Enumerable::Last(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000015 TSource System.Linq.Enumerable::SingleOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000016 TSource System.Linq.Enumerable::ElementAt(System.Collections.Generic.IEnumerable`1<TSource>,System.Int32)
// 0x00000017 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000018 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000019 System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000001A System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000001B System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource)
// 0x0000001C System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x0000001D System.Void System.Linq.Enumerable/Iterator`1::.ctor()
// 0x0000001E TSource System.Linq.Enumerable/Iterator`1::get_Current()
// 0x0000001F System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/Iterator`1::Clone()
// 0x00000020 System.Void System.Linq.Enumerable/Iterator`1::Dispose()
// 0x00000021 System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/Iterator`1::GetEnumerator()
// 0x00000022 System.Boolean System.Linq.Enumerable/Iterator`1::MoveNext()
// 0x00000023 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/Iterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000024 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/Iterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000025 System.Object System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.get_Current()
// 0x00000026 System.Collections.IEnumerator System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000027 System.Void System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.Reset()
// 0x00000028 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000029 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Clone()
// 0x0000002A System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::Dispose()
// 0x0000002B System.Boolean System.Linq.Enumerable/WhereEnumerableIterator`1::MoveNext()
// 0x0000002C System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereEnumerableIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000002D System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000002E System.Void System.Linq.Enumerable/WhereArrayIterator`1::.ctor(TSource[],System.Func`2<TSource,System.Boolean>)
// 0x0000002F System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Clone()
// 0x00000030 System.Boolean System.Linq.Enumerable/WhereArrayIterator`1::MoveNext()
// 0x00000031 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereArrayIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000032 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000033 System.Void System.Linq.Enumerable/WhereListIterator`1::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000034 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Clone()
// 0x00000035 System.Boolean System.Linq.Enumerable/WhereListIterator`1::MoveNext()
// 0x00000036 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereListIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000037 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000038 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000039 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Clone()
// 0x0000003A System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Dispose()
// 0x0000003B System.Boolean System.Linq.Enumerable/WhereSelectEnumerableIterator`2::MoveNext()
// 0x0000003C System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x0000003D System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000003E System.Void System.Linq.Enumerable/WhereSelectArrayIterator`2::.ctor(TSource[],System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x0000003F System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Clone()
// 0x00000040 System.Boolean System.Linq.Enumerable/WhereSelectArrayIterator`2::MoveNext()
// 0x00000041 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectArrayIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000042 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000043 System.Void System.Linq.Enumerable/WhereSelectListIterator`2::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000044 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Clone()
// 0x00000045 System.Boolean System.Linq.Enumerable/WhereSelectListIterator`2::MoveNext()
// 0x00000046 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectListIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000047 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000048 System.Void System.Linq.Enumerable/<>c__DisplayClass6_0`1::.ctor()
// 0x00000049 System.Boolean System.Linq.Enumerable/<>c__DisplayClass6_0`1::<CombinePredicates>b__0(TSource)
// 0x0000004A System.Void System.Linq.Enumerable/<>c__DisplayClass7_0`3::.ctor()
// 0x0000004B TResult System.Linq.Enumerable/<>c__DisplayClass7_0`3::<CombineSelectors>b__0(TSource)
// 0x0000004C System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::.ctor(System.Int32)
// 0x0000004D System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.IDisposable.Dispose()
// 0x0000004E System.Boolean System.Linq.Enumerable/<SelectManyIterator>d__17`2::MoveNext()
// 0x0000004F System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::<>m__Finally1()
// 0x00000050 System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::<>m__Finally2()
// 0x00000051 TResult System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.Generic.IEnumerator<TResult>.get_Current()
// 0x00000052 System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.IEnumerator.Reset()
// 0x00000053 System.Object System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.IEnumerator.get_Current()
// 0x00000054 System.Collections.Generic.IEnumerator`1<TResult> System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.Generic.IEnumerable<TResult>.GetEnumerator()
// 0x00000055 System.Collections.IEnumerator System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.IEnumerable.GetEnumerator()
// 0x00000056 System.Void System.Linq.Enumerable/<DistinctIterator>d__68`1::.ctor(System.Int32)
// 0x00000057 System.Void System.Linq.Enumerable/<DistinctIterator>d__68`1::System.IDisposable.Dispose()
// 0x00000058 System.Boolean System.Linq.Enumerable/<DistinctIterator>d__68`1::MoveNext()
// 0x00000059 System.Void System.Linq.Enumerable/<DistinctIterator>d__68`1::<>m__Finally1()
// 0x0000005A TSource System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.Generic.IEnumerator<TSource>.get_Current()
// 0x0000005B System.Void System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.IEnumerator.Reset()
// 0x0000005C System.Object System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.IEnumerator.get_Current()
// 0x0000005D System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.Generic.IEnumerable<TSource>.GetEnumerator()
// 0x0000005E System.Collections.IEnumerator System.Linq.Enumerable/<DistinctIterator>d__68`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000005F System.Linq.IOrderedEnumerable`1<TElement> System.Linq.IOrderedEnumerable`1::CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000060 System.Void System.Linq.Set`1::.ctor(System.Collections.Generic.IEqualityComparer`1<TElement>)
// 0x00000061 System.Boolean System.Linq.Set`1::Add(TElement)
// 0x00000062 System.Boolean System.Linq.Set`1::Find(TElement,System.Boolean)
// 0x00000063 System.Void System.Linq.Set`1::Resize()
// 0x00000064 System.Int32 System.Linq.Set`1::InternalGetHashCode(TElement)
// 0x00000065 System.Collections.Generic.IEnumerator`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerator()
// 0x00000066 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000067 System.Collections.IEnumerator System.Linq.OrderedEnumerable`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000068 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.OrderedEnumerable`1::System.Linq.IOrderedEnumerable<TElement>.CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000069 System.Void System.Linq.OrderedEnumerable`1::.ctor()
// 0x0000006A System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::.ctor(System.Int32)
// 0x0000006B System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.IDisposable.Dispose()
// 0x0000006C System.Boolean System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::MoveNext()
// 0x0000006D TElement System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.Generic.IEnumerator<TElement>.get_Current()
// 0x0000006E System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.Reset()
// 0x0000006F System.Object System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.get_Current()
// 0x00000070 System.Void System.Linq.OrderedEnumerable`2::.ctor(System.Collections.Generic.IEnumerable`1<TElement>,System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000071 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`2::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000072 System.Void System.Linq.EnumerableSorter`1::ComputeKeys(TElement[],System.Int32)
// 0x00000073 System.Int32 System.Linq.EnumerableSorter`1::CompareKeys(System.Int32,System.Int32)
// 0x00000074 System.Int32[] System.Linq.EnumerableSorter`1::Sort(TElement[],System.Int32)
// 0x00000075 System.Void System.Linq.EnumerableSorter`1::QuickSort(System.Int32[],System.Int32,System.Int32)
// 0x00000076 System.Void System.Linq.EnumerableSorter`1::.ctor()
// 0x00000077 System.Void System.Linq.EnumerableSorter`2::.ctor(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean,System.Linq.EnumerableSorter`1<TElement>)
// 0x00000078 System.Void System.Linq.EnumerableSorter`2::ComputeKeys(TElement[],System.Int32)
// 0x00000079 System.Int32 System.Linq.EnumerableSorter`2::CompareKeys(System.Int32,System.Int32)
// 0x0000007A System.Void System.Linq.Buffer`1::.ctor(System.Collections.Generic.IEnumerable`1<TElement>)
// 0x0000007B TElement[] System.Linq.Buffer`1::ToArray()
// 0x0000007C System.Void System.Collections.Generic.HashSet`1::.ctor()
// 0x0000007D System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEqualityComparer`1<T>)
// 0x0000007E System.Void System.Collections.Generic.HashSet`1::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x0000007F System.Void System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.Add(T)
// 0x00000080 System.Void System.Collections.Generic.HashSet`1::Clear()
// 0x00000081 System.Boolean System.Collections.Generic.HashSet`1::Contains(T)
// 0x00000082 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32)
// 0x00000083 System.Boolean System.Collections.Generic.HashSet`1::Remove(T)
// 0x00000084 System.Int32 System.Collections.Generic.HashSet`1::get_Count()
// 0x00000085 System.Boolean System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.get_IsReadOnly()
// 0x00000086 System.Collections.Generic.HashSet`1/Enumerator<T> System.Collections.Generic.HashSet`1::GetEnumerator()
// 0x00000087 System.Collections.Generic.IEnumerator`1<T> System.Collections.Generic.HashSet`1::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
// 0x00000088 System.Collections.IEnumerator System.Collections.Generic.HashSet`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000089 System.Void System.Collections.Generic.HashSet`1::GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x0000008A System.Void System.Collections.Generic.HashSet`1::OnDeserialization(System.Object)
// 0x0000008B System.Boolean System.Collections.Generic.HashSet`1::Add(T)
// 0x0000008C System.Void System.Collections.Generic.HashSet`1::CopyTo(T[])
// 0x0000008D System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32,System.Int32)
// 0x0000008E System.Void System.Collections.Generic.HashSet`1::Initialize(System.Int32)
// 0x0000008F System.Void System.Collections.Generic.HashSet`1::IncreaseCapacity()
// 0x00000090 System.Void System.Collections.Generic.HashSet`1::SetCapacity(System.Int32)
// 0x00000091 System.Boolean System.Collections.Generic.HashSet`1::AddIfNotPresent(T)
// 0x00000092 System.Int32 System.Collections.Generic.HashSet`1::InternalGetHashCode(T)
// 0x00000093 System.Void System.Collections.Generic.HashSet`1/Enumerator::.ctor(System.Collections.Generic.HashSet`1<T>)
// 0x00000094 System.Void System.Collections.Generic.HashSet`1/Enumerator::Dispose()
// 0x00000095 System.Boolean System.Collections.Generic.HashSet`1/Enumerator::MoveNext()
// 0x00000096 T System.Collections.Generic.HashSet`1/Enumerator::get_Current()
// 0x00000097 System.Object System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.get_Current()
// 0x00000098 System.Void System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.Reset()
static Il2CppMethodPointer s_methodPointers[152] = 
{
	Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E,
	Error_ArgumentOutOfRange_m2EFB999454161A6B48F8DAC3753FDC190538F0F2,
	Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8,
	Error_NoElements_mB89E91246572F009281D79730950808F17C3F353,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
};
static const int32_t s_InvokerIndices[152] = 
{
	4985,
	4985,
	5123,
	5123,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
};
static const Il2CppTokenRangePair s_rgctxIndices[51] = 
{
	{ 0x02000004, { 79, 4 } },
	{ 0x02000005, { 83, 9 } },
	{ 0x02000006, { 94, 7 } },
	{ 0x02000007, { 103, 10 } },
	{ 0x02000008, { 115, 11 } },
	{ 0x02000009, { 129, 9 } },
	{ 0x0200000A, { 141, 12 } },
	{ 0x0200000B, { 156, 1 } },
	{ 0x0200000C, { 157, 2 } },
	{ 0x0200000D, { 159, 12 } },
	{ 0x0200000E, { 171, 11 } },
	{ 0x02000010, { 182, 8 } },
	{ 0x02000012, { 190, 3 } },
	{ 0x02000013, { 195, 5 } },
	{ 0x02000014, { 200, 7 } },
	{ 0x02000015, { 207, 3 } },
	{ 0x02000016, { 210, 7 } },
	{ 0x02000017, { 217, 4 } },
	{ 0x02000018, { 221, 21 } },
	{ 0x0200001A, { 242, 2 } },
	{ 0x06000005, { 0, 10 } },
	{ 0x06000006, { 10, 10 } },
	{ 0x06000007, { 20, 5 } },
	{ 0x06000008, { 25, 5 } },
	{ 0x06000009, { 30, 1 } },
	{ 0x0600000A, { 31, 2 } },
	{ 0x0600000B, { 33, 2 } },
	{ 0x0600000C, { 35, 2 } },
	{ 0x0600000D, { 37, 1 } },
	{ 0x0600000E, { 38, 1 } },
	{ 0x0600000F, { 39, 2 } },
	{ 0x06000010, { 41, 3 } },
	{ 0x06000011, { 44, 2 } },
	{ 0x06000012, { 46, 4 } },
	{ 0x06000013, { 50, 3 } },
	{ 0x06000014, { 53, 4 } },
	{ 0x06000015, { 57, 3 } },
	{ 0x06000016, { 60, 3 } },
	{ 0x06000017, { 63, 1 } },
	{ 0x06000018, { 64, 3 } },
	{ 0x06000019, { 67, 2 } },
	{ 0x0600001A, { 69, 3 } },
	{ 0x0600001B, { 72, 2 } },
	{ 0x0600001C, { 74, 5 } },
	{ 0x0600002C, { 92, 2 } },
	{ 0x06000031, { 101, 2 } },
	{ 0x06000036, { 113, 2 } },
	{ 0x0600003C, { 126, 3 } },
	{ 0x06000041, { 138, 3 } },
	{ 0x06000046, { 153, 3 } },
	{ 0x06000068, { 193, 2 } },
};
static const Il2CppRGCTXDefinition s_rgctxValues[244] = 
{
	{ (Il2CppRGCTXDataType)2, 2097 },
	{ (Il2CppRGCTXDataType)3, 8831 },
	{ (Il2CppRGCTXDataType)2, 3649 },
	{ (Il2CppRGCTXDataType)2, 3163 },
	{ (Il2CppRGCTXDataType)3, 18088 },
	{ (Il2CppRGCTXDataType)2, 2218 },
	{ (Il2CppRGCTXDataType)2, 3170 },
	{ (Il2CppRGCTXDataType)3, 18127 },
	{ (Il2CppRGCTXDataType)2, 3165 },
	{ (Il2CppRGCTXDataType)3, 18095 },
	{ (Il2CppRGCTXDataType)2, 2098 },
	{ (Il2CppRGCTXDataType)3, 8832 },
	{ (Il2CppRGCTXDataType)2, 3672 },
	{ (Il2CppRGCTXDataType)2, 3172 },
	{ (Il2CppRGCTXDataType)3, 18134 },
	{ (Il2CppRGCTXDataType)2, 2237 },
	{ (Il2CppRGCTXDataType)2, 3180 },
	{ (Il2CppRGCTXDataType)3, 18191 },
	{ (Il2CppRGCTXDataType)2, 3176 },
	{ (Il2CppRGCTXDataType)3, 18160 },
	{ (Il2CppRGCTXDataType)2, 701 },
	{ (Il2CppRGCTXDataType)3, 56 },
	{ (Il2CppRGCTXDataType)3, 57 },
	{ (Il2CppRGCTXDataType)2, 1340 },
	{ (Il2CppRGCTXDataType)3, 6814 },
	{ (Il2CppRGCTXDataType)2, 702 },
	{ (Il2CppRGCTXDataType)3, 68 },
	{ (Il2CppRGCTXDataType)3, 69 },
	{ (Il2CppRGCTXDataType)2, 1351 },
	{ (Il2CppRGCTXDataType)3, 6818 },
	{ (Il2CppRGCTXDataType)3, 20869 },
	{ (Il2CppRGCTXDataType)2, 707 },
	{ (Il2CppRGCTXDataType)3, 102 },
	{ (Il2CppRGCTXDataType)2, 2772 },
	{ (Il2CppRGCTXDataType)3, 14663 },
	{ (Il2CppRGCTXDataType)2, 2773 },
	{ (Il2CppRGCTXDataType)3, 14664 },
	{ (Il2CppRGCTXDataType)3, 7450 },
	{ (Il2CppRGCTXDataType)3, 20835 },
	{ (Il2CppRGCTXDataType)2, 703 },
	{ (Il2CppRGCTXDataType)3, 74 },
	{ (Il2CppRGCTXDataType)2, 904 },
	{ (Il2CppRGCTXDataType)3, 1655 },
	{ (Il2CppRGCTXDataType)3, 1656 },
	{ (Il2CppRGCTXDataType)2, 2219 },
	{ (Il2CppRGCTXDataType)3, 9523 },
	{ (Il2CppRGCTXDataType)2, 2008 },
	{ (Il2CppRGCTXDataType)2, 1498 },
	{ (Il2CppRGCTXDataType)2, 1608 },
	{ (Il2CppRGCTXDataType)2, 1699 },
	{ (Il2CppRGCTXDataType)2, 1609 },
	{ (Il2CppRGCTXDataType)2, 1700 },
	{ (Il2CppRGCTXDataType)3, 6816 },
	{ (Il2CppRGCTXDataType)2, 2009 },
	{ (Il2CppRGCTXDataType)2, 1499 },
	{ (Il2CppRGCTXDataType)2, 1610 },
	{ (Il2CppRGCTXDataType)2, 1701 },
	{ (Il2CppRGCTXDataType)2, 1611 },
	{ (Il2CppRGCTXDataType)2, 1702 },
	{ (Il2CppRGCTXDataType)3, 6817 },
	{ (Il2CppRGCTXDataType)2, 2007 },
	{ (Il2CppRGCTXDataType)2, 1607 },
	{ (Il2CppRGCTXDataType)2, 1698 },
	{ (Il2CppRGCTXDataType)2, 1597 },
	{ (Il2CppRGCTXDataType)2, 1598 },
	{ (Il2CppRGCTXDataType)2, 1695 },
	{ (Il2CppRGCTXDataType)3, 6813 },
	{ (Il2CppRGCTXDataType)2, 1497 },
	{ (Il2CppRGCTXDataType)2, 1605 },
	{ (Il2CppRGCTXDataType)2, 1606 },
	{ (Il2CppRGCTXDataType)2, 1697 },
	{ (Il2CppRGCTXDataType)3, 6815 },
	{ (Il2CppRGCTXDataType)2, 1496 },
	{ (Il2CppRGCTXDataType)3, 20822 },
	{ (Il2CppRGCTXDataType)3, 6067 },
	{ (Il2CppRGCTXDataType)2, 1215 },
	{ (Il2CppRGCTXDataType)2, 1600 },
	{ (Il2CppRGCTXDataType)2, 1696 },
	{ (Il2CppRGCTXDataType)2, 1773 },
	{ (Il2CppRGCTXDataType)3, 8833 },
	{ (Il2CppRGCTXDataType)3, 8835 },
	{ (Il2CppRGCTXDataType)2, 470 },
	{ (Il2CppRGCTXDataType)3, 8834 },
	{ (Il2CppRGCTXDataType)3, 8843 },
	{ (Il2CppRGCTXDataType)2, 2101 },
	{ (Il2CppRGCTXDataType)2, 3166 },
	{ (Il2CppRGCTXDataType)3, 18096 },
	{ (Il2CppRGCTXDataType)3, 8844 },
	{ (Il2CppRGCTXDataType)2, 1654 },
	{ (Il2CppRGCTXDataType)2, 1726 },
	{ (Il2CppRGCTXDataType)3, 6825 },
	{ (Il2CppRGCTXDataType)3, 20808 },
	{ (Il2CppRGCTXDataType)2, 3177 },
	{ (Il2CppRGCTXDataType)3, 18161 },
	{ (Il2CppRGCTXDataType)3, 8836 },
	{ (Il2CppRGCTXDataType)2, 2100 },
	{ (Il2CppRGCTXDataType)2, 3164 },
	{ (Il2CppRGCTXDataType)3, 18089 },
	{ (Il2CppRGCTXDataType)3, 6824 },
	{ (Il2CppRGCTXDataType)3, 8837 },
	{ (Il2CppRGCTXDataType)3, 20807 },
	{ (Il2CppRGCTXDataType)2, 3173 },
	{ (Il2CppRGCTXDataType)3, 18135 },
	{ (Il2CppRGCTXDataType)3, 8850 },
	{ (Il2CppRGCTXDataType)2, 2102 },
	{ (Il2CppRGCTXDataType)2, 3171 },
	{ (Il2CppRGCTXDataType)3, 18128 },
	{ (Il2CppRGCTXDataType)3, 9575 },
	{ (Il2CppRGCTXDataType)3, 4790 },
	{ (Il2CppRGCTXDataType)3, 6826 },
	{ (Il2CppRGCTXDataType)3, 4789 },
	{ (Il2CppRGCTXDataType)3, 8851 },
	{ (Il2CppRGCTXDataType)3, 20809 },
	{ (Il2CppRGCTXDataType)2, 3181 },
	{ (Il2CppRGCTXDataType)3, 18192 },
	{ (Il2CppRGCTXDataType)3, 8864 },
	{ (Il2CppRGCTXDataType)2, 2104 },
	{ (Il2CppRGCTXDataType)2, 3179 },
	{ (Il2CppRGCTXDataType)3, 18163 },
	{ (Il2CppRGCTXDataType)3, 8865 },
	{ (Il2CppRGCTXDataType)2, 1657 },
	{ (Il2CppRGCTXDataType)2, 1729 },
	{ (Il2CppRGCTXDataType)3, 6830 },
	{ (Il2CppRGCTXDataType)3, 6829 },
	{ (Il2CppRGCTXDataType)2, 3168 },
	{ (Il2CppRGCTXDataType)3, 18098 },
	{ (Il2CppRGCTXDataType)3, 20816 },
	{ (Il2CppRGCTXDataType)2, 3178 },
	{ (Il2CppRGCTXDataType)3, 18162 },
	{ (Il2CppRGCTXDataType)3, 8857 },
	{ (Il2CppRGCTXDataType)2, 2103 },
	{ (Il2CppRGCTXDataType)2, 3175 },
	{ (Il2CppRGCTXDataType)3, 18137 },
	{ (Il2CppRGCTXDataType)3, 6828 },
	{ (Il2CppRGCTXDataType)3, 6827 },
	{ (Il2CppRGCTXDataType)3, 8858 },
	{ (Il2CppRGCTXDataType)2, 3167 },
	{ (Il2CppRGCTXDataType)3, 18097 },
	{ (Il2CppRGCTXDataType)3, 20815 },
	{ (Il2CppRGCTXDataType)2, 3174 },
	{ (Il2CppRGCTXDataType)3, 18136 },
	{ (Il2CppRGCTXDataType)3, 8871 },
	{ (Il2CppRGCTXDataType)2, 2105 },
	{ (Il2CppRGCTXDataType)2, 3183 },
	{ (Il2CppRGCTXDataType)3, 18194 },
	{ (Il2CppRGCTXDataType)3, 9576 },
	{ (Il2CppRGCTXDataType)3, 4792 },
	{ (Il2CppRGCTXDataType)3, 6832 },
	{ (Il2CppRGCTXDataType)3, 6831 },
	{ (Il2CppRGCTXDataType)3, 4791 },
	{ (Il2CppRGCTXDataType)3, 8872 },
	{ (Il2CppRGCTXDataType)2, 3169 },
	{ (Il2CppRGCTXDataType)3, 18099 },
	{ (Il2CppRGCTXDataType)3, 20817 },
	{ (Il2CppRGCTXDataType)2, 3182 },
	{ (Il2CppRGCTXDataType)3, 18193 },
	{ (Il2CppRGCTXDataType)3, 6821 },
	{ (Il2CppRGCTXDataType)3, 6822 },
	{ (Il2CppRGCTXDataType)3, 6833 },
	{ (Il2CppRGCTXDataType)3, 105 },
	{ (Il2CppRGCTXDataType)3, 104 },
	{ (Il2CppRGCTXDataType)2, 1649 },
	{ (Il2CppRGCTXDataType)2, 1722 },
	{ (Il2CppRGCTXDataType)3, 6823 },
	{ (Il2CppRGCTXDataType)2, 1663 },
	{ (Il2CppRGCTXDataType)2, 1740 },
	{ (Il2CppRGCTXDataType)3, 107 },
	{ (Il2CppRGCTXDataType)2, 620 },
	{ (Il2CppRGCTXDataType)2, 708 },
	{ (Il2CppRGCTXDataType)3, 103 },
	{ (Il2CppRGCTXDataType)3, 106 },
	{ (Il2CppRGCTXDataType)3, 76 },
	{ (Il2CppRGCTXDataType)2, 2871 },
	{ (Il2CppRGCTXDataType)3, 16372 },
	{ (Il2CppRGCTXDataType)2, 1646 },
	{ (Il2CppRGCTXDataType)2, 1720 },
	{ (Il2CppRGCTXDataType)3, 16373 },
	{ (Il2CppRGCTXDataType)3, 78 },
	{ (Il2CppRGCTXDataType)2, 467 },
	{ (Il2CppRGCTXDataType)2, 704 },
	{ (Il2CppRGCTXDataType)3, 75 },
	{ (Il2CppRGCTXDataType)3, 77 },
	{ (Il2CppRGCTXDataType)3, 6100 },
	{ (Il2CppRGCTXDataType)2, 1229 },
	{ (Il2CppRGCTXDataType)2, 3763 },
	{ (Il2CppRGCTXDataType)3, 16369 },
	{ (Il2CppRGCTXDataType)3, 16370 },
	{ (Il2CppRGCTXDataType)2, 1787 },
	{ (Il2CppRGCTXDataType)3, 16371 },
	{ (Il2CppRGCTXDataType)2, 394 },
	{ (Il2CppRGCTXDataType)2, 705 },
	{ (Il2CppRGCTXDataType)3, 88 },
	{ (Il2CppRGCTXDataType)3, 14650 },
	{ (Il2CppRGCTXDataType)2, 2774 },
	{ (Il2CppRGCTXDataType)3, 14665 },
	{ (Il2CppRGCTXDataType)2, 905 },
	{ (Il2CppRGCTXDataType)3, 1657 },
	{ (Il2CppRGCTXDataType)3, 14656 },
	{ (Il2CppRGCTXDataType)3, 4761 },
	{ (Il2CppRGCTXDataType)2, 501 },
	{ (Il2CppRGCTXDataType)3, 14651 },
	{ (Il2CppRGCTXDataType)2, 2769 },
	{ (Il2CppRGCTXDataType)3, 1694 },
	{ (Il2CppRGCTXDataType)2, 920 },
	{ (Il2CppRGCTXDataType)2, 1181 },
	{ (Il2CppRGCTXDataType)3, 4767 },
	{ (Il2CppRGCTXDataType)3, 14652 },
	{ (Il2CppRGCTXDataType)3, 4756 },
	{ (Il2CppRGCTXDataType)3, 4757 },
	{ (Il2CppRGCTXDataType)3, 4755 },
	{ (Il2CppRGCTXDataType)3, 4758 },
	{ (Il2CppRGCTXDataType)2, 1177 },
	{ (Il2CppRGCTXDataType)2, 3722 },
	{ (Il2CppRGCTXDataType)3, 6820 },
	{ (Il2CppRGCTXDataType)3, 4760 },
	{ (Il2CppRGCTXDataType)2, 1579 },
	{ (Il2CppRGCTXDataType)3, 4759 },
	{ (Il2CppRGCTXDataType)2, 1500 },
	{ (Il2CppRGCTXDataType)2, 3675 },
	{ (Il2CppRGCTXDataType)2, 1625 },
	{ (Il2CppRGCTXDataType)2, 1703 },
	{ (Il2CppRGCTXDataType)3, 6083 },
	{ (Il2CppRGCTXDataType)2, 1223 },
	{ (Il2CppRGCTXDataType)3, 7262 },
	{ (Il2CppRGCTXDataType)3, 7263 },
	{ (Il2CppRGCTXDataType)3, 7268 },
	{ (Il2CppRGCTXDataType)2, 1782 },
	{ (Il2CppRGCTXDataType)3, 7265 },
	{ (Il2CppRGCTXDataType)3, 21349 },
	{ (Il2CppRGCTXDataType)2, 1183 },
	{ (Il2CppRGCTXDataType)3, 4782 },
	{ (Il2CppRGCTXDataType)1, 1574 },
	{ (Il2CppRGCTXDataType)2, 3685 },
	{ (Il2CppRGCTXDataType)3, 7264 },
	{ (Il2CppRGCTXDataType)1, 3685 },
	{ (Il2CppRGCTXDataType)1, 1782 },
	{ (Il2CppRGCTXDataType)2, 3761 },
	{ (Il2CppRGCTXDataType)2, 3685 },
	{ (Il2CppRGCTXDataType)3, 7269 },
	{ (Il2CppRGCTXDataType)3, 7267 },
	{ (Il2CppRGCTXDataType)3, 7266 },
	{ (Il2CppRGCTXDataType)2, 331 },
	{ (Il2CppRGCTXDataType)3, 4793 },
	{ (Il2CppRGCTXDataType)2, 480 },
};
extern const CustomAttributesCacheGenerator g_System_Core_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_System_Core_CodeGenModule;
const Il2CppCodeGenModule g_System_Core_CodeGenModule = 
{
	"System.Core.dll",
	152,
	s_methodPointers,
	s_InvokerIndices,
	0,
	NULL,
	51,
	s_rgctxIndices,
	244,
	s_rgctxValues,
	NULL,
	g_System_Core_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
