using CoreFoundation;
using Foundation;
using ObjCRuntime;

namespace Flipper;

	// @protocol SKNetworkReporterDelegate
	[Protocol, Model]
    [BaseType (typeof(NSObject))]
	interface SKNetworkReporterDelegate
	{
		// @required -(void)didObserveRequest:(SKRequestInfo *)request;
		[Abstract]
		[Export ("didObserveRequest:")]
		void DidObserveRequest (SKRequestInfo request);

		// @required -(void)didObserveResponse:(SKResponseInfo *)response;
		[Abstract]
		[Export ("didObserveResponse:")]
		void DidObserveResponse (SKResponseInfo response);
	}

    // @protocol SKNetworkAdapterDelegate
	[Protocol, Model]
    [BaseType (typeof(NSObject))]
	interface SKNetworkAdapterDelegate
	{
		[Wrap ("WeakDelegate"), Abstract]
		SKNetworkReporterDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<SKNetworkReporterDelegate> delegate;
		[Abstract]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @interface SKIOSNetworkAdapter : NSObject <SKNetworkAdapterDelegate>
	[BaseType (typeof(NSObject))]
	interface SKIOSNetworkAdapter : SKNetworkAdapterDelegate
	{
		[Wrap ("WeakDelegate")]
		SKNetworkReporterDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SKNetworkReporterDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

    // @interface SKRequestInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface SKRequestInfo
	{
		// @property (assign, readwrite) int64_t identifier;
		[Export ("identifier")]
		long Identifier { get; set; }

		// @property (assign, readwrite) uint64_t timestamp;
		[Export ("timestamp")]
		ulong Timestamp { get; set; }

		// @property (nonatomic, strong) NSURLRequest * _Nullable request;
		[NullAllowed, Export ("request", ArgumentSemantic.Strong)]
		NSUrlRequest Request { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable body;
		[NullAllowed, Export ("body", ArgumentSemantic.Strong)]
		string Body { get; set; }

		// -(instancetype _Nonnull)initWithIdentifier:(int64_t)identifier timestamp:(uint64_t)timestamp request:(NSURLRequest * _Nullable)request data:(NSData * _Nullable)data;
		[Export ("initWithIdentifier:timestamp:request:data:")]
		NativeHandle Constructor (long identifier, ulong timestamp, [NullAllowed] NSUrlRequest request, [NullAllowed] NSData data);

		// -(void)setBodyFromData:(NSData * _Nullable)data;
		[Export ("setBodyFromData:")]
		void SetBodyFromData ([NullAllowed] NSData data);
	}

	// @interface SKResponseInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface SKResponseInfo
	{
		// @property (assign, readwrite) int64_t identifier;
		[Export ("identifier")]
		long Identifier { get; set; }

		// @property (assign, readwrite) uint64_t timestamp;
		[Export ("timestamp")]
		ulong Timestamp { get; set; }

		// @property (nonatomic, strong) NSURLResponse * _Nullable response;
		[NullAllowed, Export ("response", ArgumentSemantic.Strong)]
		NSUrlResponse Response { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable body;
		[NullAllowed, Export ("body", ArgumentSemantic.Strong)]
		string Body { get; set; }

		// -(instancetype _Nonnull)initWithIndentifier:(int64_t)identifier timestamp:(uint64_t)timestamp response:(NSURLResponse * _Nullable)response data:(NSData * _Nullable)data;
		[Export ("initWithIndentifier:timestamp:response:data:")]
		NativeHandle Constructor (long identifier, ulong timestamp, [NullAllowed] NSUrlResponse response, [NullAllowed] NSData data);

		// -(void)setBodyFromData:(NSData * _Nullable)data;
		[Export ("setBodyFromData:")]
		void SetBodyFromData ([NullAllowed] NSData data);
	}

    [BaseType (typeof(NSObject))]
    	// @interface FlipperKitNetworkPlugin <SKNetworkReporterDelegate>
	interface FlipperKitNetworkPlugin : SKNetworkReporterDelegate
	{
		// -(instancetype)initWithNetworkAdapter:(id<SKNetworkAdapterDelegate>)adapter;
		[Export ("initWithNetworkAdapter:")]
		NativeHandle Constructor (SKNetworkAdapterDelegate adapter);

		// -(instancetype)initWithNetworkAdapter:(id<SKNetworkAdapterDelegate>)adapter queue:(dispatch_queue_t)queue;
		[Export ("initWithNetworkAdapter:queue:")]
		NativeHandle Constructor (SKNetworkAdapterDelegate adapter, DispatchQueue queue);

		// @property (nonatomic, strong) id<SKNetworkAdapterDelegate> adapter;
		[Export ("adapter", ArgumentSemantic.Strong)]
		SKNetworkAdapterDelegate Adapter { get; set; }
	}

    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface SKDescriptorMapperProtocol
	{
	}

	// @interface SKDescriptorMapper : NSObject <SKDescriptorMapperProtocol>
	[BaseType (typeof(NSObject))]
	interface SKDescriptorMapper : SKDescriptorMapperProtocol
	{
	}

	// @interface FlipperKitLayoutPlugin : NSObject
	[BaseType (typeof(NSObject))]
	interface FlipperKitLayoutPlugin
	{
		// -(instancetype)initWithRootNode:(id<NSObject>)rootNode withDescriptorMapper:(SKDescriptorMapper *)mapper;
		[Export ("initWithRootNode:withDescriptorMapper:")]
		NativeHandle Constructor (NSObject rootNode, SKDescriptorMapper mapper);

		// -(instancetype)initWithRootNode:(id<NSObject>)rootNode withTapListener:(id)tapListener withDescriptorMapper:(SKDescriptorMapper *)mapper;
		[Export ("initWithRootNode:withTapListener:withDescriptorMapper:")]
		NativeHandle Constructor (NSObject rootNode, NSObject tapListener, SKDescriptorMapper mapper);

		// @property (readonly, nonatomic, strong) SKDescriptorMapper * descriptorMapper;
		[Export ("descriptorMapper", ArgumentSemantic.Strong)]
		SKDescriptorMapper DescriptorMapper { get; }
	}

    [Protocol, Model]
    [BaseType (typeof(NSObject))]
	interface FlipperStateUpdateListener
	{
		// @required -(void)onUpdate;
		[Abstract]
		[Export ("onUpdate")]
		void OnUpdate ();
	}

	// @interface FlipperClient : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface FlipperClient
	{
		// +(instancetype)sharedClient;
		[Static]
		[Export ("sharedClient")]
		FlipperClient SharedClient ();

		// -(void)addPlugin:(NSObject<FlipperPlugin> *)plugin;
		[Export ("addPlugin:")]
		void AddPlugin (FlipperPlugin plugin);

		// -(void)removePlugin:(NSObject<FlipperPlugin> *)plugin;
		[Export ("removePlugin:")]
		void RemovePlugin (FlipperPlugin plugin);

		// -(NSObject<FlipperPlugin> *)pluginWithIdentifier:(NSString *)identifier;
		[Export ("pluginWithIdentifier:")]
		FlipperPlugin PluginWithIdentifier (string identifier);

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)stop;
		[Export ("stop")]
		void Stop ();

		// -(NSString *)getState;
		[Export ("getState")]
		//[Verify (MethodToProperty)]
		string State { get; }

		// -(NSArray<NSDictionary *> *)getStateElements;
		[Export ("getStateElements")]
		//[Verify (MethodToProperty)]
		NSDictionary[] StateElements { get; }

		// -(void)subscribeForUpdates:(id<FlipperStateUpdateListener>)controller;
		[Export ("subscribeForUpdates:")]
		void SubscribeForUpdates (FlipperStateUpdateListener controller);

		// -(void)setCertificateProvider:(id)provider;
		[Export ("setCertificateProvider:")]
		void SetCertificateProvider (NSObject provider);

		// -(id)getCertificateProvider;
		[Export ("getCertificateProvider")]
		//[Verify (MethodToProperty)]
		NSObject CertificateProvider { get; }
	}

	// @interface FlipperKitBloksPlugin : NSObject <FlipperPlugin>
	[BaseType (typeof(NSObject))]
	interface FlipperKitBloksPlugin : FlipperPlugin
	{
		// -(void)logAction:(NSString *)action withData:(NSDictionary *)data;
		[Export ("logAction:withData:")]
		void LogAction (string action, NSDictionary data);
	}

	// @interface FlipperKitLayoutComponentKitSupport : NSObject
	[BaseType (typeof(NSObject))]
	interface FlipperKitLayoutComponentKitSupport
	{
		// +(void)setUpWithDescriptorMapper:(id)mapper;
		[Static]
		[Export ("setUpWithDescriptorMapper:")]
		void SetUpWithDescriptorMapper (NSObject mapper);
	}

    [Protocol, Model]
    [BaseType (typeof(NSObject))]
	interface FlipperPlugin
	{
		// @required -(NSString *)identifier;
		[Abstract]
		[Export ("identifier")]
		//[Verify (MethodToProperty)]
		string Identifier { get; }

		// // @required -(void)didConnect:(id<FlipperConnection>)connection;
		// [Abstract]
		// [Export ("didConnect:")]
		// void DidConnect (FlipperConnection connection);

		// @required -(void)didDisconnect;
		[Abstract]
		[Export ("didDisconnect")]
		void DidDisconnect ();

		// @optional -(BOOL)runInBackground;
		[Export ("runInBackground")]
		//[Verify (MethodToProperty)]
		bool RunInBackground { get; }
	}

	// @interface FKUserDefaultsPlugin : NSObject <FlipperPlugin>
	[BaseType (typeof(NSObject))]
	interface FKUserDefaultsPlugin : FlipperPlugin
	{
		// -(instancetype _Nonnull)initWithSuiteName:(NSString * _Nullable)suiteName;
		[Export ("initWithSuiteName:")]
		NativeHandle Constructor ([NullAllowed] string suiteName);
	}

    [Protocol]
	interface FlipperResponder
	{
		// @required -(void)success:(NSDictionary *)response;
		[Abstract]
		[Export ("success:")]
		void Success (NSDictionary response);

		// @required -(void)error:(NSDictionary *)response;
		[Abstract]
		[Export ("error:")]
		void Error (NSDictionary response);
	}

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