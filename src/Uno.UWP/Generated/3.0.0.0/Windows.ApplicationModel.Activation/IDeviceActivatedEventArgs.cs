#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.ApplicationModel.Activation
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public  partial interface IDeviceActivatedEventArgs : global::Windows.ApplicationModel.Activation.IActivatedEventArgs
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		string DeviceInformationId
		{
			get;
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		string Verb
		{
			get;
		}
		#endif
		// Forced skipping of method Windows.ApplicationModel.Activation.IDeviceActivatedEventArgs.DeviceInformationId.get
		// Forced skipping of method Windows.ApplicationModel.Activation.IDeviceActivatedEventArgs.Verb.get
	}
}