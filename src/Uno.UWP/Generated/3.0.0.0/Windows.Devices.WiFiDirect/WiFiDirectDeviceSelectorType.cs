#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Devices.WiFiDirect
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public   enum WiFiDirectDeviceSelectorType 
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		DeviceInterface,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		AssociationEndpoint,
		#endif
	}
	#endif
}
