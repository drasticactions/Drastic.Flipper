using System;
using System.Runtime.InteropServices;

namespace Flipper
{
	static class CFunctions
	{
		// extern int FlipperPerformBlockOnMainThread (void (^block)(), id<FlipperResponder> responder);
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern int FlipperPerformBlockOnMainThread (Action block, FlipperResponder responder);
	}
}
