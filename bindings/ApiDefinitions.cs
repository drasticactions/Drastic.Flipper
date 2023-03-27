using Foundation;
using ObjCRuntime;

namespace Flipper
{
	// @interface FlipperProxy : NSObject
	[BaseType (typeof(NSObject))]
	interface FlipperProxy
	{
		// @property (readonly, nonatomic, strong, class) FlipperProxy * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		FlipperProxy Shared { get; }

		// -(void)initializeProxy;
		[Export ("initializeProxy")]
		void InitializeProxy ();
	}
}