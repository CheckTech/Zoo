#include "stdafx.h"
#include "resource.h"

////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
//
// BEGIN SampleCppZooTestValidator license validator
//

class CSampleCppZooTestValidator : public CRhinoLicenseValidator
{
public:
  CSampleCppZooTestValidator() {}
  ~CSampleCppZooTestValidator() {}
  CRhinoLicenseValidator::product_build_type ProductBuildType();
  CRhinoLicenseValidator::result ValidateProductKey( const wchar_t* product_key );

private:
  ON_wString Reverse( const wchar_t* input );
};

// The one and only CSampleCppZooTestValidator object
static class CSampleCppZooTestValidator theTestRhinoPluginCPPValidator;

CRhinoLicenseValidator::product_build_type CSampleCppZooTestValidator::ProductBuildType()
{
  return CRhinoLicenseValidator::release_build;
}

CRhinoLicenseValidator::result CSampleCppZooTestValidator::ValidateProductKey( const wchar_t* product_key )
{
  AFX_MANAGE_STATE( AfxGetStaticModuleState() );

  if( 0 == product_key || 0 == product_key[0] )
    return CSampleCppZooTestValidator::error_show_message;

  // This value will never be display in any user interface.
  // When your plugin's ValidateProductKey function is called, it is
  // passed a a product, or CD, key that was entered into the Zoo
  // administrator console. Your ValidateProductKey function will validate
  // the product key and decode it into a product license. This is
  // where you can store this license. This value will be passed
  // to your application at runtime when it requests a license.
  m_product_license = product_key;

  // This value will display in user interface items, such as in
  // the Zoo console and in About dialog boxes. Also, this value
  // is used to uniquely identify this license. Thus, it is
  // critical that this value be unique per product key, entered
  // by the administrator. No other license of this product, as
  // validated by this plugin, should return this value.
  //
  // This example just reverses product_key...
  m_serial_number = Reverse( product_key );

  // This value will display in user interface items, such as in
  // the Zoo console and in About dialog boxes.
  // (e.g. "Rhinoceros 5.0", "Rhinoceros 5.0 Commercial", etc.)
  m_license_title = "SampleCppZooTest 1.0 Commercial";

  // The build of the product that this license work with.
  // When your product requests a license from the Zoo, it
  // will specify one of these build types. Note, this is just
  // the int version of CRhinoLicenseValidator::product_build_type
  // enum value.
  m_build_type = CRhinoLicenseValidator::release_build;

  // Zoo licenses can be used by more than one instance of any application.
  // For example, a single Rhino Education Lab license can be used by up
  // to 30 systems simultaneously. If your license supports multiple instance,
  // then specify the number of supported instances here. Otherwise just
  // specify a value of 1 for single instance use.
  m_license_count = 1;

  // The Zoo supports licenses that expire. If your licensing scheme
  // is sophisticated enough to support this, then specify the
  // expiration date here. Note, this value must be specified in
  // Coordinated Universal Time (UTC). If your license does not expire,
  // then just this value to null.
  memset( &m_date_to_expire, 0, sizeof(m_date_to_expire) );

  // This icon will displayed in the "Licenses" page in the Options dialog.
  // Note, Rhino will make a copy of this icon..
  m_product_icon = (HICON)::LoadImage( AfxGetInstanceHandle(), MAKEINTRESOURCE(IDI_MAIN), IMAGE_ICON, 32, 32, LR_DEFAULTCOLOR );

  return CRhinoLicenseValidator::success;
}

ON_wString CSampleCppZooTestValidator::Reverse( const wchar_t* input )
{
  ON_wString str;

  if( 0 == input || 0 == input[0] )
    return str;

  str = input;
  str.MakeReverse();

	return str;
}

//
// END SampleCppZooTestValidator license validator
//
////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
