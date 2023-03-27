XBUILD=/Applications/Xcode_14.2.0.app/Contents/Developer/usr/bin/xcodebuild
ROOT=$(PWD)
PROJECT_ROOT=$(ROOT)/../external/Drastic.FlipperKit
PROJECT_IOS=$(PROJECT_ROOT)/Drastic.FlipperKit.xcworkspace
BUILD_ROOT=$(PROJECT_ROOT)/build
PROJECTNAME=Drastic_FlipperKit
IOS_FRAMEWORK_PATH=Products/Library/Frameworks/$(PROJECTNAME).framework
FRAMEWORKS=$(ROOT)/Frameworks
TARGET_IOS="Drastic.FlipperKit"
IOS_SDK=iphoneos16.2
BINDING_OUTPUT=$(ROOT)/../bindings
HEADERS=$(ROOT)/../external/headers

make: iossimulator iosdevice xcframework dotnet_pack

iossimulator:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -workspace $(PROJECT_IOS) -scheme $(TARGET_IOS) -configuration Debug -destination "generic/platform=iOS Simulator" -archivePath $(BUILD_ROOT)/simulator.xcarchive -sdk iphonesimulator SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

iosdevice:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -workspace $(PROJECT_IOS) -scheme $(TARGET_IOS) -configuration Debug -destination "generic/platform=iOS" -archivePath $(BUILD_ROOT)/iOS.xcarchive -sdk iphoneos SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

xcframework:
	rm -rf $(BUILD_ROOT)/$(PROJECTNAME).xcframework
	$(XBUILD) -create-xcframework -framework $(BUILD_ROOT)/simulator.xcarchive/$(IOS_FRAMEWORK_PATH) -framework $(BUILD_ROOT)/iOS.xcarchive/$(IOS_FRAMEWORK_PATH) -output $(BUILD_ROOT)/$(PROJECTNAME).xcframework
	rm -rf $(FRAMEWORKS)
	mkdir -p $(FRAMEWORKS)
	cp -R $(BUILD_ROOT)/ $(FRAMEWORKS)

dotnet_pack: 
	dotnet pack $(ROOT)/Drastic.Flipper/Drastic.Flipper.csproj --configuration Release --output $(ROOT)/../nuget

sharpie:
	sharpie bind --sdk=$(IOS_SDK) --output="$(BINDING_OUTPUT)" --namespace="Flipper" --scope="$(HEADERS)" $(HEADERS)/*.h