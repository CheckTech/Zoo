using System;
using System.Collections.Generic;
using Rhino.PlugIns;

namespace SampleCsZooTest
{
  /// <summary>
  /// SampleCsZooTestPlugIn plug-in
  /// </summary>
  public class SampleCsZooTestPlugIn : PlugIn
  {
    public SampleCsZooTestPlugIn()
    {
      // Rhino only creates one instance of a plug-in, 
      // so it is safe to store a reference in a static property.
      Instance = this;
    }

    /// <summary>
    /// Gets the one and only instance of this plug-in.
    /// </summary>
    public static SampleCsZooTestPlugIn Instance
    {
      get;
      private set;
    }

    /// <summary>
    /// PlugIn.OnLoad override
    /// </summary>
    protected override LoadReturnCode OnLoad(ref string errorMessage)
    {
      // Ask Rhino to get a product license.
      var rc = GetLicense(LicenseBuildType.Release, ValidateProductKey);
      return (rc) ? LoadReturnCode.Success : LoadReturnCode.ErrorNoDialog;
    }

    /// <summary>
    /// Create a method with the same signature as the 
    /// .ValidateProductKeyDelegate delegate.
    /// </summary>
    private static ValidateResult ValidateProductKey(string productKey, out LicenseData licenseData)
    {
      // This class contains information about your product's license.
      licenseData = new LicenseData();

      // If this example, we won't do much valiation...
      if (string.IsNullOrEmpty(productKey))
        return ValidateResult.ErrorShowMessage;

      // This value will never be display in any user interface.
      // When your plugin's ValidateProductKey member is called, it is
      // passed a a product, or CD, key that was entered into the Zoo
      // administrator console. Your ValidateProductKey will validate
      // the product key and decode it into a product license. This is
      // where you can store this license. This value will be passed
      // to your application at runtime when it requests a license.
      licenseData.ProductLicense = productKey;

      // This value will display in user interface items, such as in
      // the Zoo console and in About dialog boxes. Also, this value
      // is used to uniquely identify this license. Thus, it is
      // critical that this value be unique per product key, entered
      // by the administrator. No other license of this product, as
      // validated by this plugin, should return this value.
      //
      // This example just scrambles the productKey...
      licenseData.SerialNumber = Scramble(productKey);

      // This value will display in user interface items, such as in
      // the Zoo console and in About dialog boxes.
      // (e.g. "Rhinoceros 5.0", "Rhinoceros 5.0 Commercial", etc.)
      licenseData.LicenseTitle = "SampleCsZooTest 1.0 Commercial";

      // The build of the product that this license work with.
      // When your product requests a license from the Zoo, it
      // will specify one of these build types.
      licenseData.BuildType = LicenseBuildType.Release;

      // Zoo licenses can be used by more than one instance of any application.
      // For example, a single Rhion Education Lab license can be used by up
      // to 30 systems simulaneously. If your license supports multiple instance,
      // then specify the number of supported instances here. Otherwise just
      // specify a value of 1 for single instance use.
      licenseData.LicenseCount = 1;

      // The Zoo supports licenses that expire. If your licensing scheme
      // is sophisticated enough to support this, then specify the
      // expiration date here. Note, this value must be speicified in
      // Coordinated Universal Time (UTC). If your license does not expire,
      // then just this value to null.
      licenseData.DateToExpire = null;

      // This icon will displayed in the "Licenses" page in the Options dialog.
      // Note, this can be null. Also note, LicenseData creates it's own copy
      // of the icon.
      licenseData.ProductIcon = Properties.Resources.Main;

      return ValidateResult.Success;
    }

    /// <summary>
    /// Randomizes character positions in string
    /// </summary>
    private static string Scramble(string input)
    {
      if (string.IsNullOrEmpty(input))
        return input;

      var input_chars = new List<char>(input);
      var output_chars = new char[input_chars.Count];
      var rand = new Random();

      for (var i = input_chars.Count - 1; i >= 0; i--)
      {
        var index = rand.Next(i);
        output_chars[i] = input_chars[index];
        input_chars.RemoveAt(index);
      }

      return new string(output_chars);
    }
  }
}